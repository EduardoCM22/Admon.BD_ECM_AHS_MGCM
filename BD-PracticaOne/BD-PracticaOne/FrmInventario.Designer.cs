namespace BD_PracticaOne
{
    partial class FrmInventario
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
            this.dgvInventario = new System.Windows.Forms.DataGridView();
            this.ColumnaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaFechaAd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaTipoAd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaObservaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvInventario
            // 
            this.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnaId,
            this.columnaNombre,
            this.columnaDescripcion,
            this.columnaSerie,
            this.columnaColor,
            this.columnaFechaAd,
            this.columnaTipoAd,
            this.columnaObservaciones,
            this.columnaArea});
            this.dgvInventario.Location = new System.Drawing.Point(37, 33);
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.Size = new System.Drawing.Size(950, 392);
            this.dgvInventario.TabIndex = 0;
            // 
            // ColumnaId
            // 
            this.ColumnaId.HeaderText = "Código";
            this.ColumnaId.Name = "ColumnaId";
            // 
            // columnaNombre
            // 
            this.columnaNombre.HeaderText = "Nombre";
            this.columnaNombre.Name = "columnaNombre";
            // 
            // columnaDescripcion
            // 
            this.columnaDescripcion.HeaderText = "Descripción";
            this.columnaDescripcion.Name = "columnaDescripcion";
            // 
            // columnaSerie
            // 
            this.columnaSerie.HeaderText = "Serie";
            this.columnaSerie.Name = "columnaSerie";
            // 
            // columnaColor
            // 
            this.columnaColor.HeaderText = "Color";
            this.columnaColor.Name = "columnaColor";
            // 
            // columnaFechaAd
            // 
            this.columnaFechaAd.HeaderText = "Fecha Ad";
            this.columnaFechaAd.Name = "columnaFechaAd";
            // 
            // columnaTipoAd
            // 
            this.columnaTipoAd.HeaderText = "Tipo adquisición";
            this.columnaTipoAd.Name = "columnaTipoAd";
            // 
            // columnaObservaciones
            // 
            this.columnaObservaciones.HeaderText = "Observaciones";
            this.columnaObservaciones.Name = "columnaObservaciones";
            // 
            // columnaArea
            // 
            this.columnaArea.HeaderText = "Area";
            this.columnaArea.Name = "columnaArea";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(327, 453);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(111, 53);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(464, 453);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(111, 53);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(607, 453);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(111, 53);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(831, 460);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(88, 38);
            this.btnRegresar.TabIndex = 5;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // FrmInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 539);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvInventario);
            this.Name = "FrmInventario";
            this.Text = "Agregar - Editar inventario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmInventario_FormClosing);
            this.Load += new System.EventHandler(this.FrmInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaSerie;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaFechaAd;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaTipoAd;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaObservaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaArea;
        private System.Windows.Forms.Button btnRegresar;
    }
}