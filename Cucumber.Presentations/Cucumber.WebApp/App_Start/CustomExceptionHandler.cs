using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cucumber.WebApp.App_Start
{
    public class CustomExceptionHandler : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Cucumber.Core.Infrastructure.CucumberContext.Current.Logger.Error(filterContext.Exception.ToString(), filterContext.Exception);
        }
    }
}