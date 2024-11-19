
using Microsoft.EntityFrameworkCore;

namespace APIExample.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        private readonly DbContext _context;

        public GenericRepository(GenericDbContext context)
        {
            _dbSet = context.Set<T>();
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await  _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<T> GetByIdAsync(int id) 
        {
            return await _dbSet.FindAsync(id) ?? 
                throw new ArgumentNullException("Opa! Ocorreu um erro ao tentar recuperar dados.");
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
