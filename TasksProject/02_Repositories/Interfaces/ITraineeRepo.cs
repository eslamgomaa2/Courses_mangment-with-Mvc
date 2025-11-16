using TasksProject.Models;

namespace TasksProject._02_Repositories.Interfaces
{
    public interface ITraineeRepo
    {
        public Task<Trainee> GetTraineeDetails(int id);

    }
}
