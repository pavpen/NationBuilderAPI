using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace NationBuilderAPI.V1.Http
{
    /// <summary>
    /// A wrapper around <see cref="System.Net.HttpWebRequest"/> that allows us to store additional information for debugging.
    /// </summary>
    public class NationBuilderWebRequest
    {
        /// <summary>
        /// The Web requset used to communicate with Nation Builder.
        /// </summary>
        public HttpWebRequest WebRequest;

        /// <summary>
        /// A copy of the data sent to the remote endpoint.
        /// </summary>
        public byte[] OctetsSent = null;

        public IWebProxy Proxy
        {
            get { return WebRequest.Proxy; }
            set { WebRequest.Proxy = value; }
        }

        public string ContentType
        {
            get { return WebRequest.ContentType; }
            set { WebRequest.ContentType = value; }
        }

        public string Accept
        {
            get { return WebRequest.Accept; }
            set { WebRequest.Accept = value; }
        }

        public string Method
        {
            get { return WebRequest.Method; }
            set { WebRequest.Method = value; }
        }


        public NationBuilderWebRequest(string uri)
        {
            WebRequest = (HttpWebRequest)System.Net.WebRequest.Create(uri);
        }

        public WebResponse GetResponse()
        {
            return WebRequest.GetResponse();
        }

        /// <summary>
        /// Send an array of octets to the remote endpoint.
        /// 
        /// This method sets the 'Content-Length' header before writing the data.
        /// </summary>
        /// <param name="octets">The data to send.</param>
        public void SendData(byte[] octets)
        {
            WebRequest.ContentLength = octets.Length;

//#if DEBUG
            OctetsSent = octets;
//#endif
            using (var stream = WebRequest.GetRequestStream())
            {
                stream.Write(octets, 0, octets.Length);
            }
        }
    }
}
