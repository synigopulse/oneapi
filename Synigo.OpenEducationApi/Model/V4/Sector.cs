using System.Runtime.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// The sector for this program
    /// </summary>
    public enum Sector
    {
        [EnumMember(Value = "secondary vocational education")]
        SecondaryVocationalEducation,
        [EnumMember(Value = "higher professional education")]
        HigherProfessionalEducation,
        [EnumMember(Value = "university education")]
        UniversityEducation
    }
}
