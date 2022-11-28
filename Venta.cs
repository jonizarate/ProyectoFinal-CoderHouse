using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Proyectofinal
{
    internal class Venta
    {
        public BigInteger Id { get; set; }
        public string Comentario { get; set; }
        public BigInteger IdUsuario { get; set; }
        public Venta() { }
        public Venta(BigInteger id, string comentario, BigInteger idUsuario)
        {
            Id = id;
            Comentario = comentario;
            IdUsuario = idUsuario;
        }
    }
}
