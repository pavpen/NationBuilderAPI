using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Utilities;
using NationBuilderAPI.V1;
using NationBuilderAPI.V1.Http;

namespace NationBuilderAPIv1UnitTests.V1.Serialization
{
    [TestClass]
    public class Person
    {
        [TestMethod]
        public void ShowPersonDeserialization()
        {
            string personJson;
            var httpTransport = new NationBuilderHttpTransport();
            PersonResponse<Person> res;

            personJson = DeserializationTestCases.ShowPersonResponse_withNullDonationFields_json;
            res = httpTransport.DeserializeNationBuilderObject<PersonResponse<Person>>(personJson.ToMemoryStream());

            personJson = DeserializationTestCases.ShowPersonResponse_withAuthorField_json;
            res = httpTransport.DeserializeNationBuilderObject<PersonResponse<Person>>(personJson.ToMemoryStream());
        }
    }
}
