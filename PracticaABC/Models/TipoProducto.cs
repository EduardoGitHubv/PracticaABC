using System;
using System.Collections.Generic;

namespace PracticaABC.Models;

public partial class TipoProducto
{
    public int IdTipoProd { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<ProductoDistribucion> ProductoDistribucions { get; } = new List<ProductoDistribucion>();
}
