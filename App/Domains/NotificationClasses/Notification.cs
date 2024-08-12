using Domains.UserClasses;

namespace Domains.NotificationClasses
{
    public abstract class Notification
    {
        private Guid _id;
        protected User _addressee;
        private DateTime _timestamp;

        public Notification(User adressee)
        {
            _id = Guid.NewGuid();
            _timestamp = DateTime.Now;
            _addressee = adressee;
        }

        public Notification(Guid id, DateTime timestamp, User adressee)
        {
            _id = id;
            _timestamp = timestamp;
            _addressee = adressee;
        }

        public Guid Id { get => _id; }
        public User Addressee { get => _addressee; }
        public DateTime Timestamp { get => _timestamp; }

        public virtual string ShowNotification()
        {
            return "You recevied a notification.";
        }
    }
}
