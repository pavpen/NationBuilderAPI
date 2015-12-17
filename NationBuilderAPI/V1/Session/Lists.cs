using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

using NationBuilderAPI.V1.Http;

namespace NationBuilderAPI.V1
{
    public partial class NationBuilderSession
    {
        /// <summary>
        /// The index endpoint shows a paginated list of custom lists.
        /// </summary>
        /// <param name="limit">Maximum number of results to show in one page of results. (Default: 10, max: 100.)</param>
        /// <returns>A page of <see cref="List"/> objects.</returns>
        public ResultsPageResponse<List> GetLists(int limit = 10)
        {
            StringBuilder reqUrlBuilder = RequestUrlBuilderAppendQuery(
              MakeRequestUrlBuilder("lists"),
              "&limit=", limit.ToString());
            var req = MakeHttpRequest(reqUrlBuilder);
            var res = DeserializeHttpResponse<ResultsPageResponse<List>>(req);

            return res;
        }

        /// <summary>
        /// Get an enumeration of the lists in the nation as <see cref="List"/> objects.
        /// </summary>
        /// <param name="limit">The number of result to fetch in each HTTP request.  The maximum is 100.</param>
        /// <returns>An enumeration of all lists in the nation.</returns>
        public IEnumerable<List> GetListsResults(int limit = 100)
        {
            return AllResultsFrom(GetLists(limit));
        }

        /// <summary>
        /// The people endpoint shows the people in a list.
        /// </summary>
        /// <param name="listId">ID of the list to get people from.</param>
        /// <param name="limit">Maximum number of results to show in one page of results. (Default: 10, max: 100.)</param>
        /// <returns>A page of <see cref="List"/>s.</returns>
        public ResultsPageResponse<Person> GetPeopleInList(long listId, int limit = 10)
        {
            StringBuilder reqUrlBuilder = RequestUrlBuilderAppendQuery(
                MakeRequestUrlBuilder("lists/", listId.ToString(), "/people"),
                "&limit=", limit.ToString());
            var req = MakeHttpRequest(reqUrlBuilder);
            var res = DeserializeHttpResponse<ResultsPageResponse<Person>>(req);

            return res;
        }

        /// <summary>
        /// Get an enumeration of all the people in a given list.
        /// </summary>
        /// <param name="listId">ID of the list to get people from.</param>
        /// <param name="limit">The number of result to fetch in each HTTP request.  The maximum is 100.</param>
        /// <returns>An enumeration of all the people in the given list.</returns>
        public IEnumerable<Person> GetPeopleInListResults(long listId, int limit = 100)
        {
            return AllResultsFrom(GetPeopleInList(listId, limit));
        }

        /// <summary>
        /// Creates an empty list with the given attributes.
        /// 
        /// If a list with the same slug as the list you are trying to create already exists,
        /// a <see cref="NationBuilderRemoteException"/> with <code>ExceptionCode</code> of <code>"validation_failed"</code>,
        /// and <code>HttpStatusCode</code> of <see cref="HttpStatusCode.BadRequest"/> (400) will be thrown.
        /// </summary>
        /// <param name="value">An object specifying the attributes of the list you want to create.</param>
        /// <returns>The new list.</returns>
        public ListResponse CreateList(List value)
        {
            StringBuilder reqUrlBuilder = MakeRequestUrlBuilder("lists");
            var req = MakeHttpPostRequest<ListTransportObject>(reqUrlBuilder, new ListTransportObject() { list = value });
            ListResponse res = DeserializeHttpResponse<ListResponse>(req);

            return res;
        }

        /// <summary>
        /// Creates an empty list with the given attributes.
        /// 
        /// If a list with the same slug as the list you are trying to create already exists,
        /// and the parameter <code>overwriteSlug</code> is <code>false</code>,
        /// a <see cref="NationBuilderRemoteException"/> with <code>ExceptionCode</code> of <code>"validation_failed"</code>,
        /// and <code>HttpStatusCode</code> of <see cref="HttpStatusCode.BadRequest"/> (400) will be thrown.
        /// </summary>
        /// <param name="value">An object specifying the attributes of the list you want to create.</param>
        /// <param name="overwriteSlug">Whether to destroy any already existing list with the same slug as the one to create.
        /// 
        /// Warning: Since Nation Builder does not provide operaton transactons, it is still possible for this method to fail to
        /// overwrite a list with an existing slug!
        /// </param>
        /// <returns>The new list.</returns>
        public ListResponse CreateList(List value, bool overwriteSlug)
        {
            if (overwriteSlug)
            {
                try
                {
                    return CreateList(value);
                }
                catch (NationBuilderRemoteException exc)
                {
                    if ("validation_failed" == exc.ExceptionCode && HttpStatusCode.BadRequest == exc.HttpStatusCode)
                    {
                        // Look for a list to overwrite:
                        foreach (var list in GetListsResults())
                        {
                            if (list.slug == value.slug)
                            {
                                // Overwrite the matching list:
                                DestroyList(list.id.Value);
                                return CreateList(value);
                            }
                        }
                    }
                    throw exc;
                }
            }
            else
            {
                return CreateList(value);
            }
        }

