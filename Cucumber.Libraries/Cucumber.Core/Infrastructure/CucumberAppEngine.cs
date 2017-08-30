using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Integration.Mvc;


namespace Cucumber.Core.Infrastructure
{
    public class CucumberAppEngine : ICucumberAppEngine
    {
        #region Fields
        private IocContainerManager _containerManager;
        private Cucumber.Core.Base.ILogger _logger;
        //Default path
        private string _dataPath ="/App_Data/Site_Data/";

        #endregion

        #region Utilities

        protected void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            //dependencies
            builder.RegisterInstance(this).As<ICucumberAppEngine>().SingleInstance();

            //Register all controllers 
            builder.RegisterControllers(AppDomain.CurrentDomain.GetAssemblies()
                .Where(s => s.FullName.Contains("Cucumber.WebApp")).ToArray());

            //register dependencies provided by other assemblies
            var type = typeof(IContainerRegistrar);

            var drTypes = AppDomain.CurrentDomain.GetAssemblies()
                .Where(s => s.FullName.Contains("Cucumber."))
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface);

            var drInstances = new List<IContainerRegistrar>();

            foreach (var drType in drTypes)
                drInstances.Add((IContainerRegistrar)Activator.CreateInstance(drType));

            //sort
            drInstances = drInstances.AsQueryable().OrderBy(t => t.Order).ToList();

            foreach (var dependencyRegistrar in drInstances)
                dependencyRegistrar.Register(builder);

            var container = builder.Build();

            _containerManager = new IocContainerManager(container);
        }

        #endregion

        #region Methods

        public void Initialize()
        {
            //register dependencies
            RegisterDependencies();
        }

        public object Resolve(Type type)
        {
            return IoCContainerManager.Resolve(type);
        }

        public T Resolve<T>(Type type)
        {
            return IoCContainerManager.Resolve<T>(type);
        }

        #endregion

        #region Properties        

        public IocContainerManager IoCContainerManager
        {
            get { return _containerManager; }
        }

        public string DataPath
        {
            get
            {
                return _dataPath;
            }
            set
            {
                _dataPath = value;
            }
        }

        public Cucumber.Core.Base.ILogger Logger
        {
            get
            {
                if (_logger == null)
                {
                    _logger = this.Resolve<Cucumber.Core.Base.ILogger>(typeof(Cucumber.Core.Base.ILogger)); 
                }
                return _logger;
            }
        }

        #endregion
    }
}
