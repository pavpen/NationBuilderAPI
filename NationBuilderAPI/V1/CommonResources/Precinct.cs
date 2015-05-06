using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

using NationBuilderAPI.V1.HelperClasses;

namespace NationBuilderAPI.V1
{
    [DataContract]
    public class Precinct : MemberwiseCloneableComparable
    {
        [DataMember]
        public long id;

        [DataMember]
        public string code;

        [DataMember]
        public string name;



        /// <summary>
        /// Create a shallow clone of this object.
        /// </summary>
        /// <returns>The cloned Address object.</returns>
        public new Precinct ShallowClone()
        {
            return (Precinct)this.MemberwiseClone();
        }

        public bool Equals(Precinct comparand)
        {
            return Equals((object)comparand);
        }
    }
}
