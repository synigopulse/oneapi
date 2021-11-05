using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// An area within a building where education can take place
    /// </summary>
    public class Room
    {
        /// <summary>
        /// Unique id for this room
        /// </summary>
        [JsonPropertyName("roomId")]
        public Guid RoomId { get; set; }

        /// <summary>
        /// The abbreviation of the name of this room
        /// </summary>
        [MaxLength(256)]
        [JsonPropertyName("abbreviation")]
        public string Abbreviation { get; set; }

        /// <summary>
        /// The name of this room
        /// </summary>
        [MaxLength(256)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The name of this room
        /// </summary>
        [JsonPropertyName("type")]
        public RoomType Type { get; set; }

        /// <summary>
        /// The description of this room
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// The total number of seats in the room
        /// </summary>
        [JsonPropertyName("totalSeats")]
        public int TotalSeats { get; set; }

        /// <summary>
        /// The total number of available (=non-reserved) seats in the room
        /// </summary>
        [JsonPropertyName("availableSeats")]
        public int AvailableSeats { get; set; }

        /// <summary>
        /// The floor on which this room is located
        /// </summary>
        [JsonPropertyName("floor")]
        public string Floor { get; set; }

        /// <summary>
        /// The wing in which this room is located
        /// </summary>
        [JsonPropertyName("wing")]
        public string Wing { get; set; }

        [JsonPropertyName("geolocation")]
        public Geolocation Geolocation { get; set; }

        [JsonPropertyName("ext")]
        public Dictionary<string,object> Ext { get; set; }

        [JsonPropertyName("building")]
        public Building Building { get; set; }
    }


}
