﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Core.Exceptions
{
    public class UnauthorisedException : CustomException
    {
        public UnauthorisedException(string message = "You are not allowed to perform this operation.") : base(message)
        {

        }
    }
}
