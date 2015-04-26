using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Text;

namespace NationBuilderAPI.V1
{
    public partial class NationBuilderSession
    {
        /// <summary>
        /// The index endpoint provides a paginated view of the people in a nation. Each person's data is abbreviated for the Index view.
        /// To get a full representation use the Show endpoint (<see cref="ShowPerson"/>).
        /// </summary>
        /// <param name="page">Result page number.</param>
        /// <param name="per_page">Number of results to return (max 100).</param>
        /// <returns>The results page, and results information.</returns>
        public ResultsPageResponse<AbbreviatedPerson> GetPeople(int page = 1, int per_page = 10)
        {
            StringBuilder reqUrlBuilder = RequestUrlBuilderAppendQuery(
                MakeRequestUrlBuilder("people"),
                "&page=", page.ToString(),
                "&per_page=", per_page.ToString());
            HttpWebRequest req = MakeHttpRequest(reqUrlBuilder);
            var res = DeserializeHttpResponse<ResultsPageResponse<AbbreviatedPerson>>(req);

            return res;
        }

        /// <summary>
        /// The Show endpoint returns a full representation of the person with the provided ID.
        /// </summary>
        /// <param name="id">ID of the person to retrieve.</param>
        /// <param name="idType">Type of ID to use, set to <c>"external"</c> to show the person based on their external ID. Leave as <c>null</c> to use NationBuilder's ID.</param>
        /// <returns>The full person information.</returns>
        public PersonResponse ShowPerson(long id, string idType = null)
        {
            StringBuilder reqUrlBuilder = MakeRequestUrlBuilder("people/", id.ToString());
            if (null != idType)
            {
                reqUrlBuilder = RequestUrlBuilderAppendQuery(reqUrlBuilder, "&id_type=", idType.ToString());
            }

            HttpWebRequest req = MakeHttpRequest(reqUrlBuilder);
            PersonResponse res = DeserializeHttpResponse<PersonResponse>(req);

            return res;
        }

        /// <summary>
        /// Retrieve the full representation of a person with a given external ID.
        /// 
        /// To retrieve a person by Nation Builder's ID, <see cref="ShowPerson"/>.
        /// </summary>
        /// <param name="externalId">The external ID of the person to retrieve.</param>
        /// <returns>The full person information.</returns>
        public PersonResponse ShowPersonWithExternalId(string externalId)
        {
            StringBuilder reqUrlBuilder = MakeRequestUrlBuilder("people/", WebUtility.UrlEncode(externalId), "&id_type=external");

            HttpWebRequest req = MakeHttpRequest(reqUrlBuilder);
            PersonResponse res = DeserializeHttpResponse<PersonResponse>(req);

            return res;
        }

        /// <summary>
        /// Use the match endpoint to find people that have certain attributes.
        /// A single person must match the given criteria for this endpoint to return success.
        /// 
        /// Parameters act as matching criteria.
        /// </summary>
        /// <param name="email">Email address.</param>
        /// <param name="first_name">First name.</param>
        /// <param name="last_name">Last name.</param>
        /// <param name="phone">Phone number.</param>
        /// <param name="mobile">Mobile number.</param>
        /// <returns>The matching person.</returns>
        public AbbreviatedPersonResponse MatchPerson(string email = null, string first_name = null, string last_name = null, string phone = null, string mobile = null)
        {
            StringBuilder reqUrlBuilder = RequestUrlBuilderAppendMethodNonNullParameters(
                MakeRequestUrlBuilder("people/match"),
                MethodBase.GetCurrentMethod().GetParameters(),
                email, first_name, last_name, phone, mobile);
            HttpWebRequest req = MakeHttpRequest(reqUrlBuilder);
            AbbreviatedPersonResponse res = DeserializeHttpResponse<AbbreviatedPersonResponse>(req);

            return res;
        }

