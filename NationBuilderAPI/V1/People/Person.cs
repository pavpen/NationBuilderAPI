using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;

using NationBuilderAPI.V1.HelperClasses;

namespace NationBuilderAPI.V1
{
    [DataContract]
    public class Person : AbbreviatedPerson
    {
        /// <summary>
        /// The date at which to consider a customer no longer active.
        /// </summary>
        public DateTimeOffset? active_customer_expires_at;

        [DataMember(Name = "active_customer_expires_at")]
        private string active_customer_expires_at_SerializationForm;


        /// <summary>
        /// The date from which a customer is considered active.
        /// </summary>
        public DateTimeOffset? active_customer_started_at;

        [DataMember(Name = "active_customer_started_at")]
        private string active_customer_started_at_SerializationForm;


        /// <summary>
        /// The resource ID of the person who created this person in the nation.
        /// </summary>
        [DataMember]
        public string author_id;

        /// <summary>
        /// An abbreviated person resource representing the person who created this person’s record.
        /// </summary>
        [DataMember]
        public string author;

        /// <summary>
        /// The ID given to a signup when a person is auto imported.
        /// </summary>
        [DataMember]
        public string auto_import_id;

        /// <summary>
        /// Date and time this person is available (such as for volunteer shifts).
        /// </summary>
        [DataMember]
        public string availability;


        /// <summary>
        /// The time and date this person was banned.
        /// </summary>
        public DateTimeOffset? banned_at;

        [DataMember(Name = "banned_at")]
        private string banned_at_SerializationForm;


        /// <summary>
        /// An address resource representing this person’s billing address.
        /// </summary>
        [DataMember]
        public Address billing_address;

        /// <summary>
        /// The bio information that this person provided on their public profile via the “short bio” field.
        /// </summary>
        [DataMember]
        public string bio;

        // this person's birth date:
        //public DateTime birthdate;

        /// <summary>
        /// The ID of the call status associated with this person.
        /// </summary>
        [DataMember]
        public string call_status_id;

        /// <summary>
        /// The name of the call status associated with this person.
        /// </summary>
        [DataMember]
        public string call_status_name;

        /// <summary>
        /// The balance of this person’s political or social capital, in cents.
        /// </summary>
        [DataMember]
        public int capital_amount_in_cents;

        /// <summary>
        /// The number of people assigned to this person.
        /// </summary>
        [DataMember]
        public int children_count;

        /// <summary>
        /// The church that this person goes to.
        /// </summary>
        [DataMember]
        public string church;

        // district field:
        //public string city_district;

        /// <summary>
        /// District field.
        /// </summary>
        [DataMember]
        public string city_sub_district;

        // this person’s ID from CiviCRM:
        //public string civicrm_id;

        /// <summary>
        /// The aggregate amount of all this person’s closed invoices in cents.
        /// </summary>
        [DataMember]
        public int? closed_invoices_amount_in_cents;

        /// <summary>
        /// The number of closed invoices associated with this person.
        /// </summary>
        [DataMember]
        public int? closed_invoices_count;

        /// <summary>
        /// ID of a contact status associated with this person.
        /// 
        /// Possible values: 1: answered, 2: badinfo, 9: inaccessible, 3: leftmessage, 4: meaningfulinteraction, 6: notinterested,
        ///                  7: noanswer, 8: refused, 5: sendinformation, 0: other:
        /// </summary>
        [DataMember]
        public string contact_status_id;

        /// <summary>
        /// Name of a contact status associated with this person.
        /// 
        /// Possible values: answered, badinfo, inaccessible, leftmessage, meaningfulinteraction, notinterested,
        ///                  noanswer, refused, sendinformation, other:
        /// </summary>
        [DataMember]
        public string contact_status_name;

        /// <summary>
        /// Nullable int indicating if this person could vote in an election or not, derived from their election-related IDs.
        /// 
        /// Nation Builder's API page <http://nationbuilder.com/people_api> says:
        /// "Boolean indicating if this person could vote in an election or not, derived from their election-related IDs."
        /// However, in their examples, and in actual server HTTP requests this value is a nullable int.  Values that have
        /// been seen are <c>null</c>, <c>1</c>, <c>-1</c>.
        /// </summary>
        [DataMember]
        public int? could_vote_status;

