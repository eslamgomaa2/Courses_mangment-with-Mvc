namespace TasksProject._02_Repositories.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
        public Task AddAsync(T model);
        public Task DeleteAsync(T model);
        public Task UpdateAsync(T model);
        public Task<List<T>> GetAllAsync();
        public Task<T> GetByidAsync(int id);
    }
}
