using Domains.PostClasses;

namespace LogicLayer.PostStrategies.PostFinder
{
    public class FindPostById : IPostFinder
    {
        private Guid _postId;

        public FindPostById(Guid postId)
        {
            _postId = postId;
        }

        public Post? FindPost(List<Post> givenPosts)
        {
            return givenPosts.FirstOrDefault(post => post.Id == _postId);
        }
    }
}
