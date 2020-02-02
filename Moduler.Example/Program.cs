﻿using Microsoft.Extensions.DependencyInjection;
using Moduler.Example.Services.Abstraction;
using Moduler.Extensions;

namespace Moduler.Example
{
    internal class Program
    {
        private static void Main()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddModule<ServiceModule>();

            var provider = serviceCollection.BuildServiceProvider();
            var messageService = provider.GetRequiredService<IMessageService>();

            messageService.SendAsync("Hello");
        }
    }
}
