using Electronics.Auth.Interfaces;
using Electronics.Auth.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Electronics.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public async Task<ActionResult<UserDTO>> Login(LoginDTO login)
        {
            try
            {
                await _userService.Authenticate(login.Username, login.Password);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View("Index");
            }
            return Redirect("/Home/Index");
        }

        //public IActionResult SignUp()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<ActionResult<UserDTO>> SignUp(RegisterDTO register)
        //{
        //    var user = await _userService.Register(register, this.ModelState);
        //    if (ModelState.IsValid)
        //    {
        //        return Redirect("/");
        //    }
        //    return View();
        //}

        public async Task<IActionResult> LogOut()
        {
            await _userService.LogOut();
            return RedirectToPage("/CategoriesUser/Index");
        }
    }
}
