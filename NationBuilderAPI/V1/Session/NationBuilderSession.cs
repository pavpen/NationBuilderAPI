using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace NationBuilderAPI.V1
{
    /// <summary>
    /// A session object used to access a nation's API.
    /// </summary>
    public partial class NationBuilderSession : NationBuilderHttpTransport
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
    }
}
