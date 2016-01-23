using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NationBuilderAPI.V1.Webhooks.V4
{
    /// <summary>
    /// The payload structure submitted in "Person created", "Person changed", "Person contacted", "Person destroyed" webhook call-back posts.
    /// </summary>
    [DataContract]
    public class PersonWebhookPayload<WebhookPersonType>
    {
        [DataMember]
        public WebhookPersonType person;
    }

    [DataContract]
    public class PersonWebhookPayload : PersonWebhookPayload<WebhookPerson>
    { }
}
