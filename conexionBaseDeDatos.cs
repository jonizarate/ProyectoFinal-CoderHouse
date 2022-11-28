using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyectofinal
{
    internal class conexionBaseDeDatos
    {
        private SqlConnection conexion;
        private string stringDeConexion = "Server=sql.bsite.net\\MSSQL2016;Database=cratoxss12345_sistema_gestion;User Id=cratoxss12345_sistema_gestion;Password=Cratoxss4505422;";

        public conexionBaseDeDatos()
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

        public List<Usuario> listaUsuario()
        {

            List<Usuario> lista = new List<Usuario>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Usuario", conexion))
                {
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Usuario usuario = new Usuario();
                                usuario.Id = reader.GetInt64(0);
                                usuario.Nombre = reader.GetString(1);
                                usuario.Apellido = reader.GetString(2);
                                usuario.NombreUsuario = reader.GetString(3);
                                usuario.Contrasenia = reader.GetString(4);
                                usuario.Mail = reader.GetString(5);
                                lista.Add(usuario);
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
            return lista;
        }

        public int InsertarUsuario(Usuario usuario)
        {
            try
            {
                String query = "INSERT INTO Usuario(Nombre,Apellido,NombreUsuario,Contraseña,Mail)" + "values(@nombre,@apellido,@nombreusuario,@contrasenia,@mail); SELECT @@IDENTITY;";
                conexion.Open();
                int filasAfectadas;
                int ultimoIdInsertado;
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    command.Parameters.Add(new SqlParameter("nombre", SqlDbType.VarChar) { Value = usuario.Nombre });
                    command.Parameters.Add(new SqlParameter("apellido", SqlDbType.VarChar) { Value = usuario.Apellido });
                    command.Parameters.Add(new SqlParameter("nombreusuario", SqlDbType.VarChar) { Value = usuario.NombreUsuario });
                    command.Parameters.Add(new SqlParameter("contrasenia", SqlDbType.VarChar) { Value = usuario.Contrasenia });
                    command.Parameters.Add(new SqlParameter("mail", SqlDbType.VarChar) { Value = usuario.Mail });

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
        public int EliminarUsuario(int IdUsuario)
        {
            try
            {
                String query = "DELETE FROM Usuario WHERE ID = @IdUsuario";
                conexion.Open();
                int filasAfectadas;
                //int ultimoIdInsertado;
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    command.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.VarChar) { Value = IdUsuario });

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

        public int cambiarContrasenia(Usuario usuario)
        {
            try
            {
                String query = "UPDATE Usuario set contraseña = @contrasenia WHERE ID = @IdUsuario";
                conexion.Open();
                int filasAfectadas;
                //int ultimoIdInsertado;
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                command.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.VarChar) { Value = usuario.Id });

                command.Parameters.Add(new SqlParameter("contrasenia", SqlDbType.VarChar) { Value = usuario.Contrasenia });

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

        public int cambiarContrasenia(long IdUsuario,string nuevaContrasenia )
        {
            try
            {
                String query = "UPDATE Usuario set contraseña = @contrasenia WHERE ID = @IdUsuario";
                conexion.Open();
                int filasAfectadas;
                //int ultimoIdInsertado;
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    command.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.VarChar) { Value = IdUsuario });

                    command.Parameters.Add(new SqlParameter("contrasenia", SqlDbType.VarChar) { Value = nuevaContrasenia });

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

