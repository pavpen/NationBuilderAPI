using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationBuilderAPI.V1.Smtp
{
    public class EmailAddress
    {
        /// <summary>
        /// Test if two e-mail addresses are the same.
        /// 
        /// According to RFC, the hostname part of an e-mail address is case-insensitive, but the
        /// username part is subject to interpretation by the e-mail host it resides at, and its
        /// case-sensitivity should be preserved.
        /// 
        /// This method tests the hostname part case-insensitively, and the username part
        /// case-sensitively.
        /// </summary>
        /// <param name="email1">The first e-mail to compare.</param>
        /// <param name="email2">The second e-mail to compare.</param>
        /// <returns>Whether the e-mails are the same.</returns>
        public static bool AreEqual(string email1, string email2)
        {
            if (null == email1)
            {
                return null == email2;
            }

            var email1Parsed = new EmailAddress(email1);
            var email2Parsed = new EmailAddress(email2);

            return email1Parsed.Username.Equals(email2Parsed.Username) &&
                email1Parsed.Hostname.Equals(email2Parsed.Hostname, StringComparison.CurrentCultureIgnoreCase);
        }


        public string Username;
        public string Hostname;

        public EmailAddress(string username, string hostname)
        {
            this.Username = username;
            this.Hostname = hostname;
        }

        public EmailAddress(string email)
        {
            int atIndex = email.IndexOf('@');

            if (atIndex < 0)
            {
                throw new ArgumentException("The given e-mail address contains no @ character: " + email);
            }

            Username = email.Substring(0, atIndex);
            Hostname = email.Substring(atIndex + 1);
        }
    }
}
