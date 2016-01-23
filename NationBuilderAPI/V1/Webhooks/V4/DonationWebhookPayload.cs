using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NationBuilderAPI.V1.Webhooks.V4
{
    [DataContract]
    public class DonationWebhookPayload<DonationType>
    {
        [DataMember]
        public DonationType donation;
    }

    [DataContract]
    public class DonationWebhookPayload : DonationWebhookPayload<Donation>
    { }
}
