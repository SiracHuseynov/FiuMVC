using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiu.Business.Exceptions
{
    public class FileeNotFoundException : Exception
    {
        public FileeNotFoundException(string? message) : base(message)
        {
        }
    }
}
