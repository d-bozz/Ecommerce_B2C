using System;
using System.Collections.Generic;

namespace Flowers.Models;

public partial class Carrito
{
    public int CarritoId { get; set; }

    public int CarritoCantidad { get; set; }

    public int ProductoId { get; set; }

    public int UsuarioId { get; set; }

    public DateTime? CarritoCreatedAt { get; set; }

    public virtual Producto Producto { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
