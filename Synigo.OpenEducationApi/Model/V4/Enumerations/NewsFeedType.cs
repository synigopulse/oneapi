using System.Runtime.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    public enum NewsFeedType
    {
        [EnumMember(Value = "organization")]
        Organization,
        [EnumMember(Value = "program")]
        Program,
        [EnumMember(Value = "course")]
        Course,
        [EnumMember(Value = "component")]
        Component,
        [EnumMember(Value = "person")]
        Person,
        [EnumMember(Value = "building")]
        Building,
        [EnumMember(Value = "room")]
        Room
    }
}
