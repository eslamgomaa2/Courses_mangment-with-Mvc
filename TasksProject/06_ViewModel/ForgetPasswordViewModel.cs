using System.ComponentModel.DataAnnotations;

namespace TasksProject._06_ViewModel
{
    public class ForgetPasswordViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
    }
}
