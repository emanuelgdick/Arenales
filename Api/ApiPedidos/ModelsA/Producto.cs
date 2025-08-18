using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ApiPedidos.Models
{
   
    public partial class Producto
    {
        public Producto()
        {
            CarritoItems = new HashSet<CarritoItem>();
            ComprobanteItems = new HashSet<ComprobanteItem>();
            ProductoMovimientos = new HashSet<ProductoMovimiento>();
            ProductoStocks = new HashSet<ProductoStock>();
        }

        public long Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public string CodigoBarras { get; set; } = null!;
        public decimal Precio { get; set; }
        public string? Codigo { get; set; }
        public decimal PrecioSinIva { get; set; }
        public decimal Costo { get; set; }
        public long IdImpuesto { get; set; }
        public bool Activo { get; set; }
        public bool Unidad { get; set; }
        public bool Kilogramo { get; set; }
        public long IdMarca { get; set; }
        public bool ArticuloSinPrecio { get; set; }
        public decimal? Remarca { get; set; }
        public long IdRubro { get; set; }
        public int? Fraccion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public int? StockMinimo { get; set; }
        public string? Ubicacion { get; set; }
        public decimal? StockMaximo { get; set; }
        public decimal? LoteMinimoCompra { get; set; }
        public decimal? PuntoPedido { get; set; }

        public virtual Marca? oMarca { get; set; } = null!;
        public virtual Rubro? oRubro { get; set; } = null!;
        public virtual ICollection<CarritoItem> CarritoItems { get; set; }
        public virtual ICollection<ComprobanteItem> ComprobanteItems { get; set; }
        public virtual ICollection<ProductoMovimiento> ProductoMovimientos { get; set; }
        public virtual ICollection<ProductoStock> ProductoStocks { get; set; }
    }
}
