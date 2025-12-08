using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaTabla;
using System.Data.SqlClient;
using System.Data;

namespace CapaBD
{
    public class CBDFactura : Conexion
    {
        public int InsertarFactura(CTFactura fac)
        {
            using (SqlConnection con = ObtenerConexion())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Factura (FechaEmision, IDemp, Estado, Subtotal, Impuesto, Total) " + "OUTPUT INSERTED.IDFactura " + "VALUES (@FechaEmision, @IDemp, @Estado, @Subtotal, @Impuesto, @Total)", con);

                cmd.Parameters.AddWithValue("@FechaEmision", fac.FechaEmision);
                cmd.Parameters.AddWithValue("@IDemp", fac.IDemp);
                cmd.Parameters.AddWithValue("@Estado", fac.Estado);
                cmd.Parameters.AddWithValue("@Subtotal", fac.Subtotal);
                cmd.Parameters.AddWithValue("@Impuesto", fac.Impuesto);
                cmd.Parameters.AddWithValue("@Total", fac.Total);

                return (int)cmd.ExecuteScalar();
            }
        }

        public void InsertarDetalles(int idFactura, DataTable tabla)
        {
            using (SqlConnection con = ObtenerConexion())
            {
                con.Open();

                foreach (DataRow row in tabla.Rows)
                {
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO FacturaDetalle (IDFactura, IDProducto, Cantidad, PrecioUnitario) " +
                        "VALUES (@IDFactura, @IDProducto, @Cantidad, @PrecioUnitario)", con);

                    cmd.Parameters.AddWithValue("@IDFactura", idFactura);
                    cmd.Parameters.AddWithValue("@IDProducto", row["IDProductos"]);
                    cmd.Parameters.AddWithValue("@Cantidad", row["Cantidad"]);
                    cmd.Parameters.AddWithValue("@PrecioUnitario", row["Precio"]);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}