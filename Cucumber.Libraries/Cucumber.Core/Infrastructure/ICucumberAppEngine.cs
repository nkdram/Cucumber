using System;

namespace Cucumber.Core.Infrastructure
{
    public interface ICucumberAppEngine
    {
        IocContainerManager IoCContainerManager { get; }

        string DataPath { get; set; }

        Cucumber.Core.Base.ILogger Logger { get; }

        void Initialize();

        object Resolve(Type type);
    }
}

