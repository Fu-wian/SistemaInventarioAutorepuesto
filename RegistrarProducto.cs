using CapaLogica;
using CapaTabla;
using System;
using System.Collections.Generic;
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
            this.Load += RegistrarProducto_Load; // Evento Load del formulario
        }

        // Evento Load: inicializa el ComboBox con categorías válidas
        private void RegistrarProducto_Load(object sender, EventArgs e)
        {
            var categorias = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(1, "Categoría 1"),
                new KeyValuePair<int, string>(2, "Categoría 2"),
                new KeyValuePair<int, string>(3, "Categoría 3"),
                new KeyValuePair<int, string>(4, "Categoría 4"),
                new KeyValuePair<int, string>(5, "Categoría 5"),
            };

            cbCategoria.DataSource = new BindingSource(categorias, null);
            cbCategoria.DisplayMember = "Value"; // lo que ve el usuario
            cbCategoria.ValueMember = "Key";     // valor real que se envía a la lógica
            cbCategoria.SelectedIndex = -1;      // sin selección inicial
        }

        // Botón Registrar
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que se haya seleccionado una categoría
                if (cbCategoria.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar una categoría válida.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear objeto producto
                CTProductos obj = new CTProductos
                {
                    IDProducto = txtCodigo.Text.Trim(),
                    IDCategoria = Convert.ToInt32(cbCategoria.SelectedValue),
                    NombreProducto = txtDescripcion.Text.Trim(),
                    Cantidad = Convert.ToInt32(nudCantidad.Value),
                    PrecioUnidad = Convert.ToDecimal(txtPrecio.Text.Trim())
                };

                // Intentar registrar el producto
                bool exito = logica.RegistrarProducto(obj);

                if (exito)
                {
                    MessageBox.Show("Producto registrado correctamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el producto", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para limpiar el formulario
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
