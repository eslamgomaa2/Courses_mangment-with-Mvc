using DBcontext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TasksProject.Models;

namespace TasksProject.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;

        public CourseController(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

       
        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _dbcontext.Courses.Include(c => c.Department).ToListAsync();
            return View("AllCourses",courses);
        }

        
        [HttpGet]
        public async Task<IActionResult> AddCourse()
        {
            ViewBag.Departments = await _dbcontext.Departments.ToListAsync();
            ViewBag.Action = "SaveAddedCourse";
            ViewBag.Button = "Add Course";
            return View("Add_Edit_Course");
        }

        
        [HttpPost]
        public async Task<IActionResult> SaveAddedCourse(Course model)
        {
            if (ModelState.IsValid)
            {
                await _dbcontext.Courses.AddAsync(model);
                await _dbcontext.SaveChangesAsync();
                return RedirectToAction("GetAllCourses");
            }

            ViewBag.Departments = await _dbcontext.Departments.ToListAsync();
            ViewBag.Action = "SaveAddedCourse";
            ViewBag.Button = "Add Course";
            return View("Add_Edit_Course",model);
        }

        
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var course = await _dbcontext.Courses.FindAsync(id);
            if (course == null) return NotFound();

            ViewBag.Departments = await _dbcontext.Departments.ToListAsync();
            ViewBag.Action = "SaveupdatedCourse";
            ViewBag.Button = "Edit Course";
            return View("Add_Edit_Course",course);
        }

       
        [HttpPost]
        public async Task<IActionResult> SaveupdatedCourse(Course model)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.Courses.Update(model);
                await _dbcontext.SaveChangesAsync();
                return RedirectToAction("GetAllCourses");
            }

            ViewBag.Departments = await _dbcontext.Departments.ToListAsync();
            ViewBag.Action = "SaveupdatedCourse";
            ViewBag.Button = "Edit Course";
            return View("Add_Edit_Course",model);
        }

        
        [HttpPost]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _dbcontext.Courses.FindAsync(id);
            if (course == null) return NotFound();

            _dbcontext.Courses.Remove(course);
            await _dbcontext.SaveChangesAsync();
            return RedirectToAction("GetAllCourses");
        }
    }
}
