using DataAccessLayerInterfaces;

namespace LogicLayer.ModerationClasses.ModerationRepositoriesInitializators
{
    public class ModerationRepositories
    {
        internal readonly IReportRepository _reportRepository;

        public ModerationRepositories(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
    }
}
