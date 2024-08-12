using Database.DataRepositories;
using Domains.UserClasses;
using DTOs;
using LogicLayer.Services;
using LogicLayerInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace WebApp.Pages
{
    public class MyProfileModel : PageModel
    {
        private UserService _userService = new DependencyBuilderHelper().UserService;

        [TempData]
        public string ResultMessage { get; set; }

        public User? _LoggedInUser { get; private set; }

        [BindProperty]
        public UpdateUserDTO UpdateUserDTO { get; set; }

        public IActionResult OnGet()
        {
            GetJsonAccount();
            if (_LoggedInUser != null)
            {
                UpdateUserDTO = new UpdateUserDTO(_LoggedInUser);

                return Page();
            }
            return RedirectToPage("Login");
        }

        public IActionResult OnPost()
        {
            GetJsonAccount();

            if (ModelState.IsValid)
            {
                _LoggedInUser.UpdateDetails(UpdateUserDTO.FirstName, UpdateUserDTO.LastName, UpdateUserDTO.UserName, UpdateUserDTO.Email);

                if (_userService.UpdateUser(_LoggedInUser).IsSuccess)
                {
                    ResultMessage = "Profile updated.";
                    return RedirectToPage("/MyProfile");
                }
                else
                {
                    ResultMessage = "Something went wrong while updating the profile.";
                    return RedirectToPage("/MyProfile");
                }
            }
            else
            {
                return Page();
            }          
        }

        private void GetJsonAccount()
        {
            if (HttpContext.Session.Get("accountJson") != null)
            {
                Guid userId = JsonSerializer.Deserialize<Guid>(HttpContext.Session.GetString("accountJson"));
                User? loggedInUser = _userService.GetUserById(userId);
                if (loggedInUser != null)
                {
                    _LoggedInUser = loggedInUser;
                }
            }
        }
    }
}
