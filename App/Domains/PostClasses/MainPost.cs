using Domains.ResultClasses;
using Domains.UserClasses;

namespace Domains.PostClasses
{
    public class MainPost : Post
    {
        private List<Comment> _comments;

        public MainPost(User author, string content) : base(author, content)
        {
            _comments = new List<Comment>();
        }

        public MainPost(Guid id, User author, List<PostContent> postContents, bool restricted, bool deleted) : base(id, author, postContents, restricted, deleted)
        {
            _comments = new List<Comment>();
        }

        public MainPost(Guid id, User author, List<PostContent> postContents, bool restricted, bool deleted, List<Comment> comments, List<Like> likes) : base(id, author, postContents, restricted, deleted, likes)
        {
            _comments = comments;
        }

        public List<Comment> Comments { get => _comments ; set => _comments = value;}

        public Result AddComment(Comment comment)
        {
            _comments.Add(comment);
            return new Result(true, $"{comment.Author.GetFullNameWithUserName} added a comment on the post.");
        }
    }
}
