using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKMaster.ProjetoAulaAdilson.Core.Domain.Interfaces.Notifications;

namespace TKMaster.ProjetoAulaAdilson.Core.Domain.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        #region Properties

        private IList<DomainNotification> _notifications;

        #endregion

        #region Constructor

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        #endregion


        #region Methods

        public Task Handle(DomainNotification message)
        {
            _notifications.Add(message);
            return Task.CompletedTask;
        }

        public virtual IList<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public virtual bool HasNotifications()
        {
            return GetNotifications().Any();
        }

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }

        #endregion
    }
}
