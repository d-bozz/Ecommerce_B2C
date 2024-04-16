using Ecommerce.DTO;

namespace Ecommerce.Frontend.Services.Contrat
{
    public interface IVentaService
    {
        Task<ResponseDTO<VentaDTO>> Register(VentaDTO model);
    }
}
