using Domains.UserClasses;
using Enums;

namespace LogicLayer.UserStrategies.UsersSortingFiltering
{
    public class SearchUsersByNamesAndEmail : ISortFilterUser
    {
        private string _searchPhrase;

        public SearchUsersByNamesAndEmail(string searchPhrase)
        {
            _searchPhrase = searchPhrase;
        }

        public List<User> SortAndFilter(List<User> givenUsers)
        {
            _searchPhrase = _searchPhrase.ToLower();

            if (_searchPhrase != null && _searchPhrase != string.Empty)
            {
                return givenUsers.FindAll(user => user.GetFullNameWithUserNameAndEmail().ToLower().Contains(_searchPhrase));
            }

            return givenUsers;
        }
    }
}
