using TasksProject._02_Repositories.Interfaces;
using TasksProject._03_Services.Interfaces;
using TasksProject.Models;

namespace TasksProject._03_Services.Implementions
{
    public class CourseRes_Services : ICourseRes_Services
    {
        private readonly IGenericRepo<CrsResult> genericRepo;

        public CourseRes_Services(IGenericRepo<CrsResult> genericRepo)
        {
            this.genericRepo = genericRepo;
        }

        public async Task AddCourseRes(CrsResult model)
        {
           await genericRepo.AddAsync(model);
        }

        public async Task<CrsResult> FindCourseResById(int id)
        {
           var res= await genericRepo.GetByidAsync(id);
            if (res == null) 
            {
                throw new Exception("Not Found ");
            
            }
            return res;
        }

        public bool IsTraineeExist(int id)
        {
         var rse=    genericRepo.GetByidAsync(id);
            if (rse == null) { return false; }
            return true;

        }

        public async Task UpdateCourseRes(CrsResult model)
        {
           await genericRepo.UpdateAsync(model);
        }
    }
}
