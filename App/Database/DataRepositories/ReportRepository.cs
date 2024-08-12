using DataAccessLayerInterfaces;
using Domains.ReportClasses;
using Domains.ResultClasses;
using Microsoft.Data.SqlClient;

namespace Database.DataRepositories
{
    public class ReportRepository : SqlConnetcionHelper, IReportRepository
    {
        private readonly UserRepository _userRepository = new UserRepository();
        private readonly PostRepository _postRepository = new PostRepository();

        public Result CreateReport(Report reportToBeCreated)
        {
            try
            {
                using (var connection = new SqlConnection(_sqlConnectionString))
                {
                    connection.Open();

                    string insertQuery = @"
                INSERT INTO Reports (Id, ReporterId, ReportComment, TimeStamp, Reviewed, ReportedPostId, ReportedUserId)
                VALUES (@Id, @ReporterId, @ReportComment, @TimeStamp, @Reviewed, @ReportedPostId, @ReportedUserId)";

                    using (var command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", reportToBeCreated.Id);
                        command.Parameters.AddWithValue("@ReporterId", reportToBeCreated.Reporter.Id);
                        command.Parameters.AddWithValue("@ReportComment", reportToBeCreated.ReportComment);
                        command.Parameters.AddWithValue("@TimeStamp", reportToBeCreated.TimeStamp);
                        command.Parameters.AddWithValue("@Reviewed", reportToBeCreated.Reviewed);

                        if (reportToBeCreated is UserReport)
                        {
                            command.Parameters.AddWithValue("@ReportedPostId", DBNull.Value);
                            command.Parameters.AddWithValue("@ReportedUserId", ((UserReport)reportToBeCreated).ReportedUser.Id);
                        }
                        else if (reportToBeCreated is PostReport)
                        {
                            command.Parameters.AddWithValue("@ReportedPostId", ((PostReport)reportToBeCreated).ReportedPost.Id);
                            command.Parameters.AddWithValue("@ReportedUserId", DBNull.Value);
                        }

                        command.ExecuteNonQuery();
                    }

                    return new Result { IsSuccess = true, Message = "Report created successfully" };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while creating the report: " + ex.Message);
                return new Result { IsSuccess = false, Message = $"An error occurred: {ex.Message}" };
            }
        }

        public Result DeleteReport(Guid reportToBeDeletedId)
        {
            throw new NotImplementedException();
        }

        public List<PostReport> GetAllPostReports()
        {
            throw new NotImplementedException();
        }

        public List<Report> GetAllReports()
        {
            List<Report> reports = new List<Report>();

            try
            {
                using (var connection = new SqlConnection(_sqlConnectionString))
                {
                    connection.Open();

                    string query = @"
                SELECT 
                    r.Id,
                    r.ReporterId,
                    r.ReportComment,
                    r.TimeStamp,
                    r.Reviewed,
                    r.ReportedPostId,
                    r.ReportedUserId
                FROM 
                    Reports r";

                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Report report;

                                // Check if the report is a UserReport or PostReport based on the non-nullable column
                                if (reader["ReportedPostId"] != DBNull.Value)
                                {
                                    report = new PostReport
                                    (
                                        (Guid)reader["Id"],
                                        _userRepository.GetUserByIdFromDb((Guid)reader["ReporterId"]),
                                        (DateTime)reader["TimeStamp"],
                                        (bool)reader["Reviewed"],
                                        reader["ReportComment"].ToString(),
                                        _postRepository.GetPostById((Guid)reader["ReportedPostId"])
                                    );
                                }
                                else
                                {
                                    report = new UserReport
                                    (
                                        (Guid)reader["Id"],
                                        _userRepository.GetUserByIdFromDb((Guid)reader["ReporterId"]),
                                        (DateTime)reader["TimeStamp"],
                                        (bool)reader["Reviewed"],
                                        reader["ReportComment"].ToString(),
                                        _userRepository.GetUserByIdFromDb((Guid)reader["ReportedUserId"])
                                    );
                                }

                                reports.Add(report);
                            }
                        }
                    }
                }

