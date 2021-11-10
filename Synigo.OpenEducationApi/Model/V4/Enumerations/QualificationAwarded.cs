using System.Runtime.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// Type of qualificaton that can be obtained on finishing the program
    /// </summary>
    public enum QualificationAwarded
    {
        [EnumMember(Value = "AD")]
        AD,
        [EnumMember(Value = "BA")]
        BA,
        [EnumMember(Value = "BSc")]
        BSs,
        [EnumMember(Value = "LLB")]
        LLB,
        [EnumMember(Value = "MA")]
        MA,
        [EnumMember(Value = "MSc")]
        MSc,
        [EnumMember(Value = "LLM")]
        LLM,
        [EnumMember(Value = "Phd")]
        Phd,
        [EnumMember(Value = "None")]
        None
    }
}
