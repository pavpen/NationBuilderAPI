using System.Runtime.Serialization;

namespace NationBuilderAPI.V1
{
    [DataContract]
    class WebhookTransportObject
    {
        [DataMember]
        public Webhook webhook;
    }
}
