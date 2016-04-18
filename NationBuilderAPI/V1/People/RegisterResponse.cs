using System.Runtime.Serialization;

using NationBuilderAPI.V1.CommonResources;

namespace NationBuilderAPI.V1
{
    [DataContract]
    public class RegisterResponse : NationBuilderResponse
    {
        [DataMember]
        public string status;
    }
}
