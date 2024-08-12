using DataAccessLayerInterfaces;
using Domains.NotificationClasses;
using Domains.ResultClasses;
using Domains.UserClasses;
using LogicLayerInterfaces;

namespace LogicLayer.Services
{
    public class NotificationService : INotificationService
    {
        private List<Notification> _notifications = new List<Notification>();
        private INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }


        public List<Notification> GetAllNotifications()
        {
            return _notifications;
        }
        public Notification? GetNotificationById(Guid notificationId)
        {
            return _notifications.Find(notification => notification.Id == notificationId);
        }
        public List<Notification>? GetNotificationsByAddressee(Guid adresseeId)
        {
            return _notifications.FindAll(notification => notification.Addressee.Id == adresseeId);
        }


        public Result CreateNotification(Notification notification)
        {
            _notifications.Add(notification);
            return new Result(true, "Notification created");
        }
    }
}
