using System;
using System.Collections.Generic;

namespace Frontend.Models;

public partial class Producto2
{
    public long Id { get; set; }

    public long IdMarca { get; set; }

    public long IdTalle { get; set; }

    public long IdColor { get; set; }

    public string Descripcion { get; set; } = null!;

    public string CodigoBarras { get; set; } = null!;

    public decimal Precio { get; set; }

    public string? Codigo { get; set; }

    public decimal PrecioSinIva { get; set; }

    public decimal Costo { get; set; }

    public long IdImpuesto { get; set; }

    public bool Activo { get; set; }
}
