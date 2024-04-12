using AutoMapper;
using Ecommerce.DTO;
using Ecommerce.Models;
using Ecommerce.Repository.Contract;
using Ecommerce.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Services.Implementation
{
    public class CategoriaService : ICategoriaService
    {
        #region Properties and Fields

        private readonly IGenericRepository<Categoria> _genericRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public CategoriaService(IGenericRepository<Categoria> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<CategoriaDTO> Create(CategoriaDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<Categoria>(modelo);
                var rspModelo = await _genericRepository.Create(dbModelo);

                if (rspModelo.IdCategoria != 0)
                {
                    return _mapper.Map<CategoriaDTO>(rspModelo);
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
                var consulta = _genericRepository.Get(p => p.IdCategoria == id);
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

        public async Task<bool> Edit(CategoriaDTO modelo)
        {
            try
            {
                var consulta = _genericRepository.Get(p => p.IdCategoria == modelo.IdCategoria);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.Nombre = modelo.Nombre;
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

        public async Task<CategoriaDTO> Get(int id)
        {
            try
            {
                var consulta = _genericRepository.Get(p => p.IdCategoria == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    return _mapper.Map<CategoriaDTO>(fromDbModelo);
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

        public async Task<List<CategoriaDTO>> List(string buscar)
        {
            try
            {
                var consulta = _genericRepository.Get(p =>
                p.Nombre!.ToLower().Contains(buscar.ToLower())
                );

                List<CategoriaDTO> lista = _mapper.Map<List<CategoriaDTO>>(await consulta.ToListAsync());
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
