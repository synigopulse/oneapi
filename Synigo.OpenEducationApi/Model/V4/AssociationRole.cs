using System.Runtime.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// The role of this person associated with the offering
    /// </summary>
    public enum AssociationRole
    {
        [EnumMember(Value = "student")]
        Student,
        [EnumMember(Value = "lecturer")]
        Lecturer,
        [EnumMember(Value = "teaching assistant")]
        TeachingAssistant,
        [EnumMember(Value = "coordinator")]
        Coordinator,
        [EnumMember(Value = "guest")]
        Guest
    }
}
