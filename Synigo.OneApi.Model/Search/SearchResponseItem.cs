using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Synigo.OneApi.Model.Common;

namespace Synigo.OneApi.Model.Search
{
    public class SearchResponseItem
    {
        [JsonPropertyName("breadCrumb")]
        public List<BreadCrumbItem> BreadCrumb { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("lastModifiedBy")]
        public string LastModifiedBy { get; set; }

        [JsonPropertyName("lastModifiedDate")]
        public DateTime? LastModifiedDate { get; set; }

        [JsonPropertyName("source")]
        public int Source
        {
            get
            {
                return 200;
            }
        }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("mediaType")]
        public string MediaType { get; set; }

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("rank")]
        public double Rank { get; set; }
    }
}
