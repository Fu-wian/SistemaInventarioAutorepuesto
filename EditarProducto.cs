using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;
using CapaTabla;

//Componentes utilizados:
//txtCodigo - txtDescripcion - cbCategoria - txtPrecio - nudCantidad - btnBuscarEditar - btnEditar - btnBorra - btConfirmar

namespace SistemaInventarioAutorepuesto
{
    public partial class EditarProducto : Form
    { 
        CLEditarProductos logica = new CLEditarProductos();
        public EditarProducto()
        {
            InitializeComponent();
           
        }

        private void btnBuscarEditar_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtCodigo.Text.Trim();

                var prod = logica.BuscarProducto(id);

                if (prod == null)
                {
                    MessageBox.Show("Producto no encontrado.");
                    return;
                }

                // Mostrar datos en pantalla
                txtDescripcion.Text = prod.NombreProducto;
                cbCategoria.SelectedValue = prod.IDCategoria;
                nudCantidad.Value = prod.Cantidad;
                txtPrecio.Text = prod.PrecioUnidad.ToString();

                // Deshabilitar edición hasta que se presione Editar
                HabilitarCampos(false);
                btnEditar.Enabled = true;
                btnBorrar.Enabled = true;
                btConfirmar.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarCampos(true);

            btnEditar.Enabled = false;
            btnBorrar.Enabled = true;
            btConfirmar.Enabled = true;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtCodigo.Text.Trim();

                var confirm = MessageBox.Show(
                    "¿Está seguro que desea eliminar este producto?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.No) return;

                logica.EliminarProducto(id);

                MessageBox.Show("Producto eliminado.");

                LimpiarCampos();
                DeshabilitarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                CTProductos obj = new CTProductos()
                {
                    IDProducto = txtCodigo.Text.Trim(),
                    NombreProducto = txtDescripcion.Text.Trim(),
                    PrecioUnidad = Convert.ToDecimal(txtPrecio.Text),
                    Cantidad = (int)nudCantidad.Value,
                    IDCategoria = (int)cbCategoria.SelectedValue
                };

                int result = logica.ActualizarProducto(obj);

                if (result == 1)
                {
                    MessageBox.Show("Producto actualizado correctamente.");
                    DeshabilitarCampos();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el producto.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //metodos
        private void HabilitarCampos(bool flag)
        {
            txtDescripcion.Enabled = flag;
            cbCategoria.Enabled = flag;
            nudCantidad.Enabled = flag;
            txtPrecio.Enabled = flag;
        }
        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtDescripcion.Clear();
            cbCategoria.SelectedIndex = -1;
            nudCantidad.Value = 0;
            txtPrecio.Clear();

            btnEditar.Enabled = false;
            btnBorrar.Enabled = false;
            btConfirmar.Enabled = false;
        }

        private void EditarProducto_Load(object sender, EventArgs e)
        {
            btnEditar.Enabled = false;
            btnBorrar.Enabled = false;
            btConfirmar.Enabled = false;

            HabilitarCampos(false);

            CargarCategorias();
        }

        private void CargarCategorias()
        {
            var categorias = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(1, "Categoria 1"),
                new KeyValuePair<int, string>(2, "Categoria 2"),
                new KeyValuePair<int, string>(3, "Categoria 3"),
                new KeyValuePair<int, string>(4, "Categoria 4"),
                new KeyValuePair<int, string>(5, "Categoria 5"),
            };

            cbCategoria.DataSource = new BindingSource(categorias, null);
            cbCategoria.DisplayMember = "Value";
            cbCategoria.ValueMember = "Key";
            cbCategoria.SelectedIndex = -1;
        }

        private void DeshabilitarCampos()
        {
            txtDescripcion.Enabled = false;
            cbCategoria.Enabled = false;
            txtPrecio.Enabled = false;
            nudCantidad.Enabled = false;
            btConfirmar.Enabled = false;
        }   

        private void EditarProducto_Load_1(object sender, EventArgs e)
        {
            CargarCategorias();
            DeshabilitarCampos();
        }
    }
}
