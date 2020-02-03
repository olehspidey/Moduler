using Microsoft.Extensions.DependencyInjection;
using Moduler.Tests.Fixtures.FixtureServices;
using Moduler.Tests.Fixtures.FixtureServices.Abstraction;

namespace Moduler.Tests.Fixtures
{
    public class ModuleFixture : IModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IMessageService, EmailService>();
        }
    }
}