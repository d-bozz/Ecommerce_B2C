using Ecommerce.DTO;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Contract
{
    public interface IProductoService
    {
        Task<List<ProductoDTO>> List(string buscar);

        Task<List<ProductoDTO>> Catalogue(string categoria, string buscar);

        Task<ProductoDTO> Get(int id);

        Task<ProductoDTO> Create(ProductoDTO modelo);

        Task<bool> Edit(ProductoDTO modelo);

        Task<bool> Delete(int id);
    }
}
