using TasksProject.Models;

namespace TasksProject._03_Services.Interfaces
{
    public interface IInstructorServices
    {
        public Task<Instructor> GetInstructoreById(int id);
        public Task<List<Instructor>> GetAllInstructor_RelatedData();
        public Task AddInstructor(Instructor model);
        public Task RemoveInstructor(Instructor model);
        public Task UpdateInstructor(Instructor model);
        public Task<List<Instructor>> GetAllInstructor();
        public Task<List<Course>?> GetCourseofInstructor(int instructorid);
    }
}
