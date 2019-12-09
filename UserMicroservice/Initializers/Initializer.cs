using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroservice.Initializers {
    public static class Initializer {
        public static void InitializeAll(this IServiceCollection services, IConfiguration configuration) {
            var installers = typeof(Startup).Assembly.ExportedTypes.Where(x =>
            typeof(IInitializer).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IInitializer>().ToList();

            installers.ForEach(installer => installer.InitializeServices(services, configuration));
        }
    }
}
