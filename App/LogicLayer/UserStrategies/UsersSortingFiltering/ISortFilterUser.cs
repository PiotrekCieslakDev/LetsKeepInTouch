using Domains.UserClasses;

namespace LogicLayer.UserStrategies.UsersSortingFiltering
{
    public interface ISortFilterUser
    {
        public List<User> SortAndFilter(List<User> givenUsers);
    }
}
