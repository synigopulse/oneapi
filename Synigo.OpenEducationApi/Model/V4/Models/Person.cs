﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// A person that has a relationship with this institution
    /// </summary>
    public class Person
    {
        public static readonly string Type = "https://openonderwijsapi.nl/v4/model#person";
        /// <summary>
        /// Get or set the unique id of this person
        /// </summary>
        [Required]
        [JsonPropertyName("personId")]
        public Guid PersonId { get; set; }

        /// <summary>
        /// Get or set the first name of this person
        /// </summary>
        [Required]
        [MaxLength(256)]
        [JsonPropertyName("givenName")]
        public string GivenName { get; set; }

        /// <summary>
        /// Get or set the prefix of the family name of this person
        /// </summary>
        [MaxLength(256)]
        [JsonPropertyName("surnamePrefix")]
        public string SurnamePrefix { get; set; }

        /// <summary>
        /// Get or set the family name of this person
        /// </summary>
        [Required]
        [MaxLength(256)]
        [JsonPropertyName("surname")]
        public string Surname { get; set; }

        /// <summary>
        /// Get or set the name of this person which will be displayed
        /// </summary>
        [Required]
        [MaxLength(256)]
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Get or set the initials of this person
        /// </summary>
        [MaxLength(256)]
        [JsonPropertyName("initials")]
        public string Initials { get; set; }

        /// <summary>
        /// Get or set the date of birth of this person, RFC3339 (full-date)
        /// </summary>
        [JsonPropertyName("dateOfBirth")]
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Get or set the city of birth of this person
        /// </summary>
        [MaxLength(1024)]
        [JsonPropertyName("cityOfBirth")]
        public string CityOfBirth { get; set; }

        /// <summary>
        /// Get or set the country of birth of this person the country code according to [iso-3166-1-alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)
        /// </summary>
        [MaxLength(1024)]
        [JsonPropertyName("countryOfBirth")]
        public string CountryOfBirth { get; set; }

        /// <summary>
        /// Get or set the nationality of this person the nationality according to https://gist.github.com/zspine/2365808
        /// </summary>
        [MaxLength(1024)]
        [JsonPropertyName("nationality")]
        public string Nationality { get; set; }

        /// <summary>
        /// Get or set the date of nationality of this person, RFC3339 (full-date)
        /// </summary>
        [JsonPropertyName("dateOfNationality")]
        public DateTime? DateOfNationality { get; set; }

        /// <summary>
        /// The affiliations of this person, the relations a person has with the organization providing this endpoint
        /// </summary>
        [JsonPropertyName("affiliations")]
        public List<PersonAffiliations> Affiliations { get; set; }

        /// <summary>
        /// Get or set the primary e-mailaddress of this person
        /// </summary>
        [MaxLength(256)]
        [JsonPropertyName("mail")]
        public string Mail { get; set; }

        /// <summary>
        /// Get or set the secondary e-mailaddress of this person
        /// </summary>
        [MaxLength(256)]
        [JsonPropertyName("secondaryMail")]
        public string SecondaryMail { get; set; }

        /// <summary>
        /// Get or set the telephone number of this person
        /// </summary>
        [MaxLength(256)]
        [JsonPropertyName("telephoneNumber")]
        public string TelephoneNumber { get; set; }

        /// <summary>
        /// Get or set the mobile number of this person
        /// </summary>
        [MaxLength(256)]
        [JsonPropertyName("mobileNumber")]
        public string MobileNumber { get; set; }

        /// <summary>
        /// Get or set the url of the informal picture of this person
        /// </summary>
        [MaxLength(2048)]
        [JsonPropertyName("photoSocial")]
        public string PhotoSocial { get; set; }

        /// <summary>
        /// Get or set the url of the official picture of this person
        /// </summary>
        [MaxLength(2048)]
        [JsonPropertyName("photoOfficial")]
        public string PhotoOfficial { get; set; }

        /// <summary>
        /// <see cref="V4.Gender"/>
        /// </summary>
        [MaxLength(32)]
        [JsonPropertyName("gender")]
        public Gender? Gender { get; set; }

        /// <summary>
        /// Get or set a title prefix to be used for this person
        /// </summary>
        [MaxLength(32)]
        [JsonPropertyName("titlePrefix")]
        public string TitlePrefix { get; set; }

        /// <summary>
        /// Get or set a title suffix to be used for this person
        /// </summary>
        [MaxLength(64)]
        [JsonPropertyName("titleSuffix")]
        public string TitleSuffix { get; set; }

        /// <summary>
        /// Get or set the name of the office where this person is located
        /// </summary>
        [MaxLength(2048)]
        [JsonPropertyName("office")]
        public string Office { get; set; }

        /// <summary>
        /// <see cref="Address"/>
        /// </summary>
        [JsonPropertyName("address")]
        public virtual Address Address { get; set; }

        /// <summary>
        /// Get or set full name of In Case of Emergency contact
        /// </summary>
        [MaxLength(256)]
        [JsonPropertyName("ICEName")]
        public string IceName { get; set; }

        /// <summary>
        /// Get or set phone number of In Case of Emergency contact
        /// </summary>
        [MaxLength(256)]
        [JsonPropertyName("ICEPhoneNumber")]
        public string IcePhoneNumber { get; set; }

        /// <summary>
        /// Get or set the type of relation between person and In Case of Emergency contact
        /// <see cref="V4.ICERelationType"/>
        /// </summary>
        [MaxLength(64)]
        [JsonPropertyName("ICERelation")]
        public ICERelationType? IceRelation { get; set; }

        /// <summary>
        /// Get or set the language(s) of choice for this person, RFC3066
        /// </summary>
        [JsonPropertyName("languageOfChoice")]
        public List<string> LanguageOfChoice { get; set; }

        /// <summary>
        /// Get or set object for additional non-standard attributes)
        /// </summary>
        [JsonPropertyName("ext")]
        public Dictionary<string,object> Ext { get; set; }

        [JsonIgnore]
        public List<Course> Courses { get; set; }
    }
}
