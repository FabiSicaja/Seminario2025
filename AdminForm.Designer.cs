namespace Proyecto
{
    partial class AdminForm
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
            this.btnCrearOrden = new System.Windows.Forms.Button();
            this.btnVerOrdenes = new System.Windows.Forms.Button();
            this.btnVerGastos = new System.Windows.Forms.Button();
            this.btnCerrarOrden = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.dgvOrdenes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCrearOrden
            // 
            this.btnCrearOrden.Location = new System.Drawing.Point(47, 62);
            this.btnCrearOrden.Name = "btnCrearOrden";
            this.btnCrearOrden.Size = new System.Drawing.Size(114, 32);
            this.btnCrearOrden.TabIndex = 0;
            this.btnCrearOrden.Text = "Crear Orden";
            this.btnCrearOrden.UseVisualStyleBackColor = true;
            this.btnCrearOrden.Click += new System.EventHandler(this.btnCrearOrden_Click);
            // 
            // btnVerOrdenes
            // 
            this.btnVerOrdenes.Location = new System.Drawing.Point(47, 109);
            this.btnVerOrdenes.Name = "btnVerOrdenes";
            this.btnVerOrdenes.Size = new System.Drawing.Size(114, 34);
            this.btnVerOrdenes.TabIndex = 2;
            this.btnVerOrdenes.Text = "Ver Ordenes";
            this.btnVerOrdenes.UseVisualStyleBackColor = true;

            // 
            // btnVerGastos
            // 
            this.btnVerGastos.Location = new System.Drawing.Point(47, 158);
            this.btnVerGastos.Name = "btnVerGastos";
            this.btnVerGastos.Size = new System.Drawing.Size(114, 34);
            this.btnVerGastos.TabIndex = 3;
            this.btnVerGastos.Text = "Ver Gastos";
            this.btnVerGastos.UseVisualStyleBackColor = true;
            this.btnVerGastos.Click += new System.EventHandler(this.btnVerGastos_Click);
            // 
            // btnCerrarOrden
            // 
            this.btnCerrarOrden.Location = new System.Drawing.Point(47, 209);
            this.btnCerrarOrden.Name = "btnCerrarOrden";
            this.btnCerrarOrden.Size = new System.Drawing.Size(114, 32);
            this.btnCerrarOrden.TabIndex = 5;
            this.btnCerrarOrden.Text = "Cerrar Orden";
            this.btnCerrarOrden.UseVisualStyleBackColor = true;
            this.btnCerrarOrden.Click += new System.EventHandler(this.btnCerrarOrden_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.Location = new System.Drawing.Point(47, 262);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(114, 33);
            this.btnReporte.TabIndex = 6;
            this.btnReporte.Text = "Reporte";
            this.btnReporte.UseVisualStyleBackColor = true;
            // 
            // dgvOrdenes
            // 
            this.dgvOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenes.Location = new System.Drawing.Point(246, 62);
            this.dgvOrdenes.Name = "dgvOrdenes";
            this.dgvOrdenes.RowHeadersWidth = 51;
            this.dgvOrdenes.RowTemplate.Height = 24;
            this.dgvOrdenes.Size = new System.Drawing.Size(647, 233);
            this.dgvOrdenes.TabIndex = 7;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 450);
            this.Controls.Add(this.dgvOrdenes);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.btnCerrarOrden);
            this.Controls.Add(this.btnVerGastos);
            this.Controls.Add(this.btnVerOrdenes);
            this.Controls.Add(this.btnCrearOrden);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCrearOrden;
        private System.Windows.Forms.Button btnVerOrdenes;
        private System.Windows.Forms.Button btnVerGastos;
        private System.Windows.Forms.Button btnCerrarOrden;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.DataGridView dgvOrdenes;
    }
}