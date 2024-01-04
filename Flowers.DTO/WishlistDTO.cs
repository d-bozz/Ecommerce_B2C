using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers.DTO
{
    public class WishlistDTO
    {
        public int IdWishlist { get; set; }

        public int IdUsuario { get; set; }

        public int IdProducto { get; set; }

        public int? Cantidad { get; set; }

        public ProductoDTO? Producto { get; set; }

        public DateTime? FechaCreacion { get; set; }
    }
}
