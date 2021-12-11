using Microsoft.Extensions.DependencyInjection;
using System;
using TKMaster.ProjetoAula.Core.IoC;

namespace TKMaster.ProjetoAula.Core.WebApi.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            BootStrapper.RegisterServices(services);
        }
    }
}
