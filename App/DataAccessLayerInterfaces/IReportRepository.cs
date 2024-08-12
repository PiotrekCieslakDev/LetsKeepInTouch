using Domains.ReportClasses;
using Domains.ResultClasses;

namespace DataAccessLayerInterfaces
{
    public interface IReportRepository
    {
        public Report GetReportById(Guid reportId);
        public List<Report> GetAllReports();
        public List<UserReport> GetAllUserReports();
        public List<PostReport> GetAllPostReports();

        public List<Report> GetReportsByReportedUserId(Guid userId);
        public List<Report> GetAllReportsByPost(Guid postId);

        public Result CreateReport(Report reportToBeCreated);
        public Result DeleteReport(Guid reportToBeDeletedId);
        public Result UpdateReport(Report reportToBeDeleted);
    }
}
