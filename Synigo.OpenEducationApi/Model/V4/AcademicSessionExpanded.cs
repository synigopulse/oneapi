using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    public class AcademicSessionExpanded : AcademicSession
    {
        /// <summary>
        /// The parent Academicsession of this session (e.g. fall semester 20xx where the current session is a week 40)
        /// </summary>
        [JsonPropertyName("parent")]
        public AcademicSession Parent { get; set; }

        /// <summary>
        /// The top level year of this session (e.g. 20xx where the current session is a week 40 of a semester)
        /// </summary>
        [JsonPropertyName("year")]
        public AcademicSession Year { get; set; }
    }
}
