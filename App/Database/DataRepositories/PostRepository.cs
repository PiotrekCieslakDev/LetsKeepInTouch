using DataAccessLayerInterfaces;
using Domains.PostClasses;
using Domains.ResultClasses;
using Microsoft.Data.SqlClient;

namespace Database.DataRepositories
{
    public class PostRepository : SqlConnetcionHelper, IPostRepository
    {
        private Mappers _mappers = new Mappers();

        public PostRepository() { }


        public List<Post>? GetAllPosts()
        {
            List<Post> postsReceived = new List<Post>();

            using (SqlConnection connection = new SqlConnection(_sqlConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"
                SELECT 
                    p.Id, 
                    p.AuthorId, 
                    u.FirstName AS AuthorFirstName,
                    u.LastName AS AuthorLastName,
                    u.UserName AS AuthorUserName,
                    u.Email AS AuthorEmail,
                    u.PasswordHash AS AuthorPasswordHash,
                    u.PasswordSalt AS AuthorPasswordSalt,
                    u.UserRole AS AuthorUserRole,
                    u.Deactivated AS AuthorDeactivated,
                    u.Ban AS AuthorBan,
                    p.Restricted, 
                    p.Deleted, 
                    p.MainPostId,
                    pm.Id AS MainPostContentId,
                    pm.ContentText AS MainPostContentText,
                    pm.CreationTime AS MainPostCreationTime
                FROM 
                    Posts p
                JOIN 
                    Users u ON p.AuthorId = u.Id
                LEFT JOIN
                    PostContents pm ON p.MainPostId = pm.Id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Post post = _mappers.MapPostFromDataReader(reader);
                                post.PostContents = GetAllPostsContents(post.Id);
                                postsReceived.Add(post);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("An SQL exception occurred: " + ex.Message);
                    throw;
                }
                catch (Exception ex)
                {

                    Console.WriteLine("An exception occurred: " + ex.Message);
                    throw;
                }
            }

            return postsReceived;
        }
        public List<Comment> GetAllCommentsOnPostByPostId(Guid mainPostId)
        {
            List<Comment> comments = new List<Comment>();

            using (SqlConnection connection = new SqlConnection(_sqlConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"
                SELECT 
                    p.Id, 
                    p.AuthorId, 
                    u.FirstName AS AuthorFirstName,
                    u.LastName AS AuthorLastName,
                    u.UserName AS AuthorUserName,
                    u.Email AS AuthorEmail,
                    u.PasswordHash AS AuthorPasswordHash,
                    u.PasswordSalt AS AuthorPasswordSalt,
                    u.UserRole AS AuthorUserRole,
                    u.Deactivated AS AuthorDeactivated,
                    u.Ban AS AuthorBan,
                    p.Restricted, 
                    p.Deleted, 
                    p.MainPostId,
                    pm.Id AS MainPostContentId,
                    pm.ContentText AS MainPostContentText,
                    pm.CreationTime AS MainPostCreationTime
                FROM 
                    Posts p
                JOIN 
                    Users u ON p.AuthorId = u.Id
                LEFT JOIN
                    PostContents pm ON p.MainPostId = pm.Id
                WHERE p.MainPostId = @MainPostId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MainPostId", mainPostId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Comment comment = _mappers.MapPostFromDataReader(reader) as Comment;
                                comment.PostContents = GetAllPostsContents(comment.Id);
                                comments.Add(comment);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("An SQL exception occurred: " + ex.Message);
                    throw;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An exception occurred: " + ex.Message);
                    throw;
                }
            }

            return comments;
        }
        public List<PostContent> GetAllPostsContents(Guid postId)
        {
            List<PostContent> postContents = new List<PostContent>();

            using (SqlConnection connection = new SqlConnection(_sqlConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT Id, ContentText, CreationTime FROM PostContents WHERE PostId = @PostId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PostId", postId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PostContent postContent = new PostContent(
                                    (Guid)reader["Id"],
                                    reader["ContentText"].ToString(),
                                    (DateTime)reader["CreationTime"]
                                );
                                postContents.Add(postContent);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception and handle it as needed
                    Console.WriteLine("An exception occurred while fetching post contents: " + ex.Message);
                }
            }

