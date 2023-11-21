using System;
using System.Collections.Generic;

namespace Flowers.Models;

public partial class ListaDeseo
{
    public int ListaDeseosId { get; set; }

    public int UsuarioId { get; set; }

    public int ProductoId { get; set; }

    public DateTime? ListaDeseosCreatedAt { get; set; }

    public virtual Producto Producto { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
