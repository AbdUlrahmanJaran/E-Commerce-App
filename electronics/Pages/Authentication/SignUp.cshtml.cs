using Electronics.Auth.Interfaces;
using Electronics.Auth.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Electronics.Pages.Authentication
{
    public class SignUpModel : PageModel
    {
        private IUserService _userService { get; set; }
        public SignUpModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(string userName, string email, string password)
        {
            RegisterDTO registerDTO = new RegisterDTO
            {
                Username = userName,
                Email = email,
                Password = password
            };

            try
            {
                await _userService.Register(registerDTO , this.ModelState);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return Page();
            }
            //try
            //{
            //    await _userService.Authenticate(userName, password);
            //}
            //catch (Exception e)
            //{
            //    ModelState.AddModelError("", e.Message);
            //    return Page();
            //}
            
            return Redirect("/CategoriesUser/Index");
        }

    }
}
