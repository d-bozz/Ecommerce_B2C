﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Ecommerce.Repository.Contract;
using Ecommerce.Repository.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        #region Properties and Fields
        
        private readonly EcommerceB2cContext _dbContext;

        #endregion

        #region Constructor

        public GenericRepository(EcommerceB2cContext dbContext)
        {
            _dbContext = dbContext;
        }
                
        #endregion

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

        public async Task<int> Count(Expression<Func<T, bool>>? filter = null)
        {
            try
            {
                if (filter == null)
                    return await _dbContext.Set<T>().CountAsync();
                else
                    return await _dbContext.Set<T>().CountAsync(filter);
            }
            catch
            {
                throw;
            }
        }
    }
}
