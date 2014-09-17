using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NationBuilderAPI.V1
{
    [DataContract]
    public class Donation
    {
        /// <summary>
        /// Amount of donation in the nation's currency.
        /// 
        /// Writable: Y
        /// 
        /// Required: N
        /// 
        /// Example: <c>$10.00</c>
        /// </summary>
        public string amount;

        /// <summary>
        /// Amount of donation in cents.
        /// 
        /// Writable: Y
        /// 
        /// Required: Y
        /// 
        /// Example: <c>1000</c>
        /// </summary>
        public int amount_in_cents;

        /// <summary>
        /// ID of the person who created the donation.
        /// 
        /// Writable: N
        /// 
        /// Required: N
        /// 
        /// Example: <c>67</c>
        /// 
        /// Notes:
        /// 
        ///     On the Create endpoint this field will be set to the person ID of the API access token's owner.
        /// </summary>
        public int author_id;

        /// <summary>
        /// An address resource representing the billing address.
        /// 
        /// Writable: Y
        /// 
        /// Required: N
        /// </summary>
        public Address billing_address;

        /// <summary>
        /// Timestamp representing when the donation was canceled.
        /// 
        /// Writable: Y
        /// 
        /// Required: N
        /// 
        /// Example: <c>2014-02-14T15:22:12-05:00</c>
        /// </summary>
        public DateTime canceled_at;

        /// <summary>
        /// Check/wire/MO number.
        /// 
        /// Writable: Y
        /// 
        /// Required: N
        /// 
        /// Example: <c>4747392947582</c>
        /// </summary>
        public string check_number;

        /// <summary>
        /// True if the donation is a corporate contribution.
        /// 
        /// Writable: Y
        /// 
        /// Required: N
        /// 
        /// Example: <c>false</c>
        /// </summary>
        public bool corporate_contribution;

        /// <summary>
        /// Timestamp representing when the donation was created.
        /// 
        /// Writable: N
        /// 
        /// Required: N
        /// 
        /// Example: <c>2014-02-14T14:36:29-05:00</c>
        /// </summary>
        public DateTime created_at;

        /// <summary>
        /// The person id of the donor.
        /// 
        /// Writable: Y
        /// 
        /// Required: N
        /// 
        /// Example: <c>8472</c>
        /// 
        /// Notes:
        /// 
        ///     It is strongly recommended to specify this field. If omitted, <see cref="email"/> or <see cref="first_name"/> and <see cref="last_name"/>
        ///     become required and a new <see cref="Person"/> may be created.
        /// </summary>
        public int donor_id;

        /// <summary>
        /// An abbreviated person resource representing the donor.
        /// 
        /// Writable: N
        /// 
        /// Required: N
        /// </summary>
        public AbbreviatedPerson donor;

        /// <summary>
        /// The donor's email address.
        /// 
        /// Writable: Y
        /// 
        /// Required: N
        /// 
        /// Example: <c>queen@swarm.net</c>
        /// 
        /// Notes:
        /// 
        ///     Use the <see cref="donor_id"/> field instead to specify a donor. By specifying any of these fields you override the value of the same
        ///     field on the donor.
        /// </summary>
        public string email;

        /// <summary>
        /// The name of the donor's employer.
        /// 
        /// Writable: Y
        /// 
        /// Required: N
        /// 
        /// Example: <c>ABC Consulting Co</c>
        /// 
        /// Notes:
        /// 
        ///     Use the <see cref="donor_id"/> field instead to specify a donor. By specifying any of these fields you override the value of the same
        ///     field on the donor.
        /// </summary>
        public string employer;

        /// <summary>
        /// Timestamp representing when the donation failed.
        /// 
        /// Writable: Y
        /// 
        /// Required: N
        /// 
        /// Example: <c>2014-02-14T15:22:12-05:00</c>
        /// </summary>
        public DateTime failed_at;

        /// <summary>
        /// The donor's first name and middle name.
        /// 
        /// Writable: Y
        /// 
        /// Required: N
        /// 
        /// Example: <c>Sarah</c>
        /// 
        /// Notes:
        /// 
        ///     Use the <see cref="donor_id"/> field instead to specify a donor. By specifying any of these fields you override the value of the same
        ///     field on the donor.
        /// </summary>
        public string first_name;

        /// <summary>
        /// ID of the donation.
        /// 
        /// Writable: N
        /// 
        /// Required: N
        /// 
        /// Example: <c>314</c>
        /// </summary>
        public int id;

        /// <summary>
        /// ID of the import job (if the donation was imported).
        /// 
        /// Writable: N
        /// 
        /// Required: N
        /// 
        /// Example: <c>890</c>
        /// </summary>
        public int import_id;

        /// <summary>
        /// False if the donation should not be posted publicly on the site.
        /// 
        /// Writable: Y
        /// 
        /// Required: N
        /// 
        /// Example: <c>false</c>
        /// </summary>
        public bool is_private;

        /// <summary>
        /// The donor's last name.
        /// 
        /// Writable: Y
        /// 
        /// Required: N
        /// 
        /// Example: <c>Kerrigan</c>
        /// 
        /// Notes:
        /// 
        ///     Use the <see cref="donor_id"/> field instead to specify a donor. By specifying any of these fields you override the value of the same
        ///     field on the donor.
        /// </summary>
        public string last_name;

        /// <summary>
        /// Slug of the mailing page.
        /// 
        /// Writable: N
        /// 
        /// Required: N
        /// 
        /// Example: <c>la_family</c>
        /// </summary>
        public string mailing_slug;

        /// <summary>
        /// ID of the merchant account used for paying the donation.
        /// 
        /// Writable: Y
        /// 
        /// Required: N
        /// 
        /// Example: <c>11</c>
        /// </summary>
        public int merchant_account_id;

        /// <summary>
        /// An id which is present if the donor has been imported from NGP VAN.
        /// 
        /// Writable: Y
        /// 
        /// Required: N
        /// 
        /// Example: <c>56</c>
        /// </summary>
        public int ngp_id;

        /// <summary>
        /// A note for this donation.
        /// 
        /// Writable: Y
        /// 
        /// Required: N
        /// 
        /// Example: <c>very generous</c>
        /// </summary>
        public string note;

        /// <summary>
        /// The donor's occupation.
        /// 
        /// Writable: Y
        /// 
        /// Required: N
        /// 
        /// Example: <c>Consultant</c>
        /// 
        /// Notes:
        /// 
        ///     Use the <see cref="donor_id"/> field instead to specify a donor. By specifying any of these fields you override the value of the same
        ///     field on the donor.
        /// </summary>
        public string occupation;

        /// <summary>
        /// Slug of the donation page.
        /// 
        /// Writable: N
        /// 
        /// Required: N
        /// 
        /// Example: <c>ticket_sales</c>
        /// </summary>
        public string page_slug;

        /// <summary>
        /// Name of the payment type. See <see cref="PaymentType"/>.
        /// 
        /// Writable: Y
        /// 
        /// Required: Y
        /// 
        /// Example: <c>Check</c>
        /// 
        /// Notes:
        /// 
        ///     Default: Cash (C). It is strongly recommended to specify one of these (<see cref="payment_type_name"/>, or
        ///     <see cref="payment_type_ngp_code"/>) fields.
        /// </summary>
        public string payment_type_name;

        /// <summary>
        /// Code of the payment type. See <see cref="PaymentType"/>.
        /// 
        /// Writable: Y
        /// 
        /// Required: Y
        /// 
        /// Example: <c>K</c>
        /// 
        /// Notes:
        /// 
        ///     Default: Cash (C). It is strongly recommended to specify one of these (<see cref="payment_type_name"/>, or
        ///     <see cref="payment_type_ngp_code"/>) fields.
        /// </summary>
        public char payment_type_ngp_code;

        /// <summary>
        /// The ID of the pledge this donation fulfills. Pledges are promises received from supporters to donate money in the future.
        /// 
        /// Writable: N
        /// 
        /// Required: N
        /// 
        /// Example: <c>129</c>
        /// </summary>
        public int pledge_id;

        /// <summary>
        /// Recruiter's name or email address.
        /// 
        /// Writable: Y
        /// 
        /// Required: N
        /// 
        /// Example: <c>Hayden Johns</c>
        /// 
        /// Notes:
        /// 
        ///     Use the <see cref="donor_id"/> field instead to specify a donor. By specifying any of these fields you override the value of the same
        ///     field on the donor.
        /// </summary>
        public string recruiter_name_or_email;

        /// <summary>
        /// An ID present if the donation is recurring.
        /// 
        /// Writable: N
        /// 
        /// Required: N
        /// 
        /// Example: <c>89</c>
        /// 
        /// Notes:
        /// 
        ///     This field is for internal use only.
        /// </summary>
        public int recurring_donation_id;

        /// <summary>
        /// Timestamp representing when the donation succeeded.
        /// 
        /// Writable: Y
        /// 
        /// Required: N
        /// 
        /// Example: <c>2013-02-21T10:04:15-05:00</c>
        /// 
        /// Notes:
        /// 
        ///     If omitted the donation will be considered failed.
        /// </summary>
        public DateTime succeeded_at;

        /// <summary>
        /// Tracking code for this donation.
        /// 
        /// Writable: Y
        /// 
        /// Required: N
        /// 
        /// Example: <c>vip</c>
        /// </summary>
        public string tracking_code_slug;

        /// <summary>
        /// Timestamp representing when the donation was last updated.
        /// 
        /// Writable: N
        /// 
        /// Required: N
        /// 
        /// Example: <c>2014-02-14T14:36:29-05:00</c>
        /// </summary>
        public DateTime updated_at;

        /// <summary>
        /// An address resource representing the work address.
        /// 
        /// Writable: N
        /// 
        /// Required: N
        /// </summary>
        public Address work_address;

        // Voter add-on fields:
        /// <summary>
        /// ActBlue order number.
        /// 
        /// Writable: Y
        /// 
        /// Required: N
        /// 
        /// Example: <c>543</c>
        /// </summary>
        public long actblue_order_number;

        /// <summary>
        /// FEC code name.  See <see cref="FecType"/>.
        /// 
        /// Writable: Y
        /// 
        /// Required: N
        /// 
        /// Example: <c>Contribution</c>
        /// 
        /// Notes:
        ///
        ///     Default: Contribution (C). It is strongly recommended to specify one of these fields.
        /// </summary>
        public string fec_type;

        /// <summary>
        /// NGP FEC code.  See <see cref="FecType"/>.
        /// 
        /// Writable: Y
        /// 
        /// Required: N
        /// 
        /// Example: <c>C</c>
        /// 
        /// Notes:
        /// 
        ///     Default: Contribution (C). It is strongly recommended to specify one of these fields.
        /// </summary>
        public string fec_type_ngp_code;

        /// <summary>
        /// An election resource representing an election.
        /// 
        /// Writable: Y
        /// 
        /// Required: N
        /// 
        /// Notes:
        /// 
        ///     It is strongly recommended to specify this field.
        /// </summary>
        public Election election;
    }
}
