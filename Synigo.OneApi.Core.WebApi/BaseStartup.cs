using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using Synigo.OneApi.Core.WebApi.Shared;
using Microsoft.Identity.Client;
using Microsoft.Graph;
using Synigo.OneApi.Interfaces;
using Synigo.OneApi.Core.Execution;

namespace Synigo.OneApi.Core.WebApi
{
    public abstract class BaseStartup
    {
        private OneApiBuilder _oneApiBuilder;

        public BaseStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _oneApiBuilder = new OneApiBuilder(services);

            var clientId = Configuration.GetSection("AzureAd").GetValue<string>("ClientId");
            var clientSecret = Configuration.GetSection("AzureAd").GetValue<string>("ClientSecret");
            var tenantId = Configuration.GetSection("AzureAd").GetValue<string>("TenantId");

            services.AddSingleton<IAuthenticationProvider>((serviceProvider) => {
                var app = ConfidentialClientApplicationBuilder.Create(clientId)
                        .WithAuthority(AzureCloudInstance.AzurePublic, tenantId)
                        .WithClientSecret(clientSecret)
                        .Build();

                return new GraphAuthenticationProvider(app);
            });

            // Add Bearer token auth to enable access for api's
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAd"),
                       JwtBearerDefaults.AuthenticationScheme)
                      .EnableTokenAcquisitionToCallDownstreamApi()
                      .AddInMemoryTokenCaches();


            // Allow every JS client from every location to access all resources
            services.AddCors(o => o.AddPolicy("globalCorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddScoped<IExecutionContext>((IServiceProvider serviceProvider) =>
            {
                return new OneApiExecutionContext(serviceProvider);
            });

            services.AddControllers(options =>
            {
                // Authorize everything
                options.Filters.Add(new AuthorizeFilter());
                options.Filters.Add(typeof(OneApiContextFilter));
            }).AddJsonOptions(options =>
            {
#if DEBUG
                // it's always nice to indent JSON when debugging
                options.JsonSerializerOptions.WriteIndented = true;
#endif
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });

            services.AddSwaggerGen(ConfigureSwaggerGen);

            ConfigureCustomServices(_oneApiBuilder);
           
        }

        protected virtual void ConfigureSwaggerGen(SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Synigo.OneApi.WebApi", Version = "v1" });
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            options.OperationFilter<AuthorizeCheckOperationFilter>();
        }

        protected abstract void ConfigureCustomServices(OneApiBuilder builder);

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

          

            // Defaults
            app.UseCors("globalCorsPolicy");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            // Security
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

       
        }
    }
}
