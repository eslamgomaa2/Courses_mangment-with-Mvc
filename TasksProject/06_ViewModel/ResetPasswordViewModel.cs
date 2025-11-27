using System.ComponentModel.DataAnnotations;

namespace TasksProject._06_ViewModel
{
    public class ResetPasswordViewModel
    {
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string? NewPassword { get; set; }
        [Required]
        public string? Token { get; set; }
    }
}
