using Domains.ReportClasses;
using Domains.UserClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.ReportStrategies.SortAndFilterReports
{
    public class FilterReportsByUserIdentifier : ISortFilterReports
    {
        private string _searchPhrase;

        public FilterReportsByUserIdentifier(string searchPhrase)
        {
            _searchPhrase = searchPhrase;
        }

        public List<Report> SortAndFilter(List<Report> givenReports)
        {
            _searchPhrase = _searchPhrase.ToLower();
            List<Report> filteredReports = new List<Report>();

            if (!string.IsNullOrEmpty(_searchPhrase))
            {
                foreach (Report report in givenReports)
                {
                    bool matchesSearch = false;

                    if (report is PostReport postReport)
                    {
                        matchesSearch = postReport.ReportedPost.Author
                            .GetFullNameWithUserNameAndEmail().ToLower().Contains(_searchPhrase);
                    }
                    else if (report is UserReport userReport)
                    {
                        matchesSearch = userReport.ReportedUser
                            .GetFullNameWithUserNameAndEmail().ToLower().Contains(_searchPhrase);
                    }

                    if (matchesSearch)
                    {
                        filteredReports.Add(report);
                    }
                }
            }

            return filteredReports;
        }

    }
}
