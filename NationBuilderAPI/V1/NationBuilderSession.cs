using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace NationBuilderAPI.V1
{
    public class NationBuilderSession
    {
        private string nbSlug;
        private string nbAccessToken;
        public System.Net.IWebProxy httpProxy = null;
        private DateTimeFormat dateTimeFormat = new DateTimeFormat("yyyy-MM-ddTHH:mm:ssK");

        public NationBuilderSession(string slug, string accessToken)
        {
            this.nbSlug = slug;
            this.nbAccessToken = accessToken;
        }

        /// <summary>
        /// The index endpoint provides a paginated view of the people in a nation. Each person's data is abbreviated for the Index view.
        /// To get a full representation use the Show endpoint (<see cref="ShowPerson"/>).
        /// </summary>
        /// <param name="page">Result page number.</param>
        /// <param name="per_page">Number of results to return (max 100).</param>
        /// <returns>The results page, and results information.</returns>
        public PeopleIndexResponse GetPeople(int page=1, int per_page = 10)
        {
            StringBuilder reqUrlBuilder = RequestUrlBuilderAppendQuery(
                MakeRequestUrlBuilder("people"),
                "&page=", page.ToString(),
                "&per_page=", per_page.ToString());
            HttpWebRequest req = MakeHttpRequest(reqUrlBuilder);
            PeopleIndexResponse res = DeserializeHttpResponse<PeopleIndexResponse>(req);

            return res;
        }

        /// <summary>
        /// The Show endpoint returns a full representation of the person with the provided ID.
        /// </summary>
        /// <param name="id">ID of the person to retrieve.</param>
        /// <param name="idType">Type of ID to use, set to <c>"external"</c> to show the person based on their external ID. Leave as <c>null</c> to use NationBuilder's ID.</param>
        /// <returns>The full person information.</returns>
        public PersonShowResponse ShowPerson(long id, string idType = null)
        {
            StringBuilder reqUrlBuilder = MakeRequestUrlBuilder("people/", id.ToString());
            if (null != idType)
            {
                reqUrlBuilder = RequestUrlBuilderAppendQuery(reqUrlBuilder, "&id_type=", idType.ToString());
            }

            HttpWebRequest req = MakeHttpRequest(reqUrlBuilder);
            PersonShowResponse res = DeserializeHttpResponse<PersonShowResponse>(req);

            return res;
        }

        /// <summary>
        /// Remove a webhook to have NationBuilder stop sending events to the endpoint.
        /// </summary>
        /// <param name="webhookId">ID of the webhook to destroy.</param>
        public void DestroyWebhook(string webhookId)
        {
            StringBuilder reqUrlBuilder = MakeRequestUrlBuilder("webhooks/", webhookId);
            HttpWebRequest req = MakeHttpRequest(reqUrlBuilder, "DELETE");

            req.GetResponse();
        }

        private StringBuilder MakeRequestUrlBuilder(params string[] urlComponents)
        {
            StringBuilder res = new StringBuilder("https://");

            res.Append(nbSlug);
            res.Append(".nationbuilder.com/api/v1/");
            foreach (string component in urlComponents)
            {
                res.Append(component);
            }
            res.Append("?access_token=");
            res.Append(nbAccessToken);

            return res;
        }

        private StringBuilder RequestUrlBuilderAppendQuery(StringBuilder urlBuilder, params string[] urlComponents)
        {
            foreach (string component in urlComponents)
            {
                urlBuilder.Append(component);
            }

            return urlBuilder;
        }

        private HttpWebRequest MakeHttpRequest(StringBuilder url, string method = "GET")
        {
            HttpWebRequest res = (HttpWebRequest)WebRequest.Create(url.ToString());

            res.Proxy = httpProxy;
            res.ContentType = "application/json";
            res.Accept = "application/json";
            res.Method = method;

            return res;
        }

        private ResponseT DeserializeHttpResponse<ResponseT>(HttpWebRequest req)
        {
            DataContractJsonSerializerSettings serSetgs = new DataContractJsonSerializerSettings();
            serSetgs.DateTimeFormat = dateTimeFormat;
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ResponseT), serSetgs);

            return (ResponseT)ser.ReadObject(req.GetResponse().GetResponseStream());
        }
    }
}
