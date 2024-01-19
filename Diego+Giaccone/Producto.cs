using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diego_Giaccone
{
    public class Producto
    {
        public int _id { get; set; }
        public string _descripcion { get; set; }
        public decimal _costo { get; set; }
        public decimal _precioVenta { get; set; }
        public int _stock { get; set; }
        public int _idUsuario { get; set; }
    }
}
