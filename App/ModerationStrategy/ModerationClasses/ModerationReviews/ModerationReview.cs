using Domains.ReportClasses;
using Domains.UserClasses;

namespace LogicLayer.ModerationClasses.ModerationReviews
{
    public class ModerationReview
    {
        public ModerationReview(User banningAdmin, Report reportToBeReviewed)
        {
            BanningAdmin = banningAdmin;
            ReportToBeReviewed = reportToBeReviewed;
        }

        public User BanningAdmin { get; }
        public Report ReportToBeReviewed { get; }
    }
}
