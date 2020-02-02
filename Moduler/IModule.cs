using Microsoft.Extensions.DependencyInjection;

namespace Moduler
{
    public interface IModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}