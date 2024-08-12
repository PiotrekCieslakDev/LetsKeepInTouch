using Domains.UserClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.ModerationClasses.ModerationReviews
{
    public class UserModerationReview : ModerationReview
    {
        public UserModerationReview(User banningAdmin, bool banAuthor, bool restrictAllPostsMadeByUser) : base(banningAdmin)
        {
            BanAuthor = banAuthor;
            RestrictAllPostsMadeByUser = restrictAllPostsMadeByUser;
        }

        public bool BanAuthor { get; }
        public bool RestrictAllPostsMadeByUser { get; }
    }
}
