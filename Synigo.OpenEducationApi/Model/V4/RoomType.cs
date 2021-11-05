using System.Runtime.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// The type of this room
    /// </summary>
    public enum RoomType
    {
        [EnumMember(Value = "general purpose")]
        GeneralPurpose,
        [EnumMember(Value = "lecture room")]
        LectureRoom,
        [EnumMember(Value = "computer room")]
        ComputerRoom,
        [EnumMember(Value = "laboratory")]
        Laboratory,
        [EnumMember(Value = "office")]
        Office,
        [EnumMember(Value = "workspace")]
        Workspace,
        [EnumMember(Value = "exam location")]
        ExamLocation,
        [EnumMember(Value = "study room")]
        StudyRoom,
        [EnumMember(Value = "examination room")]
        ExaminationRoom,
        [EnumMember(Value = "conference room")]
        ConferenceRoom
    }
}