        // district field:
        //public string county_district;

        // this person’s ID from a county voter file:
        //public string county_file_id;

        // timestamp representing when this person was created in the nation:
        //public DateTimeOffset created_at;

        /// <summary>
        /// Asian, Black, Hispanic, White, Other, Unknown.
        /// </summary>
        [DataMember]
        public string demo;

        // This is a boolean flag that lets us know if this person is on a do not call list.
        //public bool do_not_call;

        // This is a boolean flag that lets us know if this person is on a do not contact list.
        //public bool do_not_contact;

        /// <summary>
        /// Aggregate amount of all this person’s donations in cents.
        /// </summary>
        [DataMember]
        public int donations_amount_in_cents;

        /// <summary>
        /// The aggregate value of the donations this person made this cycle in cents.
        /// </summary>
        [DataMember]
        public int donations_amount_this_cycle_in_cents;

        /// <summary>
        /// The number of donations this person made this cycle.
        /// </summary>
        [DataMember]
        public int donations_count_this_cycle;

        /// <summary>
        /// The total number of donations made by this person.
        /// </summary>
        [DataMember]
        public int donations_count;

        /// <summary>
        /// The aggregate amount of the donations pledged by this person in cents.
        /// </summary>
        [DataMember]
        public int donations_pledged_amount_in_cents;

        /// <summary>
        /// The aggregate amount of the donations raised by this person in cents, including their own donations.
        /// </summary>
        [DataMember]
        public int donations_raised_amount_in_cents;

        /// <summary>
        /// The aggregate value of all donations raised this cycle by this person, including their own.
        /// </summary>
        [DataMember]
        public int donations_raised_amount_this_cycle_in_cents;

        /// <summary>
        /// The number of donations raised this cycle by this person, including their own.
        /// </summary>
        [DataMember]
        public int donations_raised_count_this_cycle;

        /// <summary>
        /// The total number of donations raised.
        /// </summary>
        [DataMember]
        public int donations_raised_count;

        /// <summary>
        /// The goal amount of donations for this person to raise in cents.
        /// </summary>
        [DataMember]
        public int donations_to_raise_amount_in_cents;

        // this person’s ID from Catalist:
        //public string dw_id;

        /// <summary>
        /// Boolean indicating if email1 for this person is bad.
        /// </summary>
        [DataMember]
        public bool email1_is_bad;

        /// <summary>
        /// An email address for this person.
        /// </summary>
        [DataMember]
        public string email1;

        /// <summary>
        /// Boolean indicating if email2 for this person is bad.
        /// </summary>
        [DataMember]
        public bool email2_is_bad;

        /// <summary>
        /// An email address for this person.
        /// </summary>
        [DataMember]
        public string email2;

        /// <summary>
        /// Boolean indicating if email3 for this person is bad.
        /// </summary>
        [DataMember]
        public bool email3_is_bad;

        /// <summary>
        /// An email address for this person.
        /// </summary>
        [DataMember]
        public string email3;

        /// <summary>
        /// Boolean indicating if email4 for this person is bad.
        /// </summary>
        [DataMember]
        public bool email4_is_bad;

        /// <summary>
        /// An email address for this person.
        /// </summary>
        [DataMember]
        public string email4;

        // boolean representing whether this person has opted-in to email correspondence:
        //public bool email_opt_in;

        // the person's email address if reading or writing a single address:
        //public string email;

        // the name of the company for which this person works:
        //public string employer;

        /// <summary>
        /// The ethnicity of this person as free text.
        /// </summary>
        [DataMember]
        public string ethnicity;

        // a string representing an external identifier for this person:
        //public string external_id;

        /// <summary>
        /// This person’s address based on their Facebook profile.
        /// </summary>
        [DataMember]
        public string facebook_address;

        /// <summary>
        /// The URL of this person’s Facebook profile.
        /// </summary>
        [DataMember]
        public string facebook_profile_url;


        /// <summary>
        /// The date and time this person's Facebook info was last updated.
        /// </summary>
        public DateTimeOffset? facebook_updated_at;

        [DataMember(Name = "facebook_updated_at")]
        private string facebook_updated_at_SerializationForm;


        /// <summary>
        /// This person's Facebook username.
        /// </summary>
        [DataMember]
        public string facebook_username;

