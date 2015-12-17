using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

using NationBuilderAPI.V1.HelperClasses;

namespace NationBuilderAPI.V1
{
    [DataContract]
    public class AbbreviatedPersonResponse : MemberwiseCloneableComparable
    {
        [DataMember]
        public AbbreviatedPerson person;

        [DataMember]
        public Precinct precinct;
    }
}
