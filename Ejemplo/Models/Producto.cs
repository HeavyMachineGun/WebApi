using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ejemplo.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
    }
}