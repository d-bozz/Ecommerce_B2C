using Flowers.DTO;

namespace Flowers.WebAssembly.Services.Contract
{
    public interface IUsuarioService
    {
        Task<ResponseDTO<List<UsuarioDTO>>> List(string rol, string buscar);
        Task<ResponseDTO<UsuarioDTO>> Get(int id);
        Task<ResponseDTO<SesionDTO>> Autorization(LoginDTO model);
        Task<ResponseDTO<UsuarioDTO>> Create(UsuarioDTO model);
        Task<ResponseDTO<bool>> Edit(UsuarioDTO model);
        Task<ResponseDTO<bool>> Delete(int id);
    }
}
