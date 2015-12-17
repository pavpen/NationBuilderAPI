using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NationBuilderAPI.V1
{
    [DataContract]
    public class Webhook
    {
        [DataMember]
        public string id;

        /// <summary>
        /// The payload version you want to receive. Choose from 1, 2, 3 or 4.
        /// </summary>
        [DataMember]
        public int version;

        /// <summary>
        /// The URL you want to have the webhook fire towards.
        /// </summary>
        [DataMember]
        public string url;

        /// <summary>
        /// The event you want to observe.
        /// 
        /// One on the following types of events:
        /// 
        ///  * Person creation - <c>"person_creation"</c>
        ///  
        ///  * Person update - <c>"person_update"</c>
        ///  
        ///  * Person contact - <c>"person_contact"</c>
        ///  
        ///  * Donation success - <c>"donation_success"</c>
        ///  
        ///  * Donation update - <c>"donation_update"</c>
        ///  
        ///  * Donation cancelation - <c>"donation_cancellation"</c>
        /// </summary>
        [DataMember(Name="event")]
        public string event_name;
        


        public Webhook() { }

        /// <summary>
        /// Create an <see cref="Webhook"/> object which is a shallow copy of another object.
        /// </summary>
        /// <param name="copySource">The object to copy.</param>
        public Webhook(Webhook copySource)
        {
            foreach (var info in typeof(Webhook).GetFields())
            {
                info.SetValue(this, info.GetValue(copySource));
            }
        }

        /// <summary>
        /// Create a shallow clone of this object.
        /// </summary>
        /// <returns>The cloned object.</returns>
        public Webhook ShallowClone()
        {
            return (Webhook)this.MemberwiseClone();
        }
    }
}
