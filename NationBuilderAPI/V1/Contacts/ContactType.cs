using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;

using NationBuilderAPI.V1.HelperClasses;

namespace NationBuilderAPI.V1
{
    [DataContract]
    public class ContactType : MemberwiseCloneableComparable
    {
        [DataMember]
        public long? id;

        [DataMember]
        public string name;



        /// <summary>
        /// Clone this object as a shallow copy.
        /// 
        /// Any member objects will be shared between this object and its shallow clone!
        /// </summary>
        /// <returns>The resulting copy.</returns>
        public new Contact ShallowClone()
        {
            return (Contact)this.MemberwiseClone();
        }

        public bool Equals(Contact comparand)
        {
            return Equals((object)comparand);
        }
    }
}
