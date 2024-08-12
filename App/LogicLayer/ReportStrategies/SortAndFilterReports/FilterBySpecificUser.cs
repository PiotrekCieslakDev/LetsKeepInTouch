using Domains.ReportClasses;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.ReportStrategies.SortAndFilterReports
{
    public class FilterBySpecificUser : ISortFilterReports
    {
        private Guid _userId;

        public FilterBySpecificUser(Guid userId)
        {
            _userId = userId;
        }

        public List<Report> SortAndFilter(List<Report> givenReports)
        {
            List<Report> filteredReports = new List<Report>();

            if (_userId != Guid.Empty)
            {
                foreach (Report report in givenReports)
                {
                    bool matchesSearch = false;

                    if (report is PostReport postReport)
                    {
                        matchesSearch = postReport.ReportedPost.Author.Id == _userId;
                    }
                    else if (report is UserReport userReport)
                    {
                        matchesSearch = userReport.ReportedUser.Id == _userId;
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
