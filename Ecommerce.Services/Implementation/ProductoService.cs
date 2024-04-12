using AutoMapper;
using Ecommerce.DTO;
using Ecommerce.Models;
using Ecommerce.Repository.Contract;
using Ecommerce.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Services.Implementation
{
    public class ProductoService : IProductoService
    {
        #region Properties and Fields

        private readonly IGenericRepository<Producto> _genericRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public ProductoService(IGenericRepository<Producto> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<List<ProductoDTO>> Catalogue(string categoria, string buscar)
        {
            try
            {
                var consulta = _genericRepository.Get(p =>
                p.Nombre.ToLower().Contains(buscar.ToLower()) &&
                p.IdCategoriaNavigation.Nombre.ToLower().Contains(categoria.ToLower())
                );

                List<ProductoDTO> lista = _mapper.Map<List<ProductoDTO>>(await consulta.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ProductoDTO> Create(ProductoDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<Producto>(modelo);
                var rspModelo = await _genericRepository.Create(dbModelo);

                if (rspModelo.IdProducto != 0)
                {
                    return _mapper.Map<ProductoDTO>(rspModelo);
                }
                else
                {
                    throw new TaskCanceledException("No se pudo crear");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var consulta = _genericRepository.Get(p => p.IdProducto == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    var respuesta = await _genericRepository.Delete(fromDbModelo);
                    if (!respuesta)
                    {
                        throw new TaskCanceledException("No se pudo eliminar");
                    }
                    return respuesta;
                }
                else
                    throw new TaskCanceledException("No se encontraron resultados");

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Edit(ProductoDTO modelo)
        {
            try
            {
                var consulta = _genericRepository.Get(p => p.IdProducto == modelo.IdProducto);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.Nombre = modelo.Nombre;
                    fromDbModelo.Descripcion = modelo.Descripcion;
                    fromDbModelo.IdCategoria = modelo.IdCategoria;
                    fromDbModelo.Precio = modelo.Precio;
                    fromDbModelo.PrecioOferta = modelo.PrecioOferta;
                    fromDbModelo.Cantidad = modelo.Cantidad;
                    fromDbModelo.Imagen = modelo.Imagen;
                    var respuesta = await _genericRepository.Edit(fromDbModelo);

                    if (!respuesta)
                    {
                        throw new TaskCanceledException("No se pudo editar");
                    }
                    return respuesta;
                }
                else
                {
                    throw new TaskCanceledException("No se encontraron resultados");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductoDTO> Get(int id)
        {
            try
            {
                var consulta = _genericRepository.Get(p => p.IdProducto == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    return _mapper.Map<ProductoDTO>(fromDbModelo);
                }
                else
                {
                    throw new TaskCanceledException("No se encontraron coincidencias");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<ProductoDTO>> List(string buscar)
        {
            try
            {
                var consulta = _genericRepository.Get(p =>
                p.Nombre.ToLower().Contains(buscar.ToLower())
                );

                consulta = consulta.Include(c => c.IdCategoriaNavigation);

                List<ProductoDTO> lista = _mapper.Map<List<ProductoDTO>>(await consulta.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}
