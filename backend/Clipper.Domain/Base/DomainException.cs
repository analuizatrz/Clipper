using System;
using System.Collections.Generic;

namespace Clipper.Domain.Base
{
    public class DomainException : ArgumentException
    {
        public List<string> ErrorMessages { get; set; }

        public DomainException(List<string> ErrorMessagess)
        {
            ErrorMessages = ErrorMessagess;
        }
    }
}