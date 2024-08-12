using Domains.PostClasses;
using Domains.UserClasses;
using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class PostDTO
    {
        public PostDTO()
        {
            
        }

        [Required]
        [MinLength(1, ErrorMessage = "Post must be at least 1 character.")]
        [MaxLength(300, ErrorMessage = "Post can not be more than 300 characters.")]
        public string Content { get; set; }

        public Post CreatePost(User author)
        {
            return new Post(author, Content);
        }

        public Comment CreateComment(User author)
        {
            return new Comment(author, Content);
        }
    }
}
