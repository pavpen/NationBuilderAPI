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
        /// The index endpoint provides a paginated view of the contacts made to a person.
        /// </summary>
        /// <param name="personId">ID of the contacted person you want to get contacts for.</param>
        /// <param name="limit">Max number of results to show in one page of results. (Default: 10, max: 100).</param>
        /// <returns>The results page, and results information.</returns>
        public ResultsPageResponse<Contact> GetContactsToPerson(long personId, int limit = 10)
        {
            StringBuilder reqUrlBuilder = RequestUrlBuilderAppendQuery(
                MakeRequestUrlBuilder("people/", personId.ToString(), "/contacts"),
                "&limit=", limit.ToString());
            HttpWebRequest req = MakeHttpRequest(reqUrlBuilder);
            var res = DeserializeHttpResponse<ResultsPageResponse<Contact>>(req);

            return res;
        }

        /// <summary>
        /// Get an enumeration of all contacts to a person as <see cref="Contact"/> objects.
        /// </summary>
        /// <param name="personId">ID of the contacted person you want to get contacts for.</param>
        /// <param name="limit">The number of result to fetch in each HTTP request.  The maximum is 100.</param>
        /// <returns>An enumeration of all contacts to the person.</returns>
        public IEnumerable<Contact> GetContactsToPersonResults(long personId, int limit = 100)
        {
            return AllResultsFrom(GetContactsToPerson(personId, limit));
        }

        /// <summary>
        /// This endpoint creates a record of a contact with the provided data.
        /// It returns a full representation of the contact that was created.
        /// If the creation step fails, it returns an error.
        /// </summary>
        /// <param name="personId">ID of the person that was contacted.</param>
        /// <param name="contact">A <see cref="Contact"/> object describing the contact.</param>
        /// <returns>The newly created contact.</returns>
        public ContactResponse CreateContactToPerson(long personId, Contact contact)
        {
            StringBuilder reqUrlBuilder = MakeRequestUrlBuilder("people/", personId.ToString(), "/contacts");
            HttpWebRequest req = MakeHttpPostRequest(reqUrlBuilder, new ContactResponse { contact = contact });
            var res = DeserializeHttpResponse<ContactResponse>(req);

            return res;
        }

        /// <summary>
        /// The index endpoint provides a paginated view of contact categories defined for a nation.
        /// </summary>
        /// <param name="limit">Max number of results to show in one page of results. (Default: 10, max: 100.)</param>
        /// <returns>The results page, and results information.</returns>
        public ResultsPageResponse<ContactType> GetContactTypes(int limit = 10)
        {
            StringBuilder reqUrlBuilder = RequestUrlBuilderAppendQuery(
                MakeRequestUrlBuilder("settings/contact_types"),
                "&limit=", limit.ToString());
            HttpWebRequest req = MakeHttpRequest(reqUrlBuilder);
            var res = DeserializeHttpResponse<ResultsPageResponse<ContactType>>(req);

            return res;
        }

        /// <summary>
        /// Get an enumeration of all the contact types in the nation.
        /// </summary>
        /// <param name="limit">The number of result to fetch in each HTTP request.  The maximum is 100.</param>
        /// <returns>An enumeration of all contact types in the nation.</returns>
        public IEnumerable<ContactType> GetContactTypeResults(int limit = 100)
        {
            return AllResultsFrom(GetContactTypes(limit));
        }

        /// <summary>
        /// This endpoint creates a new contact category with the provided name.
        /// It returns a full representation of the contact category that was created.
        /// If the creation step fails, it returns an error.
        /// </summary>
        /// <param name="value">The contact type to create.</param>
        /// <returns>The newly created contact type.</returns>
        public ContactTypeResponse CreateContactType(ContactType value)
        {
            StringBuilder reqUrlBuilder = MakeRequestUrlBuilder("settings/contact_types");
            HttpWebRequest req = MakeHttpPostRequest(reqUrlBuilder, new ContactTypeResponse { contact_type = value });
            var res = DeserializeHttpResponse<ContactTypeResponse>(req);

            return res;
        }

        /// <summary>
        /// This endpoint updates a contact type with the provided id and name.
        /// It returns a full representation of the updated contact type.
        /// If the update step fails, it returns an error.
        /// </summary>
        /// <param name="id">ID of the contact type to update.</param>
        /// <param name="value">The new contact type information.</param>
        /// <returns>The updated contact type.</returns>
        public ContactTypeResponse UpdateContactType(long id, ContactType value)
        {
            StringBuilder reqUrlBuilder = MakeRequestUrlBuilder("settings/contact_types/", id.ToString());
            HttpWebRequest req = MakeHttpPostRequest(reqUrlBuilder, new ContactTypeResponse { contact_type = value }, HttpMethodNames.Put);
            var res = DeserializeHttpResponse<ContactTypeResponse>(req);

            return res;
        }

        /// <summary>
        /// This endpoint removes a contact type with the provided ID.
        /// </summary>
        /// <param name="id">ID of the contact type to destroy.</param>
        public void DestroyContactType(long id)
        {
            StringBuilder reqUrlBuilder = MakeRequestUrlBuilder("settings/contact_types/", id.ToString());
            HttpWebRequest req = MakeHttpRequest(reqUrlBuilder, HttpMethodNames.Delete);

            ReceiveVoidHttpResponse(req);
        }

        /// <summary>
        /// The index endpoint provides a view of contact methods.
        /// </summary>
        /// <param name="limit"></param>
        /// <returns>The results page, and results information.</returns>
        public ResultsPageResponse<ContactMethod> GetContactMethods(int limit = 10)
        {
            StringBuilder reqUrlBuilder = RequestUrlBuilderAppendQuery(
                MakeRequestUrlBuilder("settings/contact_methods"),
                "&limit=", limit.ToString());
            HttpWebRequest req = MakeHttpRequest(reqUrlBuilder);
            var res = DeserializeHttpResponse<ResultsPageResponse<ContactMethod>>(req);

            return res;
        }

        /// <summary>
        /// Get an enumeration of all the contact methods in the nation.
        /// </summary>
        /// <param name="limit"></param>
        /// <returns>An enumeration of all contact methods in the nation.</returns>
        public IEnumerable<ContactMethod> GetContactMethodResults(int limit = 100)
        {
            return AllResultsFrom(GetContactMethods(limit));
        }

        /// <summary>
        /// The index endpoint provides a view of contact status categories.
        /// </summary>
        /// <param name="limit"></param>
        /// <returns>The results page, and results information.</returns>
        public ResultsPageResponse<ContactStatus> GetContactStatuses(int limit = 10)
        {
            StringBuilder reqUrlBuilder = RequestUrlBuilderAppendQuery(
                MakeRequestUrlBuilder("settings/contact_statuses"),
                "&limit=", limit.ToString());
            HttpWebRequest req = MakeHttpRequest(reqUrlBuilder);
            var res = DeserializeHttpResponse<ResultsPageResponse<ContactStatus>>(req);

            return res;
        }

        /// <summary>
        /// Get an enumeration of all the contact statuses in the nation.
        /// </summary>
        /// <param name="limit"></param>
        /// <returns>An enumeration of all contact statuses in the nation.</returns>
        public IEnumerable<ContactStatus> GetContactStatusesResults(int limit = 100)
        {
            return AllResultsFrom(GetContactStatuses(limit));
        }
    }
}
