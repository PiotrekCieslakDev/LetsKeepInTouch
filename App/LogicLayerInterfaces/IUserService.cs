using Domains.ResultClasses;
using Domains.UserClasses;
using Enums;

namespace LogicLayerInterfaces
{
    public interface IUserService
    {
        public List<User> GetAllUsers();
        public List<User> GetAllUsersOfUserRole(UserRole userRole);
        public User? GetUserById(Guid userId);


        public Result CreateUser(User newUser);
        public Result UpdateUser(User user);
        public Result DeleteUser(Guid userId);

        public List<User> SearchUserByFullNameAndUsername(string searchTerm, UserRole? userRole);
        public List<User> GetUsersByRoles(List<UserRole> roles);

        public Result ToggleUserBan(Guid userId, bool ban);
    }
}
