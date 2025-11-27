using TasksProject.Models;

namespace TasksProject._02_Repositories.Interfaces
{
    public interface ITraineeRepo
    {
        public Task<Trainee> GetTraineeDetails(int id);

        public Task<List<Trainee>> GetAllTrainee_InSpecific_Course(int id);

    }
}
