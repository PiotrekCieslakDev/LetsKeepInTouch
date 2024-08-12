using Database.DataRepositories;
using Domains.ResultClasses;
using Domains.UserClasses;
using Enums;

namespace UserRepoTests
{
    [TestClass]
    public class UserRepositoryTests
    {
        private UserRepository userRepository;

        public UserRepositoryTests()
        {
            userRepository = new UserRepository();
        }


        [TestMethod]
        public void GetAllUsersFromDb_ReturnsListOfUsers()
        {
            // Arrange
            userRepository = new UserRepository();

            // Act
            List<User> users = userRepository.GetAllUsersFromDb();

            // Assert
            Assert.IsNotNull(users);
            Assert.IsTrue(users.Count > 0);
        }

        [TestMethod]
        public void GetUserByIdFromDb_ExistingUserId_ReturnsUser()
        {
            // Arrange
            Guid userId = Guid.Parse("241dba26-f540-4174-b505-9da4085eed74");

            // Act
            User user = userRepository.GetUserByIdFromDb(userId);

            // Assert
            Assert.IsNotNull(user);
            Assert.AreEqual(userId, user.Id);
        }

        [TestMethod]
        public void GetUserByIdFromDb_NonExistingUserId_ReturnsNull()
        {
            // Arrange
            Guid userId = Guid.NewGuid();

            // Act
            User user = userRepository.GetUserByIdFromDb(userId);

            // Assert
            Assert.IsNull(user);
        }


        //Do not uncomment this test method. It will result in creating a new user without cleaning it up !!!!!!!!!!

        //[TestMethod]
        //public void CreateUserInDb_ValidUser_ReturnsSuccessResult()
        //{
        //    // Arrange
        //    User userToCreate = new User("Admin", "Admin", "Admin", "admin@mail.com", "password", UserRole.Admin);

        //    // Act
        //    Result result = userRepository.CreateUserInDb(userToCreate);

        //    // Assert
        //    Assert.IsTrue(result.IsSuccess);
        //    Assert.AreEqual("User created successfully.", result.Message);
        //}
    }
}
