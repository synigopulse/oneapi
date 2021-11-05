using System.Runtime.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// The type of this association
    /// </summary>
    public enum AssociationType
    {
        [EnumMember(Value = "programOfferingAssociation")]
        ProgramOfferingAssociation,
        [EnumMember(Value = "courseOfferingAssociation")]
        CourseOfferingAssociation,
        [EnumMember(Value = "componentOfferingAssociation")]
        ComponentOfferingAssociation
    }
}
