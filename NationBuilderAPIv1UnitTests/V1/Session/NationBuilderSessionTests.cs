using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NationBuilderAPIv1UnitTests.V1
{
    [TestClass]
    public partial class NationBuilderSessionTests
    {
        string TestNationSlug;
        string TestNationAccessToken;

        public NationBuilderSessionTests()
        {
            try {
                TestNationSlug = Settings.Settings.Default.TestNationSlug;
                TestNationAccessToken = Settings.Settings.Default.TestNationAccessToken;
            }
            catch (Exception exc)
            {
                throw new InvalidOperationException(
                    "Failed to read from configuration store.  You can use the UnitTestConfiguration utility to create one, and set configuration options.", exc);
            }
            if (String.IsNullOrWhiteSpace(TestNationSlug))
            {
                throw new ArgumentException("Empty TestNationSlug configuration option.  You can use the UnitTestConfiguration utility to set configuration options.");
            }
            if (String.IsNullOrWhiteSpace(TestNationAccessToken))
            {
                throw new ArgumentException("Empty TestNationAccessToken configuration option.  You can use the UnitTestConfiguration utility to set configuration options.");
            }
        }
    }
}
