using Domains.PostClasses;
using Domains.UserClasses;

namespace Domains.NotificationClasses
{
    public class NotificationPostInteraction : Notification
    {
        protected User _postInteractor;
        protected MainPost _interactedPost;

        public NotificationPostInteraction(User adressee, User postInteractor, MainPost interactedPost) : base(adressee)
        {
            _postInteractor = postInteractor;
            _interactedPost = interactedPost;
        }

        public NotificationPostInteraction(Guid id, DateTime timestamp, User adressee, User postInteractor, MainPost interactedPost) : base(id, timestamp, adressee)
        {
            _postInteractor = postInteractor;
            _interactedPost = interactedPost;
        }
    }
}
