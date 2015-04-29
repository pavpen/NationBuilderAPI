using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace NationBuilderAPI.V1
{
    public partial class NationBuilderSession : NationBuilderHttpTransport
    {
        /// <summary>
        /// Returns a paginated list of the webhooks the nation has already registered with this endpoint.
        /// </summary>
        /// <param name="limit">The number of results to show per page. (Default: 10, max: 100)</param>
        /// <returns>The requested page of webhook results.</returns>
        public ResultsPageResponse<Webhook> GetWebhooks(int limit=10)
        {
            StringBuilder reqUrlBuilder = RequestUrlBuilderAppendQuery(
                MakeRequestUrlBuilder("webhooks"),
                "&limit=", limit.ToString());
            HttpWebRequest req = MakeHttpRequest(reqUrlBuilder);
            var res = DeserializeHttpResponse<ResultsPageResponse<Webhook>>(req);

            return res;
        }

        /// <summary>
        /// Returns an iterator over all of the webhooks the nation has already registered.
        /// </summary>
        /// <param name="limit">The number of results to retrieve per page. (Max: 100)</param>
        /// <returns>An enumeration of the nation's webhooks.</returns>
        public IEnumerable<Webhook> GetWebhooksResults(int limit=100)
        {
            return AllResultsFrom(GetWebhooks(limit));
        }

        /// <summary>
        /// Show the details of an individual webhook, retrieved by its id.
        /// </summary>
        /// <param name="id">ID of the webhook to retrieve.</param>
        /// <returns>The webhook details.</returns>
        public Webhook ShowWebhook(string id)
        {
            StringBuilder reqUrlBuilder = MakeRequestUrlBuilder("webhooks/", Uri.EscapeUriString(id));
            HttpWebRequest req = MakeHttpRequest(reqUrlBuilder);
            var res = DeserializeHttpResponse<WebhookTransportObject>(req);

            return res.webhook;
        }

        /// <summary>
        /// Use this endpoint to register a webhook to fire on the occurance of a certain event.
        /// </summary>
        /// <param name="webhook">Webhook parameters.</param>
        /// <returns>The newly created webhook.</returns>
        public Webhook CreateWebhook(Webhook webhook)
        {
            StringBuilder reqUrlBuilder = MakeRequestUrlBuilder("webhooks");
            HttpWebRequest req = MakeHttpPostRequest<WebhookTransportObject>(reqUrlBuilder, new WebhookTransportObject() { webhook = webhook });
            var res = DeserializeHttpResponse<WebhookTransportObject>(req);

            return res.webhook;
        }

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
