using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NationBuilderAPI.V1
{
    [DataContract]
    public class ResultsPageResponse<ResultType>
    {
        /// <summary>
        /// URI of the page of results for this query, or <c>null</c>, if this is the last page.
        /// </summary>
        [DataMember]
        public string next;

        /// <summary>
        /// URI of the previous page of results for this query, or <c>null</c>, if this is the first page.
        /// </summary>
        [DataMember]
        public string prev;

        [DataMember]
        public int page;

        [DataMember]
        public int total_pages;

        [DataMember]
        public int per_page;

        [DataMember]
        public int total;

        [DataMember]
        public List<ResultType> results;
    }
}
