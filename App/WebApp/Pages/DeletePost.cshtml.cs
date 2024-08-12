using Domains.PostClasses;
using Domains.ResultClasses;
using Domains.UserClasses;
using LogicLayer;
using LogicLayer.Services;
using LogicLayer.UpdatingPost;
using LogicLayerInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace WebApp.Pages
{
    public class DeletePostModel : PageModel
    {
        private readonly UserService _userService = new DependencyBuilderHelper().UserService;
        private readonly PostService _postSerivce = new DependencyBuilderHelper().PostService;

        public User _LoggedInUser { get; private set; }

        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        public MainPost MainPost { get; set; }
        public Comment Comment { get; set; }

        [TempData]
        public string ResultMessage { get; set; }

        public IActionResult OnGet()
        {
            GetJsonAccount();

            if (_LoggedInUser == null)
            {
                return RedirectToPage("/Login");
            }
            else
            {
                if (Id != Guid.Empty)
                {
                    Post post = _postSerivce.GetPostById(Id);
                    if (post == null)
                    {
                        return RedirectToPage("/Index");
                    }
                    else
                    {
                        if (post is MainPost)
                        {
                            MainPost = (MainPost)post;
                        }
                        else if (post is Comment)
                        {
                            Comment = (Comment)post;
                        }

                        if (_LoggedInUser.Id == post.Author.Id)
                        {
                            return Page();
                        }
                        else
                        {
                            return RedirectToPage("Index");
                        }
                    }
                }
            }
            return Page();
        }


        public IActionResult OnPost()
        {
            GetJsonAccount();
            Post post = _postSerivce?.GetPostById(Id);
            if (post.Author.Id == _LoggedInUser.Id)
            {
                IMakeAPostUpdate[] makeAPostUpdates = new IMakeAPostUpdate[]
                {
                    new DeletePostAsUser(_LoggedInUser, true),
                };
                Result resultOfDeletion = _postSerivce.UpdatePost(Id, makeAPostUpdates);
                if (resultOfDeletion.IsSuccess)
                {
                    ResultMessage = resultOfDeletion.Message;
                    return RedirectToPage("/Index");
                }
            }
            return Page();
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
