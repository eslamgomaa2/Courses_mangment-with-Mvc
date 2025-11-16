using DBcontext;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using TasksProject._02_Repositories.Interfaces;

namespace TasksProject.Repositories.Implementions
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly ApplicationDbContext _dbcontext;

        public GenericRepo(ApplicationDbContext context)
        {
            _dbcontext = context;
        }

        public async Task AddAsync(T model)
        {
            await _dbcontext.Set<T>().AddAsync(model);

            await _dbcontext.SaveChangesAsync();

        }

        public async Task DeleteAsync(T model)
        {
            
           _dbcontext.Set<T>().Remove(model);

            await _dbcontext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
           return  await _dbcontext.Set<T>().ToListAsync();

        }

        public  async Task<T> GetByidAsync(int id)
        {
            var res = await _dbcontext.Set<T>().FindAsync(id);
            return res;
        }

        public async Task UpdateAsync( T model)
        {
            _dbcontext.Set<T>().Update(model);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
