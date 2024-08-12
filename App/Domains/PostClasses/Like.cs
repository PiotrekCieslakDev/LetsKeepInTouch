using Domains.UserClasses;

namespace Domains.PostClasses
{
    public class Like
    {
        private Guid _id;
        private User _likingUser;

        public Like(User likingUser)
        {
            _id = Guid.NewGuid();
            _likingUser = likingUser;
        }

        public Like(Guid id, User likingUser)
        {
            _id = id;
            _likingUser = likingUser;
        }

        public User LikingUser { get { return _likingUser; } }
    }
}
