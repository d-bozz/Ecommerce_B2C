using System;
using System.Collections.Generic;

namespace Flowers.Models;

public partial class OrdenItem
{
    public int OrdenItemId { get; set; }

    public int OrdenItemCantidad { get; set; }

    public decimal OrdenItemPrecio { get; set; }

    public int ProductoId { get; set; }

    public int OrdenId { get; set; }

    public DateTime? OrdenItemsCreatedAt { get; set; }

    public virtual Orden Orden { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
