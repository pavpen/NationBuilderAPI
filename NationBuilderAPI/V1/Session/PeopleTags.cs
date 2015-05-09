using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace NationBuilderAPI.V1
{
    public partial class NationBuilderSession
    {
        /// <summary>
        /// Show the tags that have been used before in a nation.
        /// </summary>
        /// <param name="limit">Max number of results to show in one page of results. (Default: 10, max: 100.)</param>
        /// <returns>The results page, and results information.</returns>
        public ResultsPageResponse<Tag> GetPeopleTags(int limit = 10)
        {
            StringBuilder reqUrlBuilder = RequestUrlBuilderAppendQuery(
                MakeRequestUrlBuilder("tags"),
                "&limit=", limit.ToString());
            HttpWebRequest req = MakeHttpRequest(reqUrlBuilder);
            var res = DeserializeHttpResponse<ResultsPageResponse<Tag>>(req);

            return res;
        }

        /// <summary>
        /// Get an enumeration of all the people tags in the nation as <see cref="Tag"/> objects.
        /// </summary>
        /// <param name="limit">The number of result to fetch in each HTTP request.  The maximum is 100.</param>
        /// <returns>An enumeration of all people tags in the nation.</returns>
        public IEnumerable<Tag> GetPeopleTagsResults(int limit = 100)
        {
            return AllResultsFrom(GetPeopleTags(limit));
        }

        /// <summary>
        /// Search for people who have been tagged with the given tag. Full representations will be returned.
        /// </summary>
        /// <param name="tagName">The tag to search by.</param>
        /// <param name="limit">Max number of results to show in one page of results. (Default: 10, max: 100.)</param>
        /// <returns>A results page of people tagged with the given tag.</returns>
        public ResultsPageResponse<Person> GetPeopleWithTag(string tagName, int limit = 10)
        {
            StringBuilder reqUrlBuilder = RequestUrlBuilderAppendQuery(
                // <c>WebUtility.UrlEncode(tagName)</c> does not work here for .NET 4.5, since the Nation Builder service
                // requires spaces to be encoded as '%20', and not '+'.
                MakeRequestUrlBuilder("tags/", Uri.EscapeDataString(tagName), "/people"),
                "&limit=", limit.ToString());
            HttpWebRequest req = MakeHttpRequest(reqUrlBuilder);
            var res = DeserializeHttpResponse<ResultsPageResponse<Person>>(req);

            return res;
        }

        /// <summary>
        /// Get an enumeration of all the people who have been tagged with a given tag.
        /// </summary>
        /// <param name="tagName">The tag to search by.</param>
        /// <param name="limit">The number of result to fetch in each HTTP request.  The maximum is 100.</param>
        /// <returns>An enumeration of all the people with a given tag.</returns>
        public IEnumerable<Person> GetPeopleWithTagResults(string tagName, int limit = 100)
        {
            return AllResultsFrom(GetPeopleWithTag(tagName, limit));
        }
    }
}
