using System;
using System.Collections.Generic;

namespace Flowers.Models;

public partial class Pago
{
    public int PagoId { get; set; }

    public string PagoMetodo { get; set; } = null!;

    public decimal PagoMonto { get; set; }

    public int UsuarioId { get; set; }

    public DateTime? PagoCreatedAt { get; set; }

    public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();

    public virtual Usuario Usuario { get; set; } = null!;
}
