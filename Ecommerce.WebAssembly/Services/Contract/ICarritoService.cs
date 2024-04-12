using Ecommerce.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.WebAssembly.Services.Contract
{
    public interface ICarritoService
    {
        event Action ShowItems;

        int QuantityProducts();
        decimal TotalProducts();
        Task AddCarrito(CarritoDTO model);
        Task RemoveCarrito(int idProducto);
        Task<List<CarritoDTO>> ReturnCarrito();
        Task CleanCarrito();
    }
}