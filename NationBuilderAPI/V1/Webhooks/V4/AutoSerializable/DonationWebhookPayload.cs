using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NationBuilderAPI.V1.Webhooks.V4.AutoSerializable
{
    [DataContract]
    public class DonationWebhookPayload
    {
        [DataMember]
        public NationBuilderAPI.V1.AutoSerializable.Donation donation;
    }
}
