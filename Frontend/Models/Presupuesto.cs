using System;
using System.Collections.Generic;

namespace Frontend.Models;

public partial class Presupuesto
{
    public long Id { get; set; }

    public DateTime Fecha { get; set; }

    public int Numero { get; set; }

    public long IdTipoComprobante { get; set; }

    public long IdCliente { get; set; }

    public decimal ImporteNeto { get; set; }

    public decimal Recargos { get; set; }

    public decimal SubTotal { get; set; }

    public decimal IvaTasa1 { get; set; }

    public decimal IvaTasa2 { get; set; }

    public decimal PercepcionIibb { get; set; }

    public decimal Total { get; set; }

    public int? IdComprobante { get; set; }

    public virtual ICollection<PresupuestoItem> PresupuestoItems { get; set; } = new List<PresupuestoItem>();
}
