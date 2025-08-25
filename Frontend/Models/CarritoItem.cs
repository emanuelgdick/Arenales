using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Frontend.Models
{
   
    public partial class CarritoItem
    {
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public long IdCarrito { get; set; }
        public long IdProducto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Punitario { get; set; }
        
        //[JsonIgnore]
        public virtual Carrito? oCarrito { get; set; } = null!;
        //[JsonIgnore]
        public virtual Producto? oProducto { get; set; } = null!;
    }
}
