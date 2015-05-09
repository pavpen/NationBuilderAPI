using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NationBuilderAPI.V1;

namespace NationBuilderAPIv1UnitTests.V1
{
    public partial class NationBuilderSessionTests
    {
        [TestMethod]
        public void GetPeopleTagResults_GetPeopleWithTagResults()
        {
            using (var session = new NationBuilderSession(TestNationSlug, TestNationAccessToken))
            {
                foreach (var tag in session.GetPeopleTagsResults())
                {
                    Assert.IsNotNull(tag.name);
                    foreach (var person in session.GetPeopleWithTagResults(tag.name))
                    {
                        Assert.IsTrue(person.id.HasValue);
                    }
                }
            }
        }
    }
}
