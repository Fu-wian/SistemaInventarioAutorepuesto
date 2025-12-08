using CapaBD;
using CapaTabla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CLIniciarSesion
    {
        CBIniciarSesion datos = new CBIniciarSesion();

        public CTPersonal Login(string usuario, string clave)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(usuario) ||
                    string.IsNullOrWhiteSpace(clave))
                {
                    return null;
                }

                return datos.Login(usuario, clave);
            }
            catch (Exception ex)
    {
                throw new Exception("Error: " + ex.Message, ex);
            }
        }
    }
}
