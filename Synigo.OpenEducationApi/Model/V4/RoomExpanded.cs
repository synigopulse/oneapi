using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    public class RoomExpanded : Room
    {
        /// <summary>
        ///  The building in which the room is located
        /// </summary>
        [JsonPropertyName("building")]
        public Building Building { get; set; }
    }
}
