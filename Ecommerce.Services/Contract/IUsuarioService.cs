using Ecommerce.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Contract
{
    public interface IUsuarioService
    {
        Task<List<UsuarioDTO>> List(string rol, string buscar);
        
        Task<UsuarioDTO> Get(int id);
        
        Task<SesionDTO> Autorization(LoginDTO modelo);
        
        Task<UsuarioDTO> Create(UsuarioDTO modelo);
        
        Task<bool> Edit(UsuarioDTO modelo);
        
        Task<bool> Delete(int id);
    }
}
