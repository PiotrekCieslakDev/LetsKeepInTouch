using Domains.ReportClasses;

namespace LogicLayer.ReportStrategies.SortAndFilterReports
{
    public class SearchPostReportsOnly : ISortFilterReports
    {
        public List<Report> SortAndFilter(List<Report> givenReports)
        {
            return givenReports.FindAll(report => report is PostReport);
        }
    }
}
