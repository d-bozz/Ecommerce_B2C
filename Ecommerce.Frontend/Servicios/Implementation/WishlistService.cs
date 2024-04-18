using Blazored.LocalStorage;
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
            try
            {
                var response = await _httpClient.PostAsJsonAsync("Wishlist/Add", model);
                return await response.Content.ReadFromJsonAsync<ResponseDTO<WishlistDTO>>();
            }
            catch (Exception ex)
            {
                return new ResponseDTO<WishlistDTO>
                {
                    IsCorrect = false,
                    Message = "Error al agregar a la lista de deseos: " + ex.Message
                };
            }
        }

        public async Task<ResponseDTO<bool>> Delete(int id)
        {
            try
            {
                return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Wishlist/Delete/{id}");
            }
            catch (Exception ex)
            {
                return new ResponseDTO<bool>
                {
                    IsCorrect = false,
                    Message = "Error al eliminar elemento de la lista de deseos: " + ex.Message
                };
            }
        }

        public async Task<ResponseDTO<WishlistDTO>> Get(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ResponseDTO<WishlistDTO>>($"Wishlist/Get/{id}");
            }
            catch (Exception ex)
            {
                return new ResponseDTO<WishlistDTO>
                {
                    IsCorrect = false,
                    Message = "Error al obtener elemento de la lista de deseos: " + ex.Message
                };
            }
        }

        public async Task<ResponseDTO<WishlistDTO>> GetByIdUsuarioAndIdProducto(int idUsuario, int idProducto)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ResponseDTO<WishlistDTO>>($"Wishlist/GetByIdUsuarioAndIdProducto/{idUsuario}/{idProducto}");
            }
            catch (Exception ex)
            {
                return new ResponseDTO<WishlistDTO>
                {
                    IsCorrect = false,
                    Message = "Error al obtener elemento de la lista de deseos por usuario y producto: " + ex.Message
                };
            }
        }

        public async Task<ResponseDTO<List<WishlistDTO>>> List(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ResponseDTO<List<WishlistDTO>>>($"Wishlist/List/{id}");
            }
            catch (Exception ex)
            {
                return new ResponseDTO<List<WishlistDTO>>
                {
                    IsCorrect = false,
                    Message = "Error al obtener lista de deseos: " + ex.Message
                };
            }
        }

        public async Task<int> GetWishlistItemCount(int userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"Wishlist/CountItems/{userId}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ResponseDTO<int>>();
                    if (result != null && result.IsCorrect)
                    {
                        return result.Result;
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        #endregion
    }
}