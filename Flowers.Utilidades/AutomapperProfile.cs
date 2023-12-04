using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Flowers.DTO;
using Flowers.Models;

namespace Flowers.Utilities
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile() 
        {
            #region Usuario

            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<Usuario, SesionDTO>();
            CreateMap<UsuarioDTO, Usuario>();

            #endregion

            #region Categoria

            CreateMap<Categoria, CategoriaDTO>();
            CreateMap<CategoriaDTO, Categoria>();

            #endregion

            #region Producto

            CreateMap<Producto, ProductoDTO>();
            CreateMap<ProductoDTO, Producto>().ForMember(destino => 
                destino.IdCategoriaNavigation,
                opt => opt.Ignore()
            );

            #endregion

            #region DetalleVenta

            CreateMap<DetalleVenta, DetalleVentaDTO>();
            CreateMap<DetalleVentaDTO, DetalleVenta>();

            #endregion

            #region Venta

            CreateMap<Venta, VentaDTO>();
            CreateMap<VentaDTO, Venta>();

            #endregion
        }
    }
}