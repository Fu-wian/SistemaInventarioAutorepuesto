namespace SistemaInventarioAutorepuesto
{
    partial class Cotizacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvCotizacion = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTotal = new System.Windows.Forms.Label();
            this.lbImpuesto = new System.Windows.Forms.Label();
            this.lbSubtotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCotizacion)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCotizacion
            // 
            this.dgvCotizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCotizacion.Location = new System.Drawing.Point(11, 11);
            this.dgvCotizacion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvCotizacion.Name = "dgvCotizacion";
            this.dgvCotizacion.RowHeadersWidth = 51;
            this.dgvCotizacion.RowTemplate.Height = 24;
            this.dgvCotizacion.Size = new System.Drawing.Size(552, 483);
            this.dgvCotizacion.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(603, 473);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 24);
            this.label3.TabIndex = 12;
            this.label3.Text = "Total";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(603, 448);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "Impuesto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(603, 424);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "Subtotal";
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Location = new System.Drawing.Point(695, 481);
            this.lbTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(31, 13);
            this.lbTotal.TabIndex = 9;
            this.lbTotal.Text = "Total";
            // 
            // lbImpuesto
            // 
            this.lbImpuesto.AutoSize = true;
            this.lbImpuesto.Location = new System.Drawing.Point(695, 456);
            this.lbImpuesto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbImpuesto.Name = "lbImpuesto";
            this.lbImpuesto.Size = new System.Drawing.Size(50, 13);
            this.lbImpuesto.TabIndex = 8;
            this.lbImpuesto.Text = "Impuesto";
            // 
            // lbSubtotal
            // 
            this.lbSubtotal.AutoSize = true;
            this.lbSubtotal.Location = new System.Drawing.Point(695, 430);
            this.lbSubtotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSubtotal.Name = "lbSubtotal";
            this.lbSubtotal.Size = new System.Drawing.Size(46, 13);
            this.lbSubtotal.TabIndex = 7;
            this.lbSubtotal.Text = "Subtotal";
            // 
            // Cotizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 525);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbTotal);
            this.Controls.Add(this.lbImpuesto);
            this.Controls.Add(this.lbSubtotal);
            this.Controls.Add(this.dgvCotizacion);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Cotizacion";
            this.Text = "CotizacionForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCotizacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCotizacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Label lbImpuesto;
        private System.Windows.Forms.Label lbSubtotal;
    }
}