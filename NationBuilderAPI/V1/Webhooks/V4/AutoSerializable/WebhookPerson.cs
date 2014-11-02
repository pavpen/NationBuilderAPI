using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NationBuilderAPI.V1.Webhooks.V4.AutoSerializable
{
    [DataContract]
    public class WebhookPerson : NationBuilderAPI.V1.AutoSerializable.Person
    {
        [DataMember]
        public string datatrust_id;

        [DataMember]
        public string profile_image_url_ssl;
    }
}
