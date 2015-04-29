using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NationBuilderAPI.V1
{
    [DataContract]
    public class Precinct
    {
        [DataMember]
        public int id;

        [DataMember]
        public string code;

        [DataMember]
        public string name;
        


        public Precinct() { }

        /// <summary>
        /// Create an <see cref="Precinct"/> object which is a shallow copy of another object.
        /// </summary>
        /// <param name="copySource">The object to copy.</param>
        public Precinct(Precinct copySource)
        {
            foreach (var info in typeof(Precinct).GetFields())
            {
                info.SetValue(this, info.GetValue(copySource));
            }
        }

        /// <summary>
        /// Create a shallow clone of this object.
        /// </summary>
        /// <returns>The cloned Address object.</returns>
        public Precinct ShallowClone()
        {
            return (Precinct)this.MemberwiseClone();
        }
    }
}
