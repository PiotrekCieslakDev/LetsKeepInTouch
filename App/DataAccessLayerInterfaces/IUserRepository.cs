using Domains.ResultClasses;
using Domains.UserClasses;

namespace DataAccessLayerInterfaces
{
    public interface IUserRepository
    {
        public List<User> GetAllUsersFromDb();

        public User? GetUserByIdFromDb(Guid userId);

        public User? GetUserByIdentifier(string identifier);

        public Result CreateUserInDb(User user);

        public Result UpdateUserInDb(User user);

        public Result DeleteUserFromDb(Guid userId);
    }
}