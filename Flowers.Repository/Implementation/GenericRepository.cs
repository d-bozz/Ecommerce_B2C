using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Flowers.Repository.Contract;
using Flowers.Repository.DBContext;

namespace Flowers.Repository.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly FlowersB2cContext _dbContext;

        public GenericRepository(FlowersB2cContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Create(T model)
        {
            try 
            {
                _dbContext.Set<T>().Add(model);
                await _dbContext.SaveChangesAsync();
                return model;
            }
            catch 
            {
                throw;
            }
        }

        public async Task<bool> Delete(T model)
        {
            try
            {
                _dbContext.Set<T>().Remove(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Edit(T model)
        {
            try
            {
                _dbContext.Set<T>().Update(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public IQueryable<T> Get(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = (filter == null) ? _dbContext.Set<T>(): _dbContext.Set<T>().Where(filter);
            return query;
        }
    }
}