        /// <summary>
        /// The fax number associated with this person.
        /// </summary>
        [DataMember]
        public string fax_number;

        // district field:
        //public string federal_district;

        /// <summary>
        /// Boolean value indicating if this user is on the U.S. Federal Do Not Call list.
        /// </summary>
        [DataMember]
        public bool federal_donotcall;

        // district field:
        //public string fire_district;

        /// <summary>
        /// Date and time of this person's first donation.
        /// </summary>
        public DateTimeOffset? first_donated_at;

        [DataMember(Name = "first_donated_at")]
        private string first_donated_at_SerializationForm;


        // date and time that this person first raised donation:
        public DateTimeOffset? first_fundraised_at;

        [DataMember(Name = "first_fundraised_at")]
        private string first_fundraised_at_SerializationForm;


        /// <summary>
        /// Date and time of this person's first invoice.
        /// </summary>
        public DateTimeOffset? first_invoice_at;

        [DataMember(Name = "first_invoice_at")]
        private string first_invoice_at_SerializationForm;

        // the person's first name:
        //public string first_name;

        /// <summary>
        /// Date and time that this user first became a prospect.
        /// </summary>
        public DateTimeOffset? first_prospect_at;

        [DataMember(Name = "first_prospect_at")]
        private string first_prospect_at_SerializationForm;


        /// <summary>
        /// Date and time that this user was first recruited.
        /// </summary>
        public DateTimeOffset? first_recruited_at;

        [DataMember(Name = "first_recruited_at")]
        private string first_recruited_at_SerializationForm;


        /// <summary>
        /// Date and time that this user became a supporter for the first time.
        /// </summary>
        public DateTimeOffset? first_supporter_at;

        [DataMember(Name = "first_supporter_at")]
        private string first_supporter_at_SerializationForm;


        /// <summary>
        /// Date and time that this person first volunteered.
        /// </summary>
        public DateTimeOffset? first_volunteer_at;

        [DataMember(Name = "first_volunteer_at")]
        private string first_volunteer_at_SerializationForm;


        /// <summary>
        /// This person’s full name.
        /// </summary>
        [DataMember]
        public string full_name;

        // a boolean representing whether this person has Facebook information:
        //public bool has_facebook;

        /// <summary>
        /// An address resource representing the home address.
        /// </summary>
        [DataMember]
        public Address home_address;

        // the NationBuilder ID of the person, specific to the authorized nation:
        //public string id;

        /// <summary>
        /// The ID associated with this person when they were imported.
        /// </summary>
        [DataMember]
        public string import_id;

        /// <summary>
        /// The party the person is believed to be associated with.
        /// </summary>
        [DataMember]
        public string inferred_party;

        /// <summary>
        /// A possible support level.
        /// </summary>
        [DataMember]
        public string inferred_support_level;

        /// <summary>
        /// Total invoice payment amount (cents).
        /// </summary>
        [DataMember]
        public int? invoice_payments_amount_in_cents;

        /// <summary>
        /// The aggregate amount of invoice payments made by recruits of this person (cents).
        /// </summary>
        [DataMember]
        public int? invoice_payments_referred_amount_in_cents;

        /// <summary>
        /// The aggregate amount of all of this person’s invoices (cents).
        /// </summary>
        [DataMember]
        public int? invoices_amount_in_cents;

        /// <summary>
        /// The number of invoices this person has.
        /// </summary>
        [DataMember]
        public int? invoices_count;

        /// <summary>
        /// A boolean field that indicates if the person is alive or not.
        /// </summary>
        [DataMember]
        public bool is_deceased;

        /// <summary>
        /// A boolean field that indicates if the person has donated.
        /// </summary>
        [DataMember]
        public bool is_donor;

        /// <summary>
        /// A boolean value that indicates if this person has previously fundraised.
        /// </summary>
        [DataMember]
        public bool is_fundraiser;

        /// <summary>
        /// A boolean that indicates whether this person is not subject to donation limits associated with the nation.
        /// </summary>
        [DataMember]
        public bool is_ignore_donation_limits;

        /// <summary>
        /// A boolean that tells if this person is allowed to show up on the leaderboard.
        /// </summary>
        [DataMember]
        public bool is_leaderboardable;

