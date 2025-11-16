using DBcontext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TasksProject._03_Services.Interfaces;
using TasksProject.Models;

namespace TasksProject.Controllers
{
    public class CrsResultController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly ICourseRes_Services courseRes_Services;


        public CrsResultController(ApplicationDbContext context, ICourseRes_Services courseRes_Services)
        {
            _dbcontext = context;
            this.courseRes_Services = courseRes_Services;
        }
        [HttpGet]

        public async Task< IActionResult> AddCrsResult(int traineeid)
        {
            ViewBag.Courses= await _dbcontext.Courses.ToListAsync();
            ViewBag.ButtonText= "Add";
            ViewBag.Action = "SaveAddCrsResult";
            
            return View("Add_Edit_CrsResult",new CrsResult { TraineeID=traineeid });
        }
        [HttpPost]
        public async Task<IActionResult> SaveAddCrsResult(CrsResult model)
        {
           
            if (!ModelState.IsValid)
            {
                ViewBag.Courses = await _dbcontext.Courses.ToListAsync();
                ViewBag.ButtonText = "Add";
                ViewBag.Action = "SaveAddCrsResult";
                return View("Add_Edit_CrsResult", model);
            }


            var traineeExists = courseRes_Services.IsTraineeExist(model.Id);

            if (!traineeExists)
            {
                ModelState.AddModelError("", "Trainee not found.");
                ViewBag.Courses = await _dbcontext.Courses.ToListAsync();
                return View("Add_Edit_CrsResult", model);
            }

          await  courseRes_Services.AddCourseRes(model);
            
            return RedirectToAction(
                "TraineeDetails", "Trainee",new { id = model.TraineeID }
            );
        }

        [HttpGet]
        public async Task<IActionResult> EditCrsResult(int id)
        {
            var crsResult = await courseRes_Services.FindCourseResById(id);
            
            ViewBag.Courses = await _dbcontext.Courses.ToListAsync();
            ViewBag.ButtonText = "Update";
            ViewBag.Action = "SaveEditCrsResult";

            return View("Add_Edit_CrsResult", crsResult);   
        }
        [HttpPost]
        public async Task<IActionResult> SaveEditCrsResult(CrsResult model)
        {
            if (ModelState.IsValid)
            {
               await  courseRes_Services.UpdateCourseRes(model);
                return RedirectToAction("TraineeDetails", "trainee");
            }
            ViewBag.Courses = await _dbcontext.Courses.ToListAsync();
            ViewBag.ButtonText = "Update";
            ViewBag.Action = "SaveEditCrsResult";
            return View("Add_Edit_CrsResult", model);
        }
    }
}
