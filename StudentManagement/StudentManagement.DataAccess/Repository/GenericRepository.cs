using Microsoft.EntityFrameworkCore;
using StudentManagement.DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DataAccess.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task<T> Create(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await Save();
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding datas: {ex.Message}");
                throw;
            }
        }

        public async Task<T> Delete(T entity)
        {
            try
            {
                _dbSet.Remove(entity);
                await Save();
                return entity;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting datas: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAll(string? includeProperties = "")
        {
            try
            {
                IQueryable<T> query = _dbSet;
                if (!string.IsNullOrWhiteSpace(includeProperties))
                    query = query.Include(includeProperties);
                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching datas: {ex.Message}");
                throw;
            }
        }

        public async Task<T> GetData(Expression<Func<T, bool>> predicate, string? includeProperties = "")
        {
            try
            {
                IQueryable<T> query = _dbSet.Where(predicate);
                if (!string.IsNullOrWhiteSpace(includeProperties))
                    query = query.Include(includeProperties);
                return await query.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching getData function: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> IsValueExit(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await _dbSet.Where(predicate).AnyAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching IsValueExit function: {ex.Message}");
                throw;
            }
        }

        public async Task Save()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred when save function: {ex.Message}");
                throw;
            }
        }

        public async Task<T> Update(T entity)
        {
            try
            {
                _dbSet.Update(entity);
                await Save();
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating datas: {ex.Message}");
                throw;
            }
        }
    }
}
