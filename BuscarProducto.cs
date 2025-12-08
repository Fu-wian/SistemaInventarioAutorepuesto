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
    public partial class BuscarProducto : Form
    {
        //dgvProductos,cbCategorias, txtCodigo, btnBuscar

        //primero que nada, hacer que esta interfaz tenga las informaciones del DB.
        //crear un stored procedure para buscar en db

        private CLBuscarProductos logicaBuscar;
        private PantallaPrincipal pantallaPrincipal;

        public BuscarProducto(PantallaPrincipal principal)
        {   
            InitializeComponent();
            logicaBuscar = new CLBuscarProductos();
            pantallaPrincipal = principal;
        }

        private void ConfigurarDataGridView()
        {
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.MultiSelect = false;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.ReadOnly = true;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarCategorias()
        {
            cbCategorias.Items.Clear();
            cbCategorias.Items.Add("Nombre");
            cbCategorias.Items.Add("Codigo");
            cbCategorias.Items.Add("Categoria");
            // Elegir un filtro por defecto para evitar null en la búsqueda
            if (cbCategorias.Items.Count > 0)
                cbCategorias.SelectedIndex = 0;
        }

        private void BuscarProducto_Load(object sender, EventArgs e)
        {
            cbCategorias.DropDownStyle = ComboBoxStyle.DropDownList;
            CargarCategorias();
            ConfigurarDataGridView();
        }

        private void FormatearColumnasDGV()//Cambiar de acuerdo al Formato del Base de Datos
        {
            // Asegurarse de usar los nombres de propiedades correctos de CTProductosDGV
            if (dgvProductos.Columns.Contains("IDProductos"))
            {
                dgvProductos.Columns["IDProductos"].Width = 120;
            }

            if (dgvProductos.Columns.Contains("Categoria"))
            {
                dgvProductos.Columns["Categoria"].Width = 120;
            }

            if (dgvProductos.Columns.Contains("NombreProducto"))
            {
                dgvProductos.Columns["NombreProducto"].Width = 200;
            }
            if (dgvProductos.Columns.Contains("Cantidad"))
            {
                dgvProductos.Columns["Cantidad"].Width = 100;
            }
            if (dgvProductos.Columns.Contains("Precio"))
            {
                dgvProductos.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvProductos.Columns["Precio"].DefaultCellStyle.Format = "N2";
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            //no tiene restricciones, quizas convertir lo buscado a minuscula o encontrar una forma de buscarse con mayuscula/minuscula
            //
        }

        private void cbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            //

        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Validar selección
                if (cbCategorias.SelectedItem == null)
                {
                    MessageBox.Show(
                        "Debe seleccionar un filtro.",
                        "Campo requerido",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    cbCategorias.Focus();
                    return;
                }

                string filtro = cbCategorias.SelectedItem.ToString();
                string texto = txtCodigo.Text?.Trim() ?? string.Empty;

                List<CTProductosDGV> productos = new List<CTProductosDGV>();

                // Determinar acción según el filtro seleccionado
                switch (filtro)
                {
                    case "Nombre":
                        // BuscarPorNombre espera el texto a buscar en el nombre
                        productos = logicaBuscar.BuscarPorNombre(texto) ?? new List<CTProductosDGV>();
                        break;

                    case "Categoria":
                        // BuscarPorCategoria espera la descripción de la categoría
                        productos = logicaBuscar.BuscarPorCategoria(texto) ?? new List<CTProductosDGV>();
                        break;

                    case "Codigo":
                        // BuscarPorCodigo espera la descripción del codigo
                        productos = logicaBuscar.BuscarPorID(texto) ?? new List<CTProductosDGV>();
                        break;
                }

                dgvProductos.DataSource = null;
                dgvProductos.DataSource = productos;
                FormatearColumnasDGV();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(
                    $"Error al consultar productos:\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al consultar productos:\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        //cuando da doble click a un elemtno de dgv tiene que agregar esa informacion a la facturacion del menu principal
        //cuando el administrador busca un producto es de vista solamente

        private void dgvProductos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dgvProductos.Rows[e.RowIndex];

                    // Crear un producto basado en la fila seleccionada
                    CTProductosDGV producto = new CTProductosDGV(
                        row.Cells["IDProductos"].Value.ToString(),
                        Convert.ToString(row.Cells["Categoria"].Value),
                        row.Cells["NombreProducto"].Value.ToString(),
                        Convert.ToInt32(row.Cells["Cantidad"].Value),
                        Convert.ToDecimal(row.Cells["Precio"].Value)
                    );

                    // Enviar a la factura usando el método del formulario principal
                    pantallaPrincipal.AgregarProductosAFactura(new List<CTProductosDGV> { producto });

                    // Opcional: cerrar la ventana después de seleccionar
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener producto: {ex.Message}");
                }
            }
        }

    }
}


