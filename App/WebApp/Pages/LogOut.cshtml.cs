using Database.DataRepositories;
using Domains.UserClasses;
using LogicLayer.Services;
using LogicLayerInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace WebApp.Pages
{
    public class LogOutModel : PageModel
    {
        private UserService _userService = new DependencyBuilderHelper().UserService;

        public User _LoggedInUser { get; private set; }

        public IActionResult OnGet()
        {
            GetJsonAccount();
            if (_LoggedInUser != null)
            {
                return Page();
            }
            return RedirectToPage("Login");
        }

        public IActionResult OnPost()
        {
            HttpContext.Session.Remove("accountJson");
            return RedirectToPage("/Login");
        }


        public void GetJsonAccount()
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
