
using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;
using System.Text;
using System;
using Microsoft.AspNetCore.Hosting;

namespace ShoppingCore.Infrastructure.Utils.Exceptions
{
    public class CoreExceptionFilter : IActionFilter, IExceptionFilter
    {
        private readonly IHostingEnvironment env;
        public CoreExceptionFilter(IHostingEnvironment env)
        {
            this.env = env;
        }

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is HttpResponseException exception)
            {
                context.Result = new Microsoft.AspNetCore.Mvc.ObjectResult(exception.Message)
                {
                    StatusCode = exception.Status,
                };
                context.ExceptionHandled = true;
            }
        }

        public void OnException(ExceptionContext context)
        {
            AddToLog(context.Exception, Path.Combine(env.ContentRootPath, "App_Data", "Logs", "ErrorLog.txt"));
        }

        public static void AddToLog(Exception exception, string path)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(DateTime.Now.ToLocalTime().ToString("F"));
            GetExceptionInfo(exception, sb);
            sb.AppendLine("------------------------------------------------------------" + Environment.NewLine);
            File.AppendAllText(path, sb.ToString());
        }

        private static void GetExceptionInfo(Exception exception, StringBuilder sb)
        {
            sb.AppendLine(exception.GetType().ToString());
            sb.AppendLine(exception.Message);
            sb.AppendLine("Stack Trace: ");
            sb.AppendLine(exception.StackTrace);
            //    if (exception is DashboardDataLoadingException)
            //    {
            //        foreach (var dataLoadingError in ((DashboardDataLoadingException)exception).Errors)
            //        {
            //            sb.AppendLine("InnerException: ");
            //            GetExceptionInfo(dataLoadingError.InnerException, sb);
            //        }
            //    }
            //    if (exception.InnerException != null)
            //    {
            //        sb.AppendLine("InnerException: ");
            //        GetExceptionInfo(exception.InnerException, sb);
            //    }
        }
    }
}
