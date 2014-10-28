using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NationBuilderAPI.V1
{
    [DataContract]
    public class ResultsPageResponse<ResultType>
    {
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
