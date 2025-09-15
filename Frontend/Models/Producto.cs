using System;
using System.Collections.Generic;

namespace Frontend.Models;

public partial class Producto
{
    public long Id { get; set; }

    public long IdMarca { get; set; }
    
    public long IdRubro { get; set; }

    public long IdTalle { get; set; }

    public long IdColor { get; set; }

    public string Descripcion { get; set; } = null!;

    public string CodigoBarras { get; set; } = null!;

    public decimal Precio { get; set; }

    public string? Codigo { get; set; }

    public decimal PrecioSinIva { get; set; }

    public decimal Costo { get; set; }

    public long IdImpuesto { get; set; }

    public bool Activo { get; set; }

    public bool? Carrito { get; set; }

    public virtual ICollection<CarritoProducto> CarritoProductos { get; set; } = new List<CarritoProducto>();

    public virtual ICollection<ComprobanteItem> ComprobanteItems { get; set; } = new List<ComprobanteItem>();

    public virtual Color IdColorNavigation { get; set; } = null!;
    public virtual Marca IdMarcaNavigation { get; set; } = null!;
    public virtual Rubro IdRubroNavigation { get; set; } = null!;
    public virtual Talle IdTalleNavigation { get; set; } = null!;

    public virtual ICollection<ProductoImagen> ProductoImagens { get; set; } = new List<ProductoImagen>();

    public virtual ICollection<ProductoMovimiento> ProductoMovimientos { get; set; } = new List<ProductoMovimiento>();

    public virtual ICollection<ProductoStock> ProductoStocks { get; set; } = new List<ProductoStock>();
}
