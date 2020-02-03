# Moduler
This library provide you possibility to create modules for DI, using `Microsoft.Extensions.DependencyInjection.IServiceCollection`.

#### Create module examples
```csharp
public class ServiceModule : IModule
{
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IMessageService, SmsService>();
        }
}
```

For create module you need create class and implement `IModule` interface.
`IModule` interface has just only one method `Load`, that gets `Microsoft.Extensions.DependencyInjection.IServiceCollection`.

#### Inject your modules examples

`Moduler` provide 3 possability to inject your module.
1. Using `serviceCollection.AddModules(Assembly.GetExecutingAssembly());`.  This method scans all modules for assembly, injects its to `IServiceCollection` by dynamically module instantiation.
2. Using `serviceCollection.AddModule(new ServiceModule())`. This method injects all module dependencies to `IServiceCollection` by directly module instantiation.
3. Using `serviceCollection.AddModule<ServiceModule>()`. This method injects all modules dependencies to `IServiceCollection` by dynamically module instantiation.

### Nuget
`Install-Package Moduler -Version 1.0.1`

