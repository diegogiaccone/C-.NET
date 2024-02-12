using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Diego_Giaccone
{
    public static class UsuarioData
    {
        private static string connectionString = "";

        public static Usuario ObtenerUsuario(int idUsuario)
        {
            // Implementar lógica para obtener un usuario por su ID
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Usuarios WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", idUsuario);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Crear un objeto Usuario con los datos del lector
                            Usuario usuario = new Usuario
                            {
                                Id = (int)reader["Id"],
                                Nombre = (string)reader["Nombre"],
                                Apellido = (string)reader["Apellido"],
                                Email = (string)reader["Email"]
                            };
                            return usuario;
                        }
                    }
                }
            }
            return null; // Retornar null si no se encuentra el usuario
        }

        public static List<Usuario> ListarUsuarios()
        {
            // Implementar lógica para listar todos los usuarios
            List<Usuario> usuarios = new List<Usuario>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Usuarios";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Crear objetos Usuario y agregar a la lista
                            Usuario usuario = new Usuario
                            {
                                Id = (int)reader["Id"],
                                Nombre = (string)reader["Nombre"],
                                Apellido = (string)reader["Apellido"],
                                Email = (string)reader["Email"]
                            };
                            usuarios.Add(usuario);
                        }
                    }
                }
            }
            return usuarios;
        }

        public static void CrearUsuario(Usuario usuario)
        {
            // Implementar lógica para crear un nuevo usuario
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Usuarios (Nombre, Apellido, Email) VALUES (@Nombre, @Apellido, @Email)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    command.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                    command.Parameters.AddWithValue("@Email", usuario.Email);

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void ModificarUsuario(Usuario usuario)
        {
            // Implementar lógica para modificar un usuario existente
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Usuarios SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", usuario.Id);
                    command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    command.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                    command.Parameters.AddWithValue("@Email", usuario.Email);

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void EliminarUsuario(int idUsuario)
        {
            // Implementar lógica para eliminar un usuario por su ID
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Usuarios WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", idUsuario);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
