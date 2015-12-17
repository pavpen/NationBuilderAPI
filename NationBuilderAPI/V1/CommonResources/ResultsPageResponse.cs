using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using NationBuilderAPI.V1.HelperClasses;

namespace NationBuilderAPI.V1
{
    [DataContract]
    public class ResultsPageResponse<ResultType>:MemberwiseCloneableComparable
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
        public List<ResultType> results;
        


        /// <summary>
        /// Create a shallow clone of this object.
        /// </summary>
        /// <returns>The cloned object.</returns>
        public new ResultsPageResponse<ResultType> ShallowClone()
        {
            return (ResultsPageResponse<ResultType>)this.MemberwiseClone();
        }

        public bool Equals(ResultsPageResponse<ResultType> comparand)
        {
            return Equals((object)comparand);
        }
    }
}
