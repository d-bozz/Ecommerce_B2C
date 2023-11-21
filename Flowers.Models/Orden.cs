using System;
using System.Collections.Generic;

namespace Flowers.Models;

public partial class Orden
{
    public int OrdenId { get; set; }

    public decimal OrdenPrecio { get; set; }

    public int UsuarioId { get; set; }

    public int PagoId { get; set; }

    public int EnvioId { get; set; }

    public DateTime? OrdenCreatedAt { get; set; }

    public virtual Envio Envio { get; set; } = null!;

    public virtual ICollection<OrdenItem> OrdenItems { get; set; } = new List<OrdenItem>();

    public virtual Pago Pago { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
