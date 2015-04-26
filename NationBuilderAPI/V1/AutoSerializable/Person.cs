using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;

namespace NationBuilderAPI.V1.AutoSerializable
{
    [DataContract]
    public class Person : AbbreviatedPerson
    {
        public DateTime? active_customer_expires_at;

        [DataMember(Name = "active_customer_expires_at")]
        private string active_customer_expires_at_SerializationForm;


        public DateTime? active_customer_started_at;

        [DataMember(Name = "active_customer_started_at")]
        private string active_customer_started_at_SerializationForm;


        [DataMember]
        public string author_id;

        [DataMember]
        public string author;

        [DataMember]
        public string auto_import_id;

        [DataMember]
        public string availability;


        public DateTime? banned_at;

        [DataMember(Name = "banned_at")]
        private string banned_at_SerializationForm;


        [DataMember]
        public Address billing_address;

        [DataMember]
        public string bio;

        [DataMember]
        public string call_status_id;

        [DataMember]
        public string call_status_name;

        [DataMember]
        public int capital_amount_in_cents;

        [DataMember]
        public int children_count;

        [DataMember]
        public string church;

        [DataMember]
        public string city_sub_district;

        [DataMember]
        public int? closed_invoices_amount_in_cents;

        [DataMember]
        public int? closed_invoices_count;

        [DataMember]
        public string contact_status_id;

        [DataMember]
        public string contact_status_name;

        [DataMember]
        public int? could_vote_status;

        [DataMember]
        public string demo;

        [DataMember]
        public int donations_amount_in_cents;

        [DataMember]
        public int donations_amount_this_cycle_in_cents;

        [DataMember]
        public int donations_count_this_cycle;

        [DataMember]
        public int donations_count;

        [DataMember]
        public int donations_pledged_amount_in_cents;

        [DataMember]
        public int donations_raised_amount_in_cents;

        [DataMember]
        public int donations_raised_amount_this_cycle_in_cents;

        [DataMember]
        public int donations_raised_count_this_cycle;

        [DataMember]
        public int donations_raised_count;

        [DataMember]
        public int donations_to_raise_amount_in_cents;

        [DataMember]
        public bool email1_is_bad;

        [DataMember]
        public string email1;

        [DataMember]
        public bool email2_is_bad;

        [DataMember]
        public string email2;

        [DataMember]
        public bool email3_is_bad;

        [DataMember]
        public string email3;

        [DataMember]
        public bool email4_is_bad;

        [DataMember]
        public string email4;

        [DataMember]
        public string ethnicity;

        [DataMember]
        public string facebook_address;

        [DataMember]
        public string facebook_profile_url;


        public DateTime? facebook_updated_at;

        [DataMember(Name = "facebook_updated_at")]
        private string facebook_updated_at_SerializationForm;


        [DataMember]
        public string facebook_username;

        [DataMember]
        public string fax_number;

        [DataMember]
        public bool federal_donotcall;


        public DateTime? first_donated_at;

        [DataMember(Name = "first_donated_at")]
        private string first_donated_at_SerializationForm;


        public DateTime? first_fundraised_at;

        [DataMember(Name = "first_fundraised_at")]
        private string first_fundraised_at_SerializationForm;


        public DateTime? first_invoice_at;

        [DataMember(Name = "first_invoice_at")]
        private string first_invoice_at_SerializationForm;


        public DateTime? first_prospect_at;

        [DataMember(Name = "first_prospect_at")]
        private string first_prospect_at_SerializationForm;


        public DateTime? first_recruited_at;

        [DataMember(Name = "first_recruited_at")]
        private string first_recruited_at_SerializationForm;


        public DateTime? first_supporter_at;

        [DataMember(Name = "first_supporter_at")]
        private string first_supporter_at_SerializationForm;


        public DateTime? first_volunteer_at;

        [DataMember(Name = "first_volunteer_at")]
        private string first_volunteer_at_SerializationForm;


