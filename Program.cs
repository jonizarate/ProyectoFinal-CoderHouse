namespace Proyectofinal
{
    internal class Program
    {
        static void Main(string[] args)
        {



            Console.WriteLine("Lista de usuarios");
            Console.WriteLine("/////////////////////////////////");

            ConexionUsuario conexionUsuario = new ConexionUsuario();
            foreach (Usuario usuarios in conexionUsuario.listaUsuario())
            {
                Console.WriteLine($"Id : {usuarios.Id} , Nombre: {usuarios.Nombre} , Apellido{usuarios.Apellido} , Usuario: {usuarios.NombreUsuario} , Contraseña:{usuarios.Contrasenia} , Mail: {usuarios.Mail}");
            }





            Console.WriteLine("Lista de Productos");
            Console.WriteLine("/////////////////////////////////");

            ConexionProducto conexionProducto = new ConexionProducto();
            
            foreach (Producto productos in conexionProducto.ListaProductos())
            {
                Console.WriteLine($"Id: {productos.Id} , Descripcion: {productos.Descripcion} , Costo{productos.Precio} , Precio de Venta: {productos.PrecioVenta} , Stock: {productos.Stock} , Id del Usuario: {productos.IdUsuario}");
            }




            Console.WriteLine("Lista de Productos Vendidos");
            Console.WriteLine("/////////////////////////////////");

            ConexionProductoVendido conexionProductosVendidos = new ConexionProductoVendido();
            
            foreach (ProductoVendido productoss in conexionProductosVendidos.ListaProductosVendidos())
            {
                Console.WriteLine($"Id: {productoss.IdProducto} , Stock: {productoss.Stock} , IdProducto: {productoss.IdProducto} , IdVenta: {productoss.IdVenta}") ;
            }





            Console.WriteLine("Lista de Ventas");
            Console.WriteLine("/////////////////////////////////");

            ConexionVenta conexionVenta = new ConexionVenta();

            foreach (Venta Ventas in conexionVenta.ListaDeVentas())
            {
                Console.WriteLine($"Id: {Ventas.Id} , Comentarios: {Ventas.Comentario} , IdUsuario: {Ventas.IdUsuario}");
            }
        }
    }
}