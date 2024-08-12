using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class ChangePasswordDTO
    {
        public ChangePasswordDTO()
        {

        }

        [Required(ErrorMessage = "Password is required.")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
