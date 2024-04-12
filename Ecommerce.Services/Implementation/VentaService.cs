using AutoMapper;
using Ecommerce.DTO;
using Ecommerce.Models;
using Ecommerce.Repository.Contract;
using Ecommerce.Services.Contract;

namespace Ecommerce.Services.Implementation
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
