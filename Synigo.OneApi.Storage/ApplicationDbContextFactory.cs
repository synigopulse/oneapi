using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Synigo.OneApi.Storage.Configuration;

namespace Synigo.OneApi.Storage
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {

        public virtual ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = StorageConfiguration.UseContextOptionsInFactory ? StorageConfiguration.DbContextOptions : new DbContextOptionsBuilder();

            switch (StorageConfiguration.StorageType)
            {
                case StorageType.Sql:
                    optionsBuilder.UseSqlServer(StorageConfiguration.ConnectionString);
                    break;
                case StorageType.SqlLite:
                    optionsBuilder.UseSqlite(StorageConfiguration.ConnectionString);
                    break;
            }
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
