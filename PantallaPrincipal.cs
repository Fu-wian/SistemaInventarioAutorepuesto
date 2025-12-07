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
    public partial class PantallaPrincipal : Form
    {
        public PantallaPrincipal(CTPersonal persona)
        {
            InitializeComponent();
            if (persona.IDRol == 1) // administrador
            {
                btnRegistrar.Enabled = true;
                btnEditar.Enabled = true;
                btnBuscar.Enabled = true;
            }
            else if (persona.IDRol == 2) // vendedor
            {
                btnRegistrar.Enabled = false;
                btnEditar.Enabled = false;
                btnBuscar.Enabled = true;
            }
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
           BuscarProducto frmBuscar = new BuscarProducto(this);
            frmBuscar.Show();
        }

        private void dgvFactura_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void AgregarProductosAFactura(IEnumerable<CTProductos> productos)
        {
            if (productos == null) return;

            try
            {
                BindingList<CTProductos> binding;

                // Si no hay DataSource, crear uno nuevo basado en la lista recibida
                if (dgvFactura.DataSource == null)
                {
                    var lista = productos.Select(p => new CTProductos(p.IDProductos, p.Categoria, p.NombreProducto, p.Cantidad, p.Precio)).ToList();
                    binding = new BindingList<CTProductos>(lista);
                    dgvFactura.DataSource = binding;
                }
                else
                {
                    binding = dgvFactura.DataSource as BindingList<CTProductos>;
                    if (binding == null)
                    {
                        // intentar convertir la fuente existente a BindingList
                        var existing = (dgvFactura.DataSource as IEnumerable<CTProductos>)?.ToList() ?? new List<CTProductos>();
                        binding = new BindingList<CTProductos>(existing);
                        dgvFactura.DataSource = binding;
                    }

                    // Añadir cada producto recibido como nueva fila
                    foreach (var p in productos)
                    {
                        binding.Add(new CTProductos(p.IDProductos, p.Categoria, p.NombreProducto, p.Cantidad, p.Precio));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar productos a la factura: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
