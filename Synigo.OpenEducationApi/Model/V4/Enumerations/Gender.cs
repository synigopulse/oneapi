using System.Runtime.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// The gender of a person
    /// </summary>
    public enum Gender
    {
        [EnumMember(Value = "M")]
        M,
        [EnumMember(Value = "F")]
        F,
        [EnumMember(Value = "U")]
        U,
        [EnumMember(Value = "X")]
        X
    }
}
