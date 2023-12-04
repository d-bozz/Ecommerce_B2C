using Flowers.DTO;
using Flowers.WebAssembly.Services.Contract;
using System.Net.Http.Json;

namespace Flowers.WebAssembly.Services.Implementation
{
    public class VentaService : IVentaService
    {
        #region Properties and Fields

        private readonly HttpClient _httpClient;

        #endregion

        #region Constructor

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
