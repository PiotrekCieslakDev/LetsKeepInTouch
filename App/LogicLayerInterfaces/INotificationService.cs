using Domains.NotificationClasses;
using Domains.ResultClasses;
using Domains.UserClasses;

namespace LogicLayerInterfaces
{
    public interface INotificationService
    {
        public List<Notification> GetAllNotifications();
        public Notification? GetNotificationById(Guid id);
        public List<Notification>? GetNotificationsByAddressee(Guid addresseeId);

        public Result CreateNotification(Notification notification);
    }
}
