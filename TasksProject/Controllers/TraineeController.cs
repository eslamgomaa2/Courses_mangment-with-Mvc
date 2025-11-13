using DBcontext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TasksProject.Models;

namespace TasksProject.Controllers
{
    public class TraineeController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;

        public TraineeController(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public async Task<IActionResult> AllTrainee()
        {
            var trainees = await _dbcontext.Trainees.ToListAsync();
            return View("AllTrainee",trainees);
        }
        [HttpGet]
        public async Task<IActionResult> AddTrainee()
        {
            ViewBag.Departments = await _dbcontext.Departments.ToListAsync();
            ViewBag.Button = "Add";
            ViewBag.Action = "SaveAddedTrainee";

            return View("Add_Edit_Trainee");
        }


        [HttpPost]
        public async Task<IActionResult> SaveAddedTrainee(Trainee model)
        {
            if (ModelState.IsValid)
            {
                await _dbcontext.Trainees.AddAsync(model);
                await _dbcontext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Departments = await _dbcontext.Departments.ToListAsync();
            ViewBag.Button = "Add";
            ViewBag.Action = "SaveAddedTrainee";
            return View("Add_Edit_Trainee",model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var trainee = await _dbcontext.Trainees.FindAsync(id);
            if (trainee == null) return NotFound();
            ViewBag.Departments = await _dbcontext.Departments.ToListAsync();
            ViewBag.Button = "Update";
            ViewBag.Action = "SaveEdit";
            return View("Add_Edit_Trainee", trainee);
        }

        [HttpPost]
        public async Task<IActionResult> SaveEdit(Trainee model)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.Trainees.Update(model);
                await _dbcontext.SaveChangesAsync();
                return RedirectToAction("GetAllTrainee");
            }
            ViewBag.Departments = await _dbcontext.Departments.ToListAsync();
            ViewBag.Button = "Update";
            ViewBag.Action = "SaveEdit";
            return View("Add_Edit_Trainee",model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var trainee = await _dbcontext.Trainees.FindAsync(id);
            if (trainee == null) return NotFound();

            _dbcontext.Trainees.Remove(trainee);
            await _dbcontext.SaveChangesAsync();
            return RedirectToAction("GetAllTrainee");
        }
    }
}
