using System;
using System.Collections.Generic;

namespace VerbsAPI.Context;

public partial class Verb
{
    public int CveVerbs { get; set; }

    public int CveAudios { get; set; }

    public int CveTraduccionesVerbs { get; set; }

    public string Nombre { get; set; } = null!;

    public ulong Aprendido { get; set; }

    public ulong PhrasalWeb { get; set; }

    public ulong Regular { get; set; }
}
