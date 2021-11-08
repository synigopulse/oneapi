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

        /// <summary>
        /// Association is between Person and Course
        /// </summary>
        [EnumMember(Value = "courseOfferingAssociation")]
        CourseOfferingAssociation,

        /// <summary>
        /// Association is between Person and Component
        /// </summary>
        [EnumMember(Value = "componentOfferingAssociation")]
        ComponentOfferingAssociation
    }
}
