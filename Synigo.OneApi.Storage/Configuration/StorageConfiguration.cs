using Microsoft.EntityFrameworkCore;

namespace Synigo.OneApi.Storage.Configuration
{
    public static class StorageConfiguration
    {
        public static bool PrimaryKeyGeneratedByDatabase { get; set; } = true;
        public static EnumToDbConversionType EnumConversionType { get; set; } = EnumToDbConversionType.EnumAsEnumValueMember;
    }
}
