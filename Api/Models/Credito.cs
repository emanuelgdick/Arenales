using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Credito
{
    public long Id { get; set; }

    public int Cuotas { get; set; }

    public decimal Interes { get; set; }

    public long IdCliente { get; set; }

    public int Numero { get; set; }

    public DateOnly Fecha { get; set; }

    public string? Descripcion { get; set; }

    public long IdEstadoCredito { get; set; }

    public decimal Saldo { get; set; }

    public decimal Capital { get; set; }

    public virtual ICollection<CuotaCredito> CuotaCreditos { get; set; } = new List<CuotaCredito>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual EstadoCredito IdEstadoCreditoNavigation { get; set; } = null!;
}
