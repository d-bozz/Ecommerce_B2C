using Ecommerce.DTO;

namespace Ecommerce.Frontend.Services.Contrat
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
