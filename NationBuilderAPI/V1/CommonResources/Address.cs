using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NationBuilderAPI.V1
{
    [DataContract]
    public class Address
    {
        // first address line:
        [DataMember]
        public string address1;

        // second address line:
        [DataMember]
        public string address2;

        // third address line:
        [DataMember]
        public string address3;

        // city:
        [DataMember]
        public string city;

        // state:
        [DataMember]
        public string state;

        // zip code:
        [DataMember]
        public string zip;

        // country code:
        [DataMember]
        public string country_code;

        // latitude (using WGS-84):
        [DataMember]
        public double? lat;

        // longitude (using WGS-84):
        [DataMember]
        public double? lng;
    }
}
