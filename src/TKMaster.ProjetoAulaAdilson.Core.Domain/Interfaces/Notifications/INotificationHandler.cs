using System.Threading.Tasks;

namespace TKMaster.ProjetoAulaAdilson.Core.Domain.Interfaces.Notifications
{
    public interface INotificationHandler<T> where T : class 
    {
        Task Handle(T notification);
    }
}
