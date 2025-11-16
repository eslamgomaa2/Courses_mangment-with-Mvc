using DBcontext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TasksProject._03_Services.Interfaces;
using TasksProject.Models;

namespace TasksProject.Controllers
{
    public class InstructorController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly IInstructorServices _instructorServices;

        public InstructorController(ApplicationDbContext dbcontext, IInstructorServices instructorServices)
        {
            _dbcontext = dbcontext;
            _instructorServices = instructorServices;
        }

        [HttpGet]
        public async Task<IActionResult> AllInstructor()
        {
            var instructors = await _instructorServices.GetAllInstructor_RelatedData();
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
                await _instructorServices.AddInstructor(model);
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
            var instructor = await _instructorServices.GetInstructoreById(id);
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
                await _instructorServices.UpdateInstructor(model);
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
            var instructor = await _instructorServices.GetInstructoreById(id);
            if (instructor == null) return NotFound();
           
            return View("InstructorDetails", instructor);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var instructor = await _instructorServices.GetInstructoreById(id);
            if (instructor == null) return NotFound();
            await _instructorServices.RemoveInstructor(instructor);
            return RedirectToAction(nameof(Index));
        }
    }
}
