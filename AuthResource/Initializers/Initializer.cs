using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace AuthResource.Initializers {
    public static class Initializer {
        public static void InitializeAll(this IServiceCollection services, IConfiguration configuration) {
            var installers = typeof(Startup).Assembly.ExportedTypes.Where(x =>
            typeof(IInitializer).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IInitializer>().ToList();

            installers.ForEach(installer => installer.InitializeServices(services, configuration));
        }
    }
}
