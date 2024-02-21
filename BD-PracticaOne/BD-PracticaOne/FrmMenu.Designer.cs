namespace BD_PracticaOne
{
    partial class FrmMenu
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
            this.btnAreas = new System.Windows.Forms.Button();
            this.btnInventario = new System.Windows.Forms.Button();
            this.lblAreas = new System.Windows.Forms.Label();
            this.lblInventario = new System.Windows.Forms.Label();
            this.lblSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAreas
            // 
            this.btnAreas.Image = global::BD_PracticaOne.Properties.Resources.area;
            this.btnAreas.Location = new System.Drawing.Point(64, 48);
            this.btnAreas.Name = "btnAreas";
            this.btnAreas.Size = new System.Drawing.Size(130, 68);
            this.btnAreas.TabIndex = 3;
            this.btnAreas.UseVisualStyleBackColor = true;
            this.btnAreas.Click += new System.EventHandler(this.btnAreas_Click);
            // 
            // btnInventario
            // 
            this.btnInventario.Image = global::BD_PracticaOne.Properties.Resources.inventario;
            this.btnInventario.Location = new System.Drawing.Point(214, 48);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(130, 68);
            this.btnInventario.TabIndex = 4;
            this.btnInventario.UseVisualStyleBackColor = true;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // lblAreas
            // 
            this.lblAreas.AutoSize = true;
            this.lblAreas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAreas.Location = new System.Drawing.Point(104, 28);
            this.lblAreas.Name = "lblAreas";
            this.lblAreas.Size = new System.Drawing.Size(51, 20);
            this.lblAreas.TabIndex = 5;
            this.lblAreas.Text = "Areas";
            // 
            // lblInventario
            // 
            this.lblInventario.AutoSize = true;
            this.lblInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInventario.Location = new System.Drawing.Point(240, 28);
            this.lblInventario.Name = "lblInventario";
            this.lblInventario.Size = new System.Drawing.Size(79, 20);
            this.lblInventario.TabIndex = 6;
            this.lblInventario.Text = "Inventario";
            // 
            // lblSalir
            // 
            this.lblSalir.Location = new System.Drawing.Point(165, 149);
            this.lblSalir.Name = "lblSalir";
            this.lblSalir.Size = new System.Drawing.Size(91, 40);
            this.lblSalir.TabIndex = 7;
            this.lblSalir.Text = "Salir";
            this.lblSalir.UseVisualStyleBackColor = true;
            this.lblSalir.Click += new System.EventHandler(this.lblSalir_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 211);
            this.Controls.Add(this.lblSalir);
            this.Controls.Add(this.lblInventario);
            this.Controls.Add(this.lblAreas);
            this.Controls.Add(this.btnInventario);
            this.Controls.Add(this.btnAreas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMenu";
            this.Text = "FrmMenu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMenu_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAreas;
        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Label lblAreas;
        private System.Windows.Forms.Label lblInventario;
        private System.Windows.Forms.Button lblSalir;
    }
}