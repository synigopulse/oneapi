using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// A component is a part of a course 
    /// </summary>
    public class Component
    {
        public static readonly string ModelType = "https://openonderwijsapi.nl/v4/model#component";
        
        /// <summary>
        /// Unique id of this component
        /// </summary>
        [Required]
        [JsonPropertyName("componentId")]
        public Guid ComponentId { get; set; }

        [Required]
        [JsonPropertyName("type")]
        public ComponentType Type { get; set; }

        /// <summary>
        /// The name of this component
        /// </summary>
        /// <example>
        /// Written test for INFOMQNM
        /// </example>
        [Required]
        [MaxLength(256)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The abbreviation of this component
        /// </summary>
        /// <example>
        /// Test-INFOMQNM
        /// </example>
        /// 
        [Required]
        [MaxLength(256)]
        [JsonPropertyName("abbreviation")]
        public string Abbreviation { get; set; }

        /// <summary>
        /// The description of this component
        /// </summary>
        /// <example>
        /// Prove executable knowledge of research methods, including:
        /// Acquire knowledge of HCI research paradigms
        /// Able to design suitable research studies(e.g., choose between within and between subject designs)
        /// Define/apply/design metrics and scales
        /// Define/produce materials(e.g., stimuli and questionnaires)
        /// Define protocols for research studies
        /// Understands and take in account concepts of reliability and validity
        /// Analyze and improve methods and analysis of published scientific articles
        /// Able to deliver scientific reports
        /// 
        /// Prove executable knowledge of ­­­statistics, including:
        /// Handle hypothesis testing with complex designs(e.g., including , dependent, independent, and co variates)
        /// Data preparation(e.g., coding and feature selection)
        /// Reason towards adequate techniques to ensure valid outcomes(e.g., be aware of type I, type II errors)
        /// Select an appropriate sampling method(e.g., stratified)
        /// Perform parametric tests(e.g., repeated measures (M) ANOVA)
        /// Perform non-parametric tests(e.g., Chi-square, Mann-Whitney, and Kruskal-Wallis)
        /// </example>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Object for additional non-standard attributes
        /// </summary>
        [JsonPropertyName("ext")]
        public Dictionary<string, object> Ext { get; set; }

        /// <summary>
        /// The course of which this component is a part
        /// </summary>
        [JsonPropertyName("course")]
        public Course Course { get; set; }

        /// <summary>
        /// Organization which provides this component
        /// </summary>
        [JsonPropertyName("organization")]
        public Organization Organization { get; set; }
    }
}
