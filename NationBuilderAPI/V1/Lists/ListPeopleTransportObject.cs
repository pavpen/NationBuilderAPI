using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NationBuilderAPI.V1
{
    [DataContract]
    class ListPeopleTransportObject
    {
        [DataMember]
        public List<long> people_ids;
    }
}
