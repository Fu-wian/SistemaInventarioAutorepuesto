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
    public partial class Cotizacion : Form
    {
            public Cotizacion(DataTable tabla, decimal subtotal, decimal impuesto, decimal total)
        {
            InitializeComponent();
            dgvCotizacion.DataSource = tabla;
            lbSubtotal.Text = subtotal.ToString("C2");
            lbImpuesto.Text = impuesto.ToString("C2");
            lbTotal.Text = total.ToString("C2");
        }
    }
}

