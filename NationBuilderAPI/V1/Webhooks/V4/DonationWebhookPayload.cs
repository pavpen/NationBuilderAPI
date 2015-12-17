using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NationBuilderAPI.V1.Webhooks.V4
{
    [DataContract]
    public class DonationWebhookPayload
    {
        [DataMember]
        public Donation donation;
    }
}
