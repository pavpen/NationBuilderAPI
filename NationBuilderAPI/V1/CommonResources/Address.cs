using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

using NationBuilderAPI.V1.HelperClasses;

namespace NationBuilderAPI.V1
{
    [DataContract]
    public class Address : MemberwiseCloneableComparable
    {
        /// <summary>
        /// First address line.
        /// </summary>
        [DataMember]
        public string address1;

        /// <summary>
        /// Second address line.
        /// </summary>
        [DataMember]
        public string address2;

        /// <summary>
        /// Third address line.
        /// </summary>
        [DataMember]
        public string address3;

        /// <summary>
        /// City.
        /// </summary>
        [DataMember]
        public string city;

        /// <summary>
        /// State.
        /// </summary>
        [DataMember]
        public string state;

        /// <summary>
        /// Zip code.
        /// </summary>
        [DataMember]
        public string zip;

        /// <summary>
        /// Country code.
        /// </summary>
        [DataMember]
        public string country_code;

        /// <summary>
        /// Latitude (using WGS-84).
        /// </summary>
        [DataMember]
        public double? lat;

        /// <summary>
        /// Longitude (using WGS-84).
        /// </summary>
        [DataMember]
        public double? lng;



        /// <summary>
        /// Create a shallow clone of this object.
        /// </summary>
        /// <returns>The cloned Address object.</returns>
        public Address ShallowClone()
        {
            return (Address)this.MemberwiseClone();
        }

        public bool Equals(Address comparand)
        {
            return Equals((object)comparand);
        }
    }
}
