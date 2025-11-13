using DBcontext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TasksProject.Models;

namespace TasksProject.Controllers
{
    public class InstructorController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;

        public InstructorController(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public async Task<IActionResult> AllInstructor()
        {
            var instructors = await _dbcontext.Instructors.Include(o=>o.Department).Include(o=>o.Course).ToListAsync();
            return View("AllInstructor",instructors);
        }

        [HttpGet]
        public async Task<IActionResult> AddInstructor()
        {
            ViewBag.Departments = await _dbcontext.Departments.ToListAsync();
            ViewBag.Courses = await _dbcontext.Courses.ToListAsync();
            ViewBag.ButtonText = "Add";            
            ViewBag.Action = "SaveAddedInstructor";

            return View("Add_Edit_Instructor", new Instructor());
        }

        [HttpPost]
        public async Task<IActionResult> SaveAddedInstructor(Instructor model)
        {
            if (ModelState.IsValid)
            {
                await _dbcontext.Instructors.AddAsync(model);
                await _dbcontext.SaveChangesAsync();
                return RedirectToAction("AllInstructor");
            }

            ViewBag.Departments = await _dbcontext.Departments.ToListAsync();
            ViewBag.Courses = await _dbcontext.Courses.ToListAsync();
            ViewBag.ButtonText = "Add";            
            ViewBag.Action = "SaveAddedInstructor";

            return View("Add_Edit_Instructor", model);
        }


        [HttpGet]
        public async Task<IActionResult> EditInstructor(int id)
        {
            var instructor = await _dbcontext.Instructors.FindAsync(id);
            if (instructor == null) return NotFound();
            ViewBag.Departments = await _dbcontext.Departments.ToListAsync();
            ViewBag.Courses = await _dbcontext.Courses.ToListAsync();
            ViewBag.Button = "Update";
            ViewBag.Action = "SaveEditInstructor";

            return View("Add_Edit_Instructor", instructor);
        }

        [HttpPost]
        public async Task<IActionResult> SaveEditInstructor(Instructor model)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.Instructors.Update(model);
                await _dbcontext.SaveChangesAsync();
                return RedirectToAction("AllInstructor");
            }
            ViewBag.Departments = await _dbcontext.Departments.ToListAsync();
            ViewBag.Courses = await _dbcontext.Courses.ToListAsync();
            ViewBag.Button = "Update";
            ViewBag.Action = "SaveEditInstructor";

            return View("Add_Edit_Instructor", model);
        }
        [HttpGet]
        public async Task<IActionResult> GetInstructorDetails(int id)
        {
            var instructor = await _dbcontext.Instructors.FindAsync(id);
            if (instructor == null) return NotFound();
           
            return View("InstructorDetails", instructor);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var instructor = await _dbcontext.Instructors.FindAsync(id);
            if (instructor == null) return NotFound();

            _dbcontext.Instructors.Remove(instructor);
            await _dbcontext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