        /// <summary>
        /// Use this endpoint to find people that have certain attributes.
        /// </summary>
        /// <param name="first_name">First name search parameter.</param>
        /// <param name="last_name">Last name search parameter.</param>
        /// <param name="city">City of the primary address of people to match.</param>
        /// <param name="state">State of the primary address of people to match.</param>
        /// <param name="sex">Sex of the people to match (optional, M or F).</param>
        /// <param name="birthdate">Date of birth of the people to match.</param>
        /// <param name="updated_since">People updated since the given date.</param>
        /// <param name="with_mobile">Only people with mobile phone numbers.</param>
        /// <param name="custom_values">
        ///     Match custom field values.
        ///     It takes a nested format, e.g. {"custom_values": {"my_field_slug": "abcd"}}.
        ///     In the query string this parameter would have to be encoded as custom_values%5Bmy_field_slug%5D=abcd.
        /// </param>
        /// <param name="civicrm_id">civicrm_id of the person to match.</param>
        /// <param name="county_file_id">county_file_id of the person to match.</param>
        /// <param name="state_file_id">state_file_id of the person to match.</param>
        /// <param name="datatrust_id">datatrust_id of the person to match.</param>
        /// <param name="dw_id">dw_id of the person to match.</param>
        /// <param name="media_market_id">media_market_id of the person to match.</param>
        /// <param name="membership_level_id">membership_level_id of the person to match.</param>
        /// <param name="ngp_id">ngp_id of the person to match.</param>
        /// <param name="pf_strat_id">pf_strat_id of the person to match.</param>
        /// <param name="van_id">van_id of the person to match.</param>
        /// <param name="salesforce_id">salesforce_id of the person to match.</param>
        /// <param name="rnc_id">rnc_id of the person to match.</param>
        /// <param name="rnc_regid">rnc_regid of the person to match.</param>
        /// <param name="external_id">external_id of the person to match.</param>
        /// <param name="page">Page number (default: 1).</param>
        /// <param name="per_page">Number of results to show per page (default: 10, max: 100).</param>
        /// <returns>The specified page of people matching the specified criteria.</returns>
        public ResultsPageResponse<AbbreviatedPerson> SearchPeople(string first_name = null, string last_name = null, string city = null, string state = null, string sex = null,
            string birthdate = null, string updated_since = null, string with_mobile = null, string custom_values = null, string civicrm_id = null,
            string county_file_id = null, string state_file_id = null, string datatrust_id = null, int? dw_id = null, string media_market_id = null,
            string membership_level_id = null, string ngp_id = null, string pf_strat_id = null, string van_id = null, string salesforce_id = null,
            string rnc_id = null, string rnc_regid = null, string external_id = null, int page = 1, int per_page = 10)
        {
            StringBuilder reqUrlBuilder = RequestUrlBuilderAppendMethodNonNullParameters(
                MakeRequestUrlBuilder("people/search"),
                MethodBase.GetCurrentMethod().GetParameters(),
                first_name, last_name, city, state, sex,
                birthdate, updated_since, with_mobile, custom_values, civicrm_id,
                county_file_id, state_file_id, datatrust_id, dw_id.HasValue ? dw_id.ToString() : null, media_market_id,
                membership_level_id, ngp_id, pf_strat_id, van_id, salesforce_id,
                rnc_id, rnc_regid, external_id, page.ToString(), per_page.ToString());
            HttpWebRequest req = MakeHttpRequest(reqUrlBuilder);
            var res = DeserializeHttpResponse<ResultsPageResponse<AbbreviatedPerson>>(req);

            return res;
        }

        /// <summary>
        /// Use this endpoint to search for people near a location defined by latitude and longitude.
        /// </summary>
        /// <param name="location">Origin of search in the format latitude,longitude. (required)</param>
        /// <param name="distance">The radius in miles for which to include results. (optional, default: 1 mile)</param>
        /// <param name="page">Page number. (default: 1)</param>
        /// <param name="per_page">Number of results to show per page. (default: 10, max: 100)</param>
        /// <returns>The specified page of people in the specified search radius.</returns>
        public ResultsPageResponse<Person> NearbyPeople(string location, double distance = 1.0, int page = 1, int per_page = 10)
        {
            StringBuilder reqUrlBuilder = RequestUrlBuilderAppendMethodNonNullParameters(
                MakeRequestUrlBuilder("people/nearby"),
                MethodBase.GetCurrentMethod().GetParameters(),
                location, distance.ToString(), page.ToString(), per_page.ToString());
            HttpWebRequest req = MakeHttpRequest(reqUrlBuilder);
            var res = DeserializeHttpResponse<ResultsPageResponse<Person>>(req);

            return res;
        }

        /// <summary>
        /// This endpoint creates a person with the provided data.
        /// It returns a full representation of the person that was created.
        /// If the creation step fails, it returns an error.
        /// </summary>
        /// <param name="person">
        /// The resource of the person to be created.
        /// 
        /// A person is considered valid with a name, a phone number or an email.
        /// If a person you create does not meet these criteria you will receive an error for a field called identity.
        /// </param>
        /// <returns>The person created.</returns>
        public PersonResponse CreatePerson(Person person)
        {
            StringBuilder reqUrlBuilder = MakeRequestUrlBuilder("people");
            HttpWebRequest req = MakeHttpPostRequest<PersonTransportObject>(reqUrlBuilder, new PersonTransportObject() { person = person });
            PersonResponse res = DeserializeHttpResponse<PersonResponse>(req);

            return res;
        }

        /// <summary>
        /// This endpoint updates a person with the provided id to have the provided data.
        /// It returns a full representation of the updated person.
        /// If the update step fails, it returns an error.
        /// </summary>
        /// <param name="id">ID of the person to update.</param>
        /// <param name="person">The resource attributes of the person to change.</param>
        /// <returns>The updated person.</returns>
        public PersonResponse UpdatePerson(long id, Person person)
        {
            StringBuilder reqUrlBuilder = MakeRequestUrlBuilder("people/", id.ToString());
            HttpWebRequest req = MakeHttpPostRequest<PersonTransportObject>(reqUrlBuilder, new PersonTransportObject() { person = person }, HttpMethodNames.Put);
            PersonResponse res = DeserializeHttpResponse<PersonResponse>(req);

            return res;
        }

        /// <summary>
        /// This endpoint updates a person matched, or creates if no match is found.
        /// Matches are found exclusively by email address or external ID.
        /// </summary>
        /// <param name="person">The resource attributes of the person to push.</param>
        /// <returns>The new, or updated person.</returns>
        public PersonResponse PushPerson(Person person)
        {
            StringBuilder reqUrlBuilder = MakeRequestUrlBuilder("people/push");
            HttpWebRequest req = MakeHttpPostRequest<PersonTransportObject>(reqUrlBuilder, new PersonTransportObject() { person = person }, HttpMethodNames.Put);
            PersonResponse res = DeserializeHttpResponse<PersonResponse>(req);

            return res;
        }

        /// <summary>
        /// This endpoint removes a person with the provided id from nation.
        /// It takes no parameters and returns response code 204 on success.
        /// </summary>
        /// <param name="id">ID of the person to destroy.</param>
        public void DestroyPerson(long id)
        {
            StringBuilder reqUrlBuilder = MakeRequestUrlBuilder("people/", id.ToString());
            HttpWebRequest req = MakeHttpRequest(reqUrlBuilder, HttpMethodNames.Delete);

            ReceiveVoidHttpResponse(req);
        }

        /// <summary>
        /// This endpoint starts a user registration process for the given person by sending an account confirmation email.
        /// </summary>
        /// <param name="id">ID of the person to register.</param>
        /// <returns>A "success" status, if the account activation email was sent successfully.</returns>
        public RegisterResponse RegisterPerson(long id)
        {
            StringBuilder reqUrlBuilder = MakeRequestUrlBuilder("people/", id.ToString(), "/register");
            HttpWebRequest req = MakeHttpRequest(reqUrlBuilder);
            RegisterResponse res = DeserializeHttpResponse<RegisterResponse>(req);

            return res;
        }

        /// <summary>
        /// This endpoint returns the access token's resource owner's representation.
        /// </summary>
        /// <returns></returns>
        public PersonResponse PersonMe()
        {
            StringBuilder reqUrlBuilder = MakeRequestUrlBuilder("people/me");
            HttpWebRequest req = MakeHttpRequest(reqUrlBuilder);
            PersonResponse res = DeserializeHttpResponse<PersonResponse>(req);

            return res;
        }
    }
}
