using Flowers.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers.Services.Contract
{
    public interface IVentaService
    {
        Task<VentaDTO> Register(VentaDTO model);
    }
}
