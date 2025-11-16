using TasksProject.Models;

namespace TasksProject.ModelView
{
    public class instructorModelView
    {

        public string ?Name { get; set; }
        public decimal Salary { get; set; }
        public string ?Image { get; set; }
        public string? Address { get; set; }
        List<Department>? departments { get; set; }
        List<Course>? courses { get; set; }

    }
}
