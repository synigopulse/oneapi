using System.Runtime.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// The state of a result
    /// </summary>
    /// <example>
    /// Completed
    /// </example>
    public enum ResultState
    {

        [EnumMember(Value = "in progress")]
        InProgress,
        [EnumMember(Value = "postponed")]
        PostPoned,
        [EnumMember(Value = "completed")]
        Completed
    }
}
