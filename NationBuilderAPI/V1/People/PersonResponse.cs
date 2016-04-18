using System.Runtime.Serialization;

using NationBuilderAPI.V1.CommonResources;

namespace NationBuilderAPI.V1
{
    [DataContract]
    public class PersonResponse<PersonType> : NationBuilderResponse
    {
        [DataMember]
        public PersonType person;

        [DataMember]
        public Precinct precinct;
    }
}
