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
            this.NationSlug = slug;
            this.AccessToken = accessToken;
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

        /// <summary>
        /// Get the next page of results from a given page of results, or <c>null</c>, if the given page is the last one.
        /// </summary>
        /// <typeparam name="ResultType">The type of result listed on the results page.</typeparam>
        /// <param name="resultsPage">The given page of results.</param>
        /// <returns>The next page of results, or <c>null</c>, if this is the last page.</returns>
        public ResultsPageResponse<ResultType> GetNextPage<ResultType>(ResultsPageResponse<ResultType> resultsPage)
        {
            if (null == resultsPage.next)
            {
                return null;
            }

            var reqUrlBuilder = MakeRequestUrlBuilderFromUnauthenticatedUrl(resultsPage.next);

            HttpWebRequest req = MakeHttpRequest(reqUrlBuilder);

            return DeserializeHttpResponse<ResultsPageResponse<ResultType>>(req);
        }

        /// <summary>
        /// Get the previous page of results from a given page of results, or <c>null</c>, if the given page is the first one.
        /// </summary>
        /// <typeparam name="ResultType">The type of result listed on the results page.</typeparam>
        /// <param name="resultsPage">The given page of results.</param>
        /// <returns>The previous page of results, or <c>null</c>, if this is the first page.</returns>
        public ResultsPageResponse<ResultType> GetPreviousPage<ResultType>(ResultsPageResponse<ResultType> resultsPage)
        {
            if (null == resultsPage.prev)
            {
                return null;
            }

            var reqUrlBuilder = MakeRequestUrlBuilderFromUnauthenticatedUrl(resultsPage.prev);

            HttpWebRequest req = MakeHttpRequest(reqUrlBuilder);

            return DeserializeHttpResponse<ResultsPageResponse<ResultType>>(req);
        }

        protected IEnumerable<ResultsPageResponse<ResultType>> FollowingPages<ResultType>(ResultsPageResponse<ResultType> startResultsPage)
        {
            for (var page = startResultsPage; null != page; page = GetNextPage(page))
            {
                yield return page;
            }
        }

        protected IEnumerable<ResultType> FollowingResults<ResultType>(ResultsPageResponse<ResultType> startResultsPage)
        {
            foreach (var page in FollowingPages(startResultsPage))
            {
                foreach (var result in page.results)
                {
                    yield return result;
                }
            }
        }
    }
}
