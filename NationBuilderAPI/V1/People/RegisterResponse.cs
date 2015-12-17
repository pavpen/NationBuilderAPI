using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

using NationBuilderAPI.V1.HelperClasses;

namespace NationBuilderAPI.V1
{
    [DataContract]
    public class RegisterResponse : MemberwiseCloneableComparable
    {
        [DataMember]
        public string status;
    }
}
