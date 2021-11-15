using Microsoft.EntityFrameworkCore;

namespace Synigo.OneApi.Storage.Configuration
{
    public static class StorageConfiguration
    {
        public static StorageType StorageType { get; set; }
        public static bool PrimaryKeyGeneratedByDatabase { get; set; } = true;
        public static string ConnectionString { get; set; }
        public static bool UseContextOptionsInFactory { get; set; } = true;
        public static DbContextOptionsBuilder DbContextOptions { get; set; }
    }
}
