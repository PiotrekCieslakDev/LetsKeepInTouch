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
    public class LoginModel : PageModel
    {
        ILoginService _loginService = new LoginService(new UserRepository());
        UserService _userService = new DependencyBuilderHelper().UserService;

        public User _LoggedInUser { get; private set; }

        [BindProperty]
        public LoginDTO LoginDTO { get; set; }

        [TempData]
        public string ResultMessage { get; set; }

        public IActionResult OnGet()
        {
            GetJsonAccount();
            if (_LoggedInUser == null)
            {
                return Page();
            }
            return RedirectToPage("/LogOut");
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                User? userToBeLoggedIn = _loginService.Login(LoginDTO.UserName, LoginDTO.Password);
                if (userToBeLoggedIn != null)
                {
                    _LoggedInUser = userToBeLoggedIn;

                    string accountJson = JsonSerializer.Serialize(_LoggedInUser.Id);
                    HttpContext.Session.SetString("accountJson", accountJson);

                    ResultMessage = null;
                    return RedirectToPage("MyProfile");
                }
                ResultMessage = "Could not login. Check your credentials";
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


