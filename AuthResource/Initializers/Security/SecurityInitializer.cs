using AuthResource.Initializers.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthResource.Initializers {
    public class SecurityInitializer : IInitializer {
        public void InitializeServices(IServiceCollection services, IConfiguration configuration) {
            services.Configure<AudienceModel>(configuration.GetSection("Audience"));
        }
    }
}
