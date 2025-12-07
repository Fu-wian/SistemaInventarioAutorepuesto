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
        private CTPersonal usuarioActual;
        private CLFacturacion logicaFacturacion = new CLFacturacion();
        public PantallaPrincipal(CTPersonal persona)
        {
            InitializeComponent();

            // Guardamos el usuario para usarlo en toda la clase
            usuarioActual = persona;

            // Controlar permisos por rol
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

            // Eventos del DataGridView para actualizar total automáticamente
            dgvFactura.CellValueChanged += (s, ev) => ActualizarTotal();
            dgvFactura.RowsRemoved += (s, ev) => ActualizarTotal();
            dgvFactura.UserAddedRow += (s, ev) => ActualizarTotal();
        }
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

            decimal subtotal = logicaFacturacion.CalcularSubtotal(tabla);
            var (impuesto, total) = logicaFacturacion.CalcularTotal(subtotal);

            lbCalculoTotal.Text = total.ToString("C2");
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
            var (impuesto, total) = logicaFacturacion.CalcularTotal(subtotal);

            // Crear objeto factura
            CLFactura logica = new CLFactura();
            CTFactura fac = new CTFactura
            {
                FechaEmision = DateTime.Now,
                IDemp = usuarioActual.IDemp,
                Estado = "PAGADA",
                Subtotal = subtotal,
                Impuesto = impuesto,
                Total = total
            };

            // Guardar factura en BD
            int idFactura = logica.GuardarFactura(fac);
            logica.GuardarDetalles(idFactura, tabla);

            MessageBox.Show("Factura registrada con éxito. ID: " + idFactura);

            // Mostrar factura
            Factura frm = new Factura(tabla, subtotal, impuesto, total);
            frm.ShowDialog();
        }
    }
}