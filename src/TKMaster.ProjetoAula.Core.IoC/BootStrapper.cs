using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using TKMaster.ProjetoAulaAdilson.Core.Data;
using TKMaster.ProjetoAulaAdilson.Core.Domain.Interfaces.Notifications;
using TKMaster.ProjetoAulaAdilson.Core.Domain.Notifications;

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

            #endregion

            #region InfraData

            services.AddScoped<MeuContextoBD>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            #endregion
        }
    }
}
