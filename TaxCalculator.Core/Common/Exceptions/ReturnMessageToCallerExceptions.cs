using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator.Core.Common.Exceptions
{
    public class ReturnMessageToCallerExceptions : ExceptionBase
    {
        public ReturnMessageToCallerExceptions(string message) : base(message)
        {
        }
    }
}
