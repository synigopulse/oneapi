using System.Runtime.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// The result value type for this offering
    /// </summary>
    /// <example>1-10</example>
    public enum ResultValueType
    {
        [EnumMember(Value = "pass-or-fail")]
        PassOrFail,
        [EnumMember(Value = "US letter")]
        UsLetter,
        [EnumMember(Value = "UK letter")]
        UKLetter,
        [EnumMember(Value = "0-100")]
        ZeroToOneHundred,
        [EnumMember(Value = "1-10")]
        OneToTen
    }
}
