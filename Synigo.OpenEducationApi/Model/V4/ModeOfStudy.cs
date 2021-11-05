using System.Runtime.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    public enum ModeOfStudy
    {
        [EnumMember(Value = "full-time")]
        FullTime,
        [EnumMember(Value = "part-time")]
        PartTime,
        [EnumMember(Value = "dual training")]
        DualTraining,
        [EnumMember(Value = "self-paced")]
        SelfPaced
    }
}
