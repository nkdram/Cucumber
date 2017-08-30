using Autofac;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Cucumber.Core.Infrastructure
{
    /// <summary>
    /// Auto Fac Controller Factory
    /// </summary>
    public class AutofacControllerFactory : DefaultControllerFactory
    {
        #region Fields

        private IContainer _container;

        #endregion

        #region Ctor

        public AutofacControllerFactory(IContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            _container = container;
        }

        #endregion

        #region Methods

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (requestContext == null)
            {
                throw new ArgumentNullException(nameof(requestContext));
            }

            if (controllerType == null)
            {
                throw new HttpException(404,
                    string.Format("No Controller Type Found For Path {0}", requestContext.HttpContext.Request.Path));
            }

            object controller;

            if (_container.TryResolve(controllerType, out controller))
            {
                return (IController)controller;
            }

            throw new HttpException(404,
                string.Format("No Controller Type: {0} Found For Path {1}", controllerType.FullName,
                    requestContext.HttpContext.Request.Path));
        }

        public override void ReleaseController(IController controller)
        {

        }

        #endregion
    }
}
