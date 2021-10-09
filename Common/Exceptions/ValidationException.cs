using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilestoneExam.Common.Exceptions
{
    public class ValidationException : Exception
    {
        private const string ValidationFaild = "Validation Failed.";
        
        public ValidationException() : base(ValidationFaild) { }

        public ValidationException(string message) : base(message ?? ValidationFaild) { }

        public override string ToString()
        {
            return Message;
        }
    }
}
