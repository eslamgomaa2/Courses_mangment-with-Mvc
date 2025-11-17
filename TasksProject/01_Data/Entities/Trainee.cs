using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TasksProject.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(40,100,ErrorMessage ="grade must be between 40 - 100")]
        public decimal Grade { get; set; }
        [Required]
        public string? Image { get; set; }
        [Required]
        public string? Country { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public Department? Department { get; set; }
        public ICollection<CrsResult>? CrsResults  { get; set; }
    }
}
