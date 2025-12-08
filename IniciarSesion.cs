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
            btnIngresar.Enabled = false;
            txtCodigoEmpleado.TextChanged += ValidarCampos;
            txtContra.TextChanged += ValidarCampos;
            this.AcceptButton = btnIngresar;
        }

        private void ValidarCampos(object sender, EventArgs e)
        {
            btnIngresar.Enabled = !string.IsNullOrWhiteSpace(txtCodigoEmpleado.Text)
                                 && !string.IsNullOrWhiteSpace(txtContra.Text);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                string usuario = txtCodigoEmpleado.Text.Trim();
                string clave = txtContra.Text;

                btnIngresar.Enabled = false;

                CTPersonal empleado = logica.Login(usuario, clave);

                if (empleado == null)
                {
                    MessageBox.Show("Credenciales incorrectas.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnIngresar.Enabled = true;
                    return;
                }

                PantallaPrincipal menu = new PantallaPrincipal(empleado);
                menu.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIngresar.Enabled = true;
            }
        }
    }
}
