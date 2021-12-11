namespace Excalibur4.IBIS.Models.Helpers
{
    /// <summary>
    /// Generic Response Message for all Calls, very simple for this application as there are no object really returned only a message and maybe an error if applicable
    /// </summary>
    public class EnvelopeFooter
    {
        /// <summary>
        /// Response message
        /// </summary>
        public string ResponseMessage { get; set; }
        /// <summary>
        /// true if there was an Exception thrown, false if not
        /// </summary>
        public bool ExceptionThrown { get; set; }
        /// <summary>
        /// The actual Exception Message can include Actual Exception for stacktrace etc but that is not nessasry in an app of this scale.
        /// </summary>
        public string ExceptionMessage { get; set; }
        
    }
}
