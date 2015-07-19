using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;

namespace NationBuilderAPI.V1
{
    /// <summary>
    /// Base class for exceptions that represent known HTTP error responses from the Nation Builder service.
    /// </summary>
    [ComVisible(true)]
    public class NationBuilderException : Exception
    {
        public NationBuilderException(string message, Exception innerException) : base(message, innerException) { }
    }

    [ComVisible(true)]
    public class NationBuilderRemoteException : NationBuilderException
    {
        public string ExceptionCode;
        public HttpStatusCode HttpStatusCode;

        public NationBuilderRemoteException(HttpStatusCode httpStatusCode, string exceptionCode, string message, Exception innerException = null)
            : base(message, innerException)
        {
            this.HttpStatusCode = httpStatusCode;
            this.ExceptionCode = exceptionCode;
        }
    }
}