        /// <summary>
        /// A boolean reflecting whether this person’s cell number is invalid.
        /// </summary>
        [DataMember]
        public bool is_mobile_bad;

        /// <summary>
        /// A boolean field that indicates if the NationBuilder matching algorithm thinks this person is a match to someone else in the nation.
        /// </summary>
        [DataMember]
        public bool is_possible_duplicate;

        /// <summary>
        /// A boolean that tells if this person’s profile is private.
        /// </summary>
        [DataMember]
        public bool is_profile_private;

        /// <summary>
        /// A boolean that tells if this person’s profile is allowed to show up in search results.
        /// </summary>
        [DataMember]
        public bool is_profile_searchable;

        /// <summary>
        /// A boolean field that indicates if this person is a prospect.
        /// </summary>
        [DataMember]
        public bool is_prospect;

        /// <summary>
        /// A boolean field that indicates if this person is a supporter.
        /// </summary>
        [DataMember]
        public bool is_supporter;

        /// <summary>
        /// A boolean field that indicates if this person’s survey responses are private.
        /// </summary>
        [DataMember]
        public bool is_survey_question_private;

        // whether the person is a Twitter follower of one of the nation’s broadcasters:
        //public bool is_twitter_follower;

        // a boolean field that indicates whether the person has volunteered:
        //public bool is_volunteer;

        // a district field:
        //public string judicial_district;

        // a district field:
        //public string labour_region;

        /// <summary>
        /// This person’s primary language.
        /// </summary>
        [DataMember]
        public string language;

        /// <summary>
        /// The ID of the last contact to this person.
        /// </summary>
        [DataMember]
        public long? last_call_id;


        /// <summary>
        /// The time and date of the last time this person was contacted.
        /// </summary>
        public DateTimeOffset? last_contacted_at;

        [DataMember(Name = "last_contacted_at")]
        private string last_contacted_at_SerializationForm;


        /// <summary>
        /// An abbreviated person resource representing the last user who contacted this person.
        /// </summary>
        [DataMember]
        public AbbreviatedPerson last_contacted_by;


        /// <summary>
        /// The time and date of this person’s last donation.
        /// </summary>
        public DateTimeOffset? last_donated_at;

        [DataMember(Name = "last_donated_at")]
        private string last_donated_at_SerializationForm;


        /// <summary>
        /// The time and date of the last time this person fundraised.
        /// </summary>
        public DateTimeOffset? last_fundraised_at;

        [DataMember(Name = "last_fundraised_at")]
        private string last_fundraised_at_SerializationForm;


        /// <summary>
        /// The time and date of this person’s last invoice.
        /// </summary>
        public DateTimeOffset? last_invoice_at;

        [DataMember(Name = "last_invoice_at")]
        private string last_invoice_at_SerializationForm;

        // this person's last name:
        //public string last_name;

        /// <summary>
        /// The time and date of this person’s last rule violation.
        /// </summary>
        public DateTimeOffset? last_rule_violation_at;

        [DataMember(Name = "last_rule_violation_at")]
        private string last_rule_violation_at_SerializationForm;


        /// <summary>
        /// The full (legal) name of this person.
        /// </summary>
        [DataMember]
        public string legal_name;

        // this person’s ID from LinkedIn:
        //public string linkedin_id;

        /// <summary>
        /// The ISO locale that the user has their administrative account set to (US, ES, FR etc.).
        /// </summary>
        [DataMember]
        public string locale;

        /// <summary>
        /// An address resource representing the mailing address.
        /// </summary>
        [DataMember]
        public Address mailing_address;

        /// <summary>
        /// The person’s marital status.
        /// </summary>
        [DataMember]
        public string marital_status;

        /// <summary>
        /// The name of this person’s media market.
        /// </summary>
        [DataMember]
        public string media_market_name;

        /// <summary>
        /// An address resource based on this person’s profile in Meetup.
        /// </summary>
        [DataMember]
        public Address meetup_address;


        /// <summary>
        /// The time and date that this user’s membership expires.
        /// </summary>
        public DateTimeOffset? membership_expires_at;

        [DataMember(Name = "membership_expires_at")]
        private string membership_expires_at_SerializationForm;


        /// <summary>
        /// The name of the level of this person’s membership.
        /// </summary>
        [DataMember]
        public string membership_level_name;


