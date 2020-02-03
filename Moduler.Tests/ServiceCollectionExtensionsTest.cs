using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Moduler.Extensions;
using Moduler.Test.WrongFixtures;
using Moduler.Tests.Fixtures;
using Moduler.Tests.Fixtures.FixtureServices;
using Moduler.Tests.Fixtures.FixtureServices.Abstraction;
using Xunit;

namespace Moduler.Tests
{
    public class ServiceCollectionExtensionsTest : IClassFixture<ModuleFixture>
    {
        private readonly ModuleFixture _moduleFixture;

        public ServiceCollectionExtensionsTest(ModuleFixture moduleFixture)
        {
            _moduleFixture = moduleFixture;
        }

        [Fact]
        public void Should_Inject_Module_With_Directly_Instantiation()
        {
            var serviceCollections = new ServiceCollection();

            serviceCollections.AddModule(_moduleFixture);

            var serviceProvider = serviceCollections.BuildServiceProvider();
            var messageService = serviceProvider.GetService<IMessageService>();

            Assert.NotNull(messageService);
            Assert.IsType<EmailService>(messageService);
        }

        [Fact]
        public void Should_Inject_Module_With_Dynamic_Instantiation()
        {
            var serviceCollections = new ServiceCollection();

            serviceCollections.AddModule<ModuleFixture>();

            var serviceProvider = serviceCollections.BuildServiceProvider();
            var messageService = serviceProvider.GetService<IMessageService>();

            Assert.NotNull(messageService);
            Assert.IsType<EmailService>(messageService);
        }

        [Fact]
        public void Should_Inject_Modules_With_Assembly_Scan_Instantiation()
        {
            var serviceCollections = new ServiceCollection();

            serviceCollections.AddModules(Assembly.GetExecutingAssembly());

            var serviceProvider = serviceCollections.BuildServiceProvider();
            var messageService = serviceProvider.GetService<IMessageService>();

            Assert.NotNull(messageService);
            Assert.IsType<EmailService>(messageService);
        }

        [Fact]
        public void Should_Throw_Exception_If_Module_Without_Default_Constructor_With_Dynamic_Instantiation()
        {
            var serviceCollections = new ServiceCollection();

            Assert.Throws<NotSupportedException>(() => { serviceCollections.AddModule<WrongModuleFixture>(); });
        }

        [Fact]
        public void Should_Throw_Exception_If_Module_Is_Null_Constructor_With_Directly_Instantiation()
        {
            var serviceCollections = new ServiceCollection();

            Assert.Throws<ArgumentNullException>(() => { serviceCollections.AddModule(null); });
        }

        [Fact]
        public void Should_Throw_Exception_If_Module_Is_Null_Constructor_With_Assembly_Scan_Instantiation()
        {
            var serviceCollections = new ServiceCollection();

            Assert.Throws<ArgumentNullException>(() => { serviceCollections.AddModules(null); });
        }

        [Fact]
        public void Should_Throw_Exception_If_Module_Without_Default_Constructor_With_Assembly_Scan_Instantiation()
        {
            var serviceCollections = new ServiceCollection();

            Assert.Throws<NotSupportedException>(() =>
            {
                serviceCollections.AddModules(Assembly.GetAssembly(typeof(WrongModuleFixture)));
            });
        }
    }
}
