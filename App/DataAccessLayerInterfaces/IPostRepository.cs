using Domains.PostClasses;
using Domains.ResultClasses;

namespace DataAccessLayerInterfaces
{
    public interface IPostRepository
    {
        public List<Post>? GetAllPosts();
        public List<Comment>? GetAllCommentsOnPostByPostId(Guid mainPostId);
        public Post? GetPostById(Guid id);
        public MainPost? GetMainPostByItsComment(Guid commentId);

        public Result CreatePost(Post post);
        public Result CreateComment(Comment newComment, Guid commentedPostId);
        public Result UpdatePost(Post post);
        //Edit post is different from Update post, update post is updating the data of the post, edit adds a new post content to database
        public Result EditPost(Guid mainPostId, PostContent postContent);

        public Result RestrictAllPostsMadeByUserByTheirId(Guid userId);
        public Result TogglePostRestriction(Guid postId, bool restrict);
    }
}
