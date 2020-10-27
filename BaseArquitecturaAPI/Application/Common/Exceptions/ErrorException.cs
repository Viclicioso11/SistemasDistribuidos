using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Exceptions
{
    public class ErrorException : Exception
    {
        public ErrorException(string errorCode, string error) : base($"Error with code {errorCode} throw {error}")
        {

        }
    }
}
