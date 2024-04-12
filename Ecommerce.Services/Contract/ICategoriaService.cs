using Ecommerce.DTO;

namespace Ecommerce.Services.Contract
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
