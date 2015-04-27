using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NationBuilderAPI.V1
{
    [DataContract]
    public class AbbreviatedPerson
    {
        /// <summary>
        /// This person's birth date.
        /// </summary>
        [DataMember]
        public DateTime? birthdate;

        /// <summary>
        /// District field.
        /// </summary>
        [DataMember]
        public string city_district;

        /// <summary>
        /// This person’s ID from CiviCRM.
        /// </summary>
        [DataMember]
        public string civicrm_id;

        /// <summary>
        /// District field.
        /// </summary>
        [DataMember]
        public string county_district;

        /// <summary>
        /// This person’s ID from a county voter file.
        /// </summary>
        [DataMember]
        public string county_file_id;

        /// <summary>
        /// Timestamp representing when this person was created in the nation.
        /// </summary>
        [DataMember]
        public DateTimeOffset created_at;

        /// <summary>
        /// This is a boolean flag that lets us know if this person is on a do not call list.
        /// </summary>
        [DataMember]
        public bool do_not_call;

        /// <summary>
        /// This is a boolean flag that lets us know if this person is on a do not contact list.
        /// </summary>
        [DataMember]
        public bool do_not_contact;

        /// <summary>
        /// This person’s ID from Catalist.
        /// </summary>
        [DataMember]
        public int? dw_id;

        /// <summary>
        /// The person's email address if reading or writing a single address.
        /// </summary>
        [DataMember]
        public string email;

        /// <summary>
        /// Boolean representing whether this person has opted-in to email correspondence.
        /// </summary>
        [DataMember]
        public bool email_opt_in;

        /// <summary>
        /// The name of the company for which this person works.
        /// </summary>
        [DataMember]
        public string employer;

        /// <summary>
        /// A string representing an external identifier for this person.
        /// </summary>
        [DataMember]
        public string external_id;

        /// <summary>
        /// District field.
        /// </summary>
        [DataMember]
        public string federal_district;

        /// <summary>
        /// District field.
        /// </summary>
        [DataMember]
        public string fire_district;

        /// <summary>
        /// The person's first name and middle names.
        /// </summary>
        [DataMember]
        public string first_name;

        /// <summary>
        /// A boolean representing whether this person has Facebook information.
        /// </summary>
        [DataMember]
        public bool has_facebook;

        /// <summary>
        /// The NationBuilder ID of the person, specific to the authorized nation.
        /// </summary>
        [DataMember]
        public int? id;

        /// <summary>
        /// Whether the person is a Twitter follower of one of the nation’s broadcasters.
        /// </summary>
        [DataMember]
        public bool is_twitter_follower;

        /// <summary>
        /// A boolean field that indicates whether the person has volunteered.
        /// </summary>
        [DataMember]
        public bool is_volunteer;

        /// <summary>
        /// District field.
        /// </summary>
        [DataMember]
        public string judicial_district;

        /// <summary>
        /// District field.
        /// </summary>
        [DataMember]
        public string labour_region;

        /// <summary>
        /// This person's last name.
        /// </summary>
        [DataMember]
        public string last_name;

        /// <summary>
        /// This person’s ID from LinkedIn.
        /// </summary>
        [DataMember]
        public string linkedin_id;

        /// <summary>
        /// A boolean representing whether the person has opted-in to mobile correspondence.
        /// </summary>
        [DataMember]
        public bool mobile_opt_in;

        /// <summary>
        /// This person's cell phone number.
        /// </summary>
        [DataMember]
        public string mobile;

        /// <summary>
        /// This person’s ID from the NationBuilder Election Center.
        /// </summary>
        [DataMember]
        public string nbec_guid;

        /// <summary>
        /// This person’s ID from NGP.
        /// </summary>
        [DataMember]
        public string ngp_id;

        /// <summary>
        /// A note to attach to the person's profile.
        /// </summary>
        [DataMember]
        public string note;

        /// <summary>
        /// The type of work this person does.
        /// </summary>
        [DataMember]
        public string occupation;

        /// <summary>
        /// A one-letter code representing provincial parties for nations.
        /// </summary>
        [DataMember]
        public string party;

        /// <summary>
        /// A person’s historical ID from PoliticalForce.
        /// </summary>
        [DataMember]
        public string pf_strat_id;

        /// <summary>
        /// This person's home phone number.
        /// </summary>
        [DataMember]
        public string phone;

        /// <summary>
        /// The ID of the precinct associated with this person.
        /// </summary>
        [DataMember]
        public string precinct_id;

        /// <summary>
        /// An address resource representing the primary address.
        /// </summary>
        [DataMember]
        public Address primary_address;

        /// <summary>
        /// The ID of the person who recruited this person.
        /// </summary>
        [DataMember]
        public string recruiter_id;

        /// <summary>
        /// This person’s ID from the RNC.
        /// </summary>
        [DataMember]
        public string rnc_id;

        /// <summary>
        /// This person’s registration ID from the RNC.
        /// </summary>
        [DataMember]
        public string rnc_regid;

        /// <summary>
        /// This person’s ID from Salesforce.
        /// </summary>
        [DataMember]
        public string salesforce_id;

        /// <summary>
        /// District field.
        /// </summary>
        [DataMember]
        public string school_district;

        /// <summary>
        /// District field.
        /// </summary>
        [DataMember]
        public string school_sub_district;

        /// <summary>
        /// This person's gender (M, F or O).
        /// </summary>
        [DataMember]
        public string sex;

        /// <summary>
        /// This person’s ID from a state voter file.
        /// </summary>
        [DataMember]
        public string state_file_id;

        /// <summary>
        /// District field.
        /// </summary>
        [DataMember]
        public string state_lower_district;

        /// <summary>
        /// District field.
        /// </summary>
        [DataMember]
        public string state_upper_district;

        /// <summary>
        /// The level of support this person has for your nation, expressed as a number between 1 and 5,
        /// 1 being Strong support, 5 meaning strong opposition, and 3 meaning undecided.
        /// </summary>
        [DataMember]
        public int? support_level;

        /// <summary>
        /// District field.
        /// </summary>
        [DataMember]
        public string supranational_district;

        /// <summary>
        /// The tags assigned to this person, as an array of strings - setting via this API has been deprecated, use the people tags API.
        /// </summary>
        [DataMember]
        public string[] tags;

        /// <summary>
        /// This person’s ID from Twitter.
        /// </summary>
        [DataMember]
        public string twitter_id;

        /// <summary>
        /// This person’s Twitter handle, e.g. FoobarSoftwares.
        /// </summary>
        [DataMember]
        public string twitter_name;

        /// <summary>
        /// The timestamp representing when this person was last updated.
        /// </summary>
        [DataMember]
        public DateTimeOffset updated_at;

        /// <summary>
        /// This person’s ID from VAN.
        /// </summary>
        [DataMember]
        public string van_id;

        /// <summary>
        /// District field.
        /// </summary>
        [DataMember]
        public string village_district;

        /// <summary>
        /// Copy field contents from another object.
        /// </summary>
        /// <param name="source">The source object to copy field contents from.</param>
        public void CopyFrom(NationBuilderAPI.V1.AutoSerializable.AbbreviatedPerson source)
        {
            birthdate = source.birthdate;
            city_district = source.city_district;
            civicrm_id = source.civicrm_id;
            county_district = source.county_district;
            county_file_id = source.county_file_id;
            created_at = source.created_at;
            do_not_call = source.do_not_call;
            do_not_contact = source.do_not_contact;
            dw_id = source.dw_id;
            email = source.email;
            email_opt_in = source.email_opt_in;
            employer = source.employer;
            external_id = source.external_id;
            federal_district = source.federal_district;
            fire_district = source.fire_district;
            first_name = source.first_name;
            has_facebook = source.has_facebook;
            id = source.id;
            is_twitter_follower = source.is_twitter_follower;
            is_volunteer = source.is_volunteer;
            judicial_district = source.judicial_district;
            labour_region = source.labour_region;
            last_name = source.last_name;
            linkedin_id = source.linkedin_id;
            mobile_opt_in = source.mobile_opt_in;
            mobile = source.mobile;
            nbec_guid = source.nbec_guid;
            ngp_id = source.ngp_id;
            note = source.note;
            occupation = source.occupation;
            party = source.party;
            pf_strat_id = source.pf_strat_id;
            phone = source.phone;
            precinct_id = source.precinct_id;
            primary_address = source.primary_address;
            recruiter_id = source.recruiter_id;
            rnc_id = source.rnc_id;
            rnc_regid = source.rnc_regid;
            salesforce_id = source.salesforce_id;
            school_district = source.school_district;
            school_sub_district = source.school_sub_district;
            sex = source.sex;
            state_file_id = source.state_file_id;
            state_lower_district = source.state_lower_district;
            state_upper_district = source.state_upper_district;
            support_level = source.support_level;
            supranational_district = source.supranational_district;
            tags = source.tags;
            twitter_id = source.twitter_id;
            twitter_name = source.twitter_name;
            updated_at = source.updated_at;
            van_id = source.van_id;
            village_district = source.village_district;
        }
    }
}