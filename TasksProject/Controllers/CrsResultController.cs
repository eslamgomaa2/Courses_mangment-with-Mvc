using DBcontext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TasksProject.Models;

namespace TasksProject.Controllers
{
    public class CrsResultController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;

        public CrsResultController(ApplicationDbContext context)
        {
            _dbcontext = context;
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
            var traineeExists = _dbcontext.Trainees.Any(t => t.Id == model.TraineeID);
            if (traineeExists) { 
            if (ModelState.IsValid)
            {
                _dbcontext.CrsResults.Add(model);
                _dbcontext.SaveChanges();
                return RedirectToAction("AllTrainee", "Trainee");
            }
           }
            ViewBag.Courses = await _dbcontext.Courses.ToListAsync();
            ViewBag.ButtonText = "Add";
            ViewBag.Action = "SaveAddCrsResult";
            return View("Add_Edit_CrsResult",model);
        }
        [HttpGet]
        public async Task<IActionResult> EditCrsResult(int id)
        {
            var crsResult = await _dbcontext.CrsResults.SingleOrDefaultAsync(o => o.Id == id);
            if (crsResult == null) return NotFound();
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
                _dbcontext.CrsResults.Update(model);
                await _dbcontext.SaveChangesAsync();
                return RedirectToAction("TraineeDetails", "trainee");
            }
            ViewBag.Courses = await _dbcontext.Courses.ToListAsync();
            ViewBag.ButtonText = "Update";
            ViewBag.Action = "SaveEditCrsResult";
            return View("Add_Edit_CrsResult", model);
        }
    }
}
