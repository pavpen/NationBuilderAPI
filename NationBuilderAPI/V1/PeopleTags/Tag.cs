using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using NationBuilderAPI.V1.HelperClasses;

namespace NationBuilderAPI.V1
{
    [DataContract]
    public class Tag : MemberwiseCloneableComparable
    {
        [DataMember]
        public string name;

        /// <summary>
        /// Clone this object as a shallow copy.
        /// 
        /// Any member objects will be shared between this object and its shallow clone!
        /// </summary>
        /// <returns>The resulting copy.</returns>
        public new Tag ShallowClone()
        {
            return (Tag)this.MemberwiseClone();
        }

        public bool Equals(Tag comparand)
        {
            return Equals((object)comparand);
        }
    }
}
