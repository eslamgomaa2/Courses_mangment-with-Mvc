using TasksProject.Models;

namespace TasksProject._02_Repositories.Interfaces
{
    public interface IcourseRepo
    {
        public Task<Course?> GetCourseWithDepartment(int id);
        
    }
}
