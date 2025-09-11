using System;
using System.Collections.Generic;

namespace Frontend.Models;

public partial class TipoCliente
{
    public long Id { get; set; }

    public string Descripcion { get; set; } = null!;
}
