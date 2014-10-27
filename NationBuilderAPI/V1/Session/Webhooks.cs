using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace NationBuilderAPI.V1
{
    public partial class NationBuilderSession : NationBuilderHttpTransport
    {
        /// <summary>
        /// Remove a webhook to have NationBuilder stop sending events to the endpoint.
        /// </summary>
        /// <param name="webhookId">ID of the webhook to destroy.</param>
        public void DestroyWebhook(string webhookId)
        {
            StringBuilder reqUrlBuilder = MakeRequestUrlBuilder("webhooks/", webhookId);
            HttpWebRequest req = MakeHttpRequest(reqUrlBuilder, HttpMethodNames.Delete);

            ReceiveVoidHttpResponse(req);
        }
    }
}
