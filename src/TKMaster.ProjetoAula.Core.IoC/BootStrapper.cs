using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using TKMaster.ProjetoAulaAdilson.Core.Data;
using TKMaster.ProjetoAulaAdilson.Core.Data.Repository;
using TKMaster.ProjetoAulaAdilson.Core.Domain.Interfaces.Notifications;
using TKMaster.ProjetoAulaAdilson.Core.Domain.Interfaces.Repositories;
using TKMaster.ProjetoAulaAdilson.Core.Domain.Interfaces.Services;
using TKMaster.ProjetoAulaAdilson.Core.Domain.Notifications;
using TKMaster.ProjetoAulaAdilson.Core.Service.Application;

namespace TKMaster.ProjetoAulaAdilson.Core.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Lifestyle.Transient => Uma instância para cada solicitação
            // Lifestyle.Singleton => Uma instância única para a classe (para servidor)
            // Lifestyle.Scoped    => Uma instância única para o request

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            #region Domain

            services.AddScoped<IClienteAppService, ClienteAppService>();

            #endregion

            #region InfraData

            services.AddScoped<MeuContextoBD>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IClienteRepository, ClienteRepository>();

            #endregion
        }
    }
}
