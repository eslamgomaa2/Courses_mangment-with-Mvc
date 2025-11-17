using TasksProject._06_ViewModel;
using TasksProject.ViewModel;

namespace TasksProject._03_Services.Interfaces
{
    public interface IAccountServices
    {
        public Task Login(LoginViewModel model);
        public Task ForgetPassword(ForgetPasswordViewModel model);
        public Task Logout ();

    }
}
