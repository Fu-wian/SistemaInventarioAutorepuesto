using CapaTabla;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CapaBD
{
    public class CBDBuscarProductos
    {
        private string conexion = "Server = greglai; Database=AutorepuestoInventario; Integrated Security=true;";

        // Método para buscar por ID
        public CTProductos BuscarPorID(string idProducto)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    SqlCommand cmd = new SqlCommand("SP_BuscarPorID", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", idProducto);

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        return new CTProductos
                        {
                            IDProductos = dr["IDProducto"].ToString(),
                            Categoria = Convert.ToString(dr["IDCategoria"]),
                            NombreProducto = dr["NombreProducto"].ToString(),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            Precio = Convert.ToDecimal(dr["PrecioUnidad"])
                        };
                    }

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa BD (BuscarPorID): " + ex.Message);
            }
        }

        // Método para buscar por nombre
        public List<CTProductos> BuscarPorNombre(string nombreP)
        {
            List<CTProductos> lista = new List<CTProductos>();

            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    SqlCommand cmd = new SqlCommand("SP_BuscarPorNombre", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nombreP", nombreP);

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        lista.Add(new CTProductos
                        {
                            IDProductos = dr["IDProducto"].ToString(),
                            Categoria = Convert.ToString(dr["IDCategoria"]),
                            NombreProducto = dr["NombreProducto"].ToString(),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            Precio = Convert.ToDecimal(dr["PrecioUnidad"])
                        });
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa BD (BuscarPorNombre): " + ex.Message);
            }
        }

        // Método para buscar por categoría (descripcion)
        public List<CTProductos> BuscarPorCategoria(string descripcionCategoria)
        {
            List<CTProductos> lista = new List<CTProductos>();

            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    SqlCommand cmd = new SqlCommand("SP_BuscarPorCategoria", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@descCategoria", descripcionCategoria);

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        lista.Add(new CTProductos
                        {
                            IDProductos = dr["IDProducto"].ToString(),
                            Categoria = Convert.ToString(dr["IDCategoria"]),
                            NombreProducto = dr["NombreProducto"].ToString(),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            Precio = Convert.ToDecimal(dr["PrecioUnidad"])
                        });
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa BD (BuscarPorCategoria): " + ex.Message);
            }
        }
    }
}
