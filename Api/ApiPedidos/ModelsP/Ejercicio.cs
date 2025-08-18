using System;
using System.Collections.Generic;

namespace ApiPedidos.Models
{
    public partial class Ejercicio
    {
        public long Id { get; set; }
        public string? Descripcion { get; set; }
        public int Numero { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaCierre { get; set; }
        public DateTime? CierreParcial { get; set; }
        public bool? Estado { get; set; }
    }
}
