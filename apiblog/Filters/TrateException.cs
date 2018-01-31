using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace apiblog.Filters
{
    public class TrateException : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var StatusCode = context.Exception.Data["statusCode"];

            var httpStatusCode = HttpStatusCode.InternalServerError;
            if (!(StatusCode == null))
            {
                httpStatusCode = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), StatusCode.ToString(), true);
            }

            context.Response = context.Request.CreateErrorResponse(httpStatusCode,
                                                                   "Bad Request",
                                                                   context.Exception);

            var httpError = (HttpError)((ObjectContent<HttpError>)context.Response.Content).Value;
 
            var Exception = context.Exception;

            var trace = new StackTrace(Exception, true);
            var FileName = trace.GetFrame(0).GetFileName();

            #if DEBUG
            httpError.Add("File", FileName);
            #endif
            #if !DEBUG
            httpError.Remove("StackTrace");
            #endif
        }
    }
}