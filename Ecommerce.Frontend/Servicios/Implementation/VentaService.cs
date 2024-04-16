using Ecommerce.DTO;
using Ecommerce.Frontend.Services.Contrat;
using System.Net.Http.Json;

namespace Ecommerce.Frontend.Services.Implementation
{
    public class VentaService : IVentaService
    {
        #region Properties and Fields

        private readonly HttpClient _httpClient;

        public VentaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #endregion

        #region Methods

        public async Task<ResponseDTO<VentaDTO>> Register(VentaDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("Venta/Register", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<VentaDTO>>();
            return result;
        }

        #endregion
    }
}