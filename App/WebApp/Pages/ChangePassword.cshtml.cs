using Domains.ResultClasses;
using Domains.UserClasses;
using DTOs;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace WebApp.Pages
{
    public class ChangePasswordModel : PageModel
    {
        private readonly UserService _userService = new DependencyBuilderHelper().UserService;

        public User? _LoggedInUser { get; private set; }

        [BindProperty]
        public ChangePasswordDTO _ChangePasswordDTO { get; set; }

        [TempData]
        public string? ResultMessage { get; set; }

        public IActionResult OnGet()
        {
            GetJsonAccount();
            
            if (_LoggedInUser == null)
            {
                return RedirectToPage("/Login");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            GetJsonAccount();

            if (ModelState.IsValid)
            {
                Result resultOfChangingPasswordInLogic = _LoggedInUser.ChangePasswordByItsUser(_ChangePasswordDTO.OldPassword, _ChangePasswordDTO.NewPassword, _LoggedInUser.Id);
                if (resultOfChangingPasswordInLogic.IsSuccess)
                {
                    if (_userService.UpdateUser(_LoggedInUser).IsSuccess)
                    {
                        ResultMessage = resultOfChangingPasswordInLogic.Message;
                        return RedirectToPage("/MyProfile");
                    }
                    else
                    {
                        ResultMessage = resultOfChangingPasswordInLogic.Message;
                        return RedirectToPage("/ChangePassword");
                    }
                }
                else
                {
                    ResultMessage = resultOfChangingPasswordInLogic.Message;
                    return RedirectToPage("/ChangePassword");
                }
            }
            else
            {
                return Page();
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
