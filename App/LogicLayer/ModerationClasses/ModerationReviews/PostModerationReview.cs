using Domains.UserClasses;

namespace LogicLayer.ModerationClasses.ModerationReviews
{
    public class PostModerationReview : ModerationReview
    {
        public PostModerationReview(User banningAdmin, bool restrictPost, bool banAuthor, bool restrictAllPostsMadeByUser) : base(banningAdmin)
        {
            RestrictPost = restrictPost;
            BanAuthor = banAuthor;
            RestrictAllPostsMadeByUser = restrictAllPostsMadeByUser;
        }

        public bool RestrictPost { get; }
        public bool BanAuthor { get; }
        public bool RestrictAllPostsMadeByUser { get; }
    }
}
