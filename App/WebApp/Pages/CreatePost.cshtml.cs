using Database.DataRepositories;
using Domains.PostClasses;
using Domains.ResultClasses;
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
    public class CreatePostModel : PageModel
    {
        private readonly PostService _postService = new DependencyBuilderHelper().PostService;
        private readonly UserService _userService = new DependencyBuilderHelper().UserService;

        public User _LoggedInUser { get; private set; }

        [BindProperty]
        public PostDTO _NewPost { get; set; }

        [TempData]
        public string ResultMessage { get; set; }

        public IActionResult OnGet()
        {
            GetJsonAccount();
            if (_LoggedInUser != null)
            {
                return Page();
            }
            return RedirectToPage("/Login");
        }

        public IActionResult OnPost()
        {
            GetJsonAccount();

            if (ModelState.IsValid)
            {
                Post mainPost = _NewPost.CreatePost(_LoggedInUser);

                Result result = _postService.CreatePost(mainPost);
                if (result.IsSuccess)
                {
                    //return RedirectToPage("/MainPostPage", mainPost.Id);
                    ResultMessage = result.Message;
                    return RedirectToPage("/Index");
                }
            }
            return Page();
        }

        public void GetJsonAccount()
        {
            if (HttpContext.Session.Get("accountJson") != null)
            {
                Guid userId = JsonSerializer.Deserialize<Guid>(HttpContext.Session.GetString("accountJson"));
                _LoggedInUser = _userService.GetUserById(userId);
            }
        }
    }
}
