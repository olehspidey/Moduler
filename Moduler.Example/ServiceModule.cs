using Microsoft.Extensions.DependencyInjection;
using Moduler.Example.Services;
using Moduler.Example.Services.Abstraction;

namespace Moduler.Example
{
    public class ServiceModule : IModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IMessageService, SmsService>();
        }
    }
}