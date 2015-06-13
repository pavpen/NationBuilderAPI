using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using NationBuilderAPI.V1.HelperClasses;

namespace NationBuilderAPI.V1
{
    [DataContract]
    public class List : MemberwiseCloneableComparable
    {
        [DataMember]
        public long? id;

        [DataMember]
        public string name;

        [DataMember]
        public string slug;

        [DataMember]
        public long? author_id;

        [DataMember]
        public string sort_order;

        [DataMember]
        public long? count;


        /// <summary>
        /// Clone this object as a shallow copy.
        /// 
        /// Any member objects will be shared between this object and its shallow clone!
        /// </summary>
        /// <returns>The resulting copy.</returns>
        public new List ShallowClone()
        {
            return (List)this.MemberwiseClone();
        }

        public bool Equals(List comparand)
        {
            return Equals((object)comparand);
        }
    }
}
