using DBcontext;
using Microsoft.EntityFrameworkCore;
using TasksProject._02_Repositories.Interfaces;
using TasksProject.Models;

namespace TasksProject._02_Repositories.Implementions
{
    public class CourseRepo : IcourseRepo
    {
       private readonly ApplicationDbContext _Dbcontext;

        public CourseRepo(ApplicationDbContext dbcontext)
        {
            _Dbcontext = dbcontext;
        }

       

       public  async Task<Course?> GetCourseWithDepartment(int id)
        {
            var course = await _Dbcontext.Courses.Include(o => o.Department).SingleOrDefaultAsync(o => o.Id == id);
            return course;
        }
    }
}
