using Ecommerce.DTO;

namespace Ecommerce.Frontend.Services.Contrat
{
    public interface IProductoService
    {
        Task<ResponseDTO<List<ProductoDTO>>> List(string buscar);
        Task<ResponseDTO<List<ProductoDTO>>> Catalogue(string categoria, string buscar);
        Task<ResponseDTO<ProductoDTO>> Get(int id);
        Task<ResponseDTO<ProductoDTO>> Create(ProductoDTO model);
        Task<ResponseDTO<bool>> Edit(ProductoDTO model);
        Task<ResponseDTO<bool>> Delete(int id);
    }
}
