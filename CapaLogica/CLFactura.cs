using CapaTabla;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaBD;
using System.Data;

namespace CapaLogica
{
    public class CLFactura
    {
        CBDFactura bd = new CBDFactura();

        public int GuardarFactura(CTFactura fac)
        {
            return bd.InsertarFactura(fac);
        }

        public void GuardarDetalles(int idFactura, DataTable tabla)
        {
            bd.InsertarDetalles(idFactura, tabla);
        }
    }
}