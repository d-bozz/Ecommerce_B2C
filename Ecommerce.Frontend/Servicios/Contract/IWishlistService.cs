using Ecommerce.DTO;

namespace Ecommerce.Frontend.Services.Contrat
{
    public interface IWishlistService
    {
        Task<ResponseDTO<List<WishlistDTO>>> List(int id);
        Task<ResponseDTO<WishlistDTO>> Get(int id);
        Task<ResponseDTO<WishlistDTO>> GetByIdUsuarioAndIdProducto(int idUsuario, int idProducto);
        Task<ResponseDTO<WishlistDTO>> Add(WishlistDTO model);
        Task<ResponseDTO<bool>> Delete(int id);
    }
}
