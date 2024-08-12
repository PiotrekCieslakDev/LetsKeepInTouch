using Domains.UserClasses;

namespace LogicLayer.ModerationClasses.ModerationReviews
{
    public class ModerationReview
    {
        public ModerationReview(User banningAdmin)
        {
            BanningAdmin = banningAdmin;
        }

        public User BanningAdmin { get; }
    }
}
