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
using Flowers.Repository.Implementation;

namespace Flowers.Services.Implementation
{
    public class VentaService : IVentaService
    {
        #region Properties and Fields

        private readonly IVentaRepository _ventaRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public VentaService(IVentaRepository ventaRepository, IMapper mapper)
        {
            _ventaRepository = ventaRepository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<VentaDTO> Register(VentaDTO model)
        {
            try
            {
                var dbModelo = _mapper.Map<Venta>(model);
                var ventaGenerada = await _ventaRepository.Register(dbModelo);

                if (ventaGenerada.IdVenta == 0)
                {
                    throw new TaskCanceledException("No se pudo registrar");
                }
                return _mapper.Map<VentaDTO>(ventaGenerada);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}
