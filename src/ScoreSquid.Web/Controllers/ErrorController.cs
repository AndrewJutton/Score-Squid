using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Elmah;
using ScoreSquid.Web.ErrorHandling;

namespace ScoreSquid.Web.Controllers
{
    public class ErrorController : Controller
    {
        public void LogJavaScriptError(string message)
        {
            ErrorSignal
                .FromCurrentContext()
                .Raise(new JavaScriptException(message));
        }
    }
}
