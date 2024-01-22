using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diego_Giaccone
{
    public class ProductoVendido
    {
        private int _id;
        private int _idProducto;
        private int _cantidadVendida;
        private int _idVenta;
  
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int IdProducto
        {
            get { return _idProducto; }
            set { _idProducto = value; }
        }

        public int CantidadVendida
        {
            get { return _cantidadVendida; }
            set { _cantidadVendida = value; }
        }

        public int IdVenta
        {
            get { return _idVenta; }
            set { _idVenta = value; }
        }

        // Método para calcular el precio total de la venta de este producto
        public decimal CalcularPrecioTotal(decimal precioUnitario)
        {
            return _cantidadVendida * precioUnitario;
        }
    }
}
