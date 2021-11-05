using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    public class Building
    {
        /// <summary>
        /// The unique id of this building
        /// </summary>
        [JsonPropertyName("buildingId")]
        public Guid BuildingId { get; set; }

        /// <summary>
        /// The abbreviation of this building
        /// </summary>
        [MaxLength(256)]
        [JsonPropertyName("abbreviation")]
        public string Abbreviation { get; set; }

        /// <summary>
        /// The name of this building
        /// </summary>
        [Required]
        [MaxLength(256)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The description of this building
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// The physical address of the building
        /// </summary>
        [Required]
        [JsonPropertyName("address")]
        public Address Address { get; set; }

        /// <summary>
        /// Get or set object for additional non-standard attributes)
        /// </summary>
        [JsonPropertyName("ext")]
        public Dictionary<string, object> Ext { get; set; }


        /// <summary>
        /// Get or set a list of rooms in this building
        /// </summary>
        [JsonPropertyName("rooms")]
        public List<Room> Rooms { get; set; }
    }
}
