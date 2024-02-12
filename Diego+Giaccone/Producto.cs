using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Diego_Giaccone
{
    public static class ProductoData
    {
        private static string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";

        public static Producto ObtenerProducto(int idProducto)
        {
            // Implementar lógica para obtener un producto por su ID
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Productos WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", idProducto);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Crear un objeto Producto con los datos del lector
                            Producto producto = new Producto
                            {
                                Id = (int)reader["Id"],
                                Descripcion = (string)reader["Descripcion"],
                                Costo = (decimal)reader["Costo"],
                                PrecioVenta = (decimal)reader["PrecioVenta"],
                                Stock = (int)reader["Stock"],
                                IdUsuario = (int)reader["IdUsuario"]
                            };
                            return producto;
                        }
                    }
                }
            }
            return null; // Retornar null si no se encuentra el producto
        }

        public static List<Producto> ListarProductos()
        {
            // Implementar lógica para listar todos los productos
            List<Producto> productos = new List<Producto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Productos";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Crear objetos Producto y agregar a la lista
                            Producto producto = new Producto
                            {
                                Id = (int)reader["Id"],
                                Descripcion = (string)reader["Descripcion"],
                                Costo = (decimal)reader["Costo"],
                                PrecioVenta = (decimal)reader["PrecioVenta"],
                                Stock = (int)reader["Stock"],
                                IdUsuario = (int)reader["IdUsuario"]
                            };
                            productos.Add(producto);
                        }
                    }
                }
            }
            return productos;
        }

        public static void CrearProducto(Producto producto)
        {
            // Implementar lógica para crear un nuevo producto
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Productos (Descripcion, Costo, PrecioVenta, Stock, IdUsuario) " +
                               "VALUES (@Descripcion, @Costo, @PrecioVenta, @Stock, @IdUsuario)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("@Costo", producto.Costo);
                    command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                    command.Parameters.AddWithValue("@Stock", producto.Stock);
                    command.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void ModificarProducto(Producto producto)
        {
            // Implementar lógica para modificar un producto existente
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Productos SET Descripcion = @Descripcion, Costo = @Costo, " +
                               "PrecioVenta = @PrecioVenta, Stock = @Stock, IdUsuario = @IdUsuario " +
                               "WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", producto.Id);
                    command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("@Costo", producto.Costo);
                    command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                    command.Parameters.AddWithValue("@Stock", producto.Stock);
                    command.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void EliminarProducto(int idProducto)
        {
            // Implementar lógica para eliminar un producto por su ID
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Productos WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", idProducto);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

