using Domains.PostClasses;
using Domains.UserClasses;

namespace Domains.NotificationClasses
{
    public class NotificationPostRestricted : Notification
    {
        private MainPost _restrictedPost;

        public NotificationPostRestricted(User adressee, MainPost restrictedPost) : base(adressee)
        {
            _addressee = restrictedPost.Author;
            _restrictedPost = restrictedPost;
        }

        public NotificationPostRestricted(Guid id, DateTime timestamp, User adressee, MainPost restrictedPost) : base(id, timestamp, adressee)
        {
            _addressee = restrictedPost.Author;
            _restrictedPost = restrictedPost;
        }

        public override string ShowNotification()
        {
            return $"Your post posted on {_restrictedPost.PostContents.First().CreationTime} has been restricted.";
        }
    }
}
