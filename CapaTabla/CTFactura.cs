using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaTabla
{
    public class CTFactura
    {
        public int IDFactura { get; set; }
        public DateTime FechaEmision { get; set; }
        public string IDemp { get; set; }
        public string Estado { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }
    }
}
