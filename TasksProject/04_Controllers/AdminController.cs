using Microsoft.AspNetCore.Mvc;
using TasksProject._03_Services.Implementions;
using TasksProject._03_Services.Interfaces;
using TasksProject.Models;

namespace TasksProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly IDepartmentServices department;
        private readonly IInstructorServices instructor;
        private readonly ICourseServices course;
        private readonly ITraineeServices trainee;

        public AdminController(IDepartmentServices admin, IInstructorServices instructor, ITraineeServices trainee, ICourseServices course, IDepartmentServices department)
        {

            this.instructor = instructor;
            this.trainee = trainee;
            this.course = course;
            this.department = department;
        }


        public async Task<IActionResult> AdminDashbord()
        {

            ViewBag.TotalCourses = await department.GetTotalCoursesCount();
            ViewBag.TotalTrainees = await department.GetTotalTraineesCount();
            ViewBag.TotalInstructors = await department.GetTotalInstructorsCount();
           

            return View("AdminDashbord");
        }

        // -------- Courses CRUD --------
        public async Task<IActionResult> GetAllCourses()
        {
            var data = await course.GetAllCoursesAsync();
            return View("AllCourses", data);
        }

        public IActionResult AddCourse() => View("Add_Edit_Course");

        [HttpPost]
        public async Task<IActionResult> AddCourse(Course model)
        {
            if (!ModelState.IsValid) return View("Add_Edit_Course", model);

            await course.AddCourseAsync(model);
            return RedirectToAction("GetAllCourses");
        }

        public async Task<IActionResult> EditCourse(int id)
        {
            var model = await course.GetCourseByIdAsync(id);
            return View("Add_Edit_Course", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditCourse(Course model)
        {
            if (!ModelState.IsValid) return View("Add_Edit_Course", model);
            await course.UpdateCourseAsync(model);
            return RedirectToAction("GetAllCourses");
        }

        public async Task<IActionResult> DeleteCourse(int id)
        {
            var cour= await course.GetCourseByIdAsync(id);
            await course.DeleteCourseAsync(cour);
            return RedirectToAction("GetAllCourses");
        }



        // -------- Departments CRUD --------
       

        // -------- Instructors CRUD --------

        public async Task<IActionResult> GetAllInstructor()
        {
            var data = await instructor.GetAllInstructor();
            return View("Allinstructor", data);
        }

        public IActionResult AddInstructor() => View("Add_Edit_Instructor");

        [HttpPost]
        public async Task<IActionResult> Addinstructor(Instructor model)
        {
            if (!ModelState.IsValid) return View("Add_Edit_instructor", model);

            await instructor.AddInstructor(model);
            return RedirectToAction("GetAllInstructor");
        }

        public async Task<IActionResult> Editinstruuctor(int id)
        {
            var model = await instructor.GetInstructoreById(id);
            return View("Add_Edit_instructor", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditInstructor(Instructor model)
        {
            if (!ModelState.IsValid) return View("Add_Edit_Instructor", model);
            await instructor.UpdateInstructor(model);
            return RedirectToAction("GetAllInstructor");
        }

        public async Task<IActionResult> Deleteinstructor(int id)
        {
        var instruc=    await instructor.GetInstructoreById(id);
            await instructor.RemoveInstructor(instruc);
            return RedirectToAction("GetAllinstructor");
        }
        public async Task<IActionResult> InstructorDetails(int id)
        {
        var instruc=    await instructor.GetInstructoreById(id);
            
            return View("InstructorDetails",instruc);
        }

        //----------------- Trainees --------
        [HttpGet]
        public async Task<IActionResult> GetAllTrainee()
        {
            var data = await trainee.GetAllTrainees();
            return View("AllTrainee", data);
        }

        public IActionResult AddTrainee() => View("Add_Edit_Trainee");

        [HttpPost]
        public async Task<IActionResult> AddTrainee(Trainee model)
        {
            if (!ModelState.IsValid) return View("Add_Edit_instructor", model);

            await trainee.AddTrainee(model);
            return RedirectToAction("GetAllTrainee");
        }

        public async Task<IActionResult> EditTrainee(int id)
        {
            var model = await trainee.GetTraineeById(id);
            return View("Add_Edit_instructor", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditTrainee(Trainee model)
        {
            if (!ModelState.IsValid) return View("Add_Edit_Instructor", model);
            await trainee.Updatetrainee(model);
            return RedirectToAction("GetAlltrainee");
        }

        public async Task<IActionResult> Deletetrainee(int id)
        {
            var train = await trainee.GetTraineeById(id);
            await trainee.RemoveTrainee(train);
            return RedirectToAction("GetAlltrainee");
        }
        public async Task<IActionResult> TraineeDetails(int id)
        {
            var train = await trainee.GetTraineeById(id);

            return View("TraineeDetails", train);
        }
        public async Task<IActionResult> CourseTrainees(int Courseid)
        {
            var train = await trainee.GetAllTrainee_InSpecific_Course(Courseid);

            return View("", train);
        }


    }
}