            return postContents;
        }
        public Post GetPostById(Guid postId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_sqlConnectionString))
                {
                    connection.Open();

                    string query = @"
                SELECT 
                    p.Id, 
                    p.AuthorId, 
                    u.FirstName AS AuthorFirstName,
                    u.LastName AS AuthorLastName,
                    u.UserName AS AuthorUserName,
                    u.Email AS AuthorEmail,
                    u.PasswordHash AS AuthorPasswordHash,
                    u.PasswordSalt AS AuthorPasswordSalt,
                    u.UserRole AS AuthorUserRole,
                    u.Deactivated AS AuthorDeactivated,
                    u.Ban AS AuthorBan,
                    p.Restricted, 
                    p.Deleted, 
                    p.MainPostId,
                    pm.Id AS MainPostContentId,
                    pm.ContentText AS MainPostContentText,
                    pm.CreationTime AS MainPostCreationTime
                FROM 
                    Posts p
                JOIN 
                    Users u ON p.AuthorId = u.Id
                LEFT JOIN
                    PostContents pm ON p.MainPostId = pm.Id
                WHERE 
                    p.Id = @PostId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PostId", postId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Post post = _mappers.MapPostFromDataReader(reader);
                                post.PostContents = GetAllPostsContents(post.Id);
                                if (post is MainPost mainPost)
                                {
                                    mainPost.Comments = GetAllCommentsOnPostByPostId(postId);
                                    return mainPost;
                                }
                                else if (post is Comment comment)
                                {
                                    return comment;
                                }
                                return post;
                            }
                            else
                            {
                                // Post not found
                                return null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred while fetching the post by ID: " + ex.Message);
                return null;
            }
        }
        public MainPost? GetMainPostByItsComment(Guid commentId)
        {
            MainPost? postToGet = null;

            using (SqlConnection connection = new SqlConnection(_sqlConnectionString))
            {
                try
                {
                    connection.Open();

                    // Get the MainPostId based on the commentId
                    string getCommentQuery = "SELECT MainPostId FROM Comments WHERE Id = @Id";

                    Guid mainPostToGetId = Guid.Empty;

                    using (SqlCommand getCommentCommand = new SqlCommand(getCommentQuery, connection))
                    {
                        getCommentCommand.Parameters.AddWithValue("@Id", commentId);
                        using (SqlDataReader commentReader = getCommentCommand.ExecuteReader())
                        {
                            if (commentReader.Read())
                            {
                                mainPostToGetId = (Guid)commentReader["MainPostId"];
                            }
                            else
                            {
                                // Comment not found
                                return null;
                            }
                        }
                    }

                    // Get the Main Post based on the retrieved MainPostId
                    string query = @"
                SELECT 
                    p.Id, 
                    p.AuthorId, 
                    u.FirstName AS AuthorFirstName,
                    u.LastName AS AuthorLastName,
                    u.UserName AS AuthorUserName,
                    u.Email AS AuthorEmail,
                    u.PasswordHash AS AuthorPasswordHash,
                    u.PasswordSalt AS AuthorPasswordSalt,
                    u.UserRole AS AuthorUserRole,
                    u.Deactivated AS AuthorDeactivated,
                    u.Ban AS AuthorBan,
                    p.Restricted, 
                    p.Deleted, 
                    p.MainPostId,
                    pm.Id AS MainPostContentId,
                    pm.ContentText AS MainPostContentText,
                    pm.CreationTime AS MainPostCreationTime
                FROM 
                    Posts p
                JOIN 
                    Users u ON p.AuthorId = u.Id
                LEFT JOIN
                    PostContents pm ON p.MainPostId = pm.Id
                WHERE p.Id = @postId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@postId", mainPostToGetId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MainPost mainPostToGet = _mappers.MapMainPostFromDataReader(reader);
                                mainPostToGet.PostContents = GetAllPostsContents(mainPostToGet.Id);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("An exception occurred while fetching the main post: " + ex.Message);
                }
            }

            return postToGet;
        }


        public Result CreatePost(Post post)
        {
            using (var connection = new SqlConnection(_sqlConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insert into the Post table
                        using (var command = new SqlCommand("INSERT INTO Posts (Id, AuthorId, Restricted, Deleted) VALUES (@Id, @AuthorId, @Restricted, @Deleted)", connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Id", post.Id);
                            command.Parameters.AddWithValue("@AuthorId", post.Author.Id);
                            command.Parameters.AddWithValue("@Restricted", post.Restricted);
                            command.Parameters.AddWithValue("@Deleted", post.Deleted);
                            command.ExecuteNonQuery();
                        }

                        // Insert into the PostContent table
                        foreach (var postContent in post.PostContents)
                        {
                            using (var command = new SqlCommand("INSERT INTO PostContents (Id, ContentText, CreationTime, PostId) VALUES (@Id, @ContentText, @CreationTime, @PostId)", connection, transaction))
                            {
                                command.Parameters.AddWithValue("@id", postContent.Id);
                                command.Parameters.AddWithValue("@ContentText", postContent.ContentText);
                                command.Parameters.AddWithValue("@CreationTime", postContent.CreationTime);
                                command.Parameters.AddWithValue("@PostId", post.Id);
                                command.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        return new Result { IsSuccess = true, Message = "Post created successfully" };
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return new Result { IsSuccess = false, Message = $"An error occurred: {ex.Message}" };
                    }
                }
            }
        }
        public Result CreateComment(Comment newComment, Guid commentedPostId)
        {
            using (var connection = new SqlConnection(_sqlConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insert into the Post table
                        using (var command = new SqlCommand("INSERT INTO Posts (Id, AuthorId, Restricted, Deleted, MainPostId) VALUES (@Id, @AuthorId, @Restricted, @Deleted, @MainPostId)", connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Id", newComment.Id);
                            command.Parameters.AddWithValue("@AuthorId", newComment.Author.Id);
                            command.Parameters.AddWithValue("@Restricted", newComment.Restricted);
                            command.Parameters.AddWithValue("@Deleted", newComment.Deleted);
                            command.Parameters.AddWithValue("@MainPostId", commentedPostId);
                            command.ExecuteNonQuery();
                        }

                        // Insert into the PostContent table
                        foreach (var postContent in newComment.PostContents)
                        {
                            using (var command = new SqlCommand("INSERT INTO PostContents (Id, ContentText, CreationTime, PostId) VALUES (@Id, @ContentText, @CreationTime, @PostId)", connection, transaction))
                            {
                                command.Parameters.AddWithValue("@id", postContent.Id);
                                command.Parameters.AddWithValue("@ContentText", postContent.ContentText);
                                command.Parameters.AddWithValue("@CreationTime", postContent.CreationTime);
                                command.Parameters.AddWithValue("@PostId", newComment.Id);
                                command.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        return new Result { IsSuccess = true, Message = "Post created successfully" };
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return new Result { IsSuccess = false, Message = $"An error occurred: {ex.Message}" };
                    }
                }
            }
        }
        public Result UpdatePost(Post post)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_sqlConnectionString))
                {
                    connection.Open();

                    // Assuming you have a table named 'Posts' in your database
                    string query = @"
                UPDATE Posts
                SET
                    Restricted = @Restricted,
                    Deleted = @Deleted
                WHERE Id = @PostId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PostId", post.Id);
                        command.Parameters.AddWithValue("@Restricted", post.Restricted);
                        command.Parameters.AddWithValue("@Deleted", post.Deleted);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return new Result { IsSuccess = true, Message = "Post updated successfully" };
                        }
                        else
                        {
                            return new Result { IsSuccess = false, Message = "Post not found or no changes made" };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred while updating the post: " + ex.Message);
                return new Result { IsSuccess = false, Message = $"An error occurred: {ex.Message}" };
            }
        }
        public Result EditPost(Guid mainPostId, PostContent postContent)
        {
            using (var connection = new SqlConnection(_sqlConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insert updated PostContents
                        using (var command = new SqlCommand("INSERT INTO PostContents (Id, ContentText, CreationTime, PostId) VALUES (@Id, @ContentText, @CreationTime, @PostId)", connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Id", postContent.Id);
                            command.Parameters.AddWithValue("@ContentText", postContent.ContentText);
                            command.Parameters.AddWithValue("@CreationTime", postContent.CreationTime);
                            command.Parameters.AddWithValue("@PostId", mainPostId);
                            command.ExecuteNonQuery();
                        }

                        // Commit the transaction if everything is successful
                        transaction.Commit();
                        return new Result { IsSuccess = true, Message = "Post updated successfully" };
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception, log it, or throw it further
                        transaction.Rollback();
                        return new Result { IsSuccess = false, Message = $"An error occurred: {ex.Message}" };
                    }
                }
            }
        }


        public Result RestrictAllPostsMadeByUserByTheirId(Guid userId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_sqlConnectionString))
                {
                    connection.Open();

                    string query = @"
                        UPDATE Posts
                        SET Restricted = @Restricted
                        WHERE AuthorId = @AuthorId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AuthorId", userId);
                        command.Parameters.AddWithValue("@Restricted", true);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return new Result { IsSuccess = true, Message = "Post restriction status updated successfully" };
                        }
                        else
                        {
                            return new Result { IsSuccess = false, Message = "Post not found or no changes made" };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred while updating the post: " + ex.Message);
                return new Result { IsSuccess = false, Message = $"An error occurred: {ex.Message}" };
            }
        }
        public Result TogglePostRestriction(Guid postId, bool restrict)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_sqlConnectionString))
                {
                    connection.Open();

                    string query = @"
                        UPDATE Posts
                        SET Restricted = @Restricted
                        WHERE Id = @PostId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PostId", postId);
                        command.Parameters.AddWithValue("@Restricted", restrict);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return new Result { IsSuccess = true, Message = "Post restriction status updated successfully" };
                        }
                        else
                        {
                            return new Result { IsSuccess = false, Message = "Post not found or no changes made" };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred while updating the post: " + ex.Message);
                return new Result { IsSuccess = false, Message = $"An error occurred: {ex.Message}" };
            }
        }

    }
}
