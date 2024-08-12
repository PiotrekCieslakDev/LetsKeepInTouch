using Database.DataRepositories;
using Domains.UserClasses;
using LogicLayer.Services;
using LogicLayer.UserStrategies.UsersSortingFiltering;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace WebApp.Pages
{
    public class BrowseUsersModel : PageModel
    {
        private const int PageSize = 20;

        private readonly UserService _userService = new DependencyBuilderHelper().UserService;

        public User _LoggedInUser { get; private set; }

        public List<User> _Users { get; private set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        public int TotalPages { get; private set; }

        public void OnGet()
        {
            GetJsonAccount();

            List<ISortFilterUser> sortFilterUserParameters = new List<ISortFilterUser>();

            if (!string.IsNullOrEmpty(SearchTerm))
            {

                sortFilterUserParameters.Add(new SearchUsersByNamesAndEmail(SearchTerm));
            }

            _Users = _userService.GetAllUsers(sortFilterUserParameters.ToArray());

            int totalCount = _Users.Count();
            TotalPages = (int)Math.Ceiling(totalCount / (double)PageSize);

            _Users = _Users
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
