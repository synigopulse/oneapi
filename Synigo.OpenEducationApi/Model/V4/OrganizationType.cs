using System.Runtime.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// The type of this organization
    /// </summary>
    public enum OrganizationType
    {
        [EnumMember(Value = "root")]
        Root,
        [EnumMember(Value = "institution")]
        Institution,
        [EnumMember(Value = "department")]
        Department,
        [EnumMember(Value = "faculty")]
        Faculty
    }
}
