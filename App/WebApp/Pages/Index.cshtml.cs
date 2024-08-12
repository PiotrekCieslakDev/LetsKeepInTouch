using Domains.PostClasses;
using Domains.UserClasses;
using LogicLayer.PostStrategies.PostsListSortingAndFiltering;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PostService _postService = new DependencyBuilderHelper().PostService;
        private readonly UserService _userService = new DependencyBuilderHelper().UserService;

        private readonly ILogger<IndexModel> _logger;
        public User? _LoggedInUser {  get; private set; }
        public List<MainPost> Posts { get; private set; }

        [TempData]
        public string ResultMessage { get; set; }

        private const int PageSize = 10;
        public int TotalPages { get; private set; }
        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            ISortFilterPost[] sortFilterPosts = new ISortFilterPost[]
            {
                new GetNotRestrictedNotDeletedPosts(),
                new OnlyMainPosts(),
                new PostsFromTheNewsestToOldestSorting()
            };
            List<Post> allMainPostsBeforeTransormed = _postService.GetAllPostsFromRepository(sortFilterPosts);
            List<MainPost> allMainPostsTransformed = _postService.TransformPostsToMainPost(allMainPostsBeforeTransormed);
            TotalPages = (int)Math.Ceiling(allMainPostsTransformed.Count / (double)PageSize);

            GetJsonAccount();



            Posts = allMainPostsTransformed
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToList();


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