using System;
using System.Data;
using System.Data.SqlClient;
using CapaTabla;

namespace CapaBD
{
    public class CBDRegistrarProductos
    {
        private string conexion = "Server= -CLEAKSITO-\\SQLEXPRESS; Database=AutorepuestoInventario; Integrated Security=True;";

        public bool RegistrarProducto(CTProductos obj)
        {
            try
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

                    // Parámetro para capturar el valor de retorno
                    SqlParameter returnParameter = cmd.Parameters.Add("RetVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    // Leer el valor de retorno del procedimiento
                    int result = (int)returnParameter.Value;

                    return result == 1; // true si la inserción fue exitosa
                }
            }
            catch (Exception ex)
            {
                // EXCEPCIÓN EN CAPA BD, REENVIAR A CAPA LÓGICA
                throw new Exception("Error en la capa BD (RegistrarProducto): " + ex.Message);
            }
        }
    }
}
