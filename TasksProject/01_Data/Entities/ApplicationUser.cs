using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TasksProject.Data.Entities
{
    public class ApplicationUser:IdentityUser<int>
    {
        [Required]
        [MaxLength(9)]
        public string? FName { get; set; }
        [Required]
        [MaxLength(9)]
        public string? LName { get; set; }
        [Required]
        public string? Address { get; set; }
    }
}
