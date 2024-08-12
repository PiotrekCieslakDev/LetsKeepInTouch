using DataAccessLayerInterfaces;
using Domains.PostClasses;
using Domains.ResultClasses;
using Domains.UserClasses;
using Enums;
using LogicLayer.PostStrategies.PostsListSortingAndFiltering;
using LogicLayer.UserStrategies.UsersSortingFiltering;
using LogicLayerInterfaces;

namespace LogicLayer.Services
{
    public class UserService
    {
        private List<User> _users;
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _users = _userRepository.GetAllUsersFromDb();
        }

        public List<User> GetAllUsers(ISortFilterUser[] sortFilterUserParameters)
        {
            List<User>? retrivedUsers = _userRepository.GetAllUsersFromDb();
            if (retrivedUsers == null)
            {
                return new List<User>();
            }
            if (sortFilterUserParameters != null && sortFilterUserParameters.Any())
            {
                foreach (ISortFilterUser sortingFilteringProcess in sortFilterUserParameters)
                {
                    retrivedUsers = sortingFilteringProcess.SortAndFilter(retrivedUsers);
                }
            }
            return retrivedUsers;
        }
        public User? GetUserById(Guid userId)
        {
            return _userRepository.GetUserByIdFromDb(userId);
        }

        public User? GetUserByIdentifier(string identifier)
        {
            return _userRepository.GetUserByIdentifier(identifier);
        }

        public Result CreateUser(User newUser)
        {
            _users = _userRepository.GetAllUsersFromDb();
            bool usernameExists = _users.Any(user => user.UserName.Equals(newUser.UserName, StringComparison.OrdinalIgnoreCase));
            bool emailExists = _users.Any(user => user.Email.Equals(newUser.Email, StringComparison.OrdinalIgnoreCase));

            if (usernameExists)
            {
                return new Result(false, "Could not create user. User with this username already exists.");
            }

            if (emailExists)
            {
                return new Result(false, "Could not create user. User with this email already exists.");
            }

            //_users.Add(newUser);
            //return new Result(true, "User successfully created.");

            return _userRepository.CreateUserInDb(newUser);
        }
        public Result UpdateUser(User user)
        {
            //User? existingUser = _users.FirstOrDefault(u => u.Id == user.Id);
            //if (existingUser != null)
            //{
            //    _users[_users.IndexOf(existingUser)] = user;
            //    return new Result(true, "User successfully updated.");
            //}

            //return new Result(false, "Something went wrong. Couldn't update the user.");

            return _userRepository.UpdateUserInDb(user);
        }
        public Result DeleteUser(Guid userId)
        {
            //int initialCount = _users.Count;
            //_users.RemoveAll(user => user.Id == userId);
            //if (_users.Count < initialCount)
            //{
            //    return new Result(true, "User successfully deleted.");
            //}
            //else
            //{
            //    return new Result(false, "Something went wrong. Couldn't delete the user.");
            //}

            return _userRepository.DeleteUserFromDb(userId);
        }

        public Result ToggleUserBan(Guid userId, bool ban)
        {
            User? user = _users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                return user.ToggleUserBan(ban);
            }
            else
            {
                return new Result(false, "User not found.");
            }
        }
    }
}
