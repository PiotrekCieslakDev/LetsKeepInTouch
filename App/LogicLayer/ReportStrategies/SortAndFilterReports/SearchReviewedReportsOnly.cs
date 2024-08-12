using Domains.ReportClasses;

namespace LogicLayer.ReportStrategies.SortAndFilterReports
{
    public class SearchReviewedReportsOnly : ISortFilterReports
    {
        public List<Report> SortAndFilter(List<Report> givenReports)
        {
            return givenReports.FindAll(report => report.Reviewed).ToList();
        }
    }
}
