using TasksProject._02_Repositories.Interfaces;
using TasksProject._03_Services.Interfaces;
using TasksProject.Models;

public class DepartmentServices : IDepartmentServices
{
    private readonly IGenericRepo<Course> courseRepo;
    private readonly IGenericRepo<Trainee> traineeRepo;
    private readonly IGenericRepo<Department> departmentRepo;
    private readonly IGenericRepo<Instructor> instructorRepo;

    public DepartmentServices(
        IGenericRepo<Department> departmentRepo,
        IGenericRepo<Trainee> traineeRepo,
        IGenericRepo<Course> courseRepo,
        IGenericRepo<Instructor> instructorRepo)
    {
        this.departmentRepo = departmentRepo;
        this.traineeRepo = traineeRepo;
        this.courseRepo = courseRepo;
        this.instructorRepo = instructorRepo;
    }

    public async Task AddDepartment(Department model)
    {
        await departmentRepo.AddAsync(model);
    }

    public async Task DeleteDepartment(int id)
    {
        var department = await departmentRepo.GetByidAsync(id);
        if (department != null)
            await departmentRepo.DeleteAsync(department);
    }

    public async Task<Department> GetDepartmentById(int id)
    {
        return await departmentRepo.GetByidAsync(id);
    }

    public async Task UpdateDepartment(Department model)
    {
        var department = await departmentRepo.GetByidAsync(model.Id);
        if (department != null)
        {
            department.Name = model.Name;
            department.Manger = model.Manger;
            await departmentRepo.UpdateAsync(department);
        }
    }

    public async Task<int> GetTotalCoursesCount()
    {
        var courses = await courseRepo.GetAllAsync();
        return courses.Count();
    }

    public async Task<int> GetTotalInstructorsCount()
    {
        var instructors = await instructorRepo.GetAllAsync();
        return instructors.Count();
    }

    public async Task<int> GetTotalTraineesCount()
    {
        var trainees = await traineeRepo.GetAllAsync();
        return trainees.Count();
    }

    public async Task<List<Department>> GetAllDepartment()
    {
        return await departmentRepo.GetAllAsync();
    }
}
