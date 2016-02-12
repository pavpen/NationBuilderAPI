using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NationBuilderAPI.V1
{
    [DataContract]
    class PersonTransportObject<PersonType>
    {
        [DataMember]
        public PersonType person;
    }
}
