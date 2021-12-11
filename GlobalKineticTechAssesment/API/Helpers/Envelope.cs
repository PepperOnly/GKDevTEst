using System;
using System.Collections.Generic;

namespace Excalibur4.IBIS.Models.Helpers
{
    /// <summary>
    /// Generic Type for all POST requests, normally this will allow for classes but for this test its a Enum as there are no other methods required.
    /// Generally this will be used for all request as you can store APIKey, enable logging etc in the heade but that is beyond the scope of this test.
    /// </summary>
    /// <typeparam name="T">In this case its a enum</typeparam>
    public class Envelope<T> where T : Enum
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Envelope()
        {
            EnvelopeBody = new List<T>();
        }

        /// <summary>
        /// This is the same for all requests and where you woul store APIKey etc...
        /// </summary>
        public EnvelopeHeader EnvelopeHeader { get; set; }
        /// <summary>
        /// Contains a List of all Request Classes in this case an Enum as there is no other request in this app
        /// </summary>
        public List<T> EnvelopeBody { get; set; }
    }
}
