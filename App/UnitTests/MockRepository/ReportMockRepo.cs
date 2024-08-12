using DataAccessLayerInterfaces;
using Domains.ReportClasses;
using Domains.ResultClasses;

namespace UnitTests.MockRepository
{
    internal class ReportMockRepo : IReportRepository
    {
        public Result CreateReport(Report reportToBeCreated)
        {
            throw new NotImplementedException();
        }

        public Result DeleteReport(Guid reportToBeDeletedId)
        {
            throw new NotImplementedException();
        }

        public List<PostReport> GetAllPostReports()
        {
            throw new NotImplementedException();
        }

        public List<Report> GetAllReports()
        {
            throw new NotImplementedException();
        }

        public List<Report> GetAllReportsByPost(Guid postId)
        {
            throw new NotImplementedException();
        }

        public List<UserReport> GetAllUserReports()
        {
            throw new NotImplementedException();
        }

        public Report GetReportById(Guid reportId)
        {
            throw new NotImplementedException();
        }

        public List<Report> GetReportsByReportedUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Result UpdateReport(Report reportToBeDeleted)
        {
            throw new NotImplementedException();
        }
    }
}