        /// <summary>
        /// The time and date that this user started a membership.
        /// </summary>
        public DateTimeOffset? membership_started_at;

        [DataMember(Name = "membership_started_at")]
        private string membership_started_at_SerializationForm;


        /// <summary>
        /// This person’s middle name.
        /// </summary>
        [DataMember]
        public string middle_name;

        /// <summary>
        /// This person's cell phone number in normalized form.
        /// </summary>
        [DataMember]
        public string mobile_normalized;

        // a boolean representing whether the person has opted-in to mobile correspondence:
        //public bool mobile_opt_in;

        // this person's cell phone number:
        //public string mobile;

        // this person’s ID from the NationBuilder Election Center:
        //public string nbec_guid;

        /// <summary>
        /// The unique identifier assigned to this person in the NationBuilder Election Center.
        /// </summary>
        [DataMember]
        public string nbec_precinct_code;

        // this person’s ID from NGP:
        //public string ngp_id;

        /// <summary>
        /// The date and time the note attached to this person was updated.
        /// </summary>
        public DateTimeOffset? note_updated_at;

        [DataMember(Name = "note_updated_at")]
        private string note_updated_at_SerializationForm;

        // a note to attach to the person's profile:
        //public string note;

        // the type of work this person does:
        //public string occupation;

        /// <summary>
        /// The aggregate value of all this person’s outstanding invoices in cents.
        /// </summary>
        [DataMember]
        public int? outstanding_invoices_amount_in_cents;

        /// <summary>
        /// The number of outstanding invoices this person has.
        /// </summary>
        [DataMember]
        public int? outstanding_invoices_count;

        /// <summary>
        /// The number of overdue invoices this person has.
        /// </summary>
        [DataMember]
        public int? overdue_invoices_count;

        /// <summary>
        /// The page this person first signed up from.
        /// </summary>
        [DataMember]
        public string page_slug;

        /// <summary>
        /// The NationBuilder ID of this person’s point person.
        /// </summary>
        [DataMember]
        public string parent_id;

        /// <summary>
        /// An abbreviated person resource representing this person’s point person.
        /// </summary>
        [DataMember]
        public AbbreviatedPerson parent;

        /// <summary>
        /// A boolean that tells if this person is a member of a political party.
        /// </summary>
        [DataMember]
        public bool? party_member;

        // a one-letter code representing provincial parties for nations:
        //public string party;

        // a person’s historical ID from PoliticalForce:
        //public string pf_strat_id;

        /// <summary>
        /// This person's home phone number in normalized form.
        /// </summary>
        [DataMember]
        public string phone_normalized;

        /// <summary>
        /// The time that has been selected as the best time to call this person.
        /// </summary>
        [DataMember]
        public string phone_time;

        // this person's home phone number:
        //public string phone;

        /// <summary>
        /// The code of the precinct that this person lives in.
        /// </summary>
        [DataMember]
        public string precinct_code;

        // the ID of the precinct associated with this person:
        //public string precinct_id;

        /// <summary>
        /// The name of the precinct that this person votes in.
        /// </summary>
        [DataMember]
        public string precinct_name;

        /// <summary>
        /// The name prefix of this person, i.e. Mr., Mrs.
        /// </summary>
        [DataMember]
        public string prefix;

        /// <summary>
        /// The party this person had selected before their current party selection.
        /// </summary>
        [DataMember]
        public string previous_party;

        // an address resource representing the primary address:
        //public Address primary_address;

        /// <summary>
        /// The resource ID of the primary email address associated with this person.
        /// </summary>
        [DataMember]
        public string primary_email_id;


        /// <summary>
        /// The date and time that this person’s priority level changed.
        /// </summary>
        public DateTimeOffset? priority_level_changed_at;

        [DataMember(Name = "priority_level_changed_at")]
        private string priority_level_changed_at_SerializationForm;


        /// <summary>
        /// The priority level associated with this person.
        /// </summary>
        [DataMember]
        public string priority_level;

        /// <summary>
        /// The profile content for this person’s public profile in HTML.
        /// </summary>
        [DataMember]
        public string profile_content_html;

        /// <summary>
        /// The content for this person’s public profile.
        /// </summary>
        [DataMember]
        public string profile_content;

