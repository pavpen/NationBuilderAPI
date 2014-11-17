using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NationBuilderAPI.V1.AutoSerializable
{
    [DataContract]
    public class Donation
    {
        [DataMember]
        public string amount;

        [DataMember]
        public int amount_in_cents;

        [DataMember]
        public long? author_id;

        [DataMember]
        public Address billing_address;


        public DateTime? canceled_at;

        [DataMember(Name = "canceled_at")]
        private string canceled_at_SerializationForm;


        [DataMember]
        public string check_number;

        [DataMember]
        public bool corporate_contribution;


        public DateTime created_at;

        [DataMember(Name = "created_at")]
        private string created_at_SerializationForm;


        [DataMember]
        public long donor_id;

        [DataMember]
        public AbbreviatedPerson donor;

        [DataMember]
        public string email;

        [DataMember]
        public string employer;


        public DateTime? failed_at;

        [DataMember(Name = "failed_at")]
        private string failed_at_SerializationForm;
        

        [DataMember]
        public string first_name;

        [DataMember]
        public long id;

        [DataMember]
        public string import_id;

        [DataMember]
        public bool is_private;

        [DataMember]
        public string last_name;

        [DataMember]
        public string mailing_slug;

        [DataMember]
        public long merchant_account_id;

        [DataMember]
        public string ngp_id;

        [DataMember]
        public string note;

        [DataMember]
        public string occupation;

        [DataMember]
        public string page_slug;

        [DataMember]
        public string payment_type_name;

        [DataMember]
        public char payment_type_ngp_code;

        [DataMember]
        public long? pledge_id;

        [DataMember]
        public string recruiter_name_or_email;

        [DataMember]
        public long? recurring_donation_id;


        public DateTime? succeeded_at;

        [DataMember(Name = "succeeded_at")]
        private string succeeded_at_SerializationForm;
        

        [DataMember]
        public string tracking_code_slug;


        public DateTime updated_at;

        [DataMember(Name = "updated_at")]
        private string updated_at_SerializationForm;
        

        [DataMember]
        public Address work_address;

        [DataMember]
        public string actblue_order_number;

        [DataMember]
        public string fec_type;

        [DataMember]
        public string fec_type_ngp_code;

        [DataMember]
        public Election election;


        [OnSerializing]
        void OnSerializing(StreamingContext context)
        {
            canceled_at_SerializationForm = Base.DateTimeGetSerializationForm(canceled_at);
            created_at_SerializationForm = Base.DateTimeGetSerializationForm(created_at);
            failed_at_SerializationForm = Base.DateTimeGetSerializationForm(failed_at);
            succeeded_at_SerializationForm = Base.DateTimeGetSerializationForm(succeeded_at);
            updated_at_SerializationForm = Base.DateTimeGetSerializationForm(updated_at);
        }

        [OnDeserialized]
        void OnDeserialized(StreamingContext context)
        {
            canceled_at = Base.NullableDateTimeDeserialize(canceled_at_SerializationForm);
            created_at = Base.DateTimeDeserialize(created_at_SerializationForm);
            failed_at = Base.NullableDateTimeDeserialize(failed_at_SerializationForm);
            succeeded_at = Base.NullableDateTimeDeserialize(succeeded_at_SerializationForm);
            updated_at = Base.DateTimeDeserialize(updated_at_SerializationForm);
        }

        /// <summary>
        /// Convert this object to the cannonical <see cref="NationBuilderAPI.V1.Donation"/>.
        /// </summary>
        /// <returns>The converted NationBuilderAPI.V1.Donation object.</returns>
        public NationBuilderAPI.V1.Donation ToDonation()
        {
            var res = new NationBuilderAPI.V1.Donation();

            res.CopyFrom(this);

            return res;
        }
    }
}
