using Domains.ReportClasses;
using Domains.ResultClasses;
using Domains.UserClasses;
using LogicLayer.PostStrategies.PostsListSortingAndFiltering;
using LogicLayer.Services;
using LogicLayerInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace WebApp.Pages
{
    public class ReportUserModel : PageModel
    {
        private readonly UserService _userService = new DependencyBuilderHelper().UserService;
        private readonly ReportService _reportService = new DependencyBuilderHelper().ReportService;

        public User _LoggedInUser {  get; private set; }
        public User _SelectedUser { get; private set; }

        [TempData]
        public string ResultMessage { get; set; }

        public IActionResult OnGet(Guid id)
        {
            GetJsonAccount();
            if (_LoggedInUser == null || _LoggedInUser.Id == Guid.Empty)
            {
                return RedirectToPage("/Login");
            }
            if (id == Guid.Empty)
            {
                return RedirectToPage("/Index");
            }
            else
            {
                User? retrievedUser = _userService.GetUserById(id);
                if (retrievedUser == null)
                {
                    ResultMessage = "Could not get the selceted user. Try again.";
                    return RedirectToPage("/Index");
                }
                else
                {
                    if(retrievedUser.Id == _LoggedInUser.Id)
                    {
                        ResultMessage = "You can not report yourself.";
                        return RedirectToPage("/Index");
                    }
                    _SelectedUser = retrievedUser;

                    return Page();
                }
            }
        }

        public IActionResult OnPost(Guid id)
        {
            GetJsonAccount();
            if (_LoggedInUser == null || _LoggedInUser.Id == Guid.Empty)
            {
                return RedirectToPage("/Login");
            }
            User? selectedUser = _userService.GetUserById(id);
            if (selectedUser == null || selectedUser.Id == Guid.Empty)
            {
                ResultMessage = "Something went wrong. Try again";
                return RedirectToPage("/Index");
            }
            _SelectedUser = selectedUser;
            UserReport newUserReport = new UserReport(_LoggedInUser, "No comment", _SelectedUser);
            Result resultOfCreatingReport = _reportService.CreateReport(newUserReport);
            ResultMessage = resultOfCreatingReport.Message;
            return RedirectToPage("/Index");
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
