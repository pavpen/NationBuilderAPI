using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NationBuilderAPI.V1.Webhooks.V4
{
    /// <summary>
    /// The structure POSTed to a webhook reception HTTP server by the Nation Builder server.
    /// 
    /// The structure for to "Person created", "Person changed", "Person contacted", "Person destroyed" is <see cref="WebhookContent<PersonWebhookPayload>"/>,
    /// and for "Donation Succeeded", "Donation Changed", "Donation Canceled": <see cref="WebhookContent<DonationWebhookPayload>"/>.
    /// </summary>
    [DataContract]
    public class WebhookContent<PayloadType>
    {
        [DataMember]
        public string nation_slug;

        [DataMember]
        public PayloadType payload;

        /// <summary>
        /// The webhook secret token that can be used to verify the authenticity of the submitted webhook data.
        /// </summary>
        [DataMember]
        public string token;

        /// <summary>
        /// The webhook structure version.  If the meaning of submitted webhook fields changes, this version will increase.
        /// </summary>
        [DataMember]
        public int version;
    }
}
