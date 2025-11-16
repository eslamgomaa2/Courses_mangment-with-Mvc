
using TasksProject.Models;

namespace TasksProject._03_Services.Implementions
{
    public interface ICourseServices
    {
        public Task AddCourseAsync(Course model);
        public Task UpdateCourseAsync(Course model);
        public Task DeleteCourseAsync(Course model);
        public Task<List<Course>> GetAllCoursesAsync();
        public Task<Course> GetCourseByIdAsync(int id);
    }
}
