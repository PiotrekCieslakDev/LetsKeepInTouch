using Domains.UserClasses;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace WebApp.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        private UserService _userService = new DependencyBuilderHelper().UserService;

        public User _LoggedInUser { get; private set; }

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
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