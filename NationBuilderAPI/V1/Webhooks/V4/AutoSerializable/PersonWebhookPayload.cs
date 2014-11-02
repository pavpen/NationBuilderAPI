using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NationBuilderAPI.V1.Webhooks.V4.AutoSerializable
{
    [DataContract]
    public class PersonWebhookPayload
    {
        [DataMember]
        public WebhookPerson person;
    }
}
