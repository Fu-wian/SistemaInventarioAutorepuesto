using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaTabla
{
    public class CTFacturaDetalle
    {
        public int IDDetalle { get; set; }
        public int IDFactura { get; set; }
        public int IDProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnidad { get; set; }
        public decimal PrecioTotal { get; set; }
    }
}
