using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Synigo.OneApi.Storage
{
    public static class EntitiyFrameworkServiceConfiguration
    {
        /// <summary>
        /// Configuration of the aplication db context
        /// Context will be configured only for storage type, other configuration can be added via optionsAction
        /// </summary>
        /// <typeparam name="T"></typeparam> 
        /// <param name="services"></param>
        /// <param name="connectionString">connection string to database</param>
        /// <param name="dbGeneratesPrimaryKeys">database will generate guids for primary keys</param>
        /// <param name="storageType">default value is sql</param>
        /// <param name="optionsAction">use action to add more configuration opstions</param>
        /// <returns></returns>
        public static IServiceCollection AddApplicationDbContext<T> (this IServiceCollection services, string connectionString , bool dbGeneratesPrimaryKeys = true,
            StorageType storageType = StorageType.Sql, Action<DbContextOptionsBuilder> optionsAction = null)
           where T : ApplicationDbContext
        {
            
            Configuration.StorageConfiguration.PrimaryKeyGeneratedByDatabase = dbGeneratesPrimaryKeys;

            services.AddDbContext<T>(options => 
            {
                switch (storageType)
                {
                    case StorageType.Sql:
                        options.UseSqlServer(connectionString, sqlServerBuilder => {
                            sqlServerBuilder.EnableRetryOnFailure();
                        } );
                        break;
                    case StorageType.SqlLite:
                        options.UseSqlite(connectionString);
                        break;
                }

                if (optionsAction != null)
                    optionsAction(options);
            });

            return services;
        }
    }
}
