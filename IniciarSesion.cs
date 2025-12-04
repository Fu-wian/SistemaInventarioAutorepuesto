using CapaLogica;
using CapaTabla;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaInventarioAutorepuesto
{
    public partial class IniciarSesion : Form
    {
        CLIniciarSesion logica = new CLIniciarSesion();

        public IniciarSesion()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                string usuario = txtCodigoEmpleado.Text;
                string clave = txtContra.Text;

                CTPersonal empleado = logica.Login(usuario, clave);

                if (empleado == null)
                {
                    MessageBox.Show("Credenciales incorrectas.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                PantallaPrincipal menu = new PantallaPrincipal(empleado);
                menu.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
