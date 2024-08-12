using DataAccessLayerInterfaces;
using Domains.ResultClasses;
using Domains.UserClasses;

namespace FakeRepository
{
    public class MockUserRepository : IUserRepository
    {
        private List<User> _users;

        public MockUserRepository()
        {
            _users = new List<User>();
        }

        public Result CreateUserInDb(User user)
        {
            try
            {
                _users.Add(user);
                return new Result(true, "User created successfully.");
            }
            catch
            {
                return new Result(false, "User creation failed.");
            }
        }

        public Result DeleteUserFromDb(Guid userId)
        {
            try
            {
                var userToRemove = _users.FirstOrDefault(user => user.Id == userId);

                if (userToRemove != null)
                {
                    _users.Remove(userToRemove);
                    return new Result(true, "User deleted successfully.");
                }
            }
            catch
            {
                return new Result(false, "User not found or deletion failed.");
            }
            return new Result(false, "User not found or deletion failed.");
        }


        public List<User> GetAllUsersFromDb()
        {
            return _users;
        }

        public User? GetUserByIdentifier(string identifier)
        {
            return _users.FirstOrDefault(user => user.Email == identifier || user.UserName == identifier);
        }


        public User? GetUserByIdFromDb(Guid userId)
        {
            return _users.First(user => user.Id == userId);
        }

        public Result UpdateUserInDb(User user)
        {
            try
            {
                var existingUser = _users.FirstOrDefault(u => u.Id == user.Id);

                if (existingUser != null)
                {
                    _users.Remove(existingUser);

                    _users.Add(user);

                    return new Result(true, "User updated successfully.");
                }
            }
            catch (Exception ex)
            {
                return new Result(false, $"Error updating user: {ex.Message}");
            }
            return new Result(false, "User not found or update failed.");
        }
    }
}
