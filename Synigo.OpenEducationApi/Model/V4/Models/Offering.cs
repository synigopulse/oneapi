using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// Either a program, course or component offering which descrbes the program, course or offering in time 
    /// </summary>
    public class Offering
    {
        public static readonly string ModelType = "https://openonderwijsapi.nl/v4/model#offering";
        /// <summary>
        /// Unique id of this offering
        /// </summary>
        [Required]
        [JsonPropertyName("offeringId")]
        public Guid OfferingId { get; set; }

        /// <summary>
        ///  The type of this offering
        /// </summary>
        [Required]
        [MaxLength(64)]
        [JsonPropertyName("type")]
        public OfferingType Type { get; set; }

        /// <summary>
        /// The <see cref="AcademicSession"/> of this Offering
        /// </summary>
        [JsonPropertyName("academicSession")]
        public AcademicSession AcademicSession { get; set; }

        /// <summary>
        /// The name of this offering
        /// </summary>
        /// <example>
        /// Final written test for INFOMQNM for fall semseter 2020
        /// </example>
        [Required]
        [MaxLength(256)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The abbreviation or internal code used to identify this offering
        /// </summary>
        /// <example>
        /// Test-INFOMQNM-20FS
        /// </example>
        [MaxLength(256)]
        [JsonPropertyName("abbreviation")]
        public string Abbreviation { get; set; }

        /// <summary>
        /// The description of this offering
        /// </summary>
        /// <example>
        /// Prove in wirting knowledge of research methods, including:
        /// Acquire knowledge of HCI research paradigms
        /// Able to design suitable research studies(e.g., choose between within and between subject designs)
        /// Define/apply/design metrics and scales
        /// Define/produce materials(e.g., stimuli and questionnaires)
        /// Define protocols for research studies
        /// Understands and take in account concepts of reliability and validity
        /// Analyze and improve methods and analysis of published scientific articles
        /// Able to deliver scientific reports
        /// Prove in writing knowledge of ­­­statistics, including:
        /// Handle hypothesis testing with complex designs(e.g., including , dependent, independent, and co variates)
        /// Data preparation(e.g., coding and feature selection)
        /// Reason towards adequate techniques to ensure valid outcomes(e.g., be aware of type I, type II errors)
        /// Select an appropriate sampling method(e.g., stratified)
        /// Perform parametric tests(e.g., repeated measures (M) ANOVA)
        /// Perform non-parametric tests(e.g., Chi-square, Mann-Whitney, and Kruskal-Wallis)
        /// </example>
        [Required]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// The main language in which the courses within this program are given, RFC3066
        /// </summary>
        /// <example>
        ///  nl-NL
        /// </example>
        [Required]
        [MaxLength(64)]
        [JsonPropertyName("mainLanguage")]
        public string MainLanguage { get; set; }

        /// <summary>
        /// The maximum number of students allowed to enroll for this offering
        /// </summary>
        /// <example>
        /// 200
        /// </example>
        [Range(0, int.MaxValue)]
        [JsonPropertyName("maxNumberStudents")]
        public int MaxNumberStudents { get; set; }

        /// <summary>
        /// The number of students that have already enrolled for this offering
        /// </summary>
        /// <example>
        /// 150
        /// </example>
        [Range(0, int.MaxValue)]
        [JsonPropertyName("enrolledNumberStudents")]
        public int EnrolledNumberStudents { get; set; }

        /// <summary>
        /// The number of students that have a pending enrollment request for this offering
        /// </summary>
        /// <example>
        /// 150
        /// </example>
        [Range(0, int.MaxValue)]
        [JsonPropertyName("pendingNumberStudents")]
        public int PendingNumberStudents { get; set; }

        /// <summary>
        /// Whether the offering is a line item or not
        /// </summary>
        /// <example>
        /// true
        /// </example>
        [Required]
        [JsonPropertyName("isLineItem")]
        public bool IsLineItem { get; set; }

        /// <summary>
        /// The <see cref="ResultValueType"/> of this offering
        /// </summary>
        [MaxLength(64)]
        [JsonPropertyName("resultValueType")]
        public ResultValueType ResultValueType { get; set; }

       

        /// <summary>
        /// The organization who offers this offering
        /// </summary>
        [JsonPropertyName("organization")]
        public Organization Organization { get; set; }

       

        /// <summary>
        /// Get or set object for additional non-standard attributes)
        /// </summary>
        [JsonPropertyName("ext")]
        public Dictionary<string, object> Ext { get; set; }
    }
}
