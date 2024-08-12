using Domains.PostClasses;

namespace Domains.ResultClasses
{
    public class GetPostResult : Result
    {
        public GetPostResult() : base()
        {
            
        }

        public GetPostResult(bool success, string message, Post post) : base(success, message)
        {
            Post = post;
        }

        public Post Post { get; }
    }
}
