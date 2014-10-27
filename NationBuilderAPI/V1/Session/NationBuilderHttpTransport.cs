using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;


namespace NationBuilderAPI.V1
{
    class HttpMethodNames
    {
        public const string Get = "GET";
        public const string Put = "PUT";
        public const string Post = "POST";
        public const string Delete = "DELETE";
    }

    /// <summary>
    /// A base class for performing the HTTP communication with Nation Builder's API server.
    /// </summary>
    public class NationBuilderHttpTransport
    {
        protected string nbSlug;
        protected string nbAccessToken;
        public System.Net.IWebProxy httpProxy = null;
        protected DateTimeFormat dateTimeFormat = new DateTimeFormat("yyyy-MM-ddTHH:mm:ssK");

        protected StringBuilder MakeRequestUrlBuilder(params string[] urlComponents)
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

        protected StringBuilder RequestUrlBuilderAppendQuery(StringBuilder urlBuilder, params string[] urlComponents)
        {
            foreach (string component in urlComponents)
            {
                urlBuilder.Append(component);
            }

            return urlBuilder;
        }

        protected HttpWebRequest MakeHttpRequest(StringBuilder url, string method = "GET")
        {
            HttpWebRequest res = (HttpWebRequest)WebRequest.Create(url.ToString());

            res.Proxy = httpProxy;
            res.ContentType = "application/json";
            res.Accept = "application/json";
            res.Method = method;

            return res;
        }

        protected HttpWebRequest MakeHttpPostRequest<PostDataT>(StringBuilder url, PostDataT postData, string method = "POST")
        {
            HttpWebRequest res = (HttpWebRequest)WebRequest.Create(url.ToString());

            res.Proxy = httpProxy;
            res.ContentType = "application/json";
            res.Accept = "application/json";
            res.Method = method;

            byte[] postDataOctets = ((MemoryStream)SerializeHttpDataObject<PostDataT>(postData)).ToArray();
            res.ContentLength = postDataOctets.Length;

            using (var stream = res.GetRequestStream())
            {
                stream.Write(postDataOctets, 0, postDataOctets.Length);
            }

            return res;
        }

        protected void ReceiveVoidHttpResponse(HttpWebRequest req, HttpStatusCode expectedStatusCode = HttpStatusCode.NoContent)
        {
            HttpWebResponse response = (HttpWebResponse) req.GetResponse();

            if (response.StatusCode != expectedStatusCode)
            {
                throw new InvalidOperationException("Unexpected HTTP status code: " + response.StatusCode + "\n" + response.StatusDescription);
            }
        }

        protected ResponseT DeserializeHttpResponse<ResponseT>(HttpWebRequest req, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            HttpWebResponse response = (HttpWebResponse)req.GetResponse();

            if (response.StatusCode != expectedStatusCode)
            {
                throw new InvalidOperationException("Unexpected HTTP status code: " + response.StatusCode + "\n" + response.StatusDescription);
            }

            DataContractJsonSerializerSettings serSetgs = new DataContractJsonSerializerSettings();
            serSetgs.DateTimeFormat = dateTimeFormat;
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ResponseT), serSetgs);

            return (ResponseT)ser.ReadObject(response.GetResponseStream());
        }

        private Stream SerializeHttpDataObject<DataObjectT>(DataObjectT dataObject, Stream outputStream = null)
        {
            DataContractJsonSerializerSettings serSetgs = new DataContractJsonSerializerSettings();
            serSetgs.DateTimeFormat = dateTimeFormat;
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(DataObjectT), serSetgs);
            Stream res = null == outputStream ? new MemoryStream() : outputStream;

            ser.WriteObject(res, dataObject);

            return res;
        }
    }
}
