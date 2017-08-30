using Autofac;

namespace Cucumber.Core.Infrastructure
{
    public interface IContainerRegistrar
    {
        void Register(ContainerBuilder builder);

        int Order { get; }
    }
}



