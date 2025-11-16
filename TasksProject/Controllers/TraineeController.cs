using DBcontext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TasksProject._03_Services.Interfaces;
using TasksProject.Models;

namespace TasksProject.Controllers
{
    public class TraineeController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly ITraineeServices _traineeServices;

        public TraineeController(ApplicationDbContext dbcontext, ITraineeServices traineeServices)
        {
            _dbcontext = dbcontext;
            _traineeServices = traineeServices;
        }

        [HttpGet]
        public async Task<IActionResult> AllTrainee()
        {
            var trainees = await _traineeServices.GetAllTrainees();
            return View("AllTrainee",trainees);
        }
        [HttpGet]
        public async Task<IActionResult> AddTrainee()
        {
            ViewBag.Departments = await _dbcontext.Departments.ToListAsync();
            ViewBag.ButtonText = "Add";
            ViewBag.Action = "SaveAddedTrainee";

            return View("Add_Edit_Trainee");
        }


        [HttpPost]
        public async Task<IActionResult> SaveAddedTrainee(Trainee model)
        {
            if (ModelState.IsValid)
            {
                await _traineeServices.AddTrainee(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Departments = await _dbcontext.Departments.ToListAsync();
            ViewBag.ButtonText = "Add";
            ViewBag.Action = "SaveAddedTrainee";
            return View("Add_Edit_Trainee",model);
        }

        [HttpGet]
        public async Task<IActionResult> EditTrainee(int id)
        {
            var trainee = await _traineeServices.GetTraineeById(id);
            
            ViewBag.Departments = await _dbcontext.Departments.ToListAsync();
            ViewBag.ButtonText = "Update";
            ViewBag.Action = "SaveEditTrainee";
            return View("Add_Edit_Trainee", trainee);
        }

        [HttpPost]
        public async Task<IActionResult> SaveEditTrainee(Trainee model)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.Trainees.Update(model);
                await _dbcontext.SaveChangesAsync();
                return RedirectToAction("GetAllTrainee");
            }
            ViewBag.Departments = await _dbcontext.Departments.ToListAsync();
            ViewBag.ButtonText = "Update";
            ViewBag.Action = "SaveEditTrainee";
            return View("Add_Edit_Trainee",model);
        }
        [HttpGet]
        public async Task<IActionResult> TraineeDetails(int id)
        {
            var trainee = await _traineeServices.GetTraineeDetails(id);

            return View("TraineeDetails",trainee);
        }




        [HttpPost]
        public async Task<IActionResult> DeleteTrainee(int id)
        {
            var trainee = await _traineeServices.GetTraineeById(id);
            await _traineeServices.RemoveTrainee(trainee);
            return RedirectToAction("GetAllTrainee");
        }
    }
}