        /// <summary>
        /// Updates a list to have the given attributes.
        /// </summary>
        /// <param name="id">ID of the list to update.</param>
        /// <param name="value">An object specifying the list's new attributes.</param>
        /// <returns>The updated list.</returns>
        public ListResponse UpdateList(long id, List value)
        {
            StringBuilder reqUrlBuilder = MakeRequestUrlBuilder("lists/", id.ToString());
            var req = MakeHttpPostRequest<ListTransportObject>(reqUrlBuilder, new ListTransportObject() { list = value }, HttpMethodNames.Put);
            ListResponse res = DeserializeHttpResponse<ListResponse>(req);

            return res;
        }

        /// <summary>
        /// Destroys the indicated list.
        /// </summary>
        /// <param name="id">ID of the list to destroy.</param>
        public void DestroyList(long id)
        {
            StringBuilder reqUrlBuilder = MakeRequestUrlBuilder("lists/", id.ToString());
            var req = MakeHttpRequest(reqUrlBuilder, HttpMethodNames.Delete);

            ReceiveVoidHttpResponse(req);
        }

        /// <summary>
        /// Adds people to a list.
        /// 
        /// Note: The Nation Builder online documentation (http://nationbuilder.com/lists_api) incorrectly indicates
        /// that this endpoint returns a list description object.
        /// Calls to the service show that the endpoint returns no content.
        /// </summary>
        /// <param name="listId">ID of the list to add to.</param>
        /// <param name="peopleIds">A list containing IDs of people you want added to the list. Up to 100,000 IDs are accepted.</param>
        public void AddPeopleToList(long listId, List<long> peopleIds)
        {
            StringBuilder reqUrlBuilder = MakeRequestUrlBuilder("lists/", listId.ToString(), "/people");
            var req = MakeHttpPostRequest(reqUrlBuilder, new ListPeopleTransportObject { people_ids = peopleIds });
            
            ReceiveVoidHttpResponse(req);
        }

        /// <summary>
        /// Deletes a list of people from a list asynchronously.
        /// 
        /// After this call returns, you can expect the people to be removed from the list after a few minutes.
        /// 
        /// Note: The Nation Builder online documentation (http://nationbuilder.com/lists_api) incorrectly indicates
        /// that this method returns a list description object.
        /// Calls to the service show that the endpoint returns no content.
        /// </summary>
        /// <param name="listId">ID of the list to delete from.</param>
        /// <param name="peopleIds">A list containing IDs of people you want removed from a list. Up to 100,000 IDs are accepted.</param>
        public void DeletePeopleFromList(long listId, List<long> peopleIds)
        {
            StringBuilder reqUrlBuilder = MakeRequestUrlBuilder("lists/", listId.ToString(), "/people");
            var req = MakeHttpPostRequest(reqUrlBuilder, new ListPeopleTransportObject { people_ids = peopleIds }, HttpMethodNames.Delete);
            
            ReceiveVoidHttpResponse(req);
        }

        /// <summary>
        /// Use this endpoint to apply a tag to the people contained in a list.
        /// 
        /// Note: this endpoint returns a HTTP 204 status code, but the tag is not applied immediately.
        /// For larger lists, this operation takes many minutes.
        /// </summary>
        /// <param name="listId">ID of the list.</param>
        /// <param name="tagName">Name of the tag to add to people in the list.</param>
        public void AddTagToPeopleInList(long listId, string tagName)
        {
            StringBuilder reqUrlBuilder = MakeRequestUrlBuilder("lists/", listId.ToString(), "/tag/", Uri.EscapeDataString(tagName));
            var req = MakeHttpRequest(reqUrlBuilder, HttpMethodNames.Post);

            ReceiveVoidHttpResponse(req);
        }

        /// <summary>
        /// Use this endpoint to delete a tag from the people contained in a list.
        /// 
        /// Note: this endpoint returns a HTTP 204 status code, but the tag is not deleted immediately.
        /// For larger lists, this operation takes many minutes.
        /// </summary>
        /// <param name="listId">ID of the list.</param>
        /// <param name="tagName">Name of the tag to remove from people in the list.</param>
        public void RemoveTagFromPeopleInList(long listId, string tagName)
        {
            StringBuilder reqUrlBuilder = MakeRequestUrlBuilder("lists/", listId.ToString(), "/tag/", Uri.EscapeDataString(tagName));
            var req = MakeHttpRequest(reqUrlBuilder, HttpMethodNames.Delete);

            ReceiveVoidHttpResponse(req);
        }
    }
}
