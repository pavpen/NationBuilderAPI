using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using NationBuilderAPI.V1.HelperClasses;

namespace NationBuilderAPI.V1.CommonResources
{
    /// <summary>
    /// Base class for objects returned by the Nation Builder API.
    /// </summary>
    [DataContract]
    public class NationBuilderResponse : MemberwiseCloneableComparable
    {
        public HttpResponseInformation Http;
    }
}
