using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;

using NationBuilderAPI.V1.HelperClasses;

namespace NationBuilderAPI.V1
{
    [DataContract]
    public class ContactStatus : MemberwiseCloneableComparable
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
        public new ContactStatus ShallowClone()
        {
            return (ContactStatus)this.MemberwiseClone();
        }

        public bool Equals(ContactStatus comparand)
        {
            return Equals((object)comparand);
        }
    }
}
