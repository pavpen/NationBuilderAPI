using System;
using System.Net;

namespace NationBuilderAPI.V1.CommonResources
{
    /// <summary>
    /// A class containing information about the response returned by the Nation Builder API.
    /// </summary>
    public class HttpResponseInformation
    {
        public HttpResponseInformation(HttpWebResponse informationSource)
        {
            _IsFromCache = informationSource.IsFromCache;
            _IsMutuallyAuthenticated = informationSource.IsMutuallyAuthenticated;
            _LastModified = informationSource.LastModified;
            _ProtocolVersion = informationSource.ProtocolVersion;
            _Server = informationSource.Server;
            _StatusCode = informationSource.StatusCode;
            _StatusDescription = informationSource.StatusDescription;
        }

        /// <summary>
        /// Whether this response was received from the cache.
        /// </summary>
        public virtual bool IsFromCache
        {
            get
            {
                return _IsFromCache;
            }
        }

        /// <summary>
        /// Whether both client and server were authenticated.
        /// </summary>
        public virtual bool IsMutuallyAuthenticated
        {
            get
            {
                return _IsMutuallyAuthenticated;
            }
        }

        /// <summary>
        /// The date and time when returned remote response was last modified.
        /// </summary>
        public DateTime LastModified
        {
            get
            {
                return _LastModified;
            }
        }

        /// <summary>
        /// Response's HTTP protocol version.
        /// </summary>
        public Version ProtocolVersion
        {
            get
            {
                return _ProtocolVersion;
            }
        }

        /// <summary>
        /// The name of the server that sent the response, from the 'Server' header.
        /// </summary>
        public string Server
        {
            get
            {
                return _Server;
            }
        }

        /// <summary>
        /// Response's HTTP status code.
        /// </summary>
        public virtual HttpStatusCode StatusCode
        {
            get
            {
                return _StatusCode;
            }
        }

        /// <summary>
        /// Response's HTTP status description.
        /// </summary>
        public virtual string StatusDescription
        {
            get
            {
                return _StatusDescription;
            }
        }

        private bool _IsFromCache;
        private bool _IsMutuallyAuthenticated;
        private DateTime _LastModified;
        private Version _ProtocolVersion;
        private string _Server;
        private HttpStatusCode _StatusCode;
        private string _StatusDescription;
    }
}
