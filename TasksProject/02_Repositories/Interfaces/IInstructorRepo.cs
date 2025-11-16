using TasksProject.Models;

namespace TasksProject._02_Repositories.Interfaces
{
    public interface IInstructorRepo
    {
        public Task<List<Instructor>> GetAllInstructor_RelatedData();
    }
}
