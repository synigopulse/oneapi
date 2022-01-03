using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// An object describing a building and the properties of a building.
    /// </summary>
    public class Building
    {
        public static readonly string ModelType = "https://openonderwijsapi.nl/v4/model#building";

        /// <summary>
        /// Unique id of this building
        /// </summary>
        /// <example>
        /// 123e4567-e89b-12d3-a456-331214174000 
        /// </example>
        [Required]
        [JsonPropertyName("buildingId")]
        public Guid BuildingId { get; set; }

        /// <summary>
        ///  The abbreviation of the name of this building
        /// </summary>
        /// <example>
        /// Bb
        /// </example>
        [MaxLength(256)]
        [JsonPropertyName("abbreviation")]
        public string Abbreviation { get; set; }

        /// <summary>
        /// The name of this building
        /// </summary>
        /// <example>
        /// Beatrix building
        /// </example>
        [Required]
        [MaxLength(256)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        ///  The description of this building
        /// </summary>
        /// <example>
        /// external rooms location for exams
        /// </example>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// The physical address of the building
        /// <see cref="Address"/>
        /// </summary>
        [Required]
        [JsonPropertyName("address")]
        public virtual Address Address { get; set; }

        /// <summary>
        /// Get or set object for additional non-standard attributes)
        /// </summary>
        [JsonPropertyName("ext")]
        public Dictionary<string, object> Ext { get; set; }

        /// <summary>
        /// Get or set a list of rooms in this building
        /// </summary>
        [JsonPropertyName("rooms")]
        public virtual List<Room> Rooms { get; set; }
    }
}
