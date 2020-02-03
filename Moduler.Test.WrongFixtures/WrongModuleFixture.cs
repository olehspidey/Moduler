using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Moduler.Tests")]
namespace Moduler.Test.WrongFixtures
{
    internal class WrongModuleFixture : IModule
    {
        private WrongModuleFixture()
        {

        }

        public void Load(IServiceCollection serviceCollection)
        {

        }
    }
}