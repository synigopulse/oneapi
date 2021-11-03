using System.Runtime.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    public enum PostalType
    {
        [EnumMember(Value = "postal")]
        Postal,
        [EnumMember(Value = "visit")]
        Visit,
        [EnumMember(Value = "deliveries")]
        Deliveries
    }
}
