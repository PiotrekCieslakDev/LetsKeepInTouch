using DataAccessLayerInterfaces;
using Domains.PostClasses;
using Domains.ResultClasses;
using Domains.UserClasses;

namespace UnitTests.MockRepository
{
    internal class UserMockRepo : IUserRepository
    {
        private List<Post> allPosts;
        private List<User> allUsers;

        public UserMockRepo()
        {
            InitializeLists();
        }

        public Result CreateUserInDb(User user)
        {
            throw new NotImplementedException();
        }

        public Result DeleteUserFromDb(Guid userId)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUsersFromDb()
        {
            return allUsers;
        }

        public User? GetUserByIdentifier(string identifier)
        {
            return allUsers.Find(user => user.UserName == identifier || user.Email == identifier);
        }

        public User? GetUserByIdFromDb(Guid userId)
        {
            return allUsers.Find(user => user.Id == userId);
        }

        public Result UpdateUserInDb(User user)
        {
            throw new NotImplementedException();
        }

        private void InitializeLists()
        {
            allPosts = new InitializingMockRepos().AllPosts.ToList();
            allUsers = new InitializingMockRepos().AllUsers.ToList();
        }
    }
}
