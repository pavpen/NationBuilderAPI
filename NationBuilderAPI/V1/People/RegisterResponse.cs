using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NationBuilderAPI.V1
{
    [DataContract]
    public class RegisterResponse
    {
        [DataMember]
        public string status;
    }
}
