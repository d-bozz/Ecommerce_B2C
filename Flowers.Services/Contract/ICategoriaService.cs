using Flowers.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers.Services.Contract
{
    public interface ICategoriaService
    {
        Task<List<CategoriaDTO>> List(string buscar);

        Task<CategoriaDTO> Get(int id);

        Task<CategoriaDTO> Create(CategoriaDTO modelo);

        Task<bool> Edit(CategoriaDTO modelo);

        Task<bool> Delete(int id);
    }
}
