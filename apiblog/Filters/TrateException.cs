using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
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

          //  context.Exception.InnerException.StackTrace.


            context.Response = context.Request.CreateErrorResponse(httpStatusCode,
                                                                   "Bad Request",
                                                                   context.Exception);

            var httpError = (HttpError)((ObjectContent<HttpError>)context.Response.Content).Value;

            //"\r\n".ToDictionary("a", "x");

            var xxx = "1:2,2:3".Split(',')
                           .Select(x => x.Split(':'))
                           .ToDictionary(x => int.Parse(x[0]),
                                         x => int.Parse(x[1]));


            var xxxz = "1:2,2:3".Split(',')
                          
                          .ToDictionary(x => x[0],
                                        x => x);


            var www = xxxz;

            // var c = context.Exception.StackTrace.Split('\n').Select(x => x).ToArray();
            var c = context.Exception.StackTrace;
            var cfv = context.Exception;

            var trace = new StackTrace(cfv, true);
            var frame = trace.GetFrames().First();
            var lineNumber = trace.GetFrames().First().GetFileLineNumber();
            var fileName = trace.GetFrames().First().GetFileName();

            var d = c;



#if !DEBUG
            httpError.Remove("StackTrace");
#endif
        }
    }
}