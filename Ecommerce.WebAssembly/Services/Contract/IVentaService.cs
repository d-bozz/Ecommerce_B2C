using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Services.Contract
{
    public interface IVentaService
    {
        Task<ResponseDTO<VentaDTO>> Register(VentaDTO model);
    }
}
