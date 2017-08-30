using System;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Core.Lifetime;
using Autofac.Integration.Mvc;

namespace Cucumber.Core.Infrastructure
{
   public class IocContainerManager
    {
        #region Fields

        private readonly IContainer _container;

        #endregion

        #region Ctor

        public IocContainerManager(IContainer container)
        {
            _container = container;
        }

        #endregion

        #region Properties

        public IContainer Container
        {
            get
            {
                return _container;
            }
        }

        #endregion

        #region Methods

        public object Resolve(Type type, ILifetimeScope scope = null)
        {
            return DependencyResolver.Current.GetService(type);
        }

        public T Resolve<T>(Type type)
        {
            return DependencyResolver.Current.GetService<T>();
        }

        public ILifetimeScope Scope()
        {
            if (HttpContext.Current != null)
                return AutofacDependencyResolver.Current.RequestLifetimeScope;
            return Container.BeginLifetimeScope(MatchingScopeLifetimeTags.RequestLifetimeScopeTag);
        }

        #endregion
    }
}

