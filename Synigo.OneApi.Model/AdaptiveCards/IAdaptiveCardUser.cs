namespace Synigo.OneApi.Model.AdaptiveCards
{
    /// <summary>
    /// The base implementation required for an adaptive card user.
    /// Classes should implement this and add additional fields themselves.
    /// </summary>
    public interface IAdaptiveCardUser
    {
        /// <summary>
        /// The username of the user.
        /// </summary>
        string Username { get; set; }
    }
}
