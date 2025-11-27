using TasksProject.Models;

namespace TasksProject._03_Services.Interfaces
{
    public interface IDepartmentServices
    {
        public Task<int> GetTotalInstructorsCount();
        public Task<int> GetTotalTraineesCount();
        public Task<int> GetTotalCoursesCount();


        public Task AddDepartment(Department model);
        public Task UpdateDepartment(Department model);
        public Task DeleteDepartment(int id);

        public Task<List<Department>> GetAllDepartment();
        public Task<Department> GetDepartmentById(int id);
        

    }
}
