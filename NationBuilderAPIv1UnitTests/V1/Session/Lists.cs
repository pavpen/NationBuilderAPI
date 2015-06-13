using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NationBuilderAPI.V1;

namespace NationBuilderAPIv1UnitTests.V1
{
    public partial class NationBuilderSessionTests
    {
        [TestMethod]
        public void GetListsResults()
        {
            using (var session = new NationBuilderSession(TestNationSlug, TestNationAccessToken))
            {
                int listCount = 0;

                // Test parsing all lists in the nation:
                foreach (var list in session.GetListsResults())
                {
                    Assert.IsTrue(list.id.HasValue);
                    Assert.IsTrue(list.count.HasValue);
                    ++listCount;
                }

                if (listCount < 1)
                {
                    Assert.Inconclusive("Zero lists found in the configured test nation.");
                }
            }
        }

        [TestMethod]
        public void GetListsPeopleResults()
        {
            using (var session = new NationBuilderSession(TestNationSlug, TestNationAccessToken))
            {
                int listCount = 0;
                int totalPersonCount = 0;

                // Test parsing all people in all lists in the nation:
                foreach (var list in session.GetListsResults())
                {
                    Assert.IsTrue(list.id.HasValue);
                    Assert.IsTrue(list.count.HasValue);
                    ++listCount;

                    int personCount = 0;

                    foreach (var person in session.GetPeopleInListResults(list.id.Value))
                    {
                        Assert.IsTrue(person.id.HasValue);
                        ++personCount;
                    }
                    Assert.AreEqual(list.count.Value, personCount);
                    totalPersonCount += personCount;
                }

                if (listCount < 1)
                {
                    Assert.Inconclusive("Zero lists found in the configured nation.");
                }
                if (totalPersonCount < 1)
                {
                    Assert.Inconclusive("Zero total number of people found in all of the nation's lists.");
                }
            }
        }

        [TestMethod]
        public void CreateUpdateDestroyList()
        {
            using (var session = new NationBuilderSession(TestNationSlug, TestNationAccessToken))
            {
                var personSelf = session.PersonMe().person;
                var testList = new List { name = "teslist", slug = "utest_lugs", author_id = personSelf.id.Value };
                List newList = session.CreateList(testList, true).list_resource;

                Assert.IsTrue(newList.id.HasValue);
                Assert.IsTrue(newList.count.HasValue);
                Assert.AreEqual(newList.count.Value, 0);
                Assert.AreEqual(testList.name, newList.name);
                Assert.AreEqual(testList.slug, newList.slug);

                newList.name += " +1";
                
                var updatedList = session.UpdateList(newList.id.Value, newList).list_resource;

                Assert.IsTrue(updatedList.id.HasValue);
                Assert.AreEqual(updatedList.id.Value, newList.id.Value);
                Assert.IsTrue(updatedList.count.HasValue);
                Assert.AreEqual(updatedList.count.Value, newList.count.Value);
                Assert.AreEqual(newList.name, updatedList.name);

                session.AddPeopleToList(newList.id.Value, new List<long> { personSelf.id.Value });

                session.DeletePeopleFromList(newList.id.Value, new List<long> { personSelf.id.Value });

                session.DestroyList(newList.id.Value);

                // Make sure the list was deleted:
                foreach (var list in session.GetListsResults())
                {
                    Assert.IsTrue(list.id.HasValue);
                    if (newList.id.Value == list.id.Value)
                    {
                        Assert.Fail("DestroyList operation did not delete the list from the nation!");
                    }
                }
            }
        }
    }
}
