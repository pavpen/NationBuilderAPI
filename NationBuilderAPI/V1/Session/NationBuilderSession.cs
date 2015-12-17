using System;
using System.Collections.Generic;
using System.Text;

using NationBuilderAPI.V1.Http;

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

            var reqUrlBuilder = MakeRequestUrlBuilderFromUnauthenticatedPath(resultsPage.next);
            var req = MakeHttpRequest(reqUrlBuilder);

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

            var reqUrlBuilder = MakeRequestUrlBuilderFromUnauthenticatedPath(resultsPage.prev);
            var req = MakeHttpRequest(reqUrlBuilder);

            return DeserializeHttpResponse<ResultsPageResponse<ResultType>>(req);
        }

        /// <summary>
        /// Returns an iterator over all query results pages, starting from a given page.
        /// </summary>
        /// <typeparam name="ResultType">Data type of the result listed on the results pages.</typeparam>
        /// <param name="startResultsPage">The given results page to start from.</param>
        /// <returns>An enumeration of all results pages, starting whith the given one.</returns>
        public IEnumerable<ResultsPageResponse<ResultType>> AllPagesFrom<ResultType>(ResultsPageResponse<ResultType> startResultsPage)
        {
            for (var page = startResultsPage; null != page; page = GetNextPage(page))
            {
                yield return page;
            }
        }

        /// <summary>
        /// Returns an iterator over all query results, starting from a given results page.
        /// </summary>
        /// <typeparam name="ResultType">Data type of each query result.</typeparam>
        /// <param name="startResultsPage">The results page to start from.</param>
        /// <returns>An enumeration of all query results, starting from the given page.</returns>
        public IEnumerable<ResultType> AllResultsFrom<ResultType>(ResultsPageResponse<ResultType> startResultsPage)
        {
            foreach (var page in AllPagesFrom(startResultsPage))
            {
                foreach (var result in page.results)
                {
                    yield return result;
                }
            }
        }
    }
}
