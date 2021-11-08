using System.Runtime.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// Indicate whether the course is full-time, part-time, dual or self-paced.
    /// - full-time: fulltime
    /// - part-time: parttime
    /// - dual training: duaal
    /// - self-paced: eigen tempo
    /// </summary>
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
