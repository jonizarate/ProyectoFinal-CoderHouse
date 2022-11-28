using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyectofinal
{
    internal class ConexionProductoVendido
    {
        private SqlConnection conexion;
        private string stringDeConexion = "Server=sql.bsite.net\\MSSQL2016;Database=cratoxss12345_sistema_gestion;User Id=cratoxss12345_sistema_gestion;Password=Cratoxss4505422;";


        //conexion a la base de datos
        public ConexionProductoVendido()
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

        //poner en una lista los productos Vendidos registrados de la base de datos
        public List<ProductoVendido> ListaProductosVendidos()
        {

            List<ProductoVendido> listaDeProductosVendidos = new List<ProductoVendido>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM ProductoVendido", conexion))
                {
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ProductoVendido ProductosVendidos = new ProductoVendido();
                                ProductosVendidos.Id = reader.GetInt64(0);
                                ProductosVendidos.Stock = reader.GetInt32(1);
                                ProductosVendidos.IdProducto = reader.GetInt64(2);
                                ProductosVendidos.IdVenta = reader.GetInt64(3);
                                listaDeProductosVendidos.Add(ProductosVendidos);
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
            return listaDeProductosVendidos;
        }
    }
}
