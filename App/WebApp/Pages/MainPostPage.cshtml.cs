using Domains.PostClasses;
using Domains.UserClasses;
using DTOs;
using LogicLayer;
using LogicLayer.Services;
using LogicLayerInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace WebApp.Pages
{
    public class MainPostWithCommentsModel : PageModel
    {
        private readonly UserService _userService = new DependencyBuilderHelper().UserService;
        private readonly PostService _postSerivce = new DependencyBuilderHelper().PostService;

        public User _LoggedInUser { get; private set; }

        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        public MainPost MainPost { get; private set; }

        [BindProperty]
        public PostDTO NewCommentDTO { get; set; }

        public void OnGet(Guid id)
        {
            GetJsonAccount();
            MainPost = _postSerivce.GetPostWithComments(id, false, false);
            Id = id;
        }

        public IActionResult OnPost(Guid id)
        {
            Id = id;
            GetJsonAccount();
            MainPost = _postSerivce.GetPostById(Id) as MainPost;

            if (ModelState.IsValid)
            {
                Comment newComment = NewCommentDTO.CreateComment(_LoggedInUser);;

                if (_postSerivce.CreatingCommentOnAPost(newComment, id).IsSuccess)
                {
                    return RedirectToPage("MainPostPage", new { id = Id });
                }
                else
                {
                    return RedirectToPage("MainPostPage", new { id = Id });
                }
            }
            return RedirectToPage("MainPostPage", new { id = Id });
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
