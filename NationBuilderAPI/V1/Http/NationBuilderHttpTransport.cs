using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Reflection;
using System.Text;
using NationBuilderAPI.V1.CommonResources;

namespace NationBuilderAPI.V1.Http
{
    /// <summary>
    /// A base class for performing the HTTP communication with Nation Builder's API server.
    /// </summary>
    public class NationBuilderHttpTransport
    {
        public const string DefaultDateTimeFormatString = "yyyy-MM-ddTHH:mm:ssK";
        public const string DefaultBirthDateFormatString = "yyyy-MM-dd";
        public static string[] DefaultBirthDateFormatStrings = new string[] { DefaultDateTimeFormatString, DefaultBirthDateFormatString };

        protected string NationSlug;
        protected string AccessToken;

        /// <summary>
        /// Whether Nation Builder service calls should trigger registered webhooks.
        /// 
        /// Defaults to <c>true</c> for all API requests.
        /// Setting to <c>false</c> will disable the firing of any webhooks that could result from that API request.
        /// </summary>
        public bool FireWebhooks = true;

        public System.Net.IWebProxy HttpProxy = null;
        protected DateTimeFormat DateTimeFormat = new DateTimeFormat(DefaultDateTimeFormatString);

        protected StringBuilder MakeRequestUrlBuilder(params string[] urlComponents)
        {
            StringBuilder res = new StringBuilder("https://");

            res.Append(NationSlug);
            res.Append(".nationbuilder.com/api/v1/");
            foreach (string component in urlComponents)
            {
                res.Append(component);
            }
            res.Append("?access_token=").Append(AccessToken);
            if (!FireWebhooks)
            {
                res.Append("&fire_webhooks=false");
            }

            return res;
        }

        /// <summary>
        /// Create a <see cref="StringBuilder"/> object containing the URI for authenticated request from
        /// the URI path for an unauthenticated request relative to the host name.
        /// 
        /// You can use this method to construct the final URLs from the <c>next</c> and <c>prev</c> URLs returned in responses containing result pages.
        /// </summary>
        /// <param name="requestUrl">The unauthenticated URL.</param>
        /// <returns>A <c>StringBuilder</c> containing the authenticated URL.</returns>
        protected StringBuilder MakeRequestUrlBuilderFromUnauthenticatedPath(string requestUrl)
        {
            StringBuilder res = new StringBuilder("https://");

            res.Append(NationSlug).Append(".nationbuilder.com");
            res.Append(requestUrl);
            res.Append("&access_token=").Append(AccessToken);
            if (!FireWebhooks)
            {
                res.Append("&fire_webhooks=false");
            }

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

        protected StringBuilder RequestUrlBuilderAppendMethodNonNullParameters(StringBuilder urlBuilder, ParameterInfo[] parameterInfo,
            params string[] parameterValues)
        {
            StringBuilder res = urlBuilder;

            for (int c = 0; c < parameterInfo.Length; ++c)
            {
                string value = parameterValues[c];

                if (null == value)
                {
                    continue;
                }

                ParameterInfo info = parameterInfo[c];

                res = RequestUrlBuilderAppendQuery(res, "&", info.Name, "=", WebUtility.UrlEncode(value));
            }

            return res;
        }

        protected NationBuilderWebRequest MakeHttpRequest(StringBuilder url, string method = "GET")
        {
            var res = new NationBuilderWebRequest(url.ToString());

            res.Proxy = HttpProxy;
            res.ContentType = "application/json";
            res.Accept = "application/json";
            res.Method = method;

            return res;
        }

        protected NationBuilderWebRequest MakeHttpPostRequest<PostDataT>(StringBuilder url, PostDataT postData, string method = "POST")
        {
            var res = new NationBuilderWebRequest(url.ToString());

            res.Proxy = HttpProxy;
            res.ContentType = "application/json";
            res.Accept = "application/json";
            res.Method = method;

            byte[] postDataOctets = ((MemoryStream)SerializeNationBuilderObject<PostDataT>(postData)).ToArray();

            res.SendData(postDataOctets);

            return res;
        }

        protected void ReceiveVoidHttpResponse(NationBuilderWebRequest req, HttpStatusCode expectedStatusCode = HttpStatusCode.NoContent)
        {
            HttpWebResponse response = RequestGetResponse(req);

            if (response.StatusCode != expectedStatusCode)
            {
                throw new InvalidOperationException("Unexpected HTTP status code: " + response.StatusCode + "\n" + response.StatusDescription);
            }
        }

        public ObjectT DeserializeNationBuilderObject<ObjectT>(Stream stream)
        {
            DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings();
            settings.DateTimeFormat = DateTimeFormat;
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ObjectT), settings);

