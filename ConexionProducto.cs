using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyectofinal
{
    internal class ConexionProducto
    {
        private SqlConnection conexion;
        private string stringDeConexion = "Server=sql.bsite.net\\MSSQL2016;Database=cratoxss12345_sistema_gestion;User Id=cratoxss12345_sistema_gestion;Password=Cratoxss4505422;";


        //conexion a la base de datos
        public ConexionProducto()
        {
            try
            {
                conexion = new SqlConnection(stringDeConexion);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
        }

        //poner en una lista los productos registrados de la base de datos
        public List<Producto> ListaProductos()
        {

            List<Producto> listaDeProductos = new List<Producto>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Producto", conexion))
                {
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Producto Productos = new Producto();
                                Productos.Id = reader.GetInt64(0);
                                Productos.Descripcion = reader.GetString(1);
                                Productos.Precio =reader.GetDouble(2);
                                Productos.PrecioVenta = reader.GetDouble(3);
                                Productos.Stock = reader.GetInt32(4);
                                Productos.IdUsuario = reader.GetInt64(5);
                                listaDeProductos.Add(Productos);
                            }
                        }
                    }
                }
                conexion.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return listaDeProductos;
        }


        //Insertar nuevo Producto a la base de datos
        public int InsertarProducto(Producto Producto)
        {
            try
            {
                String query = "INSERT INTO Producto(Descripcion,Costo,PrecioVenta,Stock,IdUsuario)" + "values(@Descripcion,@Costo,@PrecioVenta,@Stock,@IdUsuario); SELECT @@IDENTITY;";
                conexion.Open();
                int filasAfectadas;
                int ultimoIdInsertado;
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    command.Parameters.Add(new SqlParameter("Descripcion", SqlDbType.VarChar) { Value = Producto.Descripcion });
                    command.Parameters.Add(new SqlParameter("Costo", SqlDbType.VarChar) { Value = Producto.Precio });
                    command.Parameters.Add(new SqlParameter("PrecioVenta", SqlDbType.VarChar) { Value = Producto.PrecioVenta });
                    command.Parameters.Add(new SqlParameter("Stock", SqlDbType.VarChar) { Value = Producto.Stock });
                    command.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.VarChar) { Value = Producto.IdUsuario });

                    //filasAfectadas = command.ExecuteNonQuery();
                    ultimoIdInsertado = Convert.ToInt32(command.ExecuteScalar());
                }
                conexion.Close();

                return ultimoIdInsertado;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        //Eliminar usuario de la base de datos
        public int EliminarProducto(int IdProducto)
        {
            try
            {
                String query = "DELETE FROM Producto WHERE ID = @IdProducto";
                conexion.Open();
                int filasAfectadas;
                //int ultimoIdInsertado;
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    command.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.VarChar) { Value = IdProducto });

                    filasAfectadas = command.ExecuteNonQuery();
                    //ultimoIdInsertado = Convert.ToInt32(command.ExecuteScalar());
                }
                conexion.Close();

                return filasAfectadas;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        //modificar Producto
        public int cambiarPrecioDelProducto(Producto Producto)
        {
            try
            {
                String query = "UPDATE Producto set Costo = @CostoProducto WHERE ID = @IdProducto";
                conexion.Open();
                int filasAfectadas;
                //int ultimoIdInsertado;
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    command.Parameters.Add(new SqlParameter("CostoProducto", SqlDbType.VarChar) { Value = Producto.Precio });

                    command.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.VarChar) { Value = Producto.Id });

                    filasAfectadas = command.ExecuteNonQuery();
                    //ultimoIdInsertado = Convert.ToInt32(command.ExecuteScalar());
                }
                conexion.Close();
                return filasAfectadas;
            }

            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
