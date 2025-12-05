using System.Data;
using System.Data.SqlClient;
using CapaTabla;

namespace CapaBD
{
    public class CBDRegistrarProductos
    {
        public string conexion = "Server = -CLEAKSITO-\\SQLEXPRESS; Database=AutorepuestoInventario; Integrated Security=True;";

        public bool RegistrarProducto(CTProductos obj)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("SP_RegistrarProducto", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Parámetros tipados
                cmd.Parameters.Add("@IDProducto", SqlDbType.VarChar, 8).Value = obj.IDProducto;
                cmd.Parameters.Add("@IDCategoria", SqlDbType.Int).Value = obj.IDCategoria;
                cmd.Parameters.Add("@NombreProducto", SqlDbType.VarChar, 100).Value = obj.NombreProducto;
                cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = obj.Cantidad;
                cmd.Parameters.Add("@PrecioUnidad", SqlDbType.Decimal).Value = obj.PrecioUnidad;

                cn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
        }

    }
}
