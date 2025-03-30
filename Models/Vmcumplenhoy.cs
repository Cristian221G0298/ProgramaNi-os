using System;
using System.Collections.Generic;

namespace ProrgamaNiños.Models;

public partial class Vmcumplenhoy
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime? FechaNacimiento { get; set; }

    public string? Domicilio { get; set; }
}