        /// <summary>
        /// The headline for this person’s public profile.
        /// </summary>
        [DataMember]
        public string profile_headline;

        /// <summary>
        /// The aggregate amount of political capital ever received by this person.
        /// </summary>
        [DataMember]
        public int received_capital_amount_in_cents;

        // the ID of the person who recruited this person:
        //public string recruiter_id;

        /// <summary>
        /// An abbreviated person resource representing the person who recruited this person.
        /// </summary>
        [DataMember]
        public AbbreviatedPerson recruiter;

        /// <summary>
        /// The number of people that were recruited by this person.
        /// </summary>
        [DataMember]
        public int recruits_count;

        /// <summary>
        /// An address resource representing the registered address.
        /// </summary>
        [DataMember]
        public Address registered_address;


        /// <summary>
        /// The date this person registered to become a voter.
        /// </summary>
        public DateTimeOffset? registered_at;

        [DataMember(Name = "registered_at")]
        private string registered_at_SerializationForm;


        /// <summary>
        /// This person’s religion.
        /// </summary>
        [DataMember]
        public string religion;

        // this person’s ID from the RNC:
        //public string rnc_id;

        // this person’s registration ID from the RNC:
        //public string rnc_regid;

        /// <summary>
        /// The number of times this person has violated one of the nation’s rules.
        /// </summary>
        [DataMember]
        public int rule_violations_count;

        // this person’s ID from Salesforce:
        //public string salesforce_id;

        // a district field:
        //public string school_district;

        // a district field:
        //public string school_sub_district;

        // this person's gender (M, F or O):
        //public string sex;

        /// <summary>
        /// The aggregate amount of capital ever spent by this person (in cents).
        /// </summary>
        [DataMember]
        public int spent_capital_amount_in_cents;

        // this person’s ID from a state voter file:
        //public string state_file_id;

        // a district field:
        //public string state_lower_district;

        // a district field:
        //public string state_upper_district;

        /// <summary>
        /// The address this person submitted.
        /// </summary>
        [DataMember]
        public Address submitted_address;

        // !!! FIXME: Does this use a subnation data structure?
        /// <summary>
        /// An array of subnations that this person belongs to.
        /// </summary>
        [DataMember]
        public string[] subnations;

        /// <summary>
        /// The suffix this person uses w/their name, i.e. Jr., Sr. or III.
        /// </summary>
        [DataMember]
        public string suffix;


        /// <summary>
        /// The time and date that this person’s support level changed.
        /// </summary>
        public DateTimeOffset? support_level_changed_at;

        [DataMember(Name = "support_level_changed_at")]
        private string support_level_changed_at_SerializationForm;


        // the level of support this person has for your nation, expressed as a number between 1 and 5,
        //  1 being Strong support, 5 meaning strong opposition, and 3 meaning undecided.
        //public int support_level;

        /// <summary>
        /// The likelihood that this person will support you at election time.
        /// </summary>
        [DataMember]
        public double? support_probability_score;

        // district field:
        //public string supranational_district;

        // the tags assigned to this person, as an array of strings - setting via this API has been deprecated, use the people tags API:
        //public string[] tags;

        /// <summary>
        /// The probability that this person will turn out to vote.
        /// </summary>
        [DataMember]
        public double? turnout_probability_score;

        /// <summary>
        /// This person’s location based on their Twitter profile.
        /// </summary>
        [DataMember]
        public Address twitter_address;

        /// <summary>
        /// The description that this person provided in their Twitter profile.
        /// </summary>
        [DataMember]
        public string twitter_description;

        /// <summary>
        /// The number of followers this person has on Twitter.
        /// </summary>
        [DataMember]
        public int? twitter_followers_count;

        /// <summary>
        /// The number of friends this person has on Twitter.
        /// </summary>
        [DataMember]
        public int? twitter_friends_count;

        // this person’s ID from Twitter:
        //public string twitter_id;

        /// <summary>
        /// A string representing this person’s address based on Twitter’s location data.
        /// 
        /// Nation Builder's online documentation incorrectly states:
        /// "An address resource representing this person’s address based on Twitter’s location data."
        /// 
        /// The examples they show, and data returned from the service have a string in this field.
        /// </summary>
        [DataMember]
        public string twitter_location;

