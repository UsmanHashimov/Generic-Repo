using Generic_Repo.Application.Abstractions.IRepositories;
using Generic_Repo.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Generic_Repo.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDBContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(ApplicationDBContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<T> Create(T entity)
        {
            var res = await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return res.Entity;
        }

        public async Task<bool> Delete(Expression<Func<T, bool>> expression)
        {
            var res = await _dbSet.FirstOrDefaultAsync(expression);
            if (res == null)
            {
                return false;
            }
            _dbSet.Remove(res);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByAny(Expression<Func<T, bool>> expression)
        {
            try
            {
                var res = await _dbSet.FirstOrDefaultAsync(expression);
                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<T> Update(T entity)
        {
            var res = _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return res.Entity;
        }
    }
}
