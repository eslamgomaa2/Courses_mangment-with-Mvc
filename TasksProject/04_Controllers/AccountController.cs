using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TasksProject._03_Services.Interfaces;
using TasksProject._06_ViewModel;
using TasksProject.Models;
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
        public   IActionResult Login()
        {
           return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> SaveLogin(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                 await accountServices.Login(model);
                var role = User.FindFirstValue(ClaimTypes.Role) ;
                if (role == Roles.Admin.ToString())
                {
                    return RedirectToAction("AdminDashbord", "Admin");
                }
                if(role==Roles.Instructor.ToString())
                {
                    return RedirectToAction("Instructor", "Instructor");
                }
                else 
                {
                    return RedirectToAction("Index", "Home");
                }
            }
           
                return View("Login", model);
         
        }

       

        [HttpGet]
        public IActionResult ForgetPassword()
        {

            return View("ForgetPassword");
        }
        [HttpPost]
        public async Task<IActionResult> SaveForgetPassword(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                await accountServices.ForgetPassword(model);
                return View("ResetPassword");
            }
            return View("ForgetPassword", model);
        }
      

        [HttpPost]
        public async Task<IActionResult> SaveResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                await accountServices.ResetPassword(model);
                return RedirectToAction("Login");
            }
            return View("Ressetpassword", model);
        }




        [HttpPost]
        public async Task<IActionResult> Logout()
        {
           await accountServices.Logout(); 
            return RedirectToAction("Login", "Account");
        }
    }
}
