using System;
using System.Collections.Generic;

namespace Flowers.Models;

public partial class Categoria
{
    public int CategoriaId { get; set; }

    public string CategoriaNombre { get; set; } = null!;

    public DateTime? CategoriaCreatedAt { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
