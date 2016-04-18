using System.Runtime.Serialization;

using NationBuilderAPI.V1.CommonResources;

namespace NationBuilderAPI.V1
{
    [DataContract]
    public class AbbreviatedPersonResponse : NationBuilderResponse
    {
        [DataMember]
        public AbbreviatedPerson person;

        [DataMember]
        public Precinct precinct;
    }
}
