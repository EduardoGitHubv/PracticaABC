using System;
using System.Collections.Generic;

namespace PracticaABC.Models;

public partial class TipoDistribucion
{
    public int IdDist { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<ProductoDistribucion> ProductoDistribucions { get; } = new List<ProductoDistribucion>();
}
