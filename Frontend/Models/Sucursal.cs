using System;
using System.Collections.Generic;

namespace Frontend.Models
{
    public partial class Sucursal
    {
        public Sucursal()
        {
            MovimientoIdSucursalEgresoNavigations = new HashSet<Movimiento>();
            MovimientoIdSucursalIngresoNavigations = new HashSet<Movimiento>();
            ProductoStocks = new HashSet<ProductoStock>();
        }

        public long Id { get; set; }
        public string Codigo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string? Cuit { get; set; }
        public string? Direccion { get; set; }
        public DateTime? InicioActividad { get; set; }
        public string? TipoResponsabilidad { get; set; }
        public string? UltimoNumeroCai { get; set; }
        public int? TipoLecturaCodigo { get; set; }
        public bool? ActualizaPreciosCtaCte { get; set; }
        public bool? MuestraImagen { get; set; }

        public virtual ICollection<Movimiento> MovimientoIdSucursalEgresoNavigations { get; set; }
        public virtual ICollection<Movimiento> MovimientoIdSucursalIngresoNavigations { get; set; }
        public virtual ICollection<ProductoStock> ProductoStocks { get; set; }
    }
}
