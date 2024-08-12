using Domains.PostClasses;
using Domains.ReportClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.ReportStrategies.SortAndFilterReports
{
    public interface ISortFilterReports
    {
        public List<Report> SortAndFilter(List<Report> givenReports);
    }
}
