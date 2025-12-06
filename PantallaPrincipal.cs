using CapaTabla;
using CapaLogica;
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
        CLFacturacion logicaFacturacion = new CapaLogica.CLFacturacion();
        private DataTable ConvertirDgvATabla(DataGridView dgv)
        {
            DataTable dt = new DataTable();

            // Crear columnas
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                dt.Columns.Add(col.Name);
            }

            // Copiar filas
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                DataRow dr = dt.NewRow();
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    dr[col.Name] = row.Cells[col.Name].Value ?? DBNull.Value;
                }
                dt.Rows.Add(dr);
            }

            return dt;
        }
        private void ActualizarTotal()
        {
            DataTable tabla = ConvertirDgvATabla(dgvFactura);

            // Calcular subtotal
            decimal subtotal = logicaFacturacion.CalcularSubtotal(tabla);

            // Calcular impuesto + total con 7% (puedes cambiarlo)
            var (impuesto, total) = logicaFacturacion.CalcularTotal(subtotal, 7m);

            lbCalculoTotal.Text = total.ToString("C2");
        }
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
            dgvFactura.CellValueChanged += (s, ev) => ActualizarTotal();
            dgvFactura.RowsRemoved += (s, ev) => ActualizarTotal();
            dgvFactura.UserAddedRow += (s, ev) => ActualizarTotal();
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
        private void btnCotizar_Click(object sender, EventArgs e)
        {
            DataTable tabla = ConvertirDgvATabla(dgvFactura);
            if (tabla.Rows.Count == 0)
            {
                MessageBox.Show("No hay productos para cotizar.");
                return;
            }

            Cotizacion frm = new Cotizacion(tabla);
            frm.ShowDialog();
        }
        private void btnFacturar_Click(object sender, EventArgs e)
        {
            DataTable tabla = ConvertirDgvATabla(dgvFactura);

            if (tabla.Rows.Count == 0)
            {
                MessageBox.Show("No hay productos para facturar.");
                return;
            }
            decimal subtotal = logicaFacturacion.CalcularSubtotal(tabla);
            var (impuesto, total) = logicaFacturacion.CalcularTotal(subtotal, 7m);
            Factura frm = new Factura(tabla, subtotal, impuesto, total);
            frm.ShowDialog();
        }
    }
}
