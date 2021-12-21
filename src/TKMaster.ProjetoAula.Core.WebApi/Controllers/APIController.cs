using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TKMaster.ProjetoAulaAdilson.Core.Domain.Interfaces.Notifications;
using TKMaster.ProjetoAulaAdilson.Core.Domain.Notifications;
using TKMaster.ProjetoAulaAdilson.Core.WebApi.ViewModels.Responses;

namespace TKMaster.ProjetoAulaAdilson.Core.WebApi.Controllers
{
    public class APIController : ControllerBase
    {
        #region Properties

        protected readonly DomainNotificationHandler _notifications;
        protected IEnumerable<DomainNotification> Notifications =>
                    _notifications.GetNotifications();

        #endregion

        #region Constructor

        public APIController(INotificationHandler<DomainNotification> notification)
        {
            _notifications = (DomainNotificationHandler)notification;
        }

        #endregion

        #region Methods

        protected bool IsValidOperation() =>
           (!_notifications.HasNotifications());

        protected new IActionResult Response(object result = null)
        {
            if (IsValidOperation())
            {
                return Ok(new ResponseSuccesso<object>
                {
                    Success = true,
                    Data = result
                });
            }

            return Conflict(new ResponseFalha
            {
                Success = false,
                Errors = _notifications.GetNotifications().Select(n => n.Value)
            });
        }

        #endregion
    }
}
