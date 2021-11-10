using System.Runtime.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// The level of this course (ECTS-year of study if applicable)
    /// - secondary vocational education 3: mbo 3
    /// - secondary vocational education 4: mbo 4
    /// - associate degree: associate degree
    /// - bachelor: bachelor
    /// - master: master
    /// - doctoral: doctoraal
    /// </summary>
    public enum Level
    {
        [EnumMember(Value = "secondary vocational education 3")]
        SecondaryVocationalEducation3,
        [EnumMember(Value = "secondary vocational education 4")]
        SecondaryVocationalEducation4,
        [EnumMember(Value = "associate degree")]
        AssociateDegree,
        [EnumMember(Value = "bachelor")]
        Bachelor,
        [EnumMember(Value = "master")]
        Master,
        [EnumMember(Value = "doctoral")]
        Doctoral
    }
}
