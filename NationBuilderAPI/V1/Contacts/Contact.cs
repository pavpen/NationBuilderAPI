using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;

using NationBuilderAPI.V1.HelperClasses;

namespace NationBuilderAPI.V1
{
    [DataContract]
    public class Contact : MemberwiseCloneableComparable
    {
        /// <summary>
        /// ID of the contact type. For possible values use the Contact Types API.
        /// 
        /// This field can become <code>null</code>, if the type of an existing contact is deleted.
        /// 
        /// Writable: Y
        /// 
        /// Required: Y
        /// 
        /// Example value: <code>5</code>
        /// </summary>
        [DataMember]
        public long? type_id;

        /// <summary>
        /// The method through which the contact was made. For possible values use the Contact Methods API.
        /// 
        /// Writable: Y
        /// 
        /// Required: Y
        /// 
        /// Example value: <code>"door_knock"</code>
        /// </summary>
        [DataMember]
        public string method;

        /// <summary>
        /// ID of the person who made the contact.
        /// 
        /// Writable: Y
        /// 
        /// Required: Y
        /// 
        /// Example value: <code>63</code>
        /// </summary>
        [DataMember]
        public long sender_id;

        /// <summary>
        /// ID of the person who receives the contact.
        /// 
        /// Writable: N
        /// 
        /// Reqired: N
        /// 
        /// Example value: <code>342</code>
        /// </summary>
        [DataMember]
        public long? recipient_id;

        /// <summary>
        /// Status of the contact. For possible values use the Contact Statuses API.
        /// 
        /// Writable: Y
        /// 
        /// Required: N
        /// 
        /// Example value: <code>"not_interested"</code>
        /// </summary>
        [DataMember]
        public string status;

        /// <summary>
        /// ID of the broadcaster on whose behalf the sender made the contact.
        /// 
        /// Writable: Y
        /// 
        /// Required: N
        /// 
        /// Example value: <code>8123</code>
        /// </summary>
        [DataMember]
        public long? broadcaster_id;

        /// <summary>
        /// Note about the content of the contact.
        /// 
        /// Writable: Y
        /// 
        /// Required: N
        /// 
        /// Example value: <code>"He did not support the cause"</code>
        /// </summary>
        [DataMember]
        public string note;

        /// <summary>
        /// Timestamp representing when the contact was created.
        /// 
        /// Writable: N
        /// 
        /// Required: N
        /// 
        /// Example value: 2014-02-14T14:36:29-05:00
        /// </summary>
        public DateTimeOffset created_at;

        [DataMember(Name = "created_at")]
        private string created_at_SerializationForm;


        [OnSerializing]
        void OnSerializing(StreamingContext context)
        {
            created_at_SerializationForm = created_at.ToString(NationBuilderHttpTransport.DefaultDateTimeFormatString, CultureInfo.InvariantCulture);
        }

        [OnDeserialized]
        void OnDeserialized(StreamingContext context)
        {
            // The Nation Builder web service can return an out-of-range created_at date-time:
            try
            {
                created_at = DateTimeOffset.ParseExact(created_at_SerializationForm, NationBuilderHttpTransport.DefaultDateTimeFormatString, CultureInfo.InvariantCulture);
            }
            catch (System.FormatException)
            {
            }
        }

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
