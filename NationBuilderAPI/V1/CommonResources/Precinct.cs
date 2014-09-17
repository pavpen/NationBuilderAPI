using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NationBuilderAPI.V1
{
    [DataContract]
    public class Precinct
    {
        [DataMember]
        public int id;

        [DataMember]
        public string code;

        [DataMember]
        public string name;
    }
}
