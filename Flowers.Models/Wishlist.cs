using System;
using System.Collections.Generic;

namespace Flowers.Models;

public partial class Wishlist
{
    public int IdWishlist { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
