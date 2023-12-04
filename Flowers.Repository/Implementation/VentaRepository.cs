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
    public class VentaRepository : GenericRepository<Venta>, IVentaRepository
    {
        private readonly FlowersB2cContext _dbContext;

        public VentaRepository(FlowersB2cContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Venta> Register(Venta model)
        {
            throw new NotImplementedException();
        }
    }
}
