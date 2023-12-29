using Flowers.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers.Services.Contract
{
    public interface IWishlistService
    {
        Task<List<WishlistDTO>> List(int id);

        Task<WishlistDTO> Get(int id);

        Task<WishlistDTO> GetByIdUsuarioAndIdProducto(int idUsuario, int idProducto);

        Task<WishlistDTO> Add(WishlistDTO modelo);

        Task<bool> Delete(int id);
    }
}
