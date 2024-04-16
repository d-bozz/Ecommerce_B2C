using Ecommerce.DTO;
using Ecommerce.Frontend.Services.Contrat;
using System.Net.Http.Json;

namespace Ecommerce.Frontend.Services.Implementation
{
    public class WishlistService : IWishlistService
    {
        #region Properties and Fields

        private readonly HttpClient _httpClient;

        public WishlistService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #endregion

        #region Methods

        public async Task<ResponseDTO<WishlistDTO>> Add(WishlistDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("Wishlist/Add", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<WishlistDTO>>();
            return result;
        }

        public async Task<ResponseDTO<bool>> Delete(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Wishlist/Delete/{id}");
        }

        public async Task<ResponseDTO<WishlistDTO>> Get(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<WishlistDTO>>($"Wishlist/Get/{id}");
        }

        public async Task<ResponseDTO<WishlistDTO>> GetByIdUsuarioAndIdProducto(int idUsuario, int idProducto)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<WishlistDTO>>($"Wishlist/GetByIdUsuarioAndIdProducto/{idUsuario}/{idProducto}");
        }

        public async Task<ResponseDTO<List<WishlistDTO>>> List(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<WishlistDTO>>>($"Wishlist/List/{id}");
        }

        #endregion
    }
}