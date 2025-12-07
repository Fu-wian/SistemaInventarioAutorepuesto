using System;
using System.Data;
using System.Data.SqlClient;
using CapaTabla;
namespace CapaBD
{
    public class CBEditarProductos
    {
        private string conexion = "Server= -CLEAKSITO-\\SQLEXPRESS; Database=AutorepuestoInventario; Integrated Security=True;";


        //buscar productos
        public CTProductos BuscarProducto(string idProducto)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                using (SqlCommand cmd = new SqlCommand("SP_BuscarProducto", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDProducto", idProducto);

                    try
                    {
                        cn.Open();

                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            CTProductos obj = new CTProductos()
                            {
                                IDProducto = dr["IDProducto"].ToString(),
                                IDCategoria = Convert.ToInt32(dr["IDCategoria"]),
                                NombreProducto = dr["NombreProducto"].ToString(),
                                Cantidad = Convert.ToInt32(dr["Cantidad"]),
                                PrecioUnidad = Convert.ToDecimal(dr["PrecioUnidad"])
                            };

                            return obj;
                        }

                        return null; // Si no hay filas
                    }
                    catch (SqlException ex)
                    {
                        // detectar error del RAISERROR
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        //borrar productos
        public int EliminarProducto(string idProducto)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                using (SqlCommand cmd = new SqlCommand("SP_EliminarProducto", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDProducto", idProducto);

                    try
                    {
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        return 1; // Eliminado OK
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        //actualizar productos
        public int ActualizarProducto(CTProductos obj)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("SP_ActualizarProducto", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IDProducto", obj.IDProducto);
                cmd.Parameters.AddWithValue("@IDCategoria", obj.IDCategoria);
                cmd.Parameters.AddWithValue("@NombreProducto", obj.NombreProducto);
                cmd.Parameters.AddWithValue("@Cantidad", obj.Cantidad);
                cmd.Parameters.AddWithValue("@PrecioUnidad", obj.PrecioUnidad);

                // Parámetro para capturar el valor RETURN del SP
                var returnParameter = cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();

                    // leer el valor del return
                    int result = (int)returnParameter.Value;

                    return result;  // 1 = éxito, 0 = error
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}

