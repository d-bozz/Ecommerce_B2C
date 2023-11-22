using Flowers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers.Repository.Contract
{
    public interface IOrdenRepository : IGenericRepository<Orden>
    {
        Task<Orden> Register(Orden model);
    }
}
