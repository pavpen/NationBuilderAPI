using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NationBuilderAPI.V1
{
    [DataContract]
    public class AbbreviatedPersonResponse
    {
        [DataMember]
        public AbbreviatedPerson person;

        [DataMember]
        public Precinct precinct;
    }
}
