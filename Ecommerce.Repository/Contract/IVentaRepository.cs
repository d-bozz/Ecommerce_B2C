using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Contract
{
    public interface IVentaRepository : IGenericRepository<Venta>
    {
        Task<Venta> Register(Venta model);
    }
}
