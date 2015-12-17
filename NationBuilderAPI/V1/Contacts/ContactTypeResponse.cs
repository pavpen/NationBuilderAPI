using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

using NationBuilderAPI.V1.HelperClasses;

namespace NationBuilderAPI.V1
{
    [DataContract]
    public class ContactTypeResponse : MemberwiseCloneableComparable
    {
        [DataMember]
        public ContactType contact_type;
    }
}
