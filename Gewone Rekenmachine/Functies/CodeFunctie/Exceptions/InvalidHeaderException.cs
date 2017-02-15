using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gewone_Rekenmachine
{
    public class InvalidHeaderException : Exception
    {
        public InvalidHeaderException(string message)
            : base(message)
        {
        }
    }
}
