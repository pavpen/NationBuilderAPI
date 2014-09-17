using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NationBuilderAPI.V1
{
    [DataContract]
    public class PeopleIndexResponse
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
        public List<AbbreviatedPerson> results;
    }
}
