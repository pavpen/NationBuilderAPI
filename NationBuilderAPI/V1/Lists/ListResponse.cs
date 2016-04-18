using System.Runtime.Serialization;

using NationBuilderAPI.V1.CommonResources;

namespace NationBuilderAPI.V1
{
    [DataContract]
    public class ListResponse : NationBuilderResponse
    {
        [DataMember]
        public List list_resource;
    }
}
