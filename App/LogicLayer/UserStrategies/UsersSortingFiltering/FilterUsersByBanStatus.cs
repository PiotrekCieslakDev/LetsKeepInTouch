using Domains.UserClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.UserStrategies.UsersSortingFiltering
{
    public class FilterUsersByBanStatus : ISortFilterUser
    {
        private bool _lookForBannedOrNotBanned;

        public FilterUsersByBanStatus(bool lookForBannedOrNotBanned)
        {
            _lookForBannedOrNotBanned = lookForBannedOrNotBanned;
        }

        public List<User> SortAndFilter(List<User> givenUsers)
        {
            if (_lookForBannedOrNotBanned)
            {
                return givenUsers.Where(user => user.Ban).ToList();
            }
            else
            {
                return givenUsers.Where(user => !user.Ban).ToList();
            }
        }
    }
}