        [DataMember]
        public string full_name;

        [DataMember]
        public Address home_address;

        [DataMember]
        public string import_id;

        [DataMember]
        public string inferred_party;

        [DataMember]
        public string inferred_support_level;

        [DataMember]
        public int? invoice_payments_amount_in_cents;

        [DataMember]
        public int? invoice_payments_referred_amount_in_cents;

        [DataMember]
        public int? invoices_amount_in_cents;

        [DataMember]
        public int? invoices_count;

        [DataMember]
        public bool is_deceased;

        [DataMember]
        public bool is_donor;

        [DataMember]
        public bool is_fundraiser;

        [DataMember]
        public bool is_ignore_donation_limits;

        [DataMember]
        public bool is_leaderboardable;

        [DataMember]
        public bool is_mobile_bad;

        [DataMember]
        public bool is_possible_duplicate;

        [DataMember]
        public bool is_profile_private;

        [DataMember]
        public bool is_profile_searchable;

        [DataMember]
        public bool is_prospect;

        [DataMember]
        public bool is_supporter;

        [DataMember]
        public bool is_survey_question_private;

        [DataMember]
        public string language;


        public DateTime? last_call_id;

        [DataMember(Name = "last_call_id")]
        private string last_call_id_SerializationForm;


        public DateTime? last_contacted_at;

        [DataMember(Name = "last_contacted_at")]
        private string last_contacted_at_SerializationForm;


        [DataMember]
        public AbbreviatedPerson last_contacted_by;


        public DateTime? last_donated_at;

        [DataMember(Name = "last_donated_at")]
        private string last_donated_at_SerializationForm;


        public DateTime? last_fundraised_at;

        [DataMember(Name = "last_fundraised_at")]
        private string last_fundraised_at_SerializationForm;


        public DateTime? last_invoice_at;

        [DataMember(Name = "last_invoice_at")]
        private string last_invoice_at_SerializationForm;


        public DateTime? last_rule_violation_at;

        [DataMember(Name = "last_rule_violation_at")]
        private string last_rule_violation_at_SerializationForm;


        [DataMember]
        public string legal_name;

        [DataMember]
        public string locale;

        [DataMember]
        public Address mailing_address;

        [DataMember]
        public string marital_status;

        [DataMember]
        public string media_market_name;

        [DataMember]
        public Address meetup_address;


        public DateTime? membership_expires_at;

        [DataMember(Name = "membership_expires_at")]
        private string membership_expires_at_SerializationForm;


        [DataMember]
        public string membership_level_name;


        public DateTime? membership_started_at;

        [DataMember(Name = "membership_started_at")]
        private string membership_started_at_SerializationForm;


        [DataMember]
        public string middle_name;

        [DataMember]
        public string mobile_normalized;

        [DataMember]
        public string nbec_precinct_code;


        public DateTime? note_updated_at;

        [DataMember(Name = "note_updated_at")]
        private string note_updated_at_SerializationForm;


        [DataMember]
        public int? outstanding_invoices_amount_in_cents;

        [DataMember]
        public int? outstanding_invoices_count;

        [DataMember]
        public int? overdue_invoices_count;

        [DataMember]
        public string page_slug;

        [DataMember]
        public string parent_id;

        [DataMember]
        public AbbreviatedPerson parent;

        [DataMember]
        public bool? party_member;

        [DataMember]
        public string phone_normalized;

        [DataMember]
        public string phone_time;

        [DataMember]
        public string precinct_code;

        [DataMember]
        public string precinct_name;

        [DataMember]
        public string prefix;

        [DataMember]
        public string previous_party;

        [DataMember]
        public string primary_email_id;


        public DateTime? priority_level_changed_at;

        [DataMember(Name = "priority_level_changed_at")]
        private string priority_level_changed_at_SerializationForm;


        [DataMember]
        public string priority_level;

        [DataMember]
        public string profile_content_html;

