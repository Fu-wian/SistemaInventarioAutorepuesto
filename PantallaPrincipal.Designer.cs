namespace SistemaInventarioAutorepuesto
{
    partial class PantallaPrincipal
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
            this.lbFecha = new System.Windows.Forms.Label();
            this.lbNombreSistema = new System.Windows.Forms.Label();
            this.lbNombreUsuario = new System.Windows.Forms.Label();
            this.dgvFactura = new System.Windows.Forms.DataGridView();
            this.lbTotal = new System.Windows.Forms.Label();
            this.lbCalculoTotal = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.btnCotizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFactura)).BeginInit();
            this.SuspendLayout();
            // 
            // lbFecha
            // 
            this.lbFecha.AutoSize = true;
            this.lbFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFecha.Location = new System.Drawing.Point(84, 54);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Size = new System.Drawing.Size(131, 46);
            this.lbFecha.TabIndex = 0;
            this.lbFecha.Text = "Fecha";
            // 
            // lbNombreSistema
            // 
            this.lbNombreSistema.AutoSize = true;
            this.lbNombreSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNombreSistema.Location = new System.Drawing.Point(536, 54);
            this.lbNombreSistema.Name = "lbNombreSistema";
            this.lbNombreSistema.Size = new System.Drawing.Size(317, 46);
            this.lbNombreSistema.TabIndex = 1;
            this.lbNombreSistema.Text = "Nombre Sistema";
            // 
            // lbNombreUsuario
            // 
            this.lbNombreUsuario.AutoSize = true;
            this.lbNombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNombreUsuario.Location = new System.Drawing.Point(1168, 54);
            this.lbNombreUsuario.Name = "lbNombreUsuario";
            this.lbNombreUsuario.Size = new System.Drawing.Size(311, 46);
            this.lbNombreUsuario.TabIndex = 2;
            this.lbNombreUsuario.Text = "Nombre Usuario";
            // 
            // dgvFactura
            // 
            this.dgvFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFactura.Location = new System.Drawing.Point(92, 172);
            this.dgvFactura.Name = "dgvFactura";
            this.dgvFactura.RowHeadersWidth = 51;
            this.dgvFactura.RowTemplate.Height = 24;
            this.dgvFactura.Size = new System.Drawing.Size(923, 546);
            this.dgvFactura.TabIndex = 3;
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.Location = new System.Drawing.Point(663, 731);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(120, 46);
            this.lbTotal.TabIndex = 4;
            this.lbTotal.Text = "Total:";
            // 
            // lbCalculoTotal
            // 
            this.lbCalculoTotal.AutoSize = true;
            this.lbCalculoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCalculoTotal.Location = new System.Drawing.Point(789, 731);
            this.lbCalculoTotal.Name = "lbCalculoTotal";
            this.lbCalculoTotal.Size = new System.Drawing.Size(226, 42);
            this.lbCalculoTotal.TabIndex = 5;
            this.lbCalculoTotal.Text = "CalculoTotal";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Font = new System.Drawing.Font("Microsoft Tai Le", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.Location = new System.Drawing.Point(1068, 172);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(194, 94);
            this.btnRegistrar.TabIndex = 6;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Tai Le", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Location = new System.Drawing.Point(1315, 172);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(194, 94);
            this.btnEditar.TabIndex = 7;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Tai Le", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(1187, 354);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(194, 94);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnFacturar
            // 
            this.btnFacturar.Font = new System.Drawing.Font("Microsoft Tai Le", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturar.Location = new System.Drawing.Point(1068, 538);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(194, 94);
            this.btnFacturar.TabIndex = 9;
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.UseVisualStyleBackColor = true;
            // 
            // btnCotizar
            // 
            this.btnCotizar.Font = new System.Drawing.Font("Microsoft Tai Le", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCotizar.Location = new System.Drawing.Point(1315, 538);
            this.btnCotizar.Name = "btnCotizar";
            this.btnCotizar.Size = new System.Drawing.Size(194, 94);
            this.btnCotizar.TabIndex = 10;
            this.btnCotizar.Text = "Cotizar";
            this.btnCotizar.UseVisualStyleBackColor = true;
            // 
            // PantallaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1587, 796);
            this.Controls.Add(this.btnCotizar);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.lbCalculoTotal);
            this.Controls.Add(this.lbTotal);
            this.Controls.Add(this.dgvFactura);
            this.Controls.Add(this.lbNombreUsuario);
            this.Controls.Add(this.lbNombreSistema);
            this.Controls.Add(this.lbFecha);
            this.Name = "PantallaPrincipal";
            this.Text = "PantallaPrincipal";
            this.Load += new System.EventHandler(this.PantallaPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFactura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbFecha;
        private System.Windows.Forms.Label lbNombreSistema;
        private System.Windows.Forms.Label lbNombreUsuario;
        private System.Windows.Forms.DataGridView dgvFactura;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Label lbCalculoTotal;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.Button btnCotizar;
    }
}