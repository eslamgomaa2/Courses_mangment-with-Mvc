using DBcontext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TasksProject._03_Services.Implementions;
using TasksProject.Models;


namespace TasksProject.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly ICourseServices _courseService;

        public CourseController(ApplicationDbContext dbcontext, ICourseServices courseService)
        {
            _dbcontext = dbcontext;
            _courseService = courseService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return View("AllCourses",courses);
        }

        
        [HttpGet]
        public async Task<IActionResult> AddCourse()    
        {
            ViewBag.Departments = await _dbcontext.Departments.ToListAsync();
            ViewBag.Action = "SaveAddedCourse";
            ViewBag.Button = "Add int";
            return View("Add_Edit_Course");
        }

        
        [HttpPost]
        public async Task<IActionResult> SaveAddedCourse(Course model)
        {
            if (ModelState.IsValid)
            {
                await _courseService.AddCourseAsync(model);
                return RedirectToAction("GetAllCourses");
            }

            ViewBag.Departments = await _dbcontext.Departments.ToListAsync();
            ViewBag.Action = "SaveAddedCourse";
            ViewBag.Button = "Add int";
            return View("Add_Edit_Course",model);
        }

        
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null) return NotFound();

            ViewBag.Departments = await _dbcontext.Departments.ToListAsync();
            ViewBag.Action = "SaveupdatedCourse";
            ViewBag.Button = "Edit int";
            return View("Add_Edit_Course",course);
        }

       
        [HttpPost]
        public async Task<IActionResult> SaveupdatedCourse(Course model)
        {
            if (ModelState.IsValid)
            {
              await _courseService.UpdateCourseAsync(model);
                await _dbcontext.SaveChangesAsync();
                return RedirectToAction("GetAllCourses");
            }

            ViewBag.Departments = await _dbcontext.Departments.ToListAsync();
            ViewBag.Action = "SaveupdatedCourse";
            ViewBag.Button = "Edit int";
            return View("Add_Edit_Course",model);
        }

        
        [HttpPost]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null) return NotFound();

           await _courseService.DeleteCourseAsync(course);
            await _dbcontext.SaveChangesAsync();
            return RedirectToAction("GetAllCourses");
        }
    }
}
