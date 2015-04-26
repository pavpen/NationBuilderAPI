using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace NationBuilderAPI.V1
{
    /// <summary>
    /// A session object used to access a nation's API.
    /// </summary>
    public partial class NationBuilderSession : NationBuilderHttpTransport, IDisposable
    {
        /// <summary>
        /// Create a new Nation Builder session for accessing a nation's API.
        /// </summary>
        /// <param name="slug">The slug of the nation to access.</param>
        /// <param name="accessToken">The API access token for accessing the nation's API.</param>
        public NationBuilderSession(string slug, string accessToken)
        {
            this.nbSlug = slug;
            this.nbAccessToken = accessToken;
        }

        /// <summary>
        /// Dispose of any resources taken up by this session.
        /// 
        /// (This <see cref="NationBuilderSession"/> is quite state-less, and has no resources to dispose.
        /// However, it implements <see cref="IDisposable"/>, because it is conventional to think of a session as disposable.)
        /// </summary>
        void IDisposable.Dispose()
        {
            // Nothing to do here.
        }
    }
}
