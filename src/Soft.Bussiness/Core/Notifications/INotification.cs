using System.Collections.Generic;

namespace Soft.Bussiness.Core.Notifications
{
    public interface INotification
    {
        void AddNotification(string message);
        IEnumerable<string> GetNotifications();
        bool HasNotifications();
    }
}
