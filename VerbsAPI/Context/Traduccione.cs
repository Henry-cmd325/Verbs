using System;
using System.Collections.Generic;

namespace VerbsAPI.Context;

public partial class Traduccione
{
    public int CveTraducciones { get; set; }

    public int CveImagenes { get; set; }

    public string Traduccion { get; set; } = null!;
}
