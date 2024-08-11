using System.Collections.Generic;
using System.Linq;

namespace Soft.Bussiness.Core.Notifications
{
    public class Notification : INotification
    {
        private readonly List<string> _notifications = new List<string>();

        public void AddNotification(string message)
        {
            _notifications.Add(message);
        }

        public IEnumerable<string> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotifications()
        {
            return _notifications.Any();
        }
    }
}







