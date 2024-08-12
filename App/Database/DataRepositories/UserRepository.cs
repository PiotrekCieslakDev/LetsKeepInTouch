using DataAccessLayerInterfaces;
using Domains.ResultClasses;
using Domains.UserClasses;
using Enums;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Data;

namespace Database.DataRepositories
{
    public class UserRepository : SqlConnetcionHelper, IUserRepository
    {
        private Mappers _mappers = new Mappers();

        public List<User> GetAllUsersFromDb()
        {
            List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(_sqlConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM Users";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                users.Add(_mappers.MapUserFromDataReader(reader));
                            }
                        }
                    }
                }
                catch
                {
                    throw;
                }
            }

            return users;
        }

        public User? GetUserByIdFromDb(Guid userId)
        {
            User user = null;

            using (SqlConnection connection = new SqlConnection(_sqlConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM Users WHERE Id = @UserId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userId;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user = _mappers.MapUserFromDataReader(reader);
                            }
                        }
                    }
                }
                catch
                {
                    throw;
                }
            }

            return user;
        }
        public User? GetUserByEmailFromDb(string email)
        {
            User user = null;

            using (SqlConnection connection = new SqlConnection(_sqlConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM Users WHERE Email = @Email";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@Email", SqlDbType.NVarChar, 60).Value = email;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user = _mappers.MapUserFromDataReader(reader);
                            }
                        }
                    }
                }
                catch
                {
                    throw;
                }
            }

            return user;
        }
        public User? GetUserByIdentifier(string identifier)
        {
            try
            {
                using (var connection = new SqlConnection(_sqlConnectionString))
                {
                    connection.Open();

                    // Check if the identifier is an email or username
                    string query = "SELECT * FROM [Users] WHERE (Email = @Identifier OR Username = @Identifier)";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Identifier", identifier);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return _mappers.MapUserFromDataReader(reader);
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured: " + ex.Message);
            }
        }


        public Result CreateUserInDb(User user)
        {
            using (SqlConnection connection = new SqlConnection(_sqlConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO Users (Id, FirstName, LastName, UserName, Email, PasswordHash, PasswordSalt, UserRole, Deactivated, Ban) " +
                                   "VALUES (@UserId, @FirstName, @LastName, @UserName, @Email, @PasswordHash, @PasswordSalt, @UserRole, @Deactivated, @Ban)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = user.Id;
                        command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 40).Value = user.FirstName;
                        command.Parameters.Add("@LastName", SqlDbType.NVarChar, 60).Value = user.LastName;
                        command.Parameters.Add("@UserName", SqlDbType.NVarChar, 40).Value = user.UserName;
                        command.Parameters.Add("@Email", SqlDbType.NVarChar, 60).Value = user.Email;
                        command.Parameters.Add("@PasswordHash", SqlDbType.VarBinary, -1).Value = user.PasswordHash;
                        command.Parameters.Add("@PasswordSalt", SqlDbType.VarBinary, -1).Value = user.PasswordSalt;
                        command.Parameters.Add("@UserRole", SqlDbType.Int).Value = (int)user.UserRole;
                        command.Parameters.Add("@Deactivated", SqlDbType.Bit).Value = user.Deactivated;
                        command.Parameters.Add("@Ban", SqlDbType.Bit).Value = user.Ban;

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return new Result(true, "User created successfully.");
                        }
                        else
                        {
                            return new Result(false, "User creation failed.");
                        }
                    }
                }
                catch
                {
                    throw;
                }
            }
        }
        public Result DeleteUserFromDb(Guid userId)
        {
            using (SqlConnection connection = new SqlConnection(_sqlConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "DELETE FROM Users WHERE Id = @UserId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userId;

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return new Result(true, "User deleted successfully.");

                        }
                        else
                        {
                            return new Result(false, "User not found or deletion failed.");
                        }
                    }
                }
                catch
                {
                    throw;
                }
            }
        }
        public Result UpdateUserInDb(User user)
        {
            using (SqlConnection connection = new SqlConnection(_sqlConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "UPDATE Users SET FirstName = @FirstName, LastName = @LastName, UserName = @UserName, " +
                                   "Email = @Email, PasswordHash = @PasswordHash, PasswordSalt = @PasswordSalt, " +
                                   "UserRole = @UserRole, Deactivated = @Deactivated, Ban = @Ban " +
                                   "WHERE Id = @UserId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = user.Id;
                        command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 40).Value = user.FirstName;
                        command.Parameters.Add("@LastName", SqlDbType.NVarChar, 60).Value = user.LastName;
                        command.Parameters.Add("@UserName", SqlDbType.NVarChar, 40).Value = user.UserName;
                        command.Parameters.Add("@Email", SqlDbType.NVarChar, 60).Value = user.Email;
                        command.Parameters.Add("@PasswordHash", SqlDbType.VarBinary, -1).Value = user.PasswordHash;
                        command.Parameters.Add("@PasswordSalt", SqlDbType.VarBinary, -1).Value = user.PasswordSalt;
                        command.Parameters.Add("@UserRole", SqlDbType.Int).Value = (int)user.UserRole;
                        command.Parameters.Add("@Deactivated", SqlDbType.Bit).Value = user.Deactivated;
                        command.Parameters.Add("@Ban", SqlDbType.Bit).Value = user.Ban;

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return new Result(true, "User updated successfully.");
                        }
                        else
                        {
                            return new Result(false, "User not found or update failed.");
                        }
                    }
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}