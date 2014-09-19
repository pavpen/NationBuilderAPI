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

        public PeopleIndexResponse GetPeople(int page=1, int per_page = 10)
        {
            string reqURL = "https://" + nbSlug + ".nationbuilder.com/api/v1/people?access_token=" + nbAccessToken + "&page=" + page + "&per_page=" + per_page;
            PeopleIndexResponse res;

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(reqURL);
            req.Proxy = httpProxy;
            req.ContentType = "application/json";
            req.Accept = "application/json";
            DataContractJsonSerializerSettings serSetgs = new DataContractJsonSerializerSettings();
            serSetgs.DateTimeFormat = dateTimeFormat;
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(PeopleIndexResponse), serSetgs);
            res = (PeopleIndexResponse)ser.ReadObject(req.GetResponse().GetResponseStream());
            return res;
        }

        public PersonShowResponse ShowPerson(int id)
        {
            string reqURL = "https://" + nbSlug + ".nationbuilder.com/api/v1/people/" + id + "?access_token=" + nbAccessToken;
            PersonShowResponse res;

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(reqURL);
            req.Proxy = httpProxy;
            req.ContentType = "application/json";
            req.Accept = "application/json";
            DataContractJsonSerializerSettings serSetgs = new DataContractJsonSerializerSettings();
            serSetgs.DateTimeFormat = dateTimeFormat;
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(PersonShowResponse), serSetgs);
            res = (PersonShowResponse)ser.ReadObject(req.GetResponse().GetResponseStream());
            return res;
        }

        public void DestroyWebhook(string webhookId)
        {
            string reqUrl = "https://" + nbSlug + ".nationbuilder.com/api/v1/webhooks/" + webhookId + "?access_token=" + nbAccessToken;

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(reqUrl);
            req.Proxy = httpProxy;
            req.ContentType = "application/json";
            req.Accept = "application/json";
            req.Method = "DELETE";
            req.GetResponse();
        }
    }
}
