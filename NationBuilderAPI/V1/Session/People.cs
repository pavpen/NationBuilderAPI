using System;
using System.Collections.Generic;
using System.Net;
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
        public PeopleIndexResponse GetPeople(int page = 1, int per_page = 10)
        {
            StringBuilder reqUrlBuilder = RequestUrlBuilderAppendQuery(
                MakeRequestUrlBuilder("people"),
                "&page=", page.ToString(),
                "&per_page=", per_page.ToString());
            HttpWebRequest req = MakeHttpRequest(reqUrlBuilder);
            PeopleIndexResponse res = DeserializeHttpResponse<PeopleIndexResponse>(req);

            return res;
        }

        /// <summary>
        /// The Show endpoint returns a full representation of the person with the provided ID.
        /// </summary>
        /// <param name="id">ID of the person to retrieve.</param>
        /// <param name="idType">Type of ID to use, set to <c>"external"</c> to show the person based on their external ID. Leave as <c>null</c> to use NationBuilder's ID.</param>
        /// <returns>The full person information.</returns>
        public PersonShowResponse ShowPerson(long id, string idType = null)
        {
            StringBuilder reqUrlBuilder = MakeRequestUrlBuilder("people/", id.ToString());
            if (null != idType)
            {
                reqUrlBuilder = RequestUrlBuilderAppendQuery(reqUrlBuilder, "&id_type=", idType.ToString());
            }

            HttpWebRequest req = MakeHttpRequest(reqUrlBuilder);
            PersonShowResponse res = DeserializeHttpResponse<PersonShowResponse>(req);

            return res;
        }
    }
}
