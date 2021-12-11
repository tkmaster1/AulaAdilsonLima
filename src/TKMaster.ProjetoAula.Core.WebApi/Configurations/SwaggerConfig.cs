using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;

namespace TKMaster.ProjetoAula.Core.WebApi.Configurations
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc
                (
                    "v1"
                    , new OpenApiInfo
                    {
                        Version = configuration["AppSettings:Application:Version"],
                        Title = "Exemplo para aula Core API",
                        Description = "Teste Core API Swagger",
                        Contact = new OpenApiContact
                        {
                            Name = "Exemplo para aula",
                            Email = ""
                        }
                    }
                );

                s.CustomSchemaIds(x => x.FullName);
                s.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
        }
    }
}
