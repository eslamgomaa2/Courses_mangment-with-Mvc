using DBcontext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;
using TasksProject._03_Services.Implementions;
using TasksProject._03_Services.Interfaces;
using TasksProject.Models;

namespace TasksProject.Controllers
{
    public class InstructorController : Controller
    {
      
        private readonly IInstructorServices _instructorServices;
        private readonly IDepartmentServices _departmentServices;
        private readonly ICourseServices _courseServices;
        private readonly ITraineeServices _traineeServices;


        public InstructorController(IInstructorServices instructorServices, IDepartmentServices departmentServices, ICourseServices courseServices, ITraineeServices traineeServices)
        {

            _instructorServices = instructorServices;
            _departmentServices = departmentServices;
            _courseServices = courseServices;
            _traineeServices = traineeServices;
        }

        [HttpGet]
        public async Task<IActionResult> InstructorDashbord()
        {
            int instructorId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var courses = await _instructorServices.GetCourseofInstructor(instructorId);

            
            var traineesCountDict = new Dictionary<int, int>();

            foreach (var c in courses)
            {
                var trainees = await _traineeServices.GetAllTrainee_InSpecific_Course(c.Id);
                traineesCountDict[c.Id] = trainees.Count;
            }

            ViewBag.Courses = courses;
            ViewBag.TraineesCount = traineesCountDict;

            return View("InstructorDashbordcshtml");
        }

        
        [HttpGet]
        public async Task<IActionResult> GetInstructorCourse()
        {
           int instructorid= int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var course=await _instructorServices.GetCourseofInstructor(instructorid);
            return View("Coursesview",course);

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
            ViewBag.Departments =await _departmentServices.GetAllDepartment();
            ViewBag.Courses = await _courseServices.GetAllCoursesAsync();
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

            ViewBag.Departments = await _departmentServices.GetAllDepartment();
            ViewBag.Courses = await _courseServices.GetAllCoursesAsync();
            ViewBag.ButtonText = "Add";            
            ViewBag.Action = "SaveAddedInstructor";

            return View("Add_Edit_Instructor", model);
        }


        [HttpGet]
        public async Task<IActionResult> EditInstructor(int id)
        {
            var instructor = await _instructorServices.GetInstructoreById(id);
            ViewBag.Departments = await _departmentServices.GetAllDepartment();
            ViewBag.Courses = await _courseServices.GetAllCoursesAsync();
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
            ViewBag.Departments = await _departmentServices.GetAllDepartment();
            ViewBag.Courses = await _courseServices.GetAllCoursesAsync();
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
