using Database.DataRepositories;
using Domains.ResultClasses;
using Domains.UserClasses;
using DTOs;
using LogicLayer.Services;
using LogicLayerInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace WebApp.Pages
{
    public class RegisterModel : PageModel
    {
        UserService _userService = new DependencyBuilderHelper().UserService;

        public User _LoggedInUser { get; private set; }

        [BindProperty]
        public RegisterDTO? _newUser { get; set; }

        public string? ActionResultMessageText { get; set; }
        public string? ActionResultErrorMessageText { get; set; }

        public IActionResult OnGet()
        {
            GetJsonAccount();
            if (_LoggedInUser == null)
            {
                return Page();
            }
            return RedirectToPage("LogOut");
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                User newUser = _newUser.CreateUser();

                Result result = _userService.CreateUser(newUser);

                if (result.IsSuccess)
                {
                    string accountJson = JsonSerializer.Serialize(newUser.Id);
                    HttpContext.Session.SetString("accountJson", accountJson);

                    return RedirectToPage("/MyProfile");
                }
                else
                {
                    // Show error pop-up
                    TempData["ErrorMessage"] = "Registration failed";
                }
            }
            return Page();
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
