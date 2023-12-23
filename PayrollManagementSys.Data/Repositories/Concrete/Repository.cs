using Microsoft.EntityFrameworkCore;
using PayrollManagementSys.Data.Context;
using PayrollManagementSys.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagementSys.Data.Repositories.Concrete
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly AppDbContext dbContext;

        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        private DbSet<T> table { get => dbContext.Set<T>(); }
        public async Task AddAsync(T entity)
        {
            await table.AddAsync(entity);
        }

        public Task<int> CountAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(()=>table.Remove(entity));
        }

        public async Task<List<T>> GetAllAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate = null, params System.Linq.Expressions.Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = table;
           
            if(predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties.Any())
            {
                foreach(var property in includeProperties)
                {
                    query = query.Include(property);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate, params System.Linq.Expressions.Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = table;
            query = query.Where(predicate);
            if (includeProperties.Any())
            {
                foreach(var property in includeProperties)
                {
                    query.Include(property);
                }
            }
            return await query.SingleAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await table.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(()=>table.Update(entity));
            return entity;
        }
    }
}
