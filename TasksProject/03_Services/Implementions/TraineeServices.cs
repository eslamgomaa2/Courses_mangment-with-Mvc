using TasksProject._02_Repositories.Interfaces;
using TasksProject._03_Services.Interfaces;
using TasksProject.Models;

namespace TasksProject._03_Services.Implementions
{
    public class TraineeServices : ITraineeServices
    {
        private readonly ITraineeRepo _traineerepo;
        private readonly IGenericRepo<Trainee> _genericRepo;

        public TraineeServices(IGenericRepo<Trainee> genericRepo, ITraineeRepo traineerepo)
        {
            this._genericRepo = genericRepo;
            _traineerepo = traineerepo;
        }

        public async Task AddTrainee(Trainee model)
        {
            await _genericRepo.AddAsync(model);
        }

        public async Task<List<Trainee>> GetAllTrainees()
        {
            return await _genericRepo.GetAllAsync();
        }

        public async Task<Trainee> GetTraineeById(int id)
        {
           var trainee =await _genericRepo.GetByidAsync(id);
            if(trainee is null) throw new ArgumentNullException(nameof(trainee));
            return trainee;

        }

        public Task<Trainee> GetTraineeDetails(int id)
        {
            var trainee = _traineerepo.GetTraineeDetails(id);
            if (trainee == null)
            {
                throw new Exception("Trainee not found");
            }
            return trainee;
        }

        public async Task RemoveTrainee(Trainee model)
        {
            await _genericRepo.DeleteAsync(model);
        }

        public async Task Updatetrainee(Trainee model)
        {
            await _genericRepo.UpdateAsync(model);
        }
    }
}
