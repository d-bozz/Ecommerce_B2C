using Flowers.DTO;

namespace Flowers.WebAssembly.Services.Contract
{
    public interface IVentaService
    {
        Task<ResponseDTO<VentaDTO>> Register(VentaDTO model);
    }
}
