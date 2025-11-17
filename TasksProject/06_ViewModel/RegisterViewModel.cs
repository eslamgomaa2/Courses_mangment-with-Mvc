using System.ComponentModel.DataAnnotations;

namespace TasksProject.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        [Required]
        public string Email { get; set; } 
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPAssword { get; set; }
        [Required]
        public string PhoneNum { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        
    }
}
