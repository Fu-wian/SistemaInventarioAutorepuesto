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
            public Cotizacion(DataTable tabla)
        {
            InitializeComponent();
            dgvCotizacion.DataSource = tabla;
        }
    }
}
