using System;
using System.Linq;
using System.Reflection;

namespace Moduler.Helpers
{
    internal static class ExceptionsHelper
    {
        public static void ThrowIfNotRelevantConstructor(Type moduleType)
        {
            var constructors = moduleType.GetConstructors(BindingFlags.Public | BindingFlags.Instance);

            if (!constructors.Any(ci => !ci.GetParameters().Any()))
                throw new NotSupportedException($"Module {moduleType} does not have public constructor without parameters");
        }
    }
}