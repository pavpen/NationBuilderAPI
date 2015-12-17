using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NationBuilderAPI.V1
{
    [DataContract]
    class DonationTransportObject
    {
        [DataMember]
        public Donation donation;
    }
}
