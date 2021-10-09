using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using MilestoneExam.WebApi.ErrorModels;
using Microsoft.AspNetCore.Http;

namespace MilestoneExam.WebApi.Middleware
{
    public static class ExceptionMiddlware
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "text/plain";
                    var exception = context.Features.Get<IExceptionHandlerFeature>().Error;
                    if (exception != null)
                    {
                        var errorModel = new ExceptionMiddlewareErrorModel(exception);

                        var cancelationToken = context.RequestAborted;

                        context.Response.StatusCode = (int)errorModel.StatusCode;
                        await context.Response.WriteAsync(errorModel.Message, cancelationToken);
                        await context.Response.CompleteAsync();
                    }
                });
            });
        }
    }
}
