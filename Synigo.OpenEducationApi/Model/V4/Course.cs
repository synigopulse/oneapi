using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// An object describing the metadata of a course 
    /// </summary>
    public class Course
    {
        /// <summary>
        /// Unique id of this course
        /// </summary>
        [Required]
        [JsonPropertyName("courseId")]
        public Guid CourseId { get; set; }

        /// <summary>
        /// The name of this course (ECTS-title)
        /// </summary>
        /// <example>
        /// Academic and Professional Writing
        /// </example>
        [Required]
        [MaxLength(256)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The abbreviation or internal code used to identify this course (ECTS-code)
        /// </summary>
        /// <example>
        /// INFOMQNM
        /// </example>
        [Required]
        [MaxLength(256)]
        [JsonPropertyName("abbreviation")]
        public string Abbreviation { get; set; }

        /// <summary>
        /// the number of EC's that is earned when the course is completed successfully (ECTS-ects)
        /// </summary>
        /// <example>
        /// 7.5
        /// </example>
        [Range(0,Double.MaxValue)]
        [JsonPropertyName("ects")]
        public decimal Ects { get; set; }

        /// <summary>
        /// The description of this course (ECTS-description)
        /// </summary>
        /// <example>
        /// As with all empirical sciences, to assure valid outcomes, HCI studies heavily rely on research methods and statistics. 
        /// This holds for the design of user interfaces, personalized recommender systems, 
        /// and interaction paradigms for the internet of things.
        /// </example>
        [Required]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// tatements that describe the knowledge or 
        /// skills students should acquire by the end of a particular course (ECTS-learningoutcome)
        /// </summary>
        [JsonPropertyName("learningOutcomes")]
        public List<string> LearningOutcomes { get; set; }

        /// <summary>
        ///  The requirements needed to enter this course (ECTS-prerequisites)
        /// </summary>
        [JsonPropertyName("requirements")]
        public string Requirements { get; set; }

        [Required]
        [JsonPropertyName("level")]
        public Level Level { get; set; }

        [JsonPropertyName("modeOfDelivery")]
        public ModesOfDelivery ModesOfDelivery { get; set; }

        /// <summary>
        ///  The extra information that is provided for enrollment
        /// </summary>
        /// <example>
        /// enrollment through SIS
        /// </example>
        [JsonPropertyName("enrollment")]
        public string Enrollment { get; set; }

        /// <summary>
        /// An overview of the literature and other resources that is used in this course (ECTS-recommended reading and other sources)
        /// </summary>
        /// <example>
        /// ['book to be announced', 'on-line resource x']
        /// </example>
        [JsonPropertyName("resources")]
        public List<string> Resources { get; set; }

        /// <summary>
        ///  A description of the way exams for this course are taken (ECTS-assessment method and criteria)
        /// </summary>
        /// <example>
        /// Exam on campus
        /// </example>
        [JsonPropertyName("assessment")]
        public string Assessment { get; set; }

        /// <summary>
        /// URL of the course's website
        /// </summary>
        [MaxLength(2048)]
        [JsonPropertyName("link")]
        public string Link { get; set; }

        /// <summary>
        /// Get or set object for additional non-standard attributes)
        /// </summary>
        [JsonPropertyName("ext")]
        public Dictionary<string, object> Ext { get; set; }
    }
}
