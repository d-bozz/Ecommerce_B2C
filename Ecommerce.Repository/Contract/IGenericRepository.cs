﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Contract
{
    public interface IGenericRepository<T> where T:class
    {
        IQueryable<T> Get(Expression<Func<T,bool>>? filter = null);
        Task<T> Create(T model);
        Task<bool> Edit(T model);
        Task<bool> Delete(T model);
        Task<int> Count(Expression<Func<T, bool>>? filter = null);
    }
}
