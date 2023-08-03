using System;
using System.Collections.Generic;

namespace PracticaABC.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Correo { get; set; }

    public string? Clave { get; set; }
}
