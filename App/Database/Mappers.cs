using Domains.PostClasses;
using Domains.UserClasses;
using Enums;
using Microsoft.Data.SqlClient;

namespace Database
{
    internal class Mappers
    {
        public User MapUserFromDataReader(SqlDataReader reader)
        {
            User user = new User(
                (Guid)reader["Id"],
                reader["FirstName"].ToString(),
                reader["LastName"].ToString(),
                reader["UserName"].ToString(),
                reader["Email"].ToString(),
                (byte[])reader["PasswordHash"],
                (byte[])reader["PasswordSalt"],
                (UserRole)(int)reader["UserRole"],
                (bool)reader["Deactivated"],
                (bool)reader["Ban"]
                                );

            return user;
        }

        public Post MapPostFromDataReader(SqlDataReader reader)
        {
            if (reader["MainPostId"] is not DBNull)
            {
                return  new Comment(
                (Guid)reader["Id"],
                new User(
                    (Guid)reader["AuthorId"],
                    reader["AuthorFirstName"].ToString(),
                    reader["AuthorLastName"].ToString(),
                    reader["AuthorUserName"].ToString(),
                    reader["AuthorEmail"].ToString(),
                    (byte[])reader["AuthorPasswordHash"],
                    (byte[])reader["AuthorPasswordSalt"],
                    (UserRole)(int)reader["AuthorUserRole"],
                    (bool)reader["AuthorDeactivated"],
                    (bool)reader["AuthorBan"]
                ),
                //TO DO implement post contnet 
                new List<PostContent>
                {
                    new PostContent("Implement")
                },
                (bool)reader["Restricted"],
                (bool)reader["Deleted"]
                );
            }
            else
            {
                return new MainPost(
                (Guid)reader["Id"],
                new User(
                    (Guid)reader["AuthorId"],
                    reader["AuthorFirstName"].ToString(),
                    reader["AuthorLastName"].ToString(),
                    reader["AuthorUserName"].ToString(),
                    reader["AuthorEmail"].ToString(),
                    (byte[])reader["AuthorPasswordHash"],
                    (byte[])reader["AuthorPasswordSalt"],
                    (UserRole)(int)reader["AuthorUserRole"],
                    (bool)reader["AuthorDeactivated"],
                    (bool)reader["AuthorBan"]
                ),
                //TO DO implement post contnet 
                new List<PostContent>
                {
                    new PostContent("Implement")
                },
                (bool)reader["Restricted"],
                (bool)reader["Deleted"]
                );
            }

        }

        public MainPost MapMainPostFromDataReader(SqlDataReader reader)
        {
            MainPost post = new MainPost(
                (Guid)reader["Id"],
                new User(
                    (Guid)reader["AuthorId"],
                    reader["AuthorFirstName"].ToString(),
                    reader["AuthorLastName"].ToString(),
                    reader["AuthorUserName"].ToString(),
                    reader["AuthorEmail"].ToString(),
                    (byte[])reader["AuthorPasswordHash"],
                    (byte[])reader["AuthorPasswordSalt"],
                    (UserRole)(int)reader["AuthorUserRole"],
                    (bool)reader["AuthorDeactivated"],
                    (bool)reader["AuthorBan"]
                ),
                //TO DO implement post contnet 
                new List<PostContent>
                {
                    new PostContent("Implement")
                },
                (bool)reader["Restricted"],
                (bool)reader["Deleted"]
                );

            return post;
        }
    }
}
