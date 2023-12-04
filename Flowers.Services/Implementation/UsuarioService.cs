using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Flowers.Models;
using Flowers.DTO;
using Flowers.Repository.Contract;
using Flowers.Services.Contract;
using AutoMapper;

namespace Flowers.Services.Implementation
{
    public class UsuarioService : IUsuarioService
    {
        #region Properties and Fields

        private readonly IGenericRepository<Usuario> _genericRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public UsuarioService(IGenericRepository<Usuario> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<SesionDTO> Autorization(LoginDTO modelo)
        {
            try
            {
                var consulta = _genericRepository.Get(p => p.Correo == modelo.Correo && p.Clave == modelo.Clave);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    return _mapper.Map<SesionDTO>(fromDbModelo);
                }
                else 
                { 
                    throw new TaskCanceledException("El Usuario o la Clave es incorrecto");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UsuarioDTO> Create(UsuarioDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<Usuario>(modelo);
                var rspModelo = await _genericRepository.Create(dbModelo);

                if (rspModelo.IdUsuario != 0)
                {
                    return _mapper.Map<UsuarioDTO>(rspModelo);
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
                var consulta = _genericRepository.Get(p => p.IdUsuario == id);
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

        public async Task<bool> Edit(UsuarioDTO modelo)
        {
            try
            {
                var consulta = _genericRepository.Get(p => p.IdUsuario == modelo.IdUsuario);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.NombreCompleto = modelo.NombreCompleto;
                    fromDbModelo.Correo = modelo.Correo;
                    fromDbModelo.Clave = modelo.Clave;
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

        public async Task<UsuarioDTO> Get(int id)
        {
            try
            {
                var consulta = _genericRepository.Get(p => p.IdUsuario == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    return _mapper.Map<UsuarioDTO>(fromDbModelo);
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

        public async Task<List<UsuarioDTO>> List(string rol, string buscar)
        {
            try
            {
                var consulta = _genericRepository.Get(p =>
                p.Rol == rol &&
                string.Concat(p.NombreCompleto.ToLower(), p.Correo.ToLower()).Contains(buscar.ToLower())
                );

                List<UsuarioDTO> lista = _mapper.Map<List<UsuarioDTO>>(await consulta.ToListAsync());
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
