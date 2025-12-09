using CapaTabla;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBD
{
    public class CBDFacturaDetalle : Conexion
    {
        public void InsertarDetalle(CTFacturaDetalle detalle)
        {
            try {
                using (SqlConnection conn = ObtenerConexion())
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO DetalleFactura (IDFactura, IDProducto, Cantidad, PrecioUnidad, PrecioTotal) " + "VALUES (@IDFactura, @IDProducto, @Cantidad, @PrecioUnidad, @PrecioTotal)", conn
                    );

                    cmd.Parameters.AddWithValue("@IDFactura", detalle.IDFactura);
                    cmd.Parameters.AddWithValue("@IDProducto", detalle.IDProducto);
                    cmd.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                    cmd.Parameters.AddWithValue("@PrecioUnidad", detalle.PrecioUnidad);
                    cmd.Parameters.AddWithValue("@PrecioTotal", detalle.PrecioTotal);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al solicitar detalles de la facturacion: " + ex.Message);
            }
        }
    }
}