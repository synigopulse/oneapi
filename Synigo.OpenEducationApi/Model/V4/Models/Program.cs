using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    ///  A collection of courses that lead to a certifiable learning outcome   
    /// </summary>
    public class Program
    {
        public static readonly string ModelType = "https://openonderwijsapi.nl/v4/model#program";
        /// <summary>
        /// Unique id for this program
        /// </summary>
        [Required]
        [JsonPropertyName("programId")]
        public Guid ProgramId { get; set; }

        [Required]
        [JsonPropertyName("type")]
        public ProgramType Type { get; set; }

        /// <summary>
        /// The name of this program
        /// </summary>
        /// <example> Student Mobility </example>
        [Required]
        [MaxLength(256)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The abbreviation of this program
        /// </summary>
        /// <example>studM</example>
        [Required]
        [MaxLength(256)]
        [JsonPropertyName("abbreviation")]
        public string Abbreviation { get; set; }

        /// <summary>
        /// The description of this program
        /// </summary>
        /// <example>program that is a place holder for all courses that are made available for student mobility</example>
        [Required]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// The number of Euopean Credits that can be archieved in this program
        /// </summary>
        [Range(0, int.MaxValue)]
        [JsonPropertyName("ects")]
        public int Ects { get; set; }

        /// <summary>
        /// <see cref="QualificationAwarded"/>
        /// </summary>
        [MaxLength(64)]
        [JsonPropertyName("qualificationAwarded")]
        public QualificationAwarded QualificationAwarded { get; set; }

        /// <summary>
        /// The duration of this program in months
        /// </summary>
        [JsonPropertyName("lengthOfProgram")]
        public int? LengthOfProgram { get; set; }

        /// <summary>
        /// <see cref="LevelOfQualification"/>
        /// </summary>
        [MaxLength(64)]
        [JsonPropertyName("levelOfQualification")]
        public LevelOfQualification LevelOfQualification { get; set; }

        /// <summary>
        /// <see cref="Sector"/>
        /// </summary>
        [MaxLength(64)]
        [JsonPropertyName("sector")]
        public Sector Sector { get; set; }

        /// <summary>
        /// Field(s) of study (e.g. ISCED-F) 
        /// (http://uis.unesco.org/sites/default/files/documents/isced-fields-of-education-and-training-2013-en.pdf.
        /// </summary>
        /// <example>
        /// 0732
        /// </example>
        [MaxLength(4)]
        [JsonPropertyName("fieldsOfStudy")]
        public string FieldsOfStudy { get; set; }

        /// <summary>
        /// CrohoCode in wo/hbo or creboCode in mbo
        /// </summary>
        /// <example>59312</example>
        [MaxLength(64)]
        [JsonPropertyName("crohoCreboCode")]
        public string CrohoCreboCode { get; set; }

        /// <summary>
        /// Brief description of the main focus of the program
        /// </summary>
        [JsonPropertyName("profileOfProgram")]
        public string ProfileOfProgram { get; set; }

        /// <summary>
        /// List of learning outcomes at program level. It is advisable to limit the number of learning outcomes to approximately 20. 
        /// It is also advisable to make sure that the program learning outcomes in the course catalogue correspond with those on the Diploma Supplement.
        /// </summary>
        [JsonPropertyName("learningOutcomes")]
        public List<string> LearningOutcomes { get; set; }

        /// <summary>
        /// This information may be given at an institutional level and/or at the level of individual programmes.
        /// Make sure that it is clear whether the information applies to fee-paying students (national and/or international) or to exchange students.
        /// </summary>
        [JsonPropertyName("admissionRequirements")]
        public string AdmissionRequirements { get; set; }

        /// <summary>
        /// Normally, students will receive a diploma when they have completed the (official) study program and have obtained the required number of credits. 
        /// If there are any other specific requirements that students need to have fulfilled, mention them here.
        /// </summary>
        [JsonPropertyName("qualificationRequirements")]
        public string QualificationRequirements { get; set; }

        /// <summary>
        /// URL of the program's website
        /// </summary>
        [MaxLength(2048)]
        [JsonPropertyName("link")]
        public string Link { get; set; }

        /// <summary>
        /// Parent program of which the current program is a child.  
        /// </summary>
        [JsonPropertyName("parent")]
        public Program Parent { get; set; }

        /// <summary>
        /// Programs which are a part of this program (e.g specializations)
        /// </summary>
        [JsonPropertyName("children")]
        public List<Program> Chidren { get; set; }

        /// <summary>
        /// The organization providing the current course
        /// </summary>
        [JsonPropertyName("organization")]
        public Organization Organization { get; set; }

        /// <summary>
        /// Courses for this program 
        /// </summary>
        [JsonPropertyName("courses")]
        public List<Course> Courses { get; set; }
        
        /// <summary>
        /// Get or set object for additional non-standard attributes)
        /// </summary>
        [JsonPropertyName("ext")]
        public Dictionary<string, object> Ext { get; set; }
    }


}