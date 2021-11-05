using System;
using System.Runtime.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    public enum AssociationType
    {
        /// <summary>
        /// Association is between Person and Program
        /// </summary>
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
