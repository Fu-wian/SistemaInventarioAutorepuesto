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

        public BuscarProducto()
        {
            InitializeComponent();
            logicaBuscar = new CLBuscarProductos();
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
        }

        private void BuscarProducto_Load(object sender, EventArgs e)
        {
            cbCategorias.DropDownStyle = ComboBoxStyle.DropDownList;
            CargarCategorias();
            ConfigurarDataGridView();
        }

        private void FormatearColumnasDGV()//Cambiar de acuerdo al Formato del Base de Datos
        {
            if (dgvProductos.Columns.Contains("IdProductos"))
            {
                dgvProductos.Columns["IdProductos"].Width = 100;
            }

            if (dgvProductos.Columns.Contains("Categoria"))
            {
                dgvProductos.Columns["Categoria"].Width = 100;
            }

            if (dgvProductos.Columns.Contains("NombreProducto"))
            {
                dgvProductos.Columns["NombreProducto"].Width = 100;
            }
            if (dgvProductos.Columns.Contains("Cantidad"))
            {
                dgvProductos.Columns["Cantidad"].Width = 100;
            }
            if (dgvProductos.Columns.Contains("Precio"))
            {
                dgvProductos.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //aqui se puede clickar sobre el boton o agregarle un evento de cuando presiona "Enter" se busca o se ejecuta el boton
            //tiene que hacer que el datagridview actualice el cuadro o pantalla

            //Este pedazo de codigo es buscar de acuerdo a lo seleccionado del comboBox, no sirve cuando se busca por x entrada
            //del txtBox
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

                List<CTProductos> productos = null;
                string texto = txtCodigo.Text.ToString();

                // Mostrar productos por filtros
                switch (texto)
                {
                    case "Nombre":
                        productos = logicaBuscar.BuscarPorNombre(texto);
                        break;

                    case "Categoria":
                        productos = logicaBuscar.BuscarPorCategoria(texto);
                        break;

                    case "Codigo":
                        // Manejar búsqueda por código (devuelve un solo objeto)
                        CTProductos producto = logicaBuscar.BuscarPorID(texto);
                        if (producto != null)
                        {
                            productos = new List<CTProductos> { producto };
                        }
                        else
                        {
                            productos = new List<CTProductos>(); // Lista vacía
                        }
                        break;
                }

                FormatearColumnasDGV();
                dgvProductos.DataSource = null;
                dgvProductos.DataSource = productos;

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(
                    $"Error al consultar libros:\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al consultar libros:\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
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

        }





        //cuando da doble click a un elemtno de dgv tiene que agregar esa informacion a la facturacion del menu principal
        //cuando el administrador busca un producto es de vista solamente
    }
}


