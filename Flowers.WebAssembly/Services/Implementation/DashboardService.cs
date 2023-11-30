using Flowers.DTO;
using Flowers.WebAssembly.Services.Contract;
using System.Net.Http.Json;

namespace Flowers.WebAssembly.Services.Implementation
{
    public class DashboardService : IDashboardService
    {
        #region Properties and Fields

        private readonly HttpClient _httpClient;

        #endregion

        #region Constructor

        public DashboardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #endregion

        #region Methods

        public async Task<ResponseDTO<DashboardDTO>> Summary()
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<DashboardDTO>>("Dashboard/Summary");
        }

        #endregion
    }
}
