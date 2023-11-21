using System;
using System.Collections.Generic;

namespace Flowers.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string UsuarioNombre { get; set; } = null!;

    public string UsuarioApellido { get; set; } = null!;

    public string UsuarioEmail { get; set; } = null!;

    public string UsuarioPassword { get; set; } = null!;

    public string UsuarioDireccion { get; set; } = null!;

    public string UsuarioTelefono { get; set; } = null!;

    public string UsuarioRol { get; set; } = null!;

    public DateTime? UsuarioCreatedAt { get; set; }

    public virtual ICollection<Carrito> Carritos { get; set; } = new List<Carrito>();

    public virtual ICollection<Envio> Envios { get; set; } = new List<Envio>();

    public virtual ICollection<ListaDeseo> ListaDeseos { get; set; } = new List<ListaDeseo>();

    public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
