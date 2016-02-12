using System;
using System.Net;
using System.Runtime.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NationBuilderAPI.V1;
using NationBuilderAPIv1UnitTests.V1;

namespace NationBuilderAPIv1UnitTests.V1.CustomFieldsSession
{
    [TestClass]
    public class CustomPeopleTests : NationBuilderSessionTests
    {
        [DataContract]
        class CustomPerson : Person
        {
            [DataMember]
            double height;
        }

        [DataContract]
        class CustomDonation : Donation
        {
            [DataMember]
            string in_memory_of;
        }


        [TestMethod]
        public void ShowPerson()
        {
            using (var session = new NationBuilderSession<CustomPerson, CustomDonation>(TestNationSlug, TestNationAccessToken))
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
