using DBcontext;
using Microsoft.EntityFrameworkCore;
using TasksProject._02_Repositories.Interfaces;
using TasksProject.Models;

namespace TasksProject._02_Repositories.Implementions
{
    public class TraineeRepo : ITraineeRepo
    {
        private readonly ApplicationDbContext _dbcontext;

        public TraineeRepo(ApplicationDbContext context)
        {
            _dbcontext = context;
        }

        public Task<Trainee> GetTraineeDetails(int id)
        {
            var trainee = _dbcontext.Trainees
                .Include(t => t.CrsResults)!
                    .ThenInclude(r => r.Course)
                .SingleOrDefaultAsync(t => t.Id == id);
            return trainee;
        }

      
    }
}
