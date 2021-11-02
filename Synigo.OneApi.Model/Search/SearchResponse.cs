using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Synigo.OneApi.Model.Search
{
    public class SearchResponse
    {
        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }

        [JsonPropertyName("items")]
        public List<SearchResponseItem> Items { get; set; }

        [JsonPropertyName("Refiners")]
        public List<Refiner> Refiners { get; set; }
    }
}
