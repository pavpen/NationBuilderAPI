using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace NationBuilderAPI.V1.AutoSerializable
{
    static class Base
    {
        public static string DateTimeGetSerializationForm(DateTime? value)
        {
            return value.HasValue ?
                value.Value.ToString(NationBuilderHttpTransport.DefaultDateTimeFormatString, CultureInfo.InvariantCulture) : null;
        }

        public static string DateTimeGetSerializationForm(DateTime value)
        {
            return value.ToString(NationBuilderHttpTransport.DefaultDateTimeFormatString, CultureInfo.InvariantCulture);
        }

        public static DateTime? NullableDateTimeDeserialize(string value)
        {
            return null == value ?
                (DateTime?)null :
                DateTime.ParseExact(value, NationBuilderHttpTransport.DefaultDateTimeFormatString, CultureInfo.InvariantCulture);
        }

        public static DateTime DateTimeDeserialize(string value)
        {
            return DateTime.ParseExact(value, NationBuilderHttpTransport.DefaultDateTimeFormatString, CultureInfo.InvariantCulture);
        }
    }
}
