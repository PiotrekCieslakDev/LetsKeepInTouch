using Domains.PostClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class PostContentDTO
    {
        public PostContentDTO()
        {
            Content = "";
        }

        [Required]
        [MinLength(1, ErrorMessage = "Post must be at least 1 character.")]
        [MaxLength(300, ErrorMessage = "Post can not be more than 300 characters.")]
        public string Content { get; set; }
    }
}
