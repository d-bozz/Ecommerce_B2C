using Flowers.DTO;

namespace Flowers.WebAssembly.Services.Contract
{
    public interface IDashboardService
    {
        Task<ResponseDTO<DashboardDTO>> Summary();
    }
}
