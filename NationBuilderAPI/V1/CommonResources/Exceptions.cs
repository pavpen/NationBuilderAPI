using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;

using NationBuilderAPI.V1.Http;

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
        public RemoteException RemoteException;
        public NationBuilderWebRequest NationBuilderRequest;

        public NationBuilderRemoteException(HttpStatusCode httpStatusCode,
            RemoteException remoteException, NationBuilderWebRequest nationBuilderRequest, Exception innerException = null)
            : base(GetMessage(remoteException), innerException)
        {
            this.HttpStatusCode = httpStatusCode;
            this.ExceptionCode = null == remoteException.code ? remoteException.error : remoteException.code;
            this.RemoteException = remoteException;
            this.NationBuilderRequest = nationBuilderRequest;
        }

        private static string GetMessage(RemoteException remoteException)
        {
            string message = null == remoteException.message ? remoteException.error_description : remoteException.message;

            if (null != remoteException.validation_errors)
            {
                message += " Validation errors: " + String.Join("; ", remoteException.validation_errors) + ".";
            }

            return message;
        }
    }
}
