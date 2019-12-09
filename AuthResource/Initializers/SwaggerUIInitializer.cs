using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace AuthResource.Initializers {
    public class SwaggerUIInitializer : IInitializer {
        public void InitializeServices(IServiceCollection services, IConfiguration configuration) {
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo {
                    Version = "v1",
                    Title = "Auth Resource",
                    Description = "API Documentation",
                    Contact = new OpenApiContact() {
                        Name = "Sebastian Dudas",
                        Email = "seba.med@yahoo.com",
                        Url = new System.Uri("https://github.com/sebamed")
                    },
                    License = new OpenApiLicense {
                        Name = "MIT",
                        Url = new System.Uri("https://opensource.org/licenses/MIT")
                    },
                });               
            });
        }
    }
}
