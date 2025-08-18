using System;
using System.Collections.Generic;

namespace ApiPedidos.Models
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

        public virtual Cliente? oCliente { get; set; }
        public virtual Sucursal? oSucursalE { get; set; }
        public virtual Sucursal? oSucursalI { get; set; }
        public virtual TipoMovimiento oTipoMovimiento { get; set; } = null!;
        public virtual ICollection<ComprobanteCompra> ComprobanteCompras { get; set; }
        public virtual ICollection<Comprobante> Comprobantes { get; set; }
        public virtual ICollection<ProductoMovimiento> ProductoMovimientos { get; set; }
    }
}
