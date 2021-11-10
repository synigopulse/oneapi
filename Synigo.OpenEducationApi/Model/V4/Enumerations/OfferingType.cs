using System.Runtime.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// The type of this offering
    /// </summary>
    public enum OfferingType
    {
        [EnumMember(Value = "program")]
        Program,
        [EnumMember(Value = "course")]
        Course,
        [EnumMember(Value = "component")]
        Componenet
    }
}
