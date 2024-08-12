using Domains.PostClasses;

namespace LogicLayer.PostStrategies.PostFinder
{
    public interface IPostFinder
    {
        public Post? FindPost(List<Post> givenPosts);
    }
}
