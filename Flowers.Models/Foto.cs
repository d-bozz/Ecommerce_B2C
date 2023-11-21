using System;
using System.Collections.Generic;

namespace Flowers.Models;

public partial class Foto
{
    public int FotoId { get; set; }

    public string FotoPath { get; set; } = null!;

    public int ProductoId { get; set; }

    public DateTime? FotoCreatedAt { get; set; }

    public virtual Producto Producto { get; set; } = null!;
}
