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
        public static readonly string ModelType = "https://openonderwijsapi.nl/v4/model#room";

        /// <summary>
        /// Unique id for this room
        /// </summary>
        [Required]
        [JsonPropertyName("roomId")]
        public Guid RoomId { get; set; }

        /// <summary>
        /// The abbreviation of the name of this room
        /// </summary>
        /// <example>Bb 4.54</example>
        [MaxLength(256)]
        [JsonPropertyName("abbreviation")]
        public string Abbreviation { get; set; }

        /// <summary>
        /// The name of this room
        /// </summary>
        [Required]
        [MaxLength(256)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The name of this room
        /// </summary>
        [Required]
        [MaxLength(64)]
        [JsonPropertyName("type")]
        public RoomType Type { get; set; }

        /// <summary>
        /// The description of this room
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// The total number of seats located in the room
        /// </summary>
        [JsonPropertyName("totalSeats")]
        public int? TotalSeats { get; set; }

        /// <summary>
        /// The total number of available (=non-reserved) seats in the room
        /// </summary>
        [JsonPropertyName("availableSeats")]
        public int? AvailableSeats { get; set; }

        /// <summary>
        /// The floor on which this room is located
        /// </summary>
        [MaxLength(64)]
        [JsonPropertyName("floor")]
        public string Floor { get; set; }

        /// <summary>
        /// The wing in which this room is located
        /// </summary>
        [MaxLength(64)]
        [JsonPropertyName("wing")]
        public string Wing { get; set; }

        /// <summary>
        /// <see cref="V4.Geolocation"/>
        /// </summary>
        [JsonPropertyName("geolocation")]
        public Geolocation Geolocation { get; set; }

        /// <summary>
        /// <see cref="V4.Building"/>
        /// </summary>
        [JsonPropertyName("building")]
        public virtual Building Building { get; set; }

        /// <summary>
        /// Get or set object for additional non-standard attributes)
        /// </summary>
        [JsonPropertyName("ext")]
        public Dictionary<string,object> Ext { get; set; }

    }
}
