using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NationBuilderAPI.V1;

namespace NationBuilderAPIv1UnitTests.V1
{
    public partial class NationBuilderSessionTests
    {
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
    }
}
