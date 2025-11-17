using Microsoft.AspNetCore.Identity;
using TasksProject._02_Repositories.Interfaces;
using TasksProject._03_Services.Interfaces;
using TasksProject.Data.Entities;
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


        public AccountServices(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IGenericRepo<Instructor> instructorRepo, IGenericRepo<Trainee> traineeRepo)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.instructorRepo = instructorRepo;
            this.traineeRepo = traineeRepo;
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



        public  async Task Login(LoginViewModel model)
        {
           var user = await userManager.FindByEmailAsync(model.Email);
            if(user is null)
            {
                throw new Exception("Email Or PAssword Is InCorrect");
            }
           var res = await userManager.CheckPasswordAsync(user,model.Password!);
            if (res)
            {
                await signInManager.SignInAsync(user, model.RememberMe);
            }
            throw new Exception("Email Or PAssword Is InCorrect");

        }
       

        public async Task ForgetPassword(ForgetPasswordViewModel model)
        {
           var user =  await userManager.FindByEmailAsync(model.Email);
            if (user is null)
            {
                throw new Exception("Email Is Not Exsit");
            }
          var token =  await userManager.GeneratePasswordResetTokenAsync(user);
            // to do :email method to send token

        }

        public async Task Logout()
        {
           await signInManager.SignOutAsync();
        }
    }
}
