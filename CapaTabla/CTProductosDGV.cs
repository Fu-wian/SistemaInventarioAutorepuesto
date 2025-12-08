using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaTabla
{
    public class CTProductosDGV
    {
        public string IDProductos { get; set; }
        public string Categoria { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public CTProductosDGV(string idProductos, string categoria, string nombreProducto, int cantidad, decimal precio)
        {
            IDProductos = idProductos.Trim();
            Categoria = categoria.Trim();
            NombreProducto = nombreProducto.Trim();
            Cantidad = cantidad;
            Precio = precio;
        }

        public CTProductosDGV()
        {
        }
    }
}