        /// <summary>
        /// This person’s Twitter login name.
        /// </summary>
        [DataMember]
        public string twitter_login;

        // this person’s Twitter handle, e.g. FoobarSoftwares:
        //public string twitter_name;

        /// <summary>
        /// The last time this person’s Twitter record was updated.
        /// </summary>
        public DateTimeOffset? twitter_updated_at;

        [DataMember(Name = "twitter_updated_at")]
        private string twitter_updated_at_SerializationForm;


        /// <summary>
        /// The URL of the website that this person included in their Twitter profile.
        /// </summary>
        [DataMember]
        public string twitter_website;


        /// <summary>
        /// The date/time that this person unsubscribed from emails.
        /// </summary>
        public DateTimeOffset? unsubscribed_at;

        [DataMember(Name = "unsubscribed_at")]
        private string unsubscribed_at_SerializationForm;


        // the timestamp representing when this person was last updated:
        //public DateTimeOffset updated_at;

        /// <summary>
        /// An address resource representing the address this person submitted.
        /// </summary>
        [DataMember]
        public Address user_submitted_address;

        /// <summary>
        /// This person’s NationBuilder username.
        /// </summary>
        [DataMember]
        public string username;

        // this person’s ID from VAN:
        //public string van_id;

        // a district field:
        //public string village_district;

        /// <summary>
        /// The number of warnings this person has received.
        /// </summary>
        [DataMember]
        public int? warnings_count;

        /// <summary>
        /// The URL of this person’s website.
        /// </summary>
        [DataMember]
        public string website;

        /// <summary>
        /// An address resource representing this person’s work address.
        /// </summary>
        [DataMember]
        public Address work_address;

        /// <summary>
        /// A work phone number for this person.
        /// </summary>
        [DataMember]
        public string work_phone_number;


        public Person() { }

        /// <summary>
        /// Create a <see cref="Person"/> object which is a shallow copy of another object.
        /// </summary>
        /// <param name="copySource">The object to copy.</param>
        public Person(Person copySource)
        {
            foreach (var info in typeof(Person).GetFields())
            {
                info.SetValue(this, info.GetValue(copySource));
            }
        }

        [OnSerializing]
        void OnSerializing(StreamingContext context)
        {
            active_customer_expires_at_SerializationForm = Serialization.DateTimeOffsetGetSerializationForm(active_customer_expires_at);
            active_customer_started_at_SerializationForm = Serialization.DateTimeOffsetGetSerializationForm(active_customer_started_at);
            banned_at_SerializationForm = Serialization.DateTimeOffsetGetSerializationForm(banned_at);
            facebook_updated_at_SerializationForm = Serialization.DateTimeOffsetGetSerializationForm(facebook_updated_at);
            first_donated_at_SerializationForm = Serialization.DateTimeOffsetGetSerializationForm(first_donated_at);
            first_fundraised_at_SerializationForm = Serialization.DateTimeOffsetGetSerializationForm(first_fundraised_at);
            first_invoice_at_SerializationForm = Serialization.DateTimeOffsetGetSerializationForm(first_invoice_at);
            first_prospect_at_SerializationForm = Serialization.DateTimeOffsetGetSerializationForm(first_prospect_at);
            first_recruited_at_SerializationForm = Serialization.DateTimeOffsetGetSerializationForm(first_recruited_at);
            first_supporter_at_SerializationForm = Serialization.DateTimeOffsetGetSerializationForm(first_supporter_at);
            first_volunteer_at_SerializationForm = Serialization.DateTimeOffsetGetSerializationForm(first_volunteer_at);
            last_contacted_at_SerializationForm = Serialization.DateTimeOffsetGetSerializationForm(last_contacted_at);
            last_donated_at_SerializationForm = Serialization.DateTimeOffsetGetSerializationForm(last_donated_at);
            last_fundraised_at_SerializationForm = Serialization.DateTimeOffsetGetSerializationForm(last_fundraised_at);
            last_invoice_at_SerializationForm = Serialization.DateTimeOffsetGetSerializationForm(last_invoice_at);
            last_rule_violation_at_SerializationForm = Serialization.DateTimeOffsetGetSerializationForm(last_rule_violation_at);
            membership_expires_at_SerializationForm = Serialization.DateTimeOffsetGetSerializationForm(membership_expires_at);
            membership_started_at_SerializationForm = Serialization.DateTimeOffsetGetSerializationForm(membership_started_at);
            note_updated_at_SerializationForm = Serialization.DateTimeOffsetGetSerializationForm(note_updated_at);
            priority_level_changed_at_SerializationForm = Serialization.DateTimeOffsetGetSerializationForm(priority_level_changed_at);
            registered_at_SerializationForm = Serialization.DateTimeOffsetGetSerializationForm(registered_at);
            support_level_changed_at_SerializationForm = Serialization.DateTimeOffsetGetSerializationForm(support_level_changed_at);
            twitter_updated_at_SerializationForm = Serialization.DateTimeOffsetGetSerializationForm(twitter_updated_at);
            unsubscribed_at_SerializationForm = Serialization.DateTimeOffsetGetSerializationForm(unsubscribed_at);
        }

