using System;
using System.Collections.Generic;

namespace ApiPedidos.Models
{
    public partial class Comprobante
    {
        public Comprobante()
        {
            ClienteCuentaCorrienteMovimientos = new HashSet<ClienteCuentaCorrienteMovimiento>();
            ComprobanteItems = new HashSet<ComprobanteItem>();
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Numero { get; set; }
        public string Letra { get; set; } = null!;
        public string CentroEmisor { get; set; } = null!;
        public long IdTipoComprobante { get; set; }
        public long IdCliente { get; set; }
        public string RazonSocial { get; set; } = null!;
        public string? Cuit { get; set; }
        public decimal ImporteNeto { get; set; }
        public decimal Recargos { get; set; }
        public decimal SubTotal { get; set; }
        public decimal IvaTasa1 { get; set; }
        public decimal IvaTasa2 { get; set; }
        public decimal PercepcionIibb { get; set; }
        public decimal Total { get; set; }
        public int? IdCaja { get; set; }
        public long? IdMovimiento { get; set; }
        public int? IdAsiento { get; set; }
        public int? IdComprobanteReferencia { get; set; }
        public decimal Saldo { get; set; }
        public bool? Cai { get; set; }
        public long? Idanterior { get; set; }
        public string? NumeroCae { get; set; }
        public string? ObservacionesAfip { get; set; }
        public string? PuntoVenta { get; set; }
        public string? FechaVencimientoCae { get; set; }
        public decimal? TotalDolares { get; set; }
        public string? Direccion { get; set; }
        public bool? Envio { get; set; }
        public long? IdVendedor { get; set; }

        public virtual Caja? IdCajaNavigation { get; set; }
        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual Movimiento? IdMovimientoNavigation { get; set; }
        public virtual TipoComprobante IdTipoComprobanteNavigation { get; set; } = null!;
        public virtual ICollection<ClienteCuentaCorrienteMovimiento> ClienteCuentaCorrienteMovimientos { get; set; }
        public virtual ICollection<ComprobanteItem> ComprobanteItems { get; set; }
    }
}
