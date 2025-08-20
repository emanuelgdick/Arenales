using System;
using System.Collections.Generic;

namespace WebApiCarrito.Models;

public partial class Pago
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public int IdFormaPago { get; set; }

    public int IdClienteCuentaCorrienteMovimiento { get; set; }

    public decimal ImportePago { get; set; }

    public int? IdTarjeta { get; set; }

    public string? NumeroTarjeta { get; set; }

    public string? NumeroCupon { get; set; }

    public string? NumeroCheque { get; set; }

    public DateTime? FechaCobroCheque { get; set; }

    public int? IdCaja { get; set; }

    public virtual Caja? IdCajaNavigation { get; set; }

    public virtual ClienteCuentaCorrienteMovimiento IdClienteCuentaCorrienteMovimientoNavigation { get; set; } = null!;

    public virtual FormaPago IdFormaPagoNavigation { get; set; } = null!;

    public virtual Tarjetum? IdTarjetaNavigation { get; set; }
}
