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
        public List<ResultType> results;
        


        public ResultsPageResponse() { }

        /// <summary>
        /// Create a <see cref="RespltsPageResponse"/> object which is a shallow copy of another object.
        /// </summary>
        /// <param name="copySource">The object to copy.</param>
        public ResultsPageResponse(ResultsPageResponse<ResultType> copySource)
        {
            foreach (var info in typeof(ResultsPageResponse<ResultType>).GetFields())
            {
                info.SetValue(this, info.GetValue(copySource));
            }
        }

        /// <summary>
        /// Create a shallow clone of this object.
        /// </summary>
        /// <returns>The cloned object.</returns>
        public ResultsPageResponse<ResultType> ShallowClone()
        {
            return (ResultsPageResponse<ResultType>)this.MemberwiseClone();
        }
    }
}
