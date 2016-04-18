using System.Runtime.Serialization;

using NationBuilderAPI.V1.CommonResources;

namespace NationBuilderAPI.V1
{
    [DataContract]
    public class ContactTypeResponse : NationBuilderResponse
    {
        [DataMember]
        public ContactType contact_type;
    }
}
