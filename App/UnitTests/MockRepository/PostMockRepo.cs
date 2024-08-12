using DataAccessLayerInterfaces;
using Domains.PostClasses;
using Domains.ResultClasses;
using Domains.UserClasses;
using Microsoft.IdentityModel.Tokens;

namespace UnitTests.MockRepository
{
    internal class PostMockRepo : IPostRepository
    {
        private List<Post> allPosts;
        private List<User> allUsers;

        public PostMockRepo()
        {
            InitializeLists();
        }

        public Result CreateComment(Comment newComment, Guid commentedPostId)
        {
            allPosts.Add(newComment);
            return new Result(true, "Added new comment");
        }

        public Result CreatePost(Post post)
        {
            allPosts.Add(post);
            return new Result(true, "Created post");
        }

        public Result EditPost(Guid mainPostId, PostContent postContent)
        {
            throw new NotImplementedException();
        }

        public List<Comment>? GetAllCommentsOnPostByPostId(Guid mainPostId)
        {
            throw new NotImplementedException();
        }

        public List<Post>? GetAllPosts()
        {
            return allPosts;
        }

        public MainPost? GetMainPostByItsComment(Guid commentId)
        {
            throw new NotImplementedException();
        }

        public Post? GetPostById(Guid id)
        {
            return allPosts.Find(p => p.Id == id);
        }

        public Result RestrictAllPostsMadeByUserByTheirId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Result TogglePostRestriction(Guid postId, bool restrict)
        {
            throw new NotImplementedException();
        }

        public Result UpdatePost(Post post)
        {
            throw new NotImplementedException();
        }

        private void InitializeLists()
        {
            allPosts = new InitializingMockRepos().AllPosts.ToList();
            allUsers = new InitializingMockRepos().AllUsers.ToList();
        }
    }
}
