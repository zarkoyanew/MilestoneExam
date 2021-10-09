using MilestoneExam.Common.Exceptions;
using MilestoneExam.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MilestoneExam.WebApi.ErrorModels
{
    public class ExceptionMiddlewareErrorModel
    {
        public string Message { get; private set; }

        public HttpStatusCode StatusCode { get; private set; }

        public ExceptionMiddlewareErrorModel(Exception ex)
        {
            PopulateProperties(ex);
        }

        private void PopulateProperties(Exception ex)
        {
            var innerException = ex.GetInnerException();

            Message = innerException.Message;

            switch (innerException)
            {
                case EntityNotFoundException:
                    StatusCode = HttpStatusCode.NotFound;
                    break;
                case ValidationException:
                    StatusCode = HttpStatusCode.BadRequest;
                    break;
                default:
                    StatusCode = HttpStatusCode.InternalServerError;
                    break;
            }
        }
    }
}
