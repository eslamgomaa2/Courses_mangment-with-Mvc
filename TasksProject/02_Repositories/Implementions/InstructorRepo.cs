using DBcontext;
using Microsoft.EntityFrameworkCore;
using TasksProject._02_Repositories.Interfaces;
using TasksProject.Models;

namespace TasksProject._02_Repositories.Implementions
{
    public class InstructorRepo : IInstructorRepo
    {
        private readonly ApplicationDbContext _dbcontext;

        public InstructorRepo(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<Instructor>> GetAllInstructor_RelatedData()
        {
           
            var instructors = await _dbcontext.Instructors.Include(o => o.Department).Include(o => o.Course).ToListAsync();
            return instructors;
        }

        public Task<List<Course>?> GetCourseofInstructor(int instructorid)
        {
            var course = _dbcontext.Courses.Where(o => o.Instructors != null && o.Instructors.Any(o => o.Id == instructorid)).ToListAsync();
            return course!;
        }

       
    }
}