        [OnDeserialized]
        void OnDeserialized(StreamingContext context)
        {
            active_customer_expires_at = Serialization.NullableDateTimeOffsetDeserialize(active_customer_expires_at_SerializationForm);
            active_customer_started_at = Serialization.NullableDateTimeOffsetDeserialize(active_customer_started_at_SerializationForm);
            banned_at = Serialization.NullableDateTimeOffsetDeserialize(banned_at_SerializationForm);
            facebook_updated_at = Serialization.NullableDateTimeOffsetDeserialize(facebook_updated_at_SerializationForm);
            first_donated_at = Serialization.NullableDateTimeOffsetDeserialize(first_donated_at_SerializationForm);
            first_fundraised_at = Serialization.NullableDateTimeOffsetDeserialize(first_fundraised_at_SerializationForm);
            first_invoice_at = Serialization.NullableDateTimeOffsetDeserialize(first_invoice_at_SerializationForm);
            first_prospect_at = Serialization.NullableDateTimeOffsetDeserialize(first_prospect_at_SerializationForm);
            first_recruited_at = Serialization.NullableDateTimeOffsetDeserialize(first_recruited_at_SerializationForm);
            first_supporter_at = Serialization.NullableDateTimeOffsetDeserialize(first_supporter_at_SerializationForm);
            first_volunteer_at = Serialization.NullableDateTimeOffsetDeserialize(first_volunteer_at_SerializationForm);
            last_contacted_at = Serialization.NullableDateTimeOffsetDeserialize(last_contacted_at_SerializationForm);
            last_donated_at = Serialization.NullableDateTimeOffsetDeserialize(last_donated_at_SerializationForm);
            last_fundraised_at = Serialization.NullableDateTimeOffsetDeserialize(last_fundraised_at_SerializationForm);
            last_invoice_at = Serialization.NullableDateTimeOffsetDeserialize(last_invoice_at_SerializationForm);
            last_rule_violation_at = Serialization.NullableDateTimeOffsetDeserialize(last_rule_violation_at_SerializationForm);
            membership_expires_at = Serialization.NullableDateTimeOffsetDeserialize(membership_expires_at_SerializationForm);
            membership_started_at = Serialization.NullableDateTimeOffsetDeserialize(membership_started_at_SerializationForm);
            note_updated_at = Serialization.NullableDateTimeOffsetDeserialize(note_updated_at_SerializationForm);
            priority_level_changed_at = Serialization.NullableDateTimeOffsetDeserialize(priority_level_changed_at_SerializationForm);
            registered_at = Serialization.NullableDateTimeOffsetDeserialize(registered_at_SerializationForm);
            support_level_changed_at = Serialization.NullableDateTimeOffsetDeserialize(support_level_changed_at_SerializationForm);
            twitter_updated_at = Serialization.NullableDateTimeOffsetDeserialize(twitter_updated_at_SerializationForm);
            unsubscribed_at = Serialization.NullableDateTimeOffsetDeserialize(unsubscribed_at_SerializationForm);
        }

        /// <summary>
        /// Create a shallow clone of this object.
        /// 
        /// The clone will share member objects with this object!
        /// </summary>
        /// <returns>The cloned Person object.</returns>
        new public Person ShallowClone()
        {
            return (Person)this.MemberwiseClone();
        }
    }
}
