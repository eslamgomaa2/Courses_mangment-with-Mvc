
using TasksProject._02_Repositories.Interfaces;
using TasksProject.Models;
using TasksProject.Repositories.Implementions;

namespace TasksProject._03_Services.Implementions
{
    public class CourseServices :ICourseServices
    {
        private readonly IcourseRepo _courseRepo;
        private readonly IGenericRepo<Course> _genericRepo;

     

        public CourseServices(IcourseRepo courseRepo, IGenericRepo<Course> genericRepo)
        {
            _courseRepo = courseRepo;
            _genericRepo = genericRepo;
        }

        public async Task AddCourseAsync(Course model)
        {
            await _genericRepo.AddAsync(model);
        }

        public async Task DeleteCourseAsync(Course model)
        {
            await _genericRepo.DeleteAsync(model);
        }

        public async Task<List<Course>> GetAllCoursesAsync()
        {
           return  await _genericRepo.GetAllAsync();
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            var course = await _courseRepo.GetCourseWithDepartment(id);
            if (course == null)
            {
                throw new Exception("Course not found");
            }
            return course;
        }

        public async Task UpdateCourseAsync( Course model)
        {
            await _genericRepo.UpdateAsync( model);
        }
    }
}
