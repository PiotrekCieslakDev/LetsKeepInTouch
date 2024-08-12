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
    public class EditPostModel : PageModel
    {
        private readonly PostService _postService = new DependencyBuilderHelper().PostService;
        private readonly UserService _userService = new DependencyBuilderHelper().UserService;

        public User? _LoggedInUser { get; private set; }

        [BindProperty(SupportsGet = true)]
        public Guid _PostId { get; private set; }
        private Guid _postId;

        public MainPost? _ChosenMainPost { get; set; }
        public Comment? _ChosenComment { get; set; }
        public Post? _ChosenPost { get; set; }

        [BindProperty]
        public PostContentDTO? _PostContentDTO { get; set; }

        public IActionResult OnGet(Guid id)
        {
            _postId = id;

            GetJsonAccount();

            _PostContentDTO = new PostContentDTO();

            if (_LoggedInUser != null && id != Guid.Empty)
            {
                Post post = _postService.GetPostById(id);

                if (post != null && _LoggedInUser.Id == post.Author.Id)
                {
                    _ChosenPost = post;
                    switch (post)
                    {
                        case MainPost mainPost:
                            _ChosenMainPost = mainPost;
                            break;
                        case Comment comment:
                            _ChosenComment = comment;
                            break;
                    }

                    return Page();
                }
                else
                {
                    return RedirectToPage("Error");
                }
            }
            else if (_LoggedInUser == null)
            {
                return RedirectToPage("/Login");
            }
            else
            {
                return RedirectToPage("/Error");
            }
        }

        //public IActionResult OnPost(Guid id)
        //{
        //    GetJsonAccount();

        //    if (_postService.MakePostEdit(_LoggedInUser, id, _PostContentDTO.Content).IsSuccess)
        //    {
        //        return RedirectToPage("/Index");
        //    }
        //    else
        //    {
        //        return RedirectToPage("/EditPost", new { id = id });
        //    }
        //}

        public IActionResult OnPost(Guid id)
        {
            GetJsonAccount();

            if (id != Guid.Empty && _LoggedInUser != null && _PostContentDTO != null && ModelState.IsValid)
            {
                Result resultOfUpdating = _postService.MakePostEdit(_LoggedInUser, id, _PostContentDTO.Content);

                if (resultOfUpdating.IsSuccess)
                {
                    return RedirectToPage("/Index");
                }
                else
                {
                    return RedirectToPage("/EditPost", new { id = id });
                }
            }
            return RedirectToPage("/Error");
        }

        public void GetJsonAccount()
        {
            if (HttpContext.Session.Get("accountJson") != null)
            {
                Guid userId = JsonSerializer.Deserialize<Guid>(HttpContext.Session.GetString("accountJson"));
                _LoggedInUser = _userService.GetUserById(userId);
            }
        }

        private Post? GetPost(Guid id)
        {
            Post? post = _postService.GetPostById(id);

            if (post != null && _LoggedInUser != null && _LoggedInUser.Id == post.Author.Id)
            {
                switch (post)
                {
                    case MainPost mainPost:
                        _ChosenMainPost = mainPost;
                        break;
                    case Comment comment:
                        _ChosenComment = comment;
                        break;
                }
            }
            return post;
        }
    }
}
