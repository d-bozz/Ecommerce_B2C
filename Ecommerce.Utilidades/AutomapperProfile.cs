using AutoMapper;
using Ecommerce.DTO;
using Ecommerce.Models;

namespace Ecommerce.Utilities
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

            #region Wishlist

            CreateMap<Wishlist, WishlistDTO>();
            CreateMap<WishlistDTO, Wishlist>();

            #endregion
        }
    }
}