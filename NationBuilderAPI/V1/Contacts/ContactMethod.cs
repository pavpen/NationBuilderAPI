using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;

using NationBuilderAPI.V1.HelperClasses;

namespace NationBuilderAPI.V1
{
    [DataContract]
    public class ContactMethod : MemberwiseCloneableComparable
    {
        [DataMember]
        public string name;

        [DataMember]
        public string api_name;



        /// <summary>
        /// Clone this object as a shallow copy.
        /// 
        /// Any member objects will be shared between this object and its shallow clone!
        /// </summary>
        /// <returns>The resulting copy.</returns>
        public new ContactMethod ShallowClone()
        {
            return (ContactMethod)this.MemberwiseClone();
        }

        public bool Equals(ContactMethod comparand)
        {
            return Equals((object)comparand);
        }
    }
}
