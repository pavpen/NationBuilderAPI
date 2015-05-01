using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

using NationBuilderAPI.V1.HelperClasses;

namespace NationBuilderAPI.V1
{
    [DataContract]
    public class Election : MemberwiseCloneableComparable
    {
        /// <summary>
        /// Election cycle.
        /// 
        /// Writable: V
        /// 
        /// Required: N
        /// 
        /// Example: <c>2012</c>
        /// 
        /// Notes:
        ///     
        ///     It is strongly recommended to specify <see cref="cycle"/> and either <see cref="period"/> or <see cref="period_ngp_code"/>.
        ///     
        ///     Default: the current election which is displayed on the Control Panel in the Political/Settings section.
        /// </summary>
        [DataMember]
        public int cycle;

        /// <summary>
        /// Election period.
        /// 
        /// Writable: Y
        /// 
        /// Required: N
        /// 
        /// Example: <c>General</c>
        /// 
        /// Notes:
        /// 
        ///     It is strongly recommended to specify <see cref="cycle"/> and either <see cref="period"/> or <see cref="period_ngp_code"/>.
        ///     
        ///     Default: Special (S) if cycle is defined, otherwise the value of the current election period which is displayed on the Control Panel
        ///     in the Political/Settings section.
        /// </summary>
        [DataMember]
        public string period;

        /// <summary>
        /// Election period code.
        /// 
        /// Writable: Y
        /// 
        /// Required: N
        /// 
        /// Example: <c>G</c>
        /// 
        /// Notes:
        /// 
        ///     It is strongly recommended to specify <see cref="cycle"/> and either <see cref="period"/> or <see cref="period_ngp_code"/>.
        ///     
        ///     Default: Special (S) if cycle is defined, otherwise the value of the current election period which is displayed on the Control Panel
        ///     in the Political/Settings section.
        /// </summary>
        [DataMember]
        public char period_ngp_code;



        /// <summary>
        /// Create a shallow clone of this object.
        /// </summary>
        /// <returns>The cloned object.</returns>
        public new Election ShallowClone()
        {
            return (Election)this.MemberwiseClone();
        }

        public bool Equals(Election comparand)
        {
            return Equals((object)comparand);
        }
    }
}
