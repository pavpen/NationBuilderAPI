using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using NationBuilderAPI.V1.HelperClasses;

namespace NationBuilderAPI.V1
{
    /// <summary>
    /// A class for serializing and deserializing exceptions returned by the Nation Builder service
    /// 
    /// Warning: This class has been derived from undocumented Nation Builder code.  E.g.,
    /// <https://github.com/controlshift/oauth2/commit/7e60e15878e503f80c8708f5c2cca5d17664fc61>.
    /// 
    /// It seems that some API endpoints return a JSON with 'code' and 'message' properties, and
    /// some with 'error' and 'error_description' properties.  Check member values to determine which
    /// case you have.
    /// </summary>
    [DataContract]
    public class RemoteException : MemberwiseCloneableComparable
    {
        [DataMember]
        public string code;

        [DataMember]
        public string message;

        [DataMember]
        public string error;

        [DataMember]
        public string error_description;


        /// <summary>
        /// Create a shallow clone of this object.
        /// </summary>
        /// <returns>The cloned object.</returns>
        public new RemoteException ShallowClone()
        {
            return (RemoteException)this.MemberwiseClone();
        }

        public bool Equals(RemoteException comparand)
        {
            return Equals((object)comparand);
        }
    }
}
