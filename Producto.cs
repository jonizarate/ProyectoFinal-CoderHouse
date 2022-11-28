using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Proyectofinal
{
    internal class Producto
    {
        public BigInteger Id { get; set; }
        public string Descripcion { get; set; }
        public Double Precio { get; set; }
        public Double PrecioVenta { get; set; }
        public int Stock { get; set; }
        public BigInteger IdUsuario { get; set; }

        public Producto() { }
        public Producto(BigInteger id, string descripcion, Double precio, Double precioVenta, int stock, BigInteger idUsuario)
        {
            Id = id;
            Descripcion = descripcion;
            Precio = precio;
            PrecioVenta = precioVenta;
            Stock = stock;
            IdUsuario = idUsuario;
        }
    }
}
