using Domains.PostClasses;
using Domains.UserClasses;
using LogicLayer.Services;
using LogicLayerInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace WebApp.Pages
{
    public class PostEditsModel : PageModel
    {
        private readonly UserService _userService = new DependencyBuilderHelper().UserService;
        private readonly PostService _postService = new DependencyBuilderHelper().PostService;

        public User _LoggedInUser { get; private set; }

        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        public Post CurrentPost { get; private set; }

        public void OnGet(Guid id)
        {
            GetJsonAccount();
            CurrentPost = _postService.GetPostById(id);
            Id = id;
        }

        private void GetJsonAccount()
        {
            if (HttpContext.Session.Get("accountJson") != null)
            {
                Guid userId = JsonSerializer.Deserialize<Guid>(HttpContext.Session.GetString("accountJson"));
                _LoggedInUser = _userService.GetUserById(userId);
            }
        }
    }
}
