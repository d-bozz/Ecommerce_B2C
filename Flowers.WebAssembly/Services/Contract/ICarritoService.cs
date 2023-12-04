using Flowers.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers.WebAssembly.Services.Contract
{
    public interface ICarritoService
    {
        event Action ShowItems;

        int QuantityProducts();
        Task AddCarrito(CarritoDTO model);
        Task RemoveCarrito(int idProducto);
        Task<List<CarritoDTO>> ReturnCarrito();
        Task CleanCarrito();
    }
}
