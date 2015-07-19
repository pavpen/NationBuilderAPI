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
        public void GetContactsToPersonResults()
        {
            using (var session = new NationBuilderSession(TestNationSlug, TestNationAccessToken))
            {
                int contactsCount = 0;
                int peopleCount = 0;

                // Test parsing all contacts in the nation:
                foreach (var person in session.GetPeopleResults())
                {
                    foreach (var contact in session.GetContactsToPersonResults(person.id.Value))
                    {
                        ++contactsCount;
                    }
                    ++peopleCount;
                }

                if (contactsCount < 1)
                {
                    Assert.Inconclusive("Zero contacts found in the configured test nation.");
                }

                System.Diagnostics.Trace.WriteLine("Retrieved ard parsed " + contactsCount + (1 == contactsCount ? " contact" : " contacts") +
                    " for " + peopleCount + (1 == peopleCount ? " person" : " people") + ".");
            }
        }

        [TestMethod]
        public void GetContactTypeResults()
        {
            using (var session = new NationBuilderSession(TestNationSlug, TestNationAccessToken))
            {
                int typeCount = 0;

                // Test parsing all contact types:s
                foreach (var contactType in session.GetContactTypeResults())
                {
                    Assert.IsTrue(contactType.id.HasValue);
                    ++typeCount;
                }

                if (typeCount < 1)
                {
                    Assert.Inconclusive("Zero contact types found in the configured test nation.");
                }
            }
        }

        [TestMethod]
        public void CreateUpdateDestroyContactType()
        {
            using (var session = new NationBuilderSession(TestNationSlug, TestNationAccessToken))
            {
                // Create a temporary test contact type:
                var aTestContactType = new ContactType()
                {
                    name = "Test Contact Type Drive 2015",
                };
                var newContactTypeResponse = session.CreateContactType(aTestContactType);

                Assert.IsTrue(newContactTypeResponse.contact_type.id.HasValue);
                Assert.AreEqual(newContactTypeResponse.contact_type.name, aTestContactType.name);

                var testContactType = newContactTypeResponse.contact_type;
                
                Assert.IsTrue(DoesContactTypeExist(session, testContactType));

                // Update the contact type:
                testContactType.name += "+1";
                var contactTypeResponse = session.UpdateContactType(testContactType.id.Value, testContactType);

                Assert.AreEqual(testContactType.id, contactTypeResponse.contact_type.id);
                Assert.AreEqual(testContactType.name, contactTypeResponse.contact_type.name);

                Assert.IsTrue(DoesContactTypeExist(session, testContactType));

                // Destroy the contact type:
                session.DestroyContactType(testContactType.id.Value);
                // It seems that destruction is asynchronous, and doesn't occur imeediately:
                for (int c = 0; c < 5; ++c)
                {
                    session.PersonMe();
                }
                Assert.IsFalse(DoesContactTypeExist(session, testContactType));
            }
        }

        [TestMethod]
        public void CreateContactToPerson()
        {
            using (var session = new NationBuilderSession(TestNationSlug, TestNationAccessToken))
            {
                var testSender = session.PersonMe().person;
                
                Person testPerson;
                ContactType testContactType;
                ContactMethod testContactMethod;
                ContactStatus testContactStatus;

                CreateTestContactObjects(session, out testPerson, out testContactType, out testContactMethod, out testContactStatus);

                // Create a test contact to a person:
                var testContact = new Contact()
                {
                    type_id = testContactType.id.Value,
                    method = testContactMethod.api_name,
                    sender_id = testSender.id.Value,
                    status = testContactStatus.api_name,
                    note = "Tasted well",
                };
                var contactResponse = CreateTestContact(session, testPerson.id.Value, testContact);

                // Test destroying the contact type:
                session.DestroyContactType(testContactType.id.Value);

                //foreach (var contact in session.GetContactsToPersonResults(testPerson.id.Value))
                //{
                //    Assert.AreNotEqual(contact.type_id, testContactType.id.Value);
                //}

                // Destroy temporary objects:
                session.DestroyPerson(testPerson.id.Value);
            }
        }

        private bool DoesContactTypeExist(NationBuilderSession session, ContactType value)
        {
            foreach (var contactType in session.GetContactTypeResults())
            {
                if (value.Equals(contactType))
                {
                    Assert.AreEqual(value.id, contactType.id);
                    Assert.AreEqual(value.name, contactType.name);

                    return true;
                }
            }

            return false;
        }

        private void CreateTestContactObjects(NationBuilderSession session, out Person testPerson, out ContactType testContactType, out ContactMethod testContactMethod,
            out ContactStatus testContactStatus)
        {
            // Create a temporary test person object:
            var aTestPerson = new Person()
            {
                first_name = "Tes",
                last_name = "Per",
                email = "mess@age.net",
            };
            var newPersonResponse = session.PushPerson(aTestPerson);

            Assert.IsTrue(newPersonResponse.person.id.HasValue);
            Assert.AreEqual(newPersonResponse.person.first_name, aTestPerson.first_name);
            Assert.AreEqual(newPersonResponse.person.last_name, aTestPerson.last_name);
            Assert.AreEqual(newPersonResponse.person.email, aTestPerson.email);

            testPerson = newPersonResponse.person;

            // Create a temporary test contact type:
            var aTestContactType = new ContactType()
            {
                name = "Test Contact Type Drive 2015",
            };
            try
            {
                var newContactTypeResponse = session.CreateContactType(aTestContactType);

                Assert.IsTrue(newContactTypeResponse.contact_type.id.HasValue);
                Assert.AreEqual(newContactTypeResponse.contact_type.name, aTestContactType.name);

                testContactType = newContactTypeResponse.contact_type;
            }
            catch (NationBuilderRemoteException exc)
            {
                if (HttpStatusCode.BadRequest == exc.HttpStatusCode && "Validation Failed." == exc.Message)
                {
                    // A contact type with that name probably already exists, attempt to find it:
                    testContactType = null;

                    foreach (var contactType in session.GetContactTypeResults())
                    {
                        if (contactType.name == aTestContactType.name)
                        {
                            testContactType = contactType;
                            break;
                        }
                    }

                    Assert.IsNotNull(testContactType);
                }
                else
                {
                    throw exc;
                }
            }

            // Find a test contact method:
            ContactMethod aTestContactMethod = null;

            foreach (var contactMethod in session.GetContactMethodResults())
            {
                aTestContactMethod = contactMethod;
                break;
            }
            if (null == aTestContactMethod)
            {
                throw new InvalidOperationException("No available contact methods found for testing.");
            }

            testContactMethod = aTestContactMethod;

            // Find a test contact status:
            ContactStatus aTestContactStatus = null;

            foreach (var contactStatus in session.GetContactStatusesResults())
            {
                aTestContactStatus = contactStatus;
                break;
            }
            if (null == aTestContactStatus)
            {
                throw new InvalidOperationException("No available contact statuses found for testing.");
            }

            testContactStatus = aTestContactStatus;
        }

        private ContactResponse CreateTestContact(NationBuilderSession session, long contactedPersonId, Contact contact)
        {
            var contactResponse = session.CreateContactToPerson(contactedPersonId, contact);

            Assert.AreEqual(contactResponse.contact.type_id, contact.type_id);
            Assert.AreEqual(contactResponse.contact.method, contact.method);
            Assert.AreEqual(contactResponse.contact.sender_id, contact.sender_id);
            Assert.AreEqual(contactResponse.contact.status, contact.status);
            Assert.AreEqual(contactResponse.contact.note, contact.note);

            bool foundContact = false;

            foreach (var personContact in session.GetContactsToPersonResults(contactedPersonId))
            {
                if (contactResponse.contact.Equals(personContact))
                {
                    foundContact = true;
                    break;
                }
            }
            Assert.IsTrue(foundContact);

            return contactResponse;
        }
    }
}
