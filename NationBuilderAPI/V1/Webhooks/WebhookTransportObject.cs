using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NationBuilderAPI.V1
{
    [DataContract]
    class WebhookTransportObject
    {
        [DataMember]
        public Webhook webhook;
    }
}
