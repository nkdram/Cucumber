using Autofac;
using Cucumber.Core.Infrastructure;

namespace Cucumber.Service
{
    public class RegisterContainer : IContainerRegistrar
    {
        public int Order
        {
            get
            {
                return 1;
            }
        }

        public void Register(ContainerBuilder builder)
        {
            //Repository Layer
            builder.RegisterType<Cucumber.Repository.Common.CommonRepository>().As<Cucumber.Repository.Common.ICommonRepository>();

            //Service Layer
            builder.RegisterType<Cucumber.Service.Log.Logger>().As<Cucumber.Core.Base.ILogger>();
            builder.RegisterType<Cucumber.Service.Common.CommonService>().As<Cucumber.Service.Common.ICommonService>();
        }
    }

}
