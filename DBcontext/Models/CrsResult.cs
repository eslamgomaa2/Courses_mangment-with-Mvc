using System.ComponentModel.DataAnnotations.Schema;

namespace TasksProject.Models
{
    public class CrsResult
    {
        public int Id { get; set; }
        public int Degree { get; set; }
        [ForeignKey("Course")]
        public int CrsID { get; set; }
        [ForeignKey("Trainee")]
        public int TraineeID { get; set; }
        public Course? Course { get; set; }
        public Trainee? Trainee { get; set; }
    }
}
