using Domains.UserClasses;
using Enums;
using System.Data;

namespace LogicLayer.UserStrategies.UsersSortingFiltering
{
    public class FilterUsersByRole : ISortFilterUser
    {
        private readonly UserRole[] _givenUserRoles;

        public FilterUsersByRole(UserRole[] givenUserRoles)
        {
            _givenUserRoles = givenUserRoles;
        }

        public List<User> SortAndFilter(List<User> givenUsers)
        {
            return givenUsers.Where(user => _givenUserRoles.Contains(user.UserRole)).ToList();
        }
    }
}
