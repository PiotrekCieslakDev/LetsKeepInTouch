using Domains.PostClasses;
using Domains.UserClasses;

namespace Domains.NotificationClasses
{
    public class NotificationPostLiked : NotificationPostInteraction
    {
        public NotificationPostLiked(User adressee, User postInteractor, MainPost interactedPost) : base(adressee, postInteractor, interactedPost)
        {
        }

        public NotificationPostLiked(Guid id, DateTime timestamp, User adressee, User postInteractor, MainPost interactedPost) : base(id, timestamp, adressee, postInteractor, interactedPost)
        {
        }

        public override string ShowNotification()
        {
            return $"{_postInteractor.UserName} liked your post!";
        }
    }
}
