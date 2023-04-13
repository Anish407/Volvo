using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator.Core.Common.Exceptions
{
    public class ExceptionBase
       : Exception
    {
        public string Details { get; set; }

        public int StatusCode { get; set; } = 500;

        public ExceptionBase(string message, string details = "") : base(message)
        {
            Details = details;
        }
    }
}
