using System.Runtime.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    ///  The type of this news item
    /// - calamity: calamiteit
    /// - general: algemeen
    /// - schedule-change: roosterwijziging
    /// - announcement: aankondiging
    /// </summary>
    public enum NewsItemType
    {
        [EnumMember(Value = "calamity")]
        Calamity,
        [EnumMember(Value = "general")]
        General,
        [EnumMember(Value = "schedule-change")]
        ScheduleChange,
        [EnumMember(Value = "announcement")]
        Announcement
    }
}
