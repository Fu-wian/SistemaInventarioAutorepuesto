using CapaLogica;
using CapaTabla;
using System;
using System.Windows.Forms;

namespace SistemaInventarioAutorepuesto
{
    public partial class RegistrarProducto : Form
    {
        // Instancia de la lógica
        CLProductos logica = new CLProductos();

        public RegistrarProducto()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                CTProductos obj = new CTProductos
                {
                    IDProducto = txtCodigo.Text.Trim(),
                    IDCategoria = Convert.ToInt32(cbCategoria.SelectedValue), // si usa DataSource
                    NombreProducto = txtDescripcion.Text.Trim(),
                    Cantidad = Convert.ToInt32(nudCantidad.Value),
                    PrecioUnidad = Convert.ToDecimal(txtPrecio.Text.Trim())
                };

                logica.RegistrarProducto(obj);

                MessageBox.Show("Producto registrado correctamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            nudCantidad.Value = 0;
            cbCategoria.SelectedIndex = -1;
        }
    }
}