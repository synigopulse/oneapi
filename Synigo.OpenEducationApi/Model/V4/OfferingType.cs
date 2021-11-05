using System.Runtime.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// The type of an offering
    /// </summary>
    public enum OfferingType
    {
        [EnumMember(Value = "course")]
        Course,
        [EnumMember(Value = "component")]
        Component,
        [EnumMember(Value = "program")]
        Program
    }
}
