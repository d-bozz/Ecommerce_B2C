using AutoMapper;
using Flowers.Models;
using Flowers.Repository.Contract;
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
    public class DashboardService : IDashboardService
    {
        #region Properties and Fields

        private readonly IVentaRepository _ventaRepository;
        private readonly IGenericRepository<Usuario> _usuarioRepository;
        private readonly IGenericRepository<Producto> _productoRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public DashboardService(
            IGenericRepository<Usuario> usuarioRepository,
            IGenericRepository<Producto> productoRepository,
            IVentaRepository ventaRepository)
        {
            _usuarioRepository = usuarioRepository;
            _productoRepository = productoRepository;
            _ventaRepository = ventaRepository;
        }

        #endregion

        #region Methods

        private string Ingresos()
        {
            var consulta = _ventaRepository.Get();
            decimal? ingresos = consulta.Sum(x => x.Total);
            return Convert.ToString(ingresos);
        }

        private int Ventas()
        {
            var consulta = _ventaRepository.Get();
            var total = consulta.Count();
            return total;
        }

        private int Clientes()
        {
            var consulta = _usuarioRepository.Get(u => u.Rol.ToLower() == "cliente");
            var total = consulta.Count();
            return total;
        }

        private int Productos()
        {
            var consulta = _productoRepository.Get();
            var total = consulta.Count();
            return total;
        }

        public DashboardDTO Summary()
        {
            try
            {
                DashboardDTO dto = new DashboardDTO()
                {
                    TotalIngresos = Ingresos(),
                    TotalVentas = Ventas(),
                    TotalClientes = Clientes(),
                    TotalProductos = Productos()
                };

                return dto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}
