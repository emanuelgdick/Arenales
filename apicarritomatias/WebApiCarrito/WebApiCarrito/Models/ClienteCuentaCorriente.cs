using System;
using System.Collections.Generic;

namespace WebApiCarrito.Models;

public partial class ClienteCuentaCorriente
{
    public int Id { get; set; }

    public int IdCliente { get; set; }

    public int EstadoCuentaCorriente { get; set; }

    public decimal Saldo { get; set; }

    public DateOnly? FechaUltimoPago { get; set; }

    public virtual ICollection<ClienteCuentaCorrienteMovimiento> ClienteCuentaCorrienteMovimientos { get; set; } = new List<ClienteCuentaCorrienteMovimiento>();
}
