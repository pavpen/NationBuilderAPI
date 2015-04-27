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


        public Person ToPerson()
        {
            return new Person(this);
        }
    }
}
