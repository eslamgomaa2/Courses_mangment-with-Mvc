using TasksProject.Models;

namespace TasksProject._03_Services.Interfaces
{
    public interface ITraineeServices
    {
        public Task<Trainee> GetTraineeById(int id);
        public Task<Trainee> GetTraineeDetails(int id);
        public Task<List<Trainee>> GetAllTrainees();
        public Task AddTrainee(Trainee model);
        public Task RemoveTrainee(Trainee model);
        public Task Updatetrainee(Trainee model);
        public  Task<List<Trainee>> GetAllTrainee_InSpecific_Course(int courseid);
    }
}
