using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;

namespace NationBuilderAPI.V1.HelperClasses
{
    /// <summary>
    /// Base class for objects that can be memberwise cloned, and compared.
    /// </summary>
    [DataContract]
    public class MemberwiseCloneableComparable
    {
        static private MethodInfo Enumerable_SequenceEqual_2 = typeof(Enumerable).GetMethods().First(m => m.Name == "SequenceEqual" && m.GetParameters().Length == 2);

        /// <summary>
        /// Create a shallow clone of this object.
        /// </summary>
        /// <returns>The cloned object.</returns>
        public Object ShallowClone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// Copy all fields from another object.
        /// </summary>
        /// <param name="copySource">The object to copy from.</param>
        public void CopyFrom(Object copySource)
        {
            foreach (var info in this.GetType().GetFields())
            {
                info.SetValue(this, info.GetValue(copySource));
            }
        }

        /// <summary>
        /// Return whether all of this object's fields are memberwise equal to the corresponding fields on another object.
        /// </summary>
        /// <param name="obj">The object to compare with.</param>
        /// <returns>Whether this object is memberwise equal to the given object.</returns>
        public override bool Equals(Object obj)
        {
            foreach (var info in this.GetType().GetFields())
            {
                var thisObjectsValue = info.GetValue(this);
                var otherObjectsValue=info.GetValue(obj);

                if (null == thisObjectsValue)
                {
                    if (null == otherObjectsValue)
                    {
                        continue;
                    }
                    return false;
                }
                if (!thisObjectsValue.Equals(otherObjectsValue))
                {
                    if (info.FieldType.IsArray)
                    {
                        // Array's Equals() does not compare elements by value, so we have to do that:
                        var methodInfo = Enumerable_SequenceEqual_2.MakeGenericMethod(info.FieldType.GetElementType());

                        if ((bool)methodInfo.Invoke(this, new Object[] { thisObjectsValue, otherObjectsValue }))
                        {
                            continue;
                        }
                    }
                    return false;
                }
            }

            return true;
        }
    }
}
