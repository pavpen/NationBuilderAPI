using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NationBuilderAPI.V1;

namespace NationBuilderAPIv1UnitTests.V1
{
    public partial class NationBuilderSessionTests
    {
        [TestMethod]
        public void GetPeopleResults()
        {
            using (var session = new NationBuilderSession(TestNationSlug, TestNationAccessToken))
            {
                // Test parsing all people in the nation:
                foreach (var person in session.GetPeopleResults())
                {
                    Assert.IsTrue(person.id.HasValue);
                }
            }
        }

        // This is rather slow.  Enable when needed.
        //[TestMethod]
        public void ParseAllPeople()
        {
            using (var session = new NationBuilderSession(TestNationSlug, TestNationAccessToken))
            {
                bool parsedCouldVote = false;

                foreach (var person in session.GetPeopleResults())
                {
                    var personResponse = session.ShowPerson(person.id.Value);

                    Assert.IsTrue(personResponse.person.id.HasValue);
                    if (personResponse.person.could_vote_status.HasValue)
                    {
                        parsedCouldVote = true;
                    }
                }

                System.Diagnostics.Trace.WriteLine("ParsedCouldVote: " + parsedCouldVote);
            }
        }

        [TestMethod]
        public void PersonMe()
        {
            using (var session = new NationBuilderSession(TestNationSlug, TestNationAccessToken))
            {
                var personResponse = session.PersonMe();
                var person = personResponse.person;

                Assert.IsTrue(person.id.HasValue);
                Assert.AreNotEqual(person.created_at, DateTimeOffset.MinValue);
                Assert.AreNotEqual(person.created_at, DateTimeOffset.MaxValue);
                Assert.AreNotEqual(person.updated_at, DateTimeOffset.MinValue);
                Assert.AreNotEqual(person.updated_at, DateTimeOffset.MaxValue);
            }
        }

        [TestMethod]
        public void ShowPerson()
        {
            using (var session = new NationBuilderSession(TestNationSlug, TestNationAccessToken))
            {
                var personMeResponse = session.PersonMe();
                var personMe = personMeResponse.person;

                Assert.IsTrue(personMe.id.HasValue);

                var shownPersonResponse = session.ShowPerson(personMe.id.Value);
                var shownPerson = shownPersonResponse.person;

                Assert.AreEqual(personMe, shownPerson);

                // Make sure equality testing is, possibly, functioning:
                shownPerson.first_name += "suff";
                Assert.AreNotEqual(shownPerson, personMe);

                shownPerson.first_name = personMe.first_name;
                Assert.AreEqual(shownPerson, personMe);

                shownPerson.author_id += "suff";
                Assert.AreNotEqual(shownPerson, personMe);
            }
        }

        [TestMethod]
        public void ShowPerson_WithNonExistentId()
        {
            using (var session = new NationBuilderSession(TestNationSlug, TestNationAccessToken))
            {
                long testId;
                var testPerson = new Person()
                {
                    first_name = "Tes",
                    last_name = "Per",
                    email = "mess@age.net",
                };

                try
                {
                    var personResponse = session.MatchPerson(testPerson.email, testPerson.first_name, testPerson.last_name);

                    testId = personResponse.person.id.Value;
                }
                catch (NationBuilderRemoteException exc)
                {
                    if ("no_matches" == exc.ExceptionCode || "multiple_matches"==exc.ExceptionCode)
                    {
                        // Allocate a new person ID:
                        var newPersonResponse = session.CreatePerson(testPerson);

                        testId = newPersonResponse.person.id.Value;
                    }
                    else
                    {
                        throw exc;
                    }
                }

                // Make sure there's no person with that ID:
                session.DestroyPerson(testId);

                try
                {
                    var nonExistentPersonResponse = session.ShowPerson(testId);
                }
                catch (NationBuilderRemoteException exc)
                {
                    Assert.AreEqual("not_found", exc.ExceptionCode);
                    Assert.AreEqual(HttpStatusCode.NotFound, exc.HttpStatusCode);
                    return;
                }

                Assert.Fail("ShowPerson() did not thrown an exception with the expected parameters!");
            }
        }

        [TestMethod]
        public void ShowPersonWithExternalId()
        {
            using (var session = new NationBuilderSession(TestNationSlug, TestNationAccessToken))
            {
                // Test remote ID escaping:
                string testId = "h!6&access_token=null";

                // Create a test person object:
                var testPerson = new Person()
                {
                    first_name = "Tes",
                    last_name = "Per",
                    email = "mess@age.net",
                    external_id = testId,
                };
                var newPersonResponse = session.PushPerson(testPerson);

                Assert.AreEqual(newPersonResponse.person.external_id, testId);
                Assert.IsTrue(newPersonResponse.person.id.HasValue);

                var showPersonResponse = session.ShowPersonWithExternalId(testId);

                Assert.AreEqual(showPersonResponse.person.id, newPersonResponse.person.id);
                Assert.AreEqual(showPersonResponse.person.external_id, testId);

                // Remove the test person object:
                session.DestroyPerson(newPersonResponse.person.id.Value);
            }
        }

        [TestMethod]
        public void ShowPersonWithExternalId_WithNonExistentId()
        {
            using (var session = new NationBuilderSession(TestNationSlug, TestNationAccessToken))
            {
                // Test remote ID escaping:
                string testId = "h!6&access_token=null";

                try
                {
                    var nonExistentPersonResponse = session.ShowPersonWithExternalId(testId);
                }
                catch (NationBuilderRemoteException exc)
                {
                    Assert.AreEqual("not_found", exc.ExceptionCode);
                    Assert.AreEqual(HttpStatusCode.NotFound, exc.HttpStatusCode);
                    return;
                }

                Assert.Fail("ShowPersonWithExternalId() did not throw an exception with the expected parameters!");
            }
        }
    }
}
