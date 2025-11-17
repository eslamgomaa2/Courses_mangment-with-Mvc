using System.ComponentModel.DataAnnotations;

namespace TasksProject.ViewModel
{
    public class ForgetPasswordViewModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