        [DataMember]
        public string profile_content;

        [DataMember]
        public string profile_headline;

        [DataMember]
        public int received_capital_amount_in_cents;

        [DataMember]
        public AbbreviatedPerson recruiter;

        [DataMember]
        public int recruits_count;

        [DataMember]
        public Address registered_address;


        public DateTime? registered_at;

        [DataMember(Name = "registered_at")]
        private string registered_at_SerializationForm;


        [DataMember]
        public string religion;

        [DataMember]
        public int rule_violations_count;

        [DataMember]
        public int spent_capital_amount_in_cents;

        [DataMember]
        public Address submitted_address;

        [DataMember]
        public string[] subnations;

        [DataMember]
        public string suffix;


        public DateTime? support_level_changed_at;

        [DataMember(Name = "support_level_changed_at")]
        private string support_level_changed_at_SerializationForm;


        [DataMember]
        public double? support_probability_score;

        [DataMember]
        public double? turnout_probability_score;

        [DataMember]
        public Address twitter_address;

        [DataMember]
        public string twitter_description;

        [DataMember]
        public int? twitter_followers_count;

        [DataMember]
        public int? twitter_friends_count;

        [DataMember]
        public Address twitter_location;

        [DataMember]
        public string twitter_login;


        public DateTime? twitter_updated_at;

        [DataMember(Name = "twitter_updated_at")]
        private string twitter_updated_at_SerializationForm;


        [DataMember]
        public string twitter_website;


        public DateTime? unsubscribed_at;

        [DataMember(Name = "unsubscribed_at")]
        private string unsubscribed_at_SerializationForm;


        [DataMember]
        public Address user_submitted_address;

        [DataMember]
        public string username;

        [DataMember]
        public int? warnings_count;

        [DataMember]
        public string website;

        [DataMember]
        public Address work_address;

        [DataMember]
        public string work_phone_number;


        [OnSerializing]
        void OnSerializing(StreamingContext context)
        {
            active_customer_expires_at_SerializationForm = Base.DateTimeGetSerializationForm(active_customer_expires_at);
            active_customer_started_at_SerializationForm = Base.DateTimeGetSerializationForm(active_customer_started_at);
            banned_at_SerializationForm = Base.DateTimeGetSerializationForm(banned_at);
            facebook_updated_at_SerializationForm = Base.DateTimeGetSerializationForm(facebook_updated_at);
            first_donated_at_SerializationForm = Base.DateTimeGetSerializationForm(first_donated_at);
            first_fundraised_at_SerializationForm = Base.DateTimeGetSerializationForm(first_fundraised_at);
            first_invoice_at_SerializationForm = Base.DateTimeGetSerializationForm(first_invoice_at);
            first_prospect_at_SerializationForm = Base.DateTimeGetSerializationForm(first_prospect_at);
            first_recruited_at_SerializationForm = Base.DateTimeGetSerializationForm(first_recruited_at);
            first_supporter_at_SerializationForm = Base.DateTimeGetSerializationForm(first_supporter_at);
            first_volunteer_at_SerializationForm = Base.DateTimeGetSerializationForm(first_volunteer_at);
            last_call_id_SerializationForm = Base.DateTimeGetSerializationForm(last_call_id);
            last_contacted_at_SerializationForm = Base.DateTimeGetSerializationForm(last_contacted_at);
            last_donated_at_SerializationForm = Base.DateTimeGetSerializationForm(last_donated_at);
            last_fundraised_at_SerializationForm = Base.DateTimeGetSerializationForm(last_fundraised_at);
            last_invoice_at_SerializationForm = Base.DateTimeGetSerializationForm(last_invoice_at);
            last_rule_violation_at_SerializationForm = Base.DateTimeGetSerializationForm(last_rule_violation_at);
            membership_expires_at_SerializationForm = Base.DateTimeGetSerializationForm(membership_expires_at);
            membership_started_at_SerializationForm = Base.DateTimeGetSerializationForm(membership_started_at);
            note_updated_at_SerializationForm = Base.DateTimeGetSerializationForm(note_updated_at);
            priority_level_changed_at_SerializationForm = Base.DateTimeGetSerializationForm(priority_level_changed_at);
            registered_at_SerializationForm = Base.DateTimeGetSerializationForm(registered_at);
            support_level_changed_at_SerializationForm = Base.DateTimeGetSerializationForm(support_level_changed_at);
            twitter_updated_at_SerializationForm = Base.DateTimeGetSerializationForm(twitter_updated_at);
            unsubscribed_at_SerializationForm = Base.DateTimeGetSerializationForm(unsubscribed_at);
        }

