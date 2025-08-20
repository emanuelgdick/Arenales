using System;
using System.Collections.Generic;

namespace WebApiCarrito.Models;

public partial class CuotaCredito
{
    public long Id { get; set; }

    public long IdCredito { get; set; }

    public int Numero { get; set; }

    public decimal Amortizacion { get; set; }

    public decimal Interes { get; set; }

    public decimal TotalCuota { get; set; }

    public decimal TotalPago { get; set; }

    public DateOnly FechaVencimiento { get; set; }

    public DateOnly? FechaPago { get; set; }

    public bool Pago { get; set; }

    public decimal InteresMora { get; set; }

    public virtual Credito IdCreditoNavigation { get; set; } = null!;
}
