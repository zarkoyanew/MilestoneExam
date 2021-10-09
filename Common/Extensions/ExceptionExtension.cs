using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilestoneExam.Common.Extensions
{
    public static class ExceptionExtension
    {
        public static Exception GetInnerException(this Exception ex)
        {
            var innerException = ex;

            while(innerException?.InnerException != null)
            {
                innerException = innerException.InnerException;
            }

            return innerException;
        }
    }
}
