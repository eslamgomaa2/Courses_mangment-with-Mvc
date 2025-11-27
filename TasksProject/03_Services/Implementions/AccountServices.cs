using Microsoft.AspNetCore.Identity;
using TasksProject._02_Repositories.Interfaces;
using TasksProject._03_Services.Interfaces;
using TasksProject._06_ViewModel;
using TasksProject.Data.Entities;
using TasksProject.Helper;
using TasksProject.Models;
using TasksProject.ViewModel;

namespace TasksProject._03_Services.Implementions
{
    public class AccountServices : IAccountServices
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IGenericRepo<Instructor> instructorRepo;
        private readonly IGenericRepo<Trainee> traineeRepo;
        private readonly IEmailServices emailServices;
        public AccountServices(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IGenericRepo<Instructor> instructorRepo, IGenericRepo<Trainee> traineeRepo, IEmailServices emailServices)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.instructorRepo = instructorRepo;
            this.traineeRepo = traineeRepo;
            this.emailServices = emailServices;
        }

        //public AccountResponce RegisterAsIstructor(RegisterViewModel model)
        //{
        //    var AccountRes   = new AccountResponce();
        //   var user= userManager.FindByEmailAsync(model.Email);
        //    if (user is not null)
        //    {
        //        AccountRes.Message = "User Is Already Exsit";
        //        return AccountRes;
        //    }
        //    var newuser = new ApplicationUser();
        //    newuser.Email= model.Email;
        //    newuser.FName= model.FName;
        //    newuser.LName= model.LName;
        //    newuser.PhoneNumber = model.PhoneNum;

        //   var res= userManager.CreateAsync(newuser, model.Password);
        //    if (!res.IsCompletedSuccessfully) 
        //    {
        //        signInManager.SignInAsync(newuser, false);  

        //    }
        //    AccountRes.Message = "Failed To Create";
        //    return AccountRes;





        //}



        public async Task Login(LoginViewModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email!);
            if (user == null)
            {
                throw new Exception("Email or password is incorrect");
            }

            var passwordValid = await userManager.CheckPasswordAsync(user, model.Password!);
            if (!passwordValid)
            {
                throw new Exception("Email or password is incorrect");
            }

            await signInManager.SignInAsync(user, model.RememberMe);
        }



        public async Task ForgetPassword(ForgetPasswordViewModel model)
        {

           var user =  await userManager.FindByEmailAsync(model.Email!);
            if (user is null)
            {
                throw new Exception("Email Is Not Exsit");
            }
          var token =  await userManager.GeneratePasswordResetTokenAsync(user);
            var resetLink = $"https://localhost:7221/Account/ResetPassword?email={model.Email}&token={token}";
            var message = new EmailMessage();
            message.To = model.Email!;
            message.Subject = "Reset Password";
            message.Body = $"<a href='{resetLink}'>Click Here To Reset Your Password</a>";
            await emailServices.SendEmailAsync(message.To,message.Subject,message.Body);

            

        }
        public async Task ResetPassword(ResetPasswordViewModel model)
        {
           var user = await userManager.FindByEmailAsync(model.Email);
            if (user is null)
            {
                throw new Exception("Email Is Not Exsit");
            }
          var res=  await userManager.ResetPasswordAsync(user, model.Token!, model.NewPassword!);
            if (!res.Succeeded)
            {
                throw new Exception("Reset Password Failed");
            }
        }

        public async Task Logout()
        {
           await signInManager.SignOutAsync();
        }
    }
}
