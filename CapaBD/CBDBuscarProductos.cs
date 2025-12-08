using CapaTabla;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CapaBD
{
    public class CBDBuscarProductos
    {
        private string conexion = "Server = DESKTOP-9ITF4PC\\SQLEXPRESS; Database=AutorepuestoInventario; Integrated Security=true;";

        // Método para buscar por ID
        public CTProductosDGV BuscarPorID(string idProducto)
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
                        return new CTProductosDGV
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
                throw new Exception("Error al Buscar Por ID: " + ex.Message);
            }
        }

        // Método para buscar por nombre
        public List<CTProductosDGV> BuscarPorNombre(string nombreP)
        {
            List<CTProductosDGV> lista = new List<CTProductosDGV>();

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
                        lista.Add(new CTProductosDGV
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
                throw new Exception("Error al Buscar Por Nombre: " + ex.Message);
            }
        }

        // Método para buscar por categoría (descripcion)
        public List<CTProductosDGV> BuscarPorCategoria(string descripcionCategoria)
        {
            List<CTProductosDGV> lista = new List<CTProductosDGV>();

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
                        lista.Add(new CTProductosDGV
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
                throw new Exception("Error al Buscar Por Categoria: " + ex.Message);
            }
        }
    }
}
