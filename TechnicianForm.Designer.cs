namespace Proyecto
{
    partial class TechnicianForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnIngresarGasto = new System.Windows.Forms.Button();
            this.dgvOrdenes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(108, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 43);
            this.button1.TabIndex = 0;
            this.button1.Text = "Orden Asignada";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(108, 150);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 48);
            this.button2.TabIndex = 1;
            this.button2.Text = "Seleccionar Orden";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnIngresarGasto
            // 
            this.btnIngresarGasto.Location = new System.Drawing.Point(108, 222);
            this.btnIngresarGasto.Name = "btnIngresarGasto";
            this.btnIngresarGasto.Size = new System.Drawing.Size(144, 43);
            this.btnIngresarGasto.TabIndex = 2;
            this.btnIngresarGasto.Text = "Ingresar Gastos";
            this.btnIngresarGasto.UseVisualStyleBackColor = true;
            this.btnIngresarGasto.Click += new System.EventHandler(this.btnIngresarGasto_Click);
            // 
            // dgvOrdenes
            // 
            this.dgvOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenes.Location = new System.Drawing.Point(330, 98);
            this.dgvOrdenes.Name = "dgvOrdenes";
            this.dgvOrdenes.RowHeadersWidth = 51;
            this.dgvOrdenes.RowTemplate.Height = 24;
            this.dgvOrdenes.Size = new System.Drawing.Size(390, 150);
            this.dgvOrdenes.TabIndex = 3;
            // 
            // TechnicianForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvOrdenes);
            this.Controls.Add(this.btnIngresarGasto);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "TechnicianForm";
            this.Text = "TechnicianForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnIngresarGasto;
        private System.Windows.Forms.DataGridView dgvOrdenes;
    }
}