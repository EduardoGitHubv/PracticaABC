using System;
using System.Collections.Generic;

namespace PracticaABC.Models;

public partial class Estiba
{
    public int IdEstiba { get; set; }

    public string? Nombre { get; set; }

    public int? Cantidad { get; set; }

    public virtual ICollection<ProductoDistribucion> ProductoDistribucions { get; } = new List<ProductoDistribucion>();
}
