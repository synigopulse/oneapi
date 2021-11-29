namespace Synigo.OneApi.Storage.Configuration
{
    /// <summary>
    /// Enum which describes how enum values will be saved in database
    /// </summary>
    public enum EnumToDbConversionType
    {
        EnumAsInt = 1,
        EnumAsString = 2,
        EnumAsEnumValueMember = 3
    }
}