        [OnDeserialized]
        void OnDeserialized(StreamingContext context)
        {
            active_customer_expires_at = Base.NullableDateTimeDeserialize(active_customer_expires_at_SerializationForm);
            active_customer_started_at = Base.NullableDateTimeDeserialize(active_customer_started_at_SerializationForm);
            banned_at = Base.NullableDateTimeDeserialize(banned_at_SerializationForm);
            facebook_updated_at = Base.NullableDateTimeDeserialize(facebook_updated_at_SerializationForm);
            first_donated_at = Base.NullableDateTimeDeserialize(first_donated_at_SerializationForm);
            first_fundraised_at = Base.NullableDateTimeDeserialize(first_fundraised_at_SerializationForm);
            first_invoice_at = Base.NullableDateTimeDeserialize(first_invoice_at_SerializationForm);
            first_prospect_at = Base.NullableDateTimeDeserialize(first_prospect_at_SerializationForm);
            first_recruited_at = Base.NullableDateTimeDeserialize(first_recruited_at_SerializationForm);
            first_supporter_at = Base.NullableDateTimeDeserialize(first_supporter_at_SerializationForm);
            first_volunteer_at = Base.NullableDateTimeDeserialize(first_volunteer_at_SerializationForm);
            last_call_id = Base.NullableDateTimeDeserialize(last_call_id_SerializationForm);
            last_contacted_at = Base.NullableDateTimeDeserialize(last_contacted_at_SerializationForm);
            last_donated_at = Base.NullableDateTimeDeserialize(last_donated_at_SerializationForm);
            last_fundraised_at = Base.NullableDateTimeDeserialize(last_fundraised_at_SerializationForm);
            last_invoice_at = Base.NullableDateTimeDeserialize(last_invoice_at_SerializationForm);
            last_rule_violation_at = Base.NullableDateTimeDeserialize(last_rule_violation_at_SerializationForm);
            membership_expires_at = Base.NullableDateTimeDeserialize(membership_expires_at_SerializationForm);
            membership_started_at = Base.NullableDateTimeDeserialize(membership_started_at_SerializationForm);
            note_updated_at = Base.NullableDateTimeDeserialize(note_updated_at_SerializationForm);
            priority_level_changed_at = Base.NullableDateTimeDeserialize(priority_level_changed_at_SerializationForm);
            registered_at = Base.NullableDateTimeDeserialize(registered_at_SerializationForm);
            support_level_changed_at = Base.NullableDateTimeDeserialize(support_level_changed_at_SerializationForm);
            twitter_updated_at = Base.NullableDateTimeDeserialize(twitter_updated_at_SerializationForm);
            unsubscribed_at = Base.NullableDateTimeDeserialize(unsubscribed_at_SerializationForm);
        }

        /// <summary>
        /// Convert this object to the cannonical <see cref="NationBuilderAPI.V1.Person"/>.
        /// </summary>
        /// <returns>The converted NationBuilderAPI.V1.Person object.</returns>
        public NationBuilderAPI.V1.Person ToPerson()
        {
            var res = new NationBuilderAPI.V1.Person();

            res.CopyFrom(this);

            return res;
        }
    }
}
