using Domains.PostClasses;
using Domains.ResultClasses;
using Domains.UserClasses;
using LogicLayer.PostStrategies.PostsListSortingAndFiltering;
using LogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.MockRepository;

namespace UnitTests.PostTests
{
    [TestClass]
    public class PostUnitTests
    {
        [TestMethod]
        public void RetrievePosts_ShouldRetrieveMoreThanZero()
        {
            //Arrange
            PostService postService = new PostService(new PostMockRepo(), new UserMockRepo(), new NotificationMockRepo());

            //Act
            ISortFilterPost[] sortFilterPosts = new ISortFilterPost[0];
            List<Post> retrievedPosts = postService.GetAllPostsFromRepository(sortFilterPosts);

            //Assert
            Assert.IsNotNull(retrievedPosts);
            Assert.IsTrue(retrievedPosts.Any());
            Assert.IsTrue(retrievedPosts.Count() > 0);
        }

        [TestMethod]
        public void GetPostById_ShouldRetrievePost()
        {
            //Arrange
            UserMockRepo userMockRepo = new UserMockRepo();
            PostService postService = new PostService(new PostMockRepo(), userMockRepo, new NotificationMockRepo());

            //Act
            Post retrievedPost = postService.GetPostById(Guid.Parse("8e86dc87-d6e2-451e-82da-e9dca24595a7"));

            //Arrange
            Assert.IsNotNull(retrievedPost);
            Assert.AreEqual(Guid.Parse("8e86dc87-d6e2-451e-82da-e9dca24595a7"), retrievedPost.Id);
        }

        [TestMethod]
        public void CreatePost_ShouldRetrieveTrue()
        {
            //Arrange
            UserMockRepo userMockRepo = new UserMockRepo();
            PostService postService = new PostService(new PostMockRepo(), userMockRepo, new NotificationMockRepo());
            UserService userService = new UserService(userMockRepo);

            User author = userService.GetUserByIdentifier("JMartinez");
            Post newPost = new Post(author, "test post");

            //Act
            Result result = postService.CreatePost(newPost);
            Post retrievedPost = postService.GetPostById(newPost.Id);

            //Assert
            Console.WriteLine(result.Message.ToString());
            Assert.IsTrue(result.IsSuccess);
            Assert.IsNotNull(retrievedPost);
            Assert.AreEqual(newPost.Id, retrievedPost.Id);
        }
    }
}
