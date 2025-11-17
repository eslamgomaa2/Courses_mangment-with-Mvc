using Microsoft.AspNetCore.Mvc;
using TasksProject._03_Services.Interfaces;
using TasksProject.ViewModel;

namespace TasksProject._04_Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountServices accountServices;

        public AccountController(IAccountServices accountServices)
        {
            this.accountServices = accountServices;
        }

        [HttpGet]
        public async Task <IActionResult> Login()
        {
           return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> SaveLogin(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                await accountServices.Login(model);
                return RedirectToAction("Index", "Home");
            }
           
                return View("Login", model);
         
        }

       

        [HttpGet]
        public async Task<IActionResult> ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            return View();
        }
    }
}
