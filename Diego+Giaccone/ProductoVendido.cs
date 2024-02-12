using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Diego_Giaccone
{
    public static class ProductoVendidoData
    {
        private static string connectionString = "";

        public static ProductoVendido ObtenerProductoVendido(int idProductoVendido)
        {
            // Implementar lógica para obtener un producto vendido por su ID
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM ProductosVendidos WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", idProductoVendido);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Crear un objeto ProductoVendido con los datos del lector
                            ProductoVendido productoVendido = new ProductoVendido
                            {
                                Id = (int)reader["Id"],
                                IdVenta = (int)reader["IdVenta"],
                                IdProducto = (int)reader["IdProducto"],
                                Cantidad = (int)reader["Cantidad"],
                                PrecioVenta = (decimal)reader["PrecioVenta"]
                            };
                            return productoVendido;
                        }
                    }
                }
            }
            return null; // Retornar null si no se encuentra el producto vendido
        }

        public static List<ProductoVendido> ListarProductosVendidos()
        {
            // Implementar lógica para listar todos los productos vendidos
            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM ProductosVendidos";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Crear objetos ProductoVendido y agregar a la lista
                            ProductoVendido productoVendido = new ProductoVendido
                            {
                                Id = (int)reader["Id"],
                                IdVenta = (int)reader["IdVenta"],
                                IdProducto = (int)reader["IdProducto"],
                                Cantidad = (int)reader["Cantidad"],
                                PrecioVenta = (decimal)reader["PrecioVenta"]
                            };
                            productosVendidos.Add(productoVendido);
                        }
                    }
                }
            }
            return productosVendidos;
        }

        public static void CrearProductoVendido(ProductoVendido productoVendido)
        {
            // Implementar lógica para crear un nuevo producto vendido
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO ProductosVendidos (IdVenta, IdProducto, Cantidad, PrecioVenta) " +
                               "VALUES (@IdVenta, @IdProducto, @Cantidad, @PrecioVenta)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdVenta", productoVendido.IdVenta);
                    command.Parameters.AddWithValue("@IdProducto", productoVendido.IdProducto);
                    command.Parameters.AddWithValue("@Cantidad", productoVendido.Cantidad);
                    command.Parameters.AddWithValue("@PrecioVenta", productoVendido.PrecioVenta);

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void ModificarProductoVendido(ProductoVendido productoVendido)
        {
            // Implementar lógica para modificar un producto vendido existente
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE ProductosVendidos SET IdVenta = @IdVenta, IdProducto = @IdProducto, " +
                               "Cantidad = @Cantidad, PrecioVenta = @PrecioVenta WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", productoVendido.Id);
                    command.Parameters.AddWithValue("@IdVenta", productoVendido.IdVenta);
                    command.Parameters.AddWithValue("@IdProducto", productoVendido.IdProducto);
                    command.Parameters.AddWithValue("@Cantidad", productoVendido.Cantidad);
                    command.Parameters.AddWithValue("@PrecioVenta", productoVendido.PrecioVenta);

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void EliminarProductoVendido(int idProductoVendido)
        {
            // Implementar lógica para eliminar un producto vendido por su ID
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM ProductosVendidos WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", idProductoVendido);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
