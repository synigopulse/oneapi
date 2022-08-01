using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.OpenApi.Models;
using Microsoft.Identity.Client;
using Microsoft.Graph;
using Swashbuckle.AspNetCore.SwaggerGen;
using Synigo.OneApi.Core.WebApi.Shared;
using Synigo.OneApi.Interfaces;
using Synigo.OneApi.Core.Execution;
using Synigo.OneApi.Core.WebApi.Extensions;
using Synigo.OneApi.Core.WebApi.Helpers;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace Synigo.OneApi.Core.WebApi
{
    public abstract class BaseStartup
    {
        private OneApiBuilder? _oneApiBuilder;

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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAd"), JwtBearerDefaults.AuthenticationScheme)
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
                ConfigureJsonSerializerOptions(options);
            });

            services.AddSwaggerGen(ConfigureSwaggerGen);

            services.AddHealthChecks(); // Can be called multiple times but will get the same instance

            ConfigureCustomServices(_oneApiBuilder);

            services.AddProductProvidersHealthChecks();
        }

        protected virtual void ConfigureJsonSerializerOptions(Microsoft.AspNetCore.Mvc.JsonOptions options)
        {
            #if DEBUG
                // it's always nice to indent JSON when debugging
                options.JsonSerializerOptions.WriteIndented = true;
            #endif
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
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

        protected abstract void ConfigureAppSettings(ref OneApiSettings settings);


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var settings = new OneApiSettings();
            ConfigureAppSettings(ref settings);

            // Environmental
            if (env.IsDevelopment())
            {
                if (settings.DevelopmentSettings.EnableExceptionPage)
                {
                    if (settings.DevelopmentSettings.ExceptionPageOptions == null)
                    {
                        app.UseDeveloperExceptionPage();
                    } else
                    {
                        app.UseDeveloperExceptionPage(settings.DevelopmentSettings.ExceptionPageOptions);
                    }
                }
            }
            else
            {
                if (settings.ProductionSettings.EnableExceptionHandler)
                {
                    app.UseExceptionHandler(settings.ProductionSettings.ErrorHandlingPath);
                }
                if (settings.ProductionSettings.EnableHosts)
                {
                    app.UseHsts();
                }
            }

            // Defaults
            if (settings.GeneralSettings.EnableCors)
            {
                app.UseCors(settings.GeneralSettings.CorsPolicyName);
            }
            if (settings.GeneralSettings.EnableHttpsRedirection)
            {
                app.UseHttpsRedirection();
            }
            if (settings.GeneralSettings.EnableStaticFileServing)
            {
                app.UseStaticFiles();
            }
            if (settings.GeneralSettings.EnableStaticFileServing)
            {
                app.UseRouting();
            }

            // Security
            if (settings.SecuritySettings.EnableAuthentication)
            {
                app.UseAuthentication();
            }
            if (settings.SecuritySettings.EnableAuthorization)
            {
                app.UseAuthorization();
            }

            // Swagger
            if (settings.SwaggerSettings.EnableSwagger)
            {
                app.UseSwagger();
            }
            if (settings.SwaggerSettings.EnableSwaggerUI)
            {
                app.UseSwaggerUI(settings.SwaggerSettings.SwaggerUIOptions);
            }

            // Endpoints
            if (settings.EndpointSettings.EnableEndpoints)
            {
                app.UseEndpoints(endpoints =>
                {
                    if (settings.EndpointSettings.EnableControllerMapping)
                    {
                        endpoints.MapControllers();
                    }
                    if (settings.EndpointSettings.EnableHealthCheckMapping)
                    {
                        var healthCheckOptions = new HealthCheckOptions()
                        {
                            ResponseWriter = HealthCheckHelper.WriteResponse
                        };
                        if (settings.EndpointSettings.HealthCheckOptions != null)
                        {
                            settings.EndpointSettings.HealthCheckOptions.Invoke(healthCheckOptions);
                        }

                        var healthCheckEndpoint = endpoints.MapHealthChecks(settings.EndpointSettings.HealthCheckPattern,
                            healthCheckOptions);
                        if (settings.EndpointSettings.HealthCheckRequireHosts != null)
                        {
                            healthCheckEndpoint.RequireHost(settings.EndpointSettings.HealthCheckRequireHosts);
                        }
                        if (settings.EndpointSettings.HealthCheckRequireAuthorization)
                        {
                            if (settings.EndpointSettings.HealthCheckAuthorizationPolicyNames == null)
                            {
                                healthCheckEndpoint.RequireAuthorization();
                            } else
                            {
                                healthCheckEndpoint.RequireAuthorization(settings.EndpointSettings.HealthCheckAuthorizationPolicyNames);
                            }
                            
                        }
                    }
                });
            }
        }
    }
}
