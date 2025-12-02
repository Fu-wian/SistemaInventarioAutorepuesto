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
    public partial class PantallaPrincipal : Form
    {
        public PantallaPrincipal()
        {
            InitializeComponent();
        }

        private void PantallaPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarProducto frmRegistrar = new RegistrarProducto();
            frmRegistrar.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarProducto frmEditar = new EditarProducto();
            frmEditar.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
           BuscarProducto frmBuscar = new BuscarProducto();
            frmBuscar.Show();
        }
    }
}
