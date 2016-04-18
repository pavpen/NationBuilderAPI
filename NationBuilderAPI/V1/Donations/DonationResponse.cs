using NationBuilderAPI.V1.CommonResources;
using System.Runtime.Serialization;

namespace NationBuilderAPI.V1
{
    [DataContract]
    class DonationResponse<DonationType> : NationBuilderResponse
    {
        [DataMember]
        public DonationType donation;
    }
}
