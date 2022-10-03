using Synigo.OneApi.Model.AdaptiveCards;
using System.Text.Json.Serialization;

namespace Synigo.OneApi.Model.Response
{
    /// <summary>
    /// A response template used for adaptive cards.
    /// </summary>
    /// <typeparam name="T">A class definition containing additional values used in the adaptive card.</typeparam>
    public class AdaptiveCardResponse<T>
    {
        /// <summary>
        /// The user tied to the response of the adaptive card.
        /// </summary>
        [JsonPropertyName("currentUser")]
        public IAdaptiveCardUser CurrentUser { get; set; }

        /// <summary>
        /// The additional values of the adaptive card.
        /// </summary>
        [JsonPropertyName("value")]
        public T Value { get; set; }
    }
}
