using System.Collections.Generic;
using System.Linq;
using UserRandom.Domain.Notification.Contracts;

namespace UserRandom.Domain.Notification
{
    public class Notifier : INotifier
    {
        private List<Domain.Notification.Notification> _notifies;
        public Notifier()
        {
            _notifies = new List<Domain.Notification.Notification>();
        }
        public List<Domain.Notification.Notification> GetNotifications()
        {
            return _notifies;
        }

        public void Handle(Domain.Notification.Notification notification)
        {
            _notifies.Add(notification);
        }

        public bool HasNotification()
        {
            return _notifies.Any();
        }
    }
}
