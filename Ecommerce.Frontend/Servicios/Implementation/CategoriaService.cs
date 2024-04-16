using Ecommerce.DTO;
using Ecommerce.Frontend.Services.Contrat;
using System.Net.Http.Json;

namespace Ecommerce.Frontend.Services.Implementation
{
    public class CategoriaService : ICategoriaService
    {
        #region Properties and Fields

        private readonly HttpClient _httpClient;

        public CategoriaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #endregion

        #region Methods

        public async Task<ResponseDTO<CategoriaDTO>> Create(CategoriaDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("Categoria/Create", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<CategoriaDTO>>();
            return result;
        }

        public async Task<ResponseDTO<bool>> Delete(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Categoria/Delete/{id}");
        }

        public async Task<ResponseDTO<bool>> Edit(CategoriaDTO model)
        {
            var response = await _httpClient.PutAsJsonAsync("Categoria/Edit", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result;
        }

        public async Task<ResponseDTO<CategoriaDTO>> Get(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<CategoriaDTO>>($"Categoria/Get/{id}");
        }

        public async Task<ResponseDTO<List<CategoriaDTO>>> List(string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<CategoriaDTO>>>($"Categoria/List/{buscar}");
        }

        #endregion
    }
}