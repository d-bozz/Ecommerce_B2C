using Ecommerce.DTO;

namespace Ecommerce.Frontend.Services.Contrat
{
    public interface IDashboardService
    {
        Task<ResponseDTO<DashboardDTO>> Summary();
    }
}
