using Ecommerce.DTO;
using Ecommerce.Frontend.Services.Contrat;
using System.Net.Http.Json;

namespace Ecommerce.Frontend.Services.Implementation
{
    public class ProductoService : IProductoService
    {
        #region Properties and Fields

        private readonly HttpClient _httpClient;

        public ProductoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #endregion

        #region Methods

        public async Task<ResponseDTO<List<ProductoDTO>>> Catalogue(string categoria, string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ProductoDTO>>>($"Producto/Catalogue/{categoria}/{buscar}");
        }

        public async Task<ResponseDTO<ProductoDTO>> Create(ProductoDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("Producto/Create", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<ProductoDTO>>();
            return result;
        }

        public async Task<ResponseDTO<bool>> Delete(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Producto/Delete/{id}");
        }

        public async Task<ResponseDTO<bool>> Edit(ProductoDTO model)
        {
            var response = await _httpClient.PutAsJsonAsync("Producto/Edit", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result;
        }

        public async Task<ResponseDTO<ProductoDTO>> Get(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<ResponseDTO<ProductoDTO>>($"Producto/Get/{id}");

            if (response == null || !response.IsCorrect || response.Result == null)
            {
                return new ResponseDTO<ProductoDTO>
                {
                    IsCorrect = false,
                    Message = "La respuesta del servicio no es válida."
                };
            }

            return response;
        }

        public async Task<ResponseDTO<List<ProductoDTO>>> List(string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ProductoDTO>>>($"Producto/List/{buscar}");
        }

        #endregion
    }
}
