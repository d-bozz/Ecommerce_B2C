using AutoMapper;
using Ecommerce.DTO;
using Ecommerce.Models;
using Ecommerce.Repository.Contract;
using Ecommerce.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Services.Implementation
{
    public class WishlistService : IWishlistService
    {
        #region Properties and Fields

        private readonly IGenericRepository<Wishlist> _genericRepository;
        private readonly IMapper _mapper;
        private readonly IProductoService _productoServicio;

        #endregion

        #region Constructor

        public WishlistService(IGenericRepository<Wishlist> genericRepository, IMapper mapper, IProductoService productoServicio)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _productoServicio = productoServicio;
        }

        #endregion

        #region Methods

        public async Task<WishlistDTO> Add(WishlistDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<Wishlist>(modelo);
                var rspModelo = await _genericRepository.Create(dbModelo);

                if (rspModelo.IdWishlist != 0)
                {
                    return _mapper.Map<WishlistDTO>(rspModelo);
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
                var consulta = _genericRepository.Get(p => p.IdWishlist == id);
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

        public async Task<WishlistDTO> Get(int id)
        {
            try
            {
                var consulta = _genericRepository.Get(p => p.IdWishlist == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    return _mapper.Map<WishlistDTO>(fromDbModelo);
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

        public async Task<WishlistDTO> GetByIdUsuarioAndIdProducto(int idUsuario, int idProducto)
        {
            try
            {
                var consulta = _genericRepository.Get(p => p.IdUsuario == idUsuario && p.IdProducto == idProducto);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    return _mapper.Map<WishlistDTO>(fromDbModelo);
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

        public async Task<List<WishlistDTO>> List(int id)
        {
            try
            {
                var consulta = _genericRepository.Get(u => u.IdUsuario == id);
                consulta = consulta.Include(p => p.IdProductoNavigation);

                List<WishlistDTO> lista = _mapper.Map<List<WishlistDTO>>(await consulta.ToListAsync());

                foreach (var wishlistItem in lista)
                {
                    var producto = await _productoServicio.Get(wishlistItem.IdProducto);
                    wishlistItem.Producto = producto;
                }

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
