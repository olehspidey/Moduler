using System;
using Microsoft.Extensions.DependencyInjection;

namespace Moduler.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddModule(this IServiceCollection serviceCollection, IModule module)
        {
            if (module == null)
                throw new ArgumentNullException(nameof(module));

            module.Load(serviceCollection);

            return serviceCollection;
        }

        public static IServiceCollection AddModule<TModule>(this IServiceCollection serviceCollection)
            where TModule : IModule
        {
            var module = Activator.CreateInstance<TModule>();

            module.Load(serviceCollection);

            return serviceCollection;
        }

        public static IServiceCollection AddModule<TModule>(this IServiceCollection serviceCollection, Func<IServiceCollection, TModule> implementFunc)
            where TModule : IModule
        {
            var module = implementFunc(serviceCollection);

            module.Load(serviceCollection);

            return serviceCollection;
        }
    }
}