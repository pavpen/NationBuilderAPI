using System;
using System.Collections.Generic;
using System.Text;

using NationBuilderAPI.V1.Http;

namespace NationBuilderAPI.V1
{
    public partial class NationBuilderSession<PersonType, DonationType>
    {
        /// <summary>
        /// The index endpoint provides a paginated view of the donations in a nation.
        /// </summary>
        /// <param name="limit">Number of results to show on each page of results (max 100).</param>
        /// <returns>The requested page of results, and result information.</returns>
        public ResultsPageResponse<DonationType> GetDonations(int limit = 100)
        {
            StringBuilder reqUrlBuilder = RequestUrlBuilderAppendQuery(
                MakeRequestUrlBuilder("donations"),
                "&limit=", limit.ToString());
            var req = MakeHttpRequest(reqUrlBuilder);
            var res = DeserializeHttpResponse<ResultsPageResponse<DonationType>>(req);

            return res;
        }

        /// <summary>
        /// Get an enumeration of all the donations in a nation.
        /// </summary>
        /// <param name="limit">Number of results to retrieve on each page of results (max 100).</param>
        /// <returns>All the donations in the nation.</returns>
        public IEnumerable<DonationType> GetDonationsResults(int limit = 100)
        {
            return AllResultsFrom(GetDonations(limit));
        }

        /// <summary>
        /// This endpoint creates a donation with the provided data.
        /// It returns a full representation of the donation that was created.
        /// If the creation step fails, it returns an error.
        /// 
        /// Note:
        /// 
        /// * A donation is always attached to a donor.
        ///   Use the Create or Match endpoints on the People API to create or find the person who will act as the donor.
        /// 
        /// * When creating a donation, the id of the donor should be specified in the donor_id field.
        /// 
        /// * If donor_id is specified the following fields are copied from the donor to the donation so there is no need to specify them:
        ///   email, first_name, last_name, employer, occupation, recruiter_id.
        /// 
        /// * recurring_donation_id should not be set when creating a new donation.
        /// </summary>
        /// <param name="donation">The resource of the donation to be created.</param>
        /// <returns>The newly-created donation.</returns>
        public DonationType CreateDonation(DonationType donation)
        {
            StringBuilder reqUrlBuilder = MakeRequestUrlBuilder("donations");
            var req = MakeHttpPostRequest<DonationTransportObject<DonationType>>(
                reqUrlBuilder,
                new DonationTransportObject<DonationType>() { donation = donation });
            var res = DeserializeHttpResponse<DonationResponse<DonationType>>(req);

            return res.donation;
        }

        /// <summary>
        /// This endpoint updates a donation with the provided id and data.
        /// It returns a full representation of the updated donation.
        /// If the update step fails, it returns an error.
        /// </summary>
        /// <param name="id">ID of the donation to update.</param>
        /// <param name="donation">The resource attributes of the donation to change.</param>
        /// <returns>A full representation of the updated donation.</returns>
        public DonationType UpdateDonation(long id, DonationType donation)
        {
            StringBuilder reqUrlBuilder = MakeRequestUrlBuilder("donations/", id.ToString());
            var req = MakeHttpPostRequest<DonationTransportObject<DonationType>>(
                reqUrlBuilder,
                new DonationTransportObject<DonationType>() { donation = donation },
                "PUT");
            var res = DeserializeHttpResponse<DonationResponse<DonationType>>(req);

            return res.donation;
        }

        /// <summary>
        /// This endpoint removes a donation with the provided id. It takes no parameters and returns response code 204 on success.
        /// </summary>
        /// <param name="id">The ID of the donation to destroy.</param>
        public void DestroyDonation(long id)
        {
            StringBuilder reqUrlBuilder = MakeRequestUrlBuilder("donations/", id.ToString());
            var req = MakeHttpRequest(reqUrlBuilder, HttpMethodNames.Delete);

            ReceiveVoidHttpResponse(req);
        }
    }
}
