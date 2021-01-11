﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string error) : base(error)
        {

        }
    }
}
