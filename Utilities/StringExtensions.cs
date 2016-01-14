using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Utilities
{
    public static class StringExtensions
    {
        public static MemoryStream ToMemoryStream(this string self)
        {
            var res = new MemoryStream(self.Length);
            var writer = new StreamWriter(res);

            writer.Write(self);
            writer.Flush();
            res.Position = 0;

            return res;
        }
    }
}
