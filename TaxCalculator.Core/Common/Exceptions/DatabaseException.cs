using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator.Core.Common.Exceptions
{
    public class DatabaseException : ExceptionBase
    {
        public DatabaseException(string message, string details)
            : base(message, details)
        {
            StatusCode = 400;
        }
    }
}
