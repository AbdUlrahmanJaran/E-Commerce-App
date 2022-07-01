using Electronics.Auth.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Electronics.Pages.Authentication
{
    public class LogInModel : PageModel
    {
        private IUserService _userService { get; set; }

        public LogInModel(IUserService userService)
        {
            _userService = userService;
        }


        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost(string userName , string password)
        {
            try
            {
                await _userService.Authenticate(userName, password);
                return Redirect("/CategoriesUser/Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return Page();
            }
            
        }
    }
}
