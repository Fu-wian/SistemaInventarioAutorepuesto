using CapaTabla;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBD
{
    public class CBIniciarSesion : Conexion
    {
        public CTPersonal Login(string usuario, string clave)
        {
            try
            {
                using (SqlConnection cn = ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_LoginPersonal", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IDemp", usuario);
                    cmd.Parameters.AddWithValue("@Clave", clave);

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        return new CTPersonal
    {
                            IDemp = dr["IDemp"].ToString(),
                            Nombre = dr["Nombre"].ToString(),
                            Apellido = dr["Apellido"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Clave = dr["Clave"].ToString(),
                            IDRol = Convert.ToInt32(dr["IDRol"])
                        };
                    }

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar la base de datos: " + ex.Message, ex);
            }
        }
    }
}
