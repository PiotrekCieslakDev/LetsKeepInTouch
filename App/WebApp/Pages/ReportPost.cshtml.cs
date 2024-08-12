using Domains.PostClasses;
using Domains.ReportClasses;
using Domains.ResultClasses;
using Domains.UserClasses;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace WebApp.Pages
{
    public class ReportPostModel : PageModel
    {
        private readonly UserService _userService = new DependencyBuilderHelper().UserService;
        private readonly PostService _postSerivce = new DependencyBuilderHelper().PostService;
        private readonly ReportService _reportService = new DependencyBuilderHelper().ReportService;

        [TempData]
        public string ResultMessage { get; set; }

        public User _LoggedInUser { get; private set; }
        public Post _CurrentPost;

        public IActionResult OnGet(Guid id)
        {
            GetJsonAccount();
            if (_LoggedInUser == null)
            {
                return RedirectToPage("/Login");
            }
            else
            {
                Post retrievedPost = _postSerivce.GetPostById(id);
                if (retrievedPost == null)
                {
                    return RedirectToPage("/Index");
                }
                else
                {
                    _CurrentPost = retrievedPost;
                    return Page();
                }
            }
        }

        public IActionResult OnPost(Guid id)
        {
            GetJsonAccount();
            Post? currentPost = _postSerivce.GetPostById(id);
            if (currentPost != null)
            {
                Report newReport = new PostReport(_LoggedInUser, "no comment", currentPost);
                Result resultOfCreatingReport = _reportService.CreateReport(newReport);
                ResultMessage = resultOfCreatingReport.Message;
                if (resultOfCreatingReport.IsSuccess)
                {
                    return RedirectToPage("/Index");
                }
            }
            return RedirectToPage("ReportPost", new { id = _CurrentPost.Id });
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
