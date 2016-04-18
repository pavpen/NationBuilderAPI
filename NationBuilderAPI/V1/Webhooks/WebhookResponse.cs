using NationBuilderAPI.V1.CommonResources;
using System.Runtime.Serialization;

namespace NationBuilderAPI.V1
{
    [DataContract]
    class WebhookResponse : NationBuilderResponse
    {
        [DataMember]
        public Webhook webhook;
    }
}
