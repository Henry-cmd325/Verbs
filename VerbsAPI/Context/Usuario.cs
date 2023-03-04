using System;
using System.Collections.Generic;

namespace VerbsAPI.Context;

public partial class Usuario
{
    public int CveUsuarios { get; set; }

    public string Correo { get; set; } = null!;

    public string Contraseña { get; set; } = null!;
}
