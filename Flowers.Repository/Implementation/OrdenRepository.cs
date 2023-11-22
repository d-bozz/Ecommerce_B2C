using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flowers.Models;
using Flowers.Repository.Contract;
using Flowers.Repository.DBContext;

namespace Flowers.Repository.Implementation
{
    public class OrdenRepository : GenericRepository<Orden>, IOrdenRepository
    {
        private readonly FlowersB2cContext _dbContext;

        public OrdenRepository(FlowersB2cContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Orden> Register(Orden model)
        {
            throw new NotImplementedException();
        }
    }
}
