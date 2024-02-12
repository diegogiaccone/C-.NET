using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Diego_Giaccone
{
    public static class VentaData
    {
        private static string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";

        public static Venta ObtenerVenta(int idVenta)
        {
            // Implementar lógica para obtener una venta por su ID
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Ventas WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", idVenta);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Crear un objeto Venta con los datos del lector
                            Venta venta = new Venta
                            {
                                Id = (int)reader["Id"],
                                FechaVenta = (DateTime)reader["FechaVenta"],
                                IdUsuario = (int)reader["IdUsuario"]
                            };
                            return venta;
                        }
                    }
                }
            }
            return null; // Retornar null si no se encuentra la venta
        }

        public static List<Venta> ListarVentas()
        {
            // Implementar lógica para listar todas las ventas
            List<Venta> ventas = new List<Venta>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Ventas";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Crear objetos Venta y agregar a la lista
                            Venta venta = new Venta
                            {
                                Id = (int)reader["Id"],
                                FechaVenta = (DateTime)reader["FechaVenta"],
                                IdUsuario = (int)reader["IdUsuario"]
                            };
                            ventas.Add(venta);
                        }
                    }
                }
            }
            return ventas;
        }

        public static void CrearVenta(Venta venta)
        {
            // Implementar lógica para crear una nueva venta
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Ventas (FechaVenta, IdUsuario) VALUES (@FechaVenta, @IdUsuario)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FechaVenta", venta.FechaVenta);
                    command.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void ModificarVenta(Venta venta)
        {
            // Implementar lógica para modificar una venta existente
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Ventas SET FechaVenta = @FechaVenta, IdUsuario = @IdUsuario WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", venta.Id);
                    command.Parameters.AddWithValue("@FechaVenta", venta.FechaVenta);
                    command.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void EliminarVenta(int idVenta)
        {
            // Implementar lógica para eliminar una venta por su ID
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Ventas WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", idVenta);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
