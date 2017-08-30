using Autofac;

namespace Cucumber.Core.Infrastructure
{
    /// <summary>
    /// Registering contariner
    /// </summary>
    public interface IContainerRegistrar
    {
        /// <summary>
        /// Register Conainer Builder
        /// </summary>
        /// <param name="builder"></param>
        void Register(ContainerBuilder builder);

        /// <summary>
        /// Provide order in which it should get registered
        /// </summary>
        int Order { get; }
    }
}



