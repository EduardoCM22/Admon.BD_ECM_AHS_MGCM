using Datos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace BD_PracticaOne
{
    public partial class FrmAreas : Form
    {
        // Instancia estática de AgregarEditar
        private static FrmAreas instancia;
        private static FrmMenu menu;
        // Método estático para obtener la instancia (o crearla si no existe)
        public static FrmAreas ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed || instancia.Visible == false)
            {
                instancia = new FrmAreas();
            }
            return instancia;
        }
        public static List<Area> ListaAreas = new List<Area>();
        AreaDAO areaDAO = new AreaDAO();
        public FrmAreas()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            ListaAreas.Clear();
            ListaAreas = areaDAO.ObtenerAreas();
            dgvAreas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }        
        public FrmAreas(FrmMenu menuP): this()
        {
            menu = menuP;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmAgregarEditarArea agregarEditarAreas = new FrmAgregarEditarArea(this);
            agregarEditarAreas.Show();
        }
        private void FrmAreas_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            // Asigna la lista al DataSource del DataGridView
            for (int i = 0; i < ListaAreas.Count; i++)
            {
                dgvAreas.Rows.Add();
                dgvAreas.Rows[i].Cells["columnaId"].Value = ListaAreas[i].AreaID;
                dgvAreas.Rows[i].Cells["columnaNombre"].Value = ListaAreas[i].Nombre;
                dgvAreas.Rows[i].Cells["ColumnaUbicacion"].Value = ListaAreas[i].Ubicacion;
            }
        }
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            //FrmMenu menu = FrmMenu.ObtenerInstancia();
            // Muestra el formulario FrmMenu
            menu.Show();
            this.Dispose();
        }
        int id = 0;
        string nombre = null;
        string ubicacion = null;
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvAreas.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvAreas.SelectedRows[0];
                if (!selectedRow.IsNewRow)
                {
                    // Obtener valores de las celdas
                    id = Convert.ToInt32(selectedRow.Cells["columnaId"].Value);
                    nombre = selectedRow.Cells["columnaNombre"].Value.ToString();
                    ubicacion = selectedRow.Cells["columnaUbicacion"].Value.ToString();
                    this.Hide();
                    FrmAgregarEditarArea agregarEditarAreas = new FrmAgregarEditarArea(id, nombre, ubicacion, this);
                    agregarEditarAreas.ShowDialog();
                    agregarEditarAreas.FormClosed += (s, args) => this.Show();
                }
                else
                {
                    MessageBox.Show("No se puede obtener datos de una fila nueva sin confirmar.", "Advertencia");
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para obtener datos.", "Advertencia");
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvAreas.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvAreas.SelectedRows[0];
                if (!selectedRow.IsNewRow)
                {
                    int codigoArea = Convert.ToInt32(selectedRow.Cells["columnaId"].Value);
                    try
                    {
                        areaDAO.EliminarArea(codigoArea);
                        MessageBox.Show("Eliminación completa", "Listo");
                        dgvAreas.Rows.RemoveAt(selectedRow.Index);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }
                }
                else
                {
                    MessageBox.Show("No se puede eliminar una fila nueva sin confirmar.", "Advertencia");
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para eliminar.", "Advertencia");
            }
        }
        private void FrmAreas_FormClosing(object sender, FormClosingEventArgs e)
        {
            //FrmMenu menu = FrmMenu.ObtenerInstancia();
            // Muestra el formulario FrmMenu
            menu.Show();
            this.Dispose();
        }
    }
}
