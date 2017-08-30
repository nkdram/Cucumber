using Autofac.Integration.Mvc;
using Cucumber.Core.Infrastructure;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Cucumber.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Inialize Controller Factory

            InitContainer();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            App_Start.BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        /// <summary>
        /// Initialize Container
        /// </summary>
        private void InitContainer()
        {
            CucumberContext.Initialize();
            CucumberContext.Current.DataPath = HttpContext.Current.Server.MapPath("~/App_Data/Site_Data/");

            var cdr = new CustomDependencyResolver(
                new AutofacDependencyResolver(CucumberContext.Current.IoCContainerManager.Container),
                DependencyResolver.Current);

            DependencyResolver.SetResolver(cdr);

            var controllerFactory = new AutofacControllerFactory(CucumberContext.Current.IoCContainerManager.Container);

            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}
