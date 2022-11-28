using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Proyectofinal
{
    internal class ProductoVendido
    {
        public BigInteger Id { get; set; }
        public int Stock { get; set; }
        public BigInteger IdProducto { get; set; }
        public BigInteger IdVenta { get; set; }


        public ProductoVendido() { }
        public ProductoVendido(BigInteger id, int stock, BigInteger idProducto, BigInteger idVenta)
        {
            Id = id;
            Stock = stock;
            IdProducto = idProducto;
            IdVenta = idVenta;
        }
    }
}
