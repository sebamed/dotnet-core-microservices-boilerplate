using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthResource.Services;
using AuthResource.Services.Implementation;
using AuthResource.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace AuthResource.Initializers {

    /**
     * Class that initializes singletons neccesary for DI
     */
    public class SingletonInitializer : IInitializer {

        public void InitializeServices(IServiceCollection services, IConfiguration configuration) {

            services.AddSingleton<IAuthService, AuthService>();
            services.AddTransient<JwtGenerator>();

        }
    }
}
