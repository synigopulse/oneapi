using System;
using System.Text.Json.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{

    public class Program
    {
        [JsonPropertyName("programId")]
        public string ProgramId { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("abbreviation")]
        public string Abbreviation { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("ects")]
        public int Ects { get; set; }

        [JsonPropertyName("qualificationAwarded")]
        public string QualificationAwarded { get; set; }

        [JsonPropertyName("lengthOfProgram")]
        public int LengthOfProgram { get; set; }

        [JsonPropertyName("levelOfQualification")]
        public string LevelOfQualification { get; set; }

        [JsonPropertyName("sector")]
        public string Sector { get; set; }

        [JsonPropertyName("fieldsOfStudy")]
        public string FieldsOfStudy { get; set; }

        [JsonPropertyName("crohoCreboCode")]
        public string CrohoCreboCode { get; set; }

        [JsonPropertyName("profileOfProgram")]
        public string ProfileOfProgram { get; set; }

        [JsonPropertyName("learningOutcomes")]
        public List<string> LearningOutcomes { get; set; }

        [JsonPropertyName("admissionRequirements")]
        public string AdmissionRequirements { get; set; }

        [JsonPropertyName("qualificationRequirements")]
        public string QualificationRequirements { get; set; }

        [JsonPropertyName("link")]
        public string Link { get; set; }

        [JsonPropertyName("ext")]
        public Ext Ext { get; set; }

        [JsonPropertyName("parent")]
        public Parent Parent { get; set; }

        [JsonPropertyName("children")]
        public List<Child> Children { get; set; }

        [JsonPropertyName("organization")]
        public Organization Organization { get; set; }
    }


}