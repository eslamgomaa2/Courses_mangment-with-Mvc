using TasksProject.Models;

namespace TasksProject._03_Services.Interfaces
{
    public interface ICourseRes_Services
    {
        public Task AddCourseRes(CrsResult model);
        public bool IsTraineeExist(int id);

          public Task<CrsResult> FindCourseResById(int id);
            public Task UpdateCourseRes(CrsResult model);
    }
}
