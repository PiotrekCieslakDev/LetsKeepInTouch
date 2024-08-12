using Domains.ResultClasses;
using Domains.UserClasses;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace WebApp.Pages
{
    public class ResultModel : PageModel
    {
        private UserService _userService = new DependencyBuilderHelper().UserService;

        public User _LoggedInUser { get; private set; }

        [BindProperty(SupportsGet = true)]
        public string Result { get; set; }

        public void OnGet(string result)
        {
            Result = result;
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
