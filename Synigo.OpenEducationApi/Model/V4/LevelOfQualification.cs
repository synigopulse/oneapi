using System.Runtime.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// Level of qualification according to the National Qualification Framework and the European Qualifications Framework
    /// </summary>
    public enum LevelOfQualification
    {
        [EnumMember(Value = "1")]
        EQF1,
        [EnumMember(Value = "2")]
        EQF2,
        [EnumMember(Value = "3")]
        EQF3,
        [EnumMember(Value = "4")]
        EQF4,
        [EnumMember(Value = "4+")]
        EQF4Plus,
        [EnumMember(Value = "5")]
        EQF5,
        [EnumMember(Value = "6")]
        EQF6,
        [EnumMember(Value = "7")]
        EQF7,
        [EnumMember(Value = "8")]
        EQF8
    }
}
