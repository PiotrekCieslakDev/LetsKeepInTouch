using Domains.ReportClasses;
using Domains.ResultClasses;
using LogicLayer.LoginClasses.LoginStrategies;
using LogicLayer.ModerationClasses.ModerationRepositoriesInitializators;
using LogicLayer.ModerationClasses.ModerationReviews;

namespace LogicLayer.ModerationClasses.ModerationStrategies
{
    public interface IModerationStrategy
    {
        public Result ReviewReport(ModerationReview moderationReview, ModerationRepositories moderationRepositories);
    }
}
