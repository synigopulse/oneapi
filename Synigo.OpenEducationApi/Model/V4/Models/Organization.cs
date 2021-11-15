using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{

    /// <summary>
    /// A description of a group of people working to gether to achieve a goal
    /// </summary>
    public class Organization
    {
        public static readonly string ModelType = "https://openonderwijsapi.nl/v4/model#organization";

        /// <summary>
        /// Unique id of this organization
        /// </summary>
        [Required]
        [JsonPropertyName("organizationId")]
        public Guid OrganizationId { get; set; }

        /// <summary>
        /// The name of the organization
        /// </summary>
        /// <example>Coöperatie SURF U.A.</example>
        [Required]
        [MaxLength(256)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Short name of the organization
        /// </summary>
        /// <example>SURF</example>
        [Required]
        [MaxLength(256)]
        [JsonPropertyName("shortName")]
        public string ShortName { get; set; }

        /// <summary>
        /// Any general description of the organization should clearly mention the type of higher education organization, especially in the case of a binary system. 
        /// In Dutch; universiteit (university) or hogeschool (university of applied sciences).
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// The <see cref="OrganizationType"/> of this organization
        /// </summary>
        [Required]
        [MaxLength(64)]
        [JsonPropertyName("type")]
        public OrganizationType Type { get; set; }

        /// <summary>
        /// A list of <see cref="Address"/> of this organization
        /// </summary>
        [JsonPropertyName("addresses")]
        public List<Address> Addresses { get; set; }

        /// <summary>
        /// URL of the organization's website
        /// </summary>
        [MaxLength(2048)]
        [JsonPropertyName("link")]
        public string Link { get; set; }

        /// <summary>
        /// Logo of this organization
        /// </summary>
        [MaxLength(2048)]
        [JsonPropertyName("logo")]
        public string Logo { get; set; }

        /// <summary>
        /// BRIN-code of this organization
        ///  -00BX(BRIN-nummer instelling)
        ///  -26ED00 (BRIN-nummer vestiging)
        ///  -10305 (nummer Bevoegd Gezag)
        ///  -641 (nummer Administratie Kantoor)
        /// </summary>
        /// <example>00AA</example>
        [MaxLength(256)]
        [JsonPropertyName("brin")]
        public string Brin { get; set; }

        /// <summary>
        /// The <see cref="Organization"/> parent of this organization
        /// </summary>
        public Organization Parent { get; set; }

        /// <summary>
        /// A List of <see cref="Organization"/> children of this organization
        /// </summary>
        public List<Organization> Children { get; set; }

        /// <summary>
        /// Get or set object for additional non-standard attributes)
        /// </summary>
        [JsonPropertyName("ext")]
        public Dictionary<string, object> Ext { get; set; }
    }
}
