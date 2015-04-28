﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace NationBuilderAPI.V1
{
    public partial class NationBuilderSession : NationBuilderHttpTransport
    {
        /// <summary>
        /// The index endpoint provides a paginated view of the donations in a nation.
        /// </summary>
        /// <param name="page">Result page number.</param>
        /// <param name="per_page">Number of results to show on each page of results (max 100).</param>
        /// <returns>The requested page of results, and result information.</returns>
        public ResultsPageResponse<Donation> GetDonations(int page = 1, int per_page = 100)
        {
            StringBuilder reqUrlBuilder = RequestUrlBuilderAppendQuery(
                MakeRequestUrlBuilder("donations"),
                "&page=", page.ToString(),
                "&per_page=", per_page.ToString());
            HttpWebRequest req = MakeHttpRequest(reqUrlBuilder);
            var res = DeserializeHttpResponse<ResultsPageResponse<Donation>>(req);

            return res;
        }

        /// <summary>
        /// Get an enumeration of all the donations in a nation.
        /// </summary>
        /// <param name="page">Results page to start from.</param>
        /// <param name="per_page">Number of results to retrieve on each page of results (max 100).</param>
        /// <returns>All the donations in the nation.</returns>
        public IEnumerable<Donation> GetDonationsResults(int page = 1, int per_page = 100)
        {
            return AllResultsFrom(GetDonations(page, per_page));
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
        public Donation CreateDonation(Donation donation)
        {
            StringBuilder reqUrlBuilder = MakeRequestUrlBuilder("donations");
            HttpWebRequest req = MakeHttpPostRequest<DonationTransportObject>(reqUrlBuilder, new DonationTransportObject() { donation = donation });
            DonationTransportObject res = DeserializeHttpResponse<DonationTransportObject>(req);

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
        public Donation UpdateDonation(long id, Donation donation)
        {
            StringBuilder reqUrlBuilder = MakeRequestUrlBuilder("donations/", id.ToString());
            HttpWebRequest req = MakeHttpPostRequest<DonationTransportObject>(reqUrlBuilder, new DonationTransportObject() { donation = donation }, "PUT");
            DonationTransportObject res = DeserializeHttpResponse<DonationTransportObject>(req);

            return res.donation;
        }

        /// <summary>
        /// This endpoint removes a donation with the provided id. It takes no parameters and returns response code 204 on success.
        /// </summary>
        /// <param name="id">The ID of the donation to destroy.</param>
        public void DestroyDonation(long id)
        {
            StringBuilder reqUrlBuilder = MakeRequestUrlBuilder("donations/", id.ToString());
            HttpWebRequest req = MakeHttpRequest(reqUrlBuilder, HttpMethodNames.Delete);

            ReceiveVoidHttpResponse(req);
        }
    }
}
