namespace Excalibur4.IBIS.Models.Helpers
{
    /// <summary>
    /// Header for Requests, used for sending API Key etc but really beyond the scope for this Application
    /// </summary>
    public class EnvelopeHeader
    {
        /// <summary>
        /// Not Applicable for this Application
        /// </summary>
        public string ApiKey { get; set; }
        /// <summary>
        /// Enable console debugging for request
        /// </summary>
        public bool EnableLogging { get; set; } = false;
    }
}
