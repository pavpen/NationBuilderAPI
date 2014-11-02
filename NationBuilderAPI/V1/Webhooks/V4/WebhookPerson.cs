using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NationBuilderAPI.V1.Webhooks.V4
{
    /// <summary>
    /// The <c>Person</c> structure that appears in the payload posted by webhook call-back requests.
    /// </summary>
    [DataContract]
    public class WebhookPerson : Person
    {
        [DataMember]
        public string datatrust_id;

        [DataMember]
        public string profile_image_url_ssl;

        /*
        [IgnoreDataMember]
        new public DateTime? active_customer_expires_at;

        [DataMember(Name = "active_customer_expires_at")]
        private string active_customer_expires_at_SerializationForm;
                
        [DataMember(Name = "active_customer_started_at")]
        public DateTime? active_customer_started_at_SerializationForm;

        [DataMember(Name = "banned_at")]
        public DateTime? banned_at_SerializationForm;

        [DataMember(Name = "facebook_updated_at")]
        public DateTime? facebook_updated_at_SerializationForm;

        [DataMember(Name = "first_donated_at")]
        public DateTime? first_donated_at_SerializationForm;

        [DataMember(Name = "first_fundraised_at")]
        public DateTime? first_fundraised_at_SerializationForm;

        [DataMember(Name = "first_invoice_at")]
        public DateTime? first_invoice_at_SerializationForm;

        [DataMember(Name = "first_prospect_at")]
        public DateTime? first_prospect_at_SerializationForm;

        [DataMember(Name = "first_recruited_at")]
        public DateTime? first_recruited_at_SerializationForm;

        [DataMember(Name = "first_supporter_at")]
        public DateTime? first_supporter_at_SerializationForm;

        [DataMember(Name = "first_volunteer_at")]
        public DateTime? first_volunteer_at_SerializationForm;

        [DataMember(Name = "last_call_id")]
        public DateTime? last_call_id_SerializationForm;

        [DataMember(Name = "last_contacted_at")]
        public DateTime? last_contacted_at_SerializationForm;

        [DataMember(Name = "last_donated_at")]
        public DateTime? last_donated_at_SerializationForm;

        [DataMember(Name = "last_fundraised_at")]
        public DateTime? last_fundraised_at_SerializationForm;

        [DataMember(Name = "last_invoice_at")]
        public DateTime? last_invoice_at_SerializationForm;

        [DataMember(Name = "last_rule_violation_at")]
        public DateTime? last_rule_violation_at_SerializationForm;

        [DataMember(Name = "membership_expires_at")]
        public DateTime? membership_expires_at_SerializationForm;

        [DataMember(Name = "membership_started_at")]
        public DateTime? membership_started_at_SerializationForm;

        [DataMember(Name = "note_updated_at")]
        public DateTime? note_updated_at_SerializationForm;

        [DataMember(Name = "priority_level_changed_at")]
        public DateTime? priority_level_changed_at_SerializationForm;

        [DataMember(Name = "registered_at")]
        public DateTime? registered_at_SerializationForm;

        [DataMember(Name = "support_level_changed_at")]
        public DateTime? support_level_changed_at_SerializationForm;

        [DataMember(Name = "twitter_updated_at")]
        public DateTime? twitter_updated_at_SerializationForm;

        [DataMember(Name = "unsubscribed_at")]
        public DateTime? unsubscribed_at_SerializationForm;
         */
    }
}
