using Domains.ReportClasses;
using LogicLayer.ReportStrategies.SortAndFilterReports;

namespace LogicLayer.ReportStrategies
{
    public class SearchUserReportsOnly : ISortFilterReports
    {
        public List<Report> SortAndFilter(List<Report> givenReports)
        {
            return givenReports.FindAll(report => report is UserReport).ToList();
        }
    }
}
