using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NationBuilderAPI.V1.Webhooks.V4
{
    /// <summary>
    /// The <c>Person</c> structure that appears in the payload posted by webhook call-back requests.
    /// </summary>
    [DataContract]
    public class WebhookPerson : Person
    {
        [DataMember]
        public string datatrust_id;

        [DataMember]
        public string profile_image_url_ssl;



        /// <summary>
        /// Create a shallow <see cref="Person"/> clone of this <see cref="WebhookPerson"/> object.
        /// 
        /// You may want to use this method instead of having to resolve data types at runtime,
        /// if you need to serialize it back as a <see cref="Person"/> object.
        /// </summary>
        /// <returns>The <see cref="Person"/> object.</returns>
        public Person ToPerson()
        {
            var res = new Person();

            res.CopyFrom(this);

            return res;
        }
    }
}
