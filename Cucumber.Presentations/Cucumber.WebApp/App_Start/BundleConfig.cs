using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Cucumber.WebApp.App_Start
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;

            bundles.Add(new ScriptBundle("~/bundles/Scripts/Global").Include(new string[]
             {
                "~/Scripts/jquery-3.2.min.js",
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.unobtrusive.min.js",
                "~/Scripts/jquery.unobtrusive-ajax.min.js",
                "~/Styles/js/popper.js",
                "~/Scripts/Bootstrap.min.js",
                "~/Styles/js/cleansheet.js"
             }));

            bundles.Add(new ScriptBundle("~/bundles/Scripts/Custom").Include(new string[]
            {
                "~/Scripts/Custom/Conversion.js",
                "~/Scripts/Custom/Settings.js"
            }));

            bundles.Add(new StyleBundle("~/bundles/Styles/Global").Include(new string[]
            {
                "~/Styles/css/bootstrap.min.css",
                "~/Styles/css/cleansheet.css"
            }));

            bundles.Add(new StyleBundle("~/bundles/Styles/Custom").Include(new string[]
           {
               "~/Styles/css/custom.css"
           }));
        }
    }


}