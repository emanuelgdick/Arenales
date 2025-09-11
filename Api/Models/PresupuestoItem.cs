using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class PresupuestoItem
{
    public long Id { get; set; }

    public long IdProducto { get; set; }

    public long? IdPresupuesto { get; set; }

    public decimal Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal ImpuestoUnitario { get; set; }

    public decimal TotalItem { get; set; }

    public decimal? Bonificacion { get; set; }

    public string? Descripcion { get; set; }

    public virtual Presupuesto? IdPresupuestoNavigation { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
