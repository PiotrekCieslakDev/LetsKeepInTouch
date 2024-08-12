using Domains.PostClasses;
using Domains.UserClasses;

namespace Domains.NotificationClasses
{
    public class NotificationPostCommented : NotificationPostInteraction
    {
        public NotificationPostCommented(User adressee, User postInteractor, MainPost interactedPost) : base(adressee, postInteractor, interactedPost)
        {
        }

        public NotificationPostCommented(Guid id, DateTime timestamp, User adressee, User postInteractor, MainPost interactedPost) : base(id, timestamp, adressee, postInteractor, interactedPost)
        {
        }

        public override string ShowNotification()
        {
            return $"{_postInteractor.UserName} commented on your post!";
        }
    }
}
