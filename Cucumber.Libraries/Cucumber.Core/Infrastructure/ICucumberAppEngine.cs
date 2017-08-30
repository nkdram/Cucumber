using System;

namespace Cucumber.Core.Infrastructure
{
    /// <summary>
    /// Cucumber Engine
    /// </summary>
    public interface ICucumberAppEngine
    {
        /// <summary>
        /// Container Manager
        /// </summary>
        IocContainerManager IoCContainerManager { get; }

        /// <summary>
        /// Data path of JSON
        /// </summary>
        string DataPath { get; set; }

        /// <summary>
        /// Logger attached to Current App Context
        /// </summary>
        Cucumber.Core.Base.ILogger Logger { get; }

        /// <summary>
        /// Initilize Dependencies
        /// </summary>
        void Initialize();

        /// <summary>
        /// Resolve a Type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        object Resolve(Type type);
    }
}

