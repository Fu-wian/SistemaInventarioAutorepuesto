using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapaBD
{
    public class Conexion
    {
        protected SqlConnection ObtenerConexion()
        {
            return new SqlConnection("Data Source=BUNS\\SQLEXPRESS;Initial Catalog=AutorepuestoInventario;Integrated Security=True;"


            );
        }
    }
}