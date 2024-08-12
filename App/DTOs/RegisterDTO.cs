using Domains.UserClasses;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace DTOs
{
    public class RegisterDTO
    {
        public RegisterDTO()
        {
            
        }

        [Required(ErrorMessage = "Username is required.")]
        [MinLength(6, ErrorMessage = "Username must be at least 6 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        public User CreateUser()
        {
            return new User(FirstName, LastName, UserName, Email, Password, Enums.UserRole.Regular);
        }
    }
}
