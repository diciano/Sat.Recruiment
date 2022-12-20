using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruiment.Model.Exceptions
{
    public class DuplicateUserException : Exception
    {
        public DuplicateUserException(string message) : base(message)
        {
        }
    }
}
