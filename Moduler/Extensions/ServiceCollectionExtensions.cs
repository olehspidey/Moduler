using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Moduler.Helpers;

namespace Moduler.Extensions
{
    /// <summary>
    /// Represents light way extension class for creating service modules
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// This extension method injects all module dependencies to <see cref="IServiceCollection"/> by directly module instantiation
        /// </summary>
        /// <param name="serviceCollection">Collections of DI services</param>
        /// <param name="module">Inject module</param>
        /// <returns>Collections of DI services <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddModule(this IServiceCollection serviceCollection, IModule module)
        {
            if (module == null)
                throw new ArgumentNullException(nameof(module));

            module.Load(serviceCollection);

            return serviceCollection;
        }

        /// <summary>
        /// This extension method injects all modules dependencies to <see cref="IServiceCollection"/> by dynamically module instantiation
        /// </summary>
        /// <typeparam name="TModule">Realization type of <see cref="IModule"/></typeparam>
        /// <param name="serviceCollection">Collections of DI services</param>
        /// <returns>Collections of DI services <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddModule<TModule>(this IServiceCollection serviceCollection)
            where TModule : IModule
        {
            var moduleType = typeof(TModule);

            ExceptionsHelper.ThrowIfNotRelevantConstructor(moduleType);

            var module = (IModule)Activator.CreateInstance(moduleType);

            module.Load(serviceCollection);

            return serviceCollection;
        }

        /// <summary>
        /// This extension method scans all modules for assembly, injects its to <see cref="IServiceCollection"/> by dynamically module instantiation
        /// </summary>
        /// <param name="serviceCollection">Collections of DI services</param>
        /// <param name="scanAssembly">Assembly for scanning modules</param>
        /// <returns>Collections of DI services <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddModules(this IServiceCollection serviceCollection, Assembly scanAssembly)
        {
            if (scanAssembly == null)
                throw new ArgumentNullException(nameof(scanAssembly));

            var moduleTypes = scanAssembly
                .GetTypes()
                .Where(type => type.GetInterfaces().Any(interfaceType => interfaceType == typeof(IModule)));

            foreach (var moduleType in moduleTypes)
            {
                ExceptionsHelper.ThrowIfNotRelevantConstructor(moduleType);

                var module = (IModule)Activator.CreateInstance(moduleType);

                module.Load(serviceCollection);
            }

            return serviceCollection;
        }
    }
}