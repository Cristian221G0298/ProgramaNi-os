using System;
using System.Collections.Generic;

namespace ProrgamaNiños.Models;

public partial class Vmmenoresde15
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime? FechaNacimiento { get; set; }

    public string? Domicilio { get; set; }
}
