using Domains.UserClasses;

namespace Domains.PostClasses
{
    public class Comment : Post
    {
        public Comment(User author, string content) : base(author, content)
        {

        }

        public Comment(Guid id, User author, List<PostContent> postContents, bool restricted, bool deleted) : base(id, author, postContents, restricted, deleted)
        {
        }

        public Comment(Guid id, User author, List<PostContent> postContents, bool restricted, bool deleted, List<Like> likes) : base(id, author, postContents, restricted, deleted, likes)
        {
        }
    }
}
