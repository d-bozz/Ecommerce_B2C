using System;
using System.Collections.Generic;

namespace Flowers.Models;

public partial class Envio
{
    public int EnvioId { get; set; }

    public string EnvioDireccion { get; set; } = null!;

    public string EnvioCiudad { get; set; } = null!;

    public string EnvioDepartamento { get; set; } = null!;

    public string EnvioDescripcion { get; set; } = null!;

    public int UsuarioId { get; set; }

    public DateTime? EnvioCreatedAt { get; set; }

    public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();

    public virtual Usuario Usuario { get; set; } = null!;
}
