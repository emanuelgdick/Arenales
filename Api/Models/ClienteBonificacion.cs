using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class ClienteBonificacion
{
    public long Id { get; set; }

    public long? IdTipoCliente { get; set; }

    public long? IdRubro { get; set; }

    public decimal? Descuento { get; set; }

    public string? Descripcion { get; set; }
}
