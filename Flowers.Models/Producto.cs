using System;
using System.Collections.Generic;

namespace Flowers.Models;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string ProductoCodigo { get; set; } = null!;

    public string ProductoNombre { get; set; } = null!;

    public string ProductoDescripcion { get; set; } = null!;

    public decimal ProductoPrecio { get; set; }

    public int ProductoStock { get; set; }

    public int CategoriaId { get; set; }

    public DateTime? ProductoCreatedAt { get; set; }

    public virtual ICollection<Carrito> Carritos { get; set; } = new List<Carrito>();

    public virtual Categoria Categoria { get; set; } = null!;

    public virtual ICollection<Foto> Fotos { get; set; } = new List<Foto>();

    public virtual ICollection<ListaDeseo> ListaDeseos { get; set; } = new List<ListaDeseo>();

    public virtual ICollection<OrdenItem> OrdenItems { get; set; } = new List<OrdenItem>();
}
