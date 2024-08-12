using Database.DataRepositories;
using Domains.MessageClasses;
using Domains.PostClasses;
using Domains.ResultClasses;
using Domains.UserClasses;
using LogicLayer.Services;

namespace UnitTests
{
    [TestClass]
    public class UnitTestPost
    {
        private PostService _postService;
        private UserService _userService;

        public UnitTestPost()
        {
            _postService = new PostService(new PostRepository(), new UserRepository(), new NotificationRepository());
            _userService = new UserService(new UserRepository());
        }


        //[TestMethod]
        //public void DeletePost_ExistingPost_Success()
        //{
        //    Arrange
        //   User author = new User("FirstName", "LastName", "UserName", "email@email.com", "Password", Enums.UserRole.Regular);
        //    Post existingPost = new Post(author, "Existing post");
        //    _postService.CreatePost(existingPost);
        //    Post? post = _postService.Posts.FirstOrDefault();

        //    Act
        //   Result result = _postService.DeletePostAsUser(author.Id, post.Id);

        //    Assert
        //    Assert.IsTrue(result.IsSuccess);
        //    Assert.AreEqual(true, _postService.Posts[0].Deleted);
        //}

        //[TestMethod]
        //public void MakePostEdit_ExistingPost_ReturnsSuccessResult()
        //{
        //    // Arrange
        //    User author = new User("FirstName", "LastName", "UserName", "email@email.com", "Password", Enums.UserRole.Regular);
        //    _postService.CreatePost(new Post(author, "Test content"));
        //    Post? post = _postService.Posts.FirstOrDefault();
        //    string content = "Updated content";

        //    // Act
        //    Result result = _postService.MakePostEdit(author, post.Id, content);

        //    // Assert
        //    Assert.IsTrue(result.IsSuccess);
        //    Assert.AreEqual(2, _postService.Posts[0].PostContents.Count());
        //    Assert.AreEqual(content, _postService.Posts[0].PostContents[1].ContentText);
        //}

        //[TestMethod]
        //public void MakePostEdit_NonExistingPost_ReturnsFailureResult()
        //{
        //    // Arrange
        //    User author = new User("FirstName", "LastName", "UserName", "email@email.com", "Password", Enums.UserRole.Regular);
        //    Guid postId = Guid.NewGuid();
        //    string content = "Updated content";

        //    // Act
        //    Result result = _postService.MakePostEdit(author, postId, content);

        //    // Assert
        //    Assert.IsFalse(result.IsSuccess);
        //}

        //[TestMethod]
        //public void CreatingCommentOnAPost_ValidData_Success()
        //{
        //    // Arrange
        //    User author = new User("FirstName", "LastName", "UserName", "email@email.com", "Password", Enums.UserRole.Regular);
        //    string commentContent = "This is a test comment";

        //    Post existingPost = new Post(author, "Existing post");
        //    _postService.CreatePost(existingPost);

        //    // Act
        //    Result result = _postService.CreatingCommentOnAPost(new Post(author, commentContent), existingPost.Id);

        //    // Assert
        //    Assert.IsTrue(result.IsSuccess);
        //    Assert.AreEqual(1, existingPost.Comments.Count());
        //    Assert.AreEqual(commentContent, existingPost.Comments[0].PostContents[0].ContentText);
        //}

        //[TestMethod]
        //public void CreatePostInDataBase_ShouldReturnSuccess()
        //{
        //    //Arrange
        //    Guid authorId = Guid.Parse("AA8CEE8A-F3D1-408A-9F8C-49FB041ACDED");
        //    User? author = _userService.GetUserById(authorId);

        //    //Act
        //    MainPost newPost = new MainPost(author, "this my first test post");
        //    Result result = _postService.CreatePost(newPost);

        //    //Assert
        //    Assert.AreEqual(authorId, author.Id);
        //    Assert.IsTrue(result.IsSuccess);
        //}
    }
}