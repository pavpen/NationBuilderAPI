using System.Runtime.Serialization;

namespace NationBuilderAPI.V1
{
    [DataContract]
    class DonationTransportObject<DonationType>
    {
        [DataMember]
        public DonationType donation;
    }
}