            return (ObjectT)serializer.ReadObject(stream);
        }

        protected ResponseT DeserializeHttpResponse<ResponseT>
            (NationBuilderWebRequest req, int minimumStatusCode, int maximumStatusCode)
            where ResponseT : NationBuilderResponse
        {
            HttpWebResponse response = RequestGetResponse(req);
            int statusCodeInt = (int)response.StatusCode;

            if (statusCodeInt < minimumStatusCode || statusCodeInt > maximumStatusCode)
            {
                throw new InvalidOperationException("Unexpected HTTP status code: " + response.StatusCode + "\n" + response.StatusDescription);
            }

            var res = DeserializeNationBuilderObject<ResponseT>(response.GetResponseStream());

            res.Http = new HttpResponseInformation(response);

            return res;
        }

        protected ResponseT DeserializeHttpResponse<ResponseT>
            (NationBuilderWebRequest req, HttpStatusCode expectedStatusCode)
            where ResponseT : NationBuilderResponse
        {
            return DeserializeHttpResponse<ResponseT>(req, (int)expectedStatusCode, (int)expectedStatusCode);
        }

        protected ResponseT DeserializeHttpResponse<ResponseT>(NationBuilderWebRequest req)
            where ResponseT : NationBuilderResponse
        {
            return DeserializeHttpResponse<ResponseT>(req, 200, 299);
        }

        protected HttpWebResponse RequestGetResponse(NationBuilderWebRequest req)
        {
            HttpWebResponse response;

            try
            {
                response = (HttpWebResponse)req.GetResponse();
            }
            catch (WebException exc)
            {
                response = (HttpWebResponse)exc.Response;
                
                if (null == response)
                {
                    throw; // unrecognized exceptions back.
                }

                // Marshall Nation Builder exceptions back:
                switch (response.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.NotFound:
                        RemoteException exceptionInformation;

                        try {
                            exceptionInformation = DeserializeNationBuilderObject<RemoteException>(response.GetResponseStream());
                        }
                        catch
                        {
                            Stream stream = response.GetResponseStream();

                            stream.Seek(0, SeekOrigin.Begin);
                            using (var reader = new StreamReader(stream, Encoding.UTF8)) {
                                exceptionInformation = new RemoteException()
                                {
                                    message = "Unknown error. See 'error_description' field for the unparsed server response.",
                                    error_description = reader.ReadToEnd(),
                                };
                            }
                        }

                        throw new NationBuilderRemoteException(response.StatusCode, exceptionInformation, req, exc);
                }

                // Throw unrecognized exceptions back:
                throw;
            }

            return response;
        }

        public Stream SerializeNationBuilderObject<ObjectT>(ObjectT dataObject, Stream outputStream = null)
        {
            DataContractJsonSerializerSettings serSetgs = new DataContractJsonSerializerSettings();
            serSetgs.DateTimeFormat = DateTimeFormat;
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ObjectT), serSetgs);
            Stream res = null == outputStream ? new MemoryStream() : outputStream;

            ser.WriteObject(res, dataObject);

            return res;
        }
    }
}
