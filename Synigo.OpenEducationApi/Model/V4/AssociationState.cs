using System.Runtime.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// The state of this association
    /// </summary>
    public enum AssociationState
    {
        [EnumMember(Value = "pending")]
        Pending,
        [EnumMember(Value = "canceled")]
        Canceled,
        [EnumMember(Value = "denied")]
        Denied,
        [EnumMember(Value = "associated")]
        Associated,
    }
}
