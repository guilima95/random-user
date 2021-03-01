using System;
using System.Collections.Generic;
using System.Text;

namespace UserRandom.Domain.Notification.Contracts
{
    public interface INotifier
    {
        List<Notification> GetNotifications();
        void Handle(Notification notification);
        bool HasNotification();

    }
}
