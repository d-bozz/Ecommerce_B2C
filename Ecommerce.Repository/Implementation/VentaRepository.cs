using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Models;
using Ecommerce.Repository.Contract;
using Ecommerce.Repository.DBContext;

namespace Ecommerce.Repository.Implementation
{
    public class VentaRepository : GenericRepository<Venta>, IVentaRepository
    {
        private readonly EcommerceB2cContext _dbContext;

        public VentaRepository(EcommerceB2cContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Venta> Register(Venta model)
        {
            throw new NotImplementedException();
        }
    }
}
