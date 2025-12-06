using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CLFacturacion
    {
        //columnas "Cantidad" y "PrecioUnidad"
        public decimal CalcularSubtotal(DataTable tabla)
        {
            decimal subtotal = 0m;
            if (tabla == null || tabla.Rows.Count == 0)
                return subtotal;
            foreach (DataRow row in tabla.Rows)
            {
                if (row["Cantidad"] == DBNull.Value || row["PrecioUnidad"] == DBNull.Value)
                    continue;
                int cantidad = Convert.ToInt32(row["Cantidad"]);
                decimal precio = Convert.ToDecimal(row["PrecioUnidad"]);
                subtotal += cantidad * precio;
            }
            return subtotal;
        }
        public (decimal impuesto, decimal total) CalcularTotal(decimal subtotal, decimal porcentajeImpuesto = 7m)
        {
            decimal impuesto = Math.Round(subtotal * (porcentajeImpuesto / 100), 2);
            decimal total = subtotal + impuesto;
            return (impuesto, total);
        }
    }
}
