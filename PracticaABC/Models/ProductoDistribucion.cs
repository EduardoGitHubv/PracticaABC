using System;
using System.Collections.Generic;

namespace PracticaABC.Models;

public partial class ProductoDistribucion
{
    public int IdProducto { get; set; }

    public string? Nombre { get; set; }

    public int? PrecioMayor { get; set; }

    public int? PrecioMenor { get; set; }

    public int? Cantidad { get; set; }

    public int? IdDist { get; set; }

    public int? IdEstiba { get; set; }

    public int? IdTipoProd { get; set; }

    public virtual TipoDistribucion? IdDistNavigation { get; set; }

    public virtual Estiba? IdEstibaNavigation { get; set; }

    public virtual TipoProducto? IdTipoProdNavigation { get; set; }
}
