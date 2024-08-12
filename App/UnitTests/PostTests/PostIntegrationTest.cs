using DataAccessLayerInterfaces;
using Database.DataRepositories;
using Domains.PostClasses;
using Domains.ResultClasses;
using Domains.UserClasses;
using LogicLayer.Services;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.PostTests
{    
    [TestClass]
    public class PostIntegrationTest
    {
        PostService _postService = new PostService(new PostRepository(), new UserRepository(), new NotificationRepository());
        UserService _userService = new UserService(new UserRepository());

        //[TestMethod]
        //public void EditPost_ShouldReturnTrue()
        //{
        //    //Arrange
        //    Post? postToBeEdited = _postService.GetPostById(Guid.Parse("F7BFCF68-7ED8-437C-8D2C-7C5C32637348"));
        //    User? editingUser = _userService.GetUserById(Guid.Parse("AA8CEE8A-F3D1-408A-9F8C-49FB041ACDED"));
        //    string editContent = "edited post via tests tests";

        //    //Act
        //    Result result = _postService.MakePostEdit(editingUser, postToBeEdited.Id, editContent);

        //    //Assert
        //    Assert.IsTrue(result.IsSuccess, result.Message);
        //}

        //[TestMethod]
        //public void AddCommentOnAPost_ShouldAddCommentAndReturnTrue()
        //{
        //    //Arrange
        //    Post postToComment = _postService.GetPostById(Guid.Parse("F7BFCF68-7ED8-437C-8D2C-7C5C32637348"));
        //    User commentingUser = _userService.GetUserById(Guid.Parse("AA8CEE8A-F3D1-408A-9F8C-49FB041ACDED"));
        //    Comment newComment = new Comment(commentingUser, "comment from tests");

        //    //Act
        //    Result result = _postService.CreatingCommentOnAPost(newComment, Guid.Parse("F7BFCF68-7ED8-437C-8D2C-7C5C32637348"));

        //    //Assert
        //    Assert.IsTrue(result.IsSuccess, result.Message);
        //}

        [TestMethod]
        public void GetPostWithComments_ShouldRetrievePostAndMoreThanZeroComments()
        {
            //Arrange
            Guid postId = Guid.Parse("F7BFCF68-7ED8-437C-8D2C-7C5C32637348");

            //Act
            MainPost postToGet = _postService.GetPostWithComments(postId, false, false);

            //Assert
            Assert.IsNotNull(postToGet);
            Assert.IsTrue(postToGet.Comments.Any());
            Assert.IsTrue(postToGet.Comments.Count() > 0);
        }
    }
}
