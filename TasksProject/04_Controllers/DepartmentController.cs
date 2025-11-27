using Microsoft.AspNetCore.Mvc;
using TasksProject._03_Services.Interfaces;
using TasksProject.Models;

namespace TasksProject._04_Controllers
{
    public class DepartmentController : Controller
    {

        private readonly IDepartmentServices department;

        public DepartmentController(IDepartmentServices department)
        {
            this.department = department;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var data = await department.GetAllDepartment();
            return View("AllDepartments", data);
        }

        public IActionResult AddDepartment()
        {
          
           return  View("Add_Edit_Department");
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(Department model)
        {
            if (!ModelState.IsValid) return View("Add_Edit_Department", model);

            await department.AddDepartment(model);
            return RedirectToAction("GetAllDepartments");
        }

        public async Task<IActionResult> EditDepartment(int id)
        {
            var model = await department.GetDepartmentById(id);
            return View("Add_Edit_Department", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditDepartment(Department model)
        {
            if (!ModelState.IsValid) return View("Add_Edit_Department", model);
            await department.UpdateDepartment(model);
            return RedirectToAction("GetAllDepartments");
        }

        public async Task<IActionResult> DeleteDepartment(int id)
        {

            await department.DeleteDepartment(id);
            return RedirectToAction("GetAllDepartments");
        }

    }
}
