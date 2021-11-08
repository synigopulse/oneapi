using System.Runtime.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// The component type
    /// </summary>
    public enum ComponentType
    {
        [EnumMember(Value = "test")]
        Test,
        [EnumMember(Value = "lecture")]
        Lecture,
        [EnumMember(Value = "practical")]
        Practical,
        [EnumMember(Value = "tutorial")]
        Tutorial,
        [EnumMember(Value = "consultation")]
        Consultation,
        [EnumMember(Value = "project")]
        Project,
        [EnumMember(Value = "workshop")]
        Workshop,
        [EnumMember(Value = "excursion")]
        Excursion,
        [EnumMember(Value = "independent study")]
        IndependentStudy,
        [EnumMember(Value = "external")]
        External,
        [EnumMember(Value = "skills training")]
        SkillsTraining
    }
}