                return reports;
            }
            catch (Exception ex)
            {
                // Log the exception and handle it as needed
                Console.WriteLine("An error occurred while retrieving reports: " + ex.Message);
                // You might want to throw an exception or return an empty list or null based on your error handling strategy
                return new List<Report>();
            }
        }

        public List<Report> GetAllReportsByPost(Guid postId)
        {
            throw new NotImplementedException();
        }

        public List<UserReport> GetAllUserReports()
        {
            throw new NotImplementedException();
        }

        public Report GetReportById(Guid reportId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_sqlConnectionString))
                {
                    connection.Open();

                    string query = @"
                SELECT 
                    r.Id,
                    r.ReporterId,
                    r.ReportComment,
                    r.TimeStamp,
                    r.Reviewed,
                    r.ReportedPostId,
                    r.ReportedUserId
                FROM 
                    Reports r
                WHERE 
                    r.Id = @ReportId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ReportId", reportId);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Report report;

                                // Check if the report is a UserReport or PostReport based on the non-nullable column
                                if (reader["ReportedPostId"] != DBNull.Value)
                                {
                                    report = new PostReport
                                    (
                                        (Guid)reader["Id"],
                                        _userRepository.GetUserByIdFromDb((Guid)reader["ReporterId"]),
                                        (DateTime)reader["TimeStamp"],
                                        (bool)reader["Reviewed"],
                                        reader["ReportComment"].ToString(),
                                        _postRepository.GetPostById((Guid)reader["ReportedPostId"])
                                    );
                                }
                                else
                                {
                                    report = new UserReport
                                    (
                                        (Guid)reader["Id"],
                                        _userRepository.GetUserByIdFromDb((Guid)reader["ReporterId"]),
                                        (DateTime)reader["TimeStamp"],
                                        (bool)reader["Reviewed"],
                                        reader["ReportComment"].ToString(),
                                        _userRepository.GetUserByIdFromDb((Guid)reader["ReportedUserId"])
                                    );
                                }

                                return report;
                            }
                            else
                            {
                                // Report with the specified ID not found
                                return null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred while retrieving the report: " + ex.Message);
                // You might want to throw an exception or return null based on your error handling strategy
                return null;
            }
        }


        public List<Report> GetReportsByReportedUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Result UpdateReport(Report updatedReport)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_sqlConnectionString))
                {
                    connection.Open();

                    string updateQuery = @"
                UPDATE Reports
                SET 
                    ReporterId = @ReporterId,
                    ReportComment = @ReportComment,
                    TimeStamp = @TimeStamp,
                    Reviewed = @Reviewed,
                    ReportedPostId = @ReportedPostId,
                    ReportedUserId = @ReportedUserId
                WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", updatedReport.Id);
                        command.Parameters.AddWithValue("@ReporterId", updatedReport.Reporter.Id);
                        command.Parameters.AddWithValue("@ReportComment", updatedReport.ReportComment);
                        command.Parameters.AddWithValue("@TimeStamp", updatedReport.TimeStamp);
                        command.Parameters.AddWithValue("@Reviewed", updatedReport.Reviewed);

                        // Check the type of report and set the appropriate columns to null
                        if (updatedReport is UserReport)
                        {
                            command.Parameters.AddWithValue("@ReportedPostId", DBNull.Value);
                            command.Parameters.AddWithValue("@ReportedUserId", ((UserReport)updatedReport).ReportedUser.Id);
                        }
                        else if (updatedReport is PostReport)
                        {
                            command.Parameters.AddWithValue("@ReportedPostId", ((PostReport)updatedReport).ReportedPost.Id);
                            command.Parameters.AddWithValue("@ReportedUserId", DBNull.Value);
                        }

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return new Result { IsSuccess = true, Message = "Report updated successfully" };
                        }
                        else
                        {
                            return new Result { IsSuccess = false, Message = "Report not found or no changes made" };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred while updating the report: " + ex.Message);
                return new Result { IsSuccess = false, Message = $"An error occurred: {ex.Message}" };
            }
        }

    }
}
