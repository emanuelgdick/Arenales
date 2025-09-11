using System;
using System.Collections.Generic;

namespace Frontend.Models
{
    public partial class Movimiento
    {
        public Movimiento()
        {
            ComprobanteCompras = new HashSet<ComprobanteCompra>();
            Comprobantes = new HashSet<Comprobante>();
            ProductoMovimientos = new HashSet<ProductoMovimiento>();
        }

        public long Id { get; set; }
        public long IdTipoMovimiento { get; set; }
        public long? IdSucursalIngreso { get; set; }
        public long? IdSucursalEgreso { get; set; }
        public DateTime Fecha { get; set; }
        public long Numero { get; set; }
        public long? IdCliente { get; set; }
        public bool? Facturado { get; set; }
        public long? IdAnterior { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }

        public virtual Cliente? IdClienteNavigation { get; set; }
        public virtual Sucursal? IdSucursalEgresoNavigation { get; set; }
        public virtual Sucursal? IdSucursalIngresoNavigation { get; set; }
        public virtual TipoMovimiento IdTipoMovimientoNavigation { get; set; } = null!;
        public virtual ICollection<ComprobanteCompra> ComprobanteCompras { get; set; }
        public virtual ICollection<Comprobante> Comprobantes { get; set; }
        public virtual ICollection<ProductoMovimiento> ProductoMovimientos { get; set; }
    }
}
