using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyectofinal
{
    internal class ConexionVenta
    {
        private SqlConnection conexion;
        private string stringDeConexion = "Server=sql.bsite.net\\MSSQL2016;Database=cratoxss12345_sistema_gestion;User Id=cratoxss12345_sistema_gestion;Password=Cratoxss4505422;";


        //conexion a la base de datos
        public ConexionVenta()
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

        //poner en una lista las ventas registradas de la base de datos
        public List<Venta> ListaDeVentas()
        {

            List<Venta> ListaDeVentas = new List<Venta>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Venta", conexion))
                {
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Venta Ventas = new Venta();
                                Ventas.Id = reader.GetInt64(0);
                                Ventas.Comentario = reader.GetString(1);
                                Ventas.IdUsuario = reader.GetInt64(2);
                                ListaDeVentas.Add(Ventas);
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
            return ListaDeVentas;
        }
    }
}
