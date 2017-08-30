using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Cucumber.Core.Infrastructure
{
    /// <summary>
    /// Custom depency Resolver
    /// </summary>
    public class CustomDependencyResolver : IDependencyResolver
    {

        IDependencyResolver _fallbackResolver;
        IDependencyResolver _newResolver;

        /// <summary>
        /// Custom Dependency Resolver with a fallback
        /// </summary>
        /// <param name="newResolver"></param>
        /// <param name="fallbackResolver"></param>
        public CustomDependencyResolver(IDependencyResolver newResolver, IDependencyResolver fallbackResolver)
        {
            _newResolver = newResolver;
            _fallbackResolver = fallbackResolver;
        }

        /// <summary>
        /// Provides the type registered in Container
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            object result = null;

            result = _newResolver.GetService(serviceType);

            if (result != null)
            {
                return result;
            }

            return _fallbackResolver.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            IEnumerable<object> results = null;

            results = _newResolver.GetServices(serviceType);

            if (results != null)
            {
                return results;
            }

            return _fallbackResolver.GetServices(serviceType);
        }
    }
}


