using System.Runtime.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// The type of this program
    /// </summary>
    public enum ProgramType
    {
        [EnumMember(Value = "program")]
        Program,
        [EnumMember(Value = "minor")]
        Minor,
        [EnumMember(Value = "honours")]
        Honours,
        [EnumMember(Value = "specialization")]
        Specialization,
        [EnumMember(Value = "elective")]
        Elective,
        [EnumMember(Value = "module")]
        Module,
        [EnumMember(Value = "track")]
        Track,
        [EnumMember(Value = "joint-degree")]
        JointDegree,
        [EnumMember(Value = "alliance")]
        Alliance
    }
}
