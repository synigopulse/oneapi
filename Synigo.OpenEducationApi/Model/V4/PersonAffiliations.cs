using System;
using System.Runtime.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// The affiliations of a person, the relations a person has with the organization providing a endpoint
    /// </summary>
    public enum PersonAffiliations
    {
        [EnumMember(Value = "student")]
        Student,
        [EnumMember(Value = "employee")]
        Employee,
        [EnumMember(Value = "guest")]
        Guest
    }
}
