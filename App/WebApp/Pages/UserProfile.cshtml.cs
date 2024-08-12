using Domains.PostClasses;
using Domains.UserClasses;
using LogicLayer.PostStrategies.PostsListSortingAndFiltering;
using LogicLayer.Services;
using LogicLayerInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

namespace WebApp.Pages
{
    public class UserProfileModel : PageModel
    {
        private readonly UserService _userService = new DependencyBuilderHelper().UserService;
        private readonly PostService _PostService = new DependencyBuilderHelper().PostService;

        public User _LoggedInUser { get; private set; }
        public User _SelectedUser { get; private set; }
        public List<Post> _SelectedUsersPosts { get; private set; }

        [TempData]
        public string ResultMessage { get; set; }

        private const int PageSize = 10;
        public int TotalPages { get; private set; }
        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; }

        public IActionResult OnGet(Guid id)
        {
            GetJsonAccount();
            if (id == Guid.Empty)
            {
                return RedirectToPage("/Index");
            }
            else
            {
                User? retrievedUser = _userService.GetUserById(id);
                if (retrievedUser == null)
                {
                    ResultMessage = "Could not get the selceted user and his profile. Try again.";
                    return RedirectToPage("/Index");
                }
                else
                {
                    _SelectedUser = retrievedUser;

                    List<ISortFilterPost> sortFilterPostsParameters = new List<ISortFilterPost>()
                    {
                        new OnlyMainPosts(),
                        new AllPostsBySpecificUser(_SelectedUser.Id),
                        new GetNotRestrictedNotDeletedPosts()
                    };

                    _SelectedUsersPosts = _PostService.GetAllPostsFromRepository(sortFilterPostsParameters.ToArray());

                    TotalPages = (int)Math.Ceiling(_SelectedUsersPosts.Count / (double)PageSize);

                    _SelectedUsersPosts = _SelectedUsersPosts
                        .Skip((PageNumber - 1) * PageSize)
                        .Take(PageSize)
                        .ToList();

                    return Page();
                }
            }
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
