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
            var personJson = ShowPersonResponse1_json.Value;
            var httpTransport = new NationBuilderHttpTransport();

            PersonResponse res = httpTransport.DeserializeNationBuilderObject<PersonResponse>(personJson.ToMemoryStream());
        }
    }
}
