using Domains.ReportClasses;
using Domains.UserClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.ModerationClasses.ModerationReviews
{
    internal class UserModerationReview : ModerationReview
    {
        public UserModerationReview(User banningAdmin, Report reportToBeReviewed, bool banAuthor, bool restrictAllPostsMadeByUser) : base(banningAdmin, reportToBeReviewed)
        {
            BanAuthor = banAuthor;
            RestrictAllPostsMadeByUser = restrictAllPostsMadeByUser;
        }

        public bool BanAuthor { get; }
        public bool RestrictAllPostsMadeByUser { get; }
    }
}
