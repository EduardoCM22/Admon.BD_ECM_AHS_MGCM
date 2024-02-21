using Datos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace BD_PracticaOne
{
    public partial class FrmInventario : Form
    {
        ProductoDAO productoDAO = new ProductoDAO();
        public static List<Producto> ListaInventario = new List<Producto>();
        // Instancia estática de FrmMenu
        private static FrmInventario instancia;
        private static FrmMenu menu;

        // Método estático para obtener la instancia (o crearla si no existe)
        public static FrmInventario ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed || instancia.Visible == false)
            {
                instancia = new FrmInventario();
            }
            return instancia;
        }
        public FrmInventario()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            ListaInventario = productoDAO.ObtenerProductosInventario();
            dgvInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        public FrmInventario(FrmMenu menuP) : this() {
            menu = menuP;
        }
        private void FrmInventario_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            // Asigna la lista al DataSource del DataGridView
            for (int i = 0; i < ListaInventario.Count; i++)
            {
                dgvInventario.Rows.Add();
                dgvInventario.Rows[i].Cells["columnaId"].Value = ListaInventario[i].ProductoID;
                dgvInventario.Rows[i].Cells["columnaNombre"].Value = ListaInventario[i].ProductoNombre;
                dgvInventario.Rows[i].Cells["columnaDescripcion"].Value = ListaInventario[i].ProductoDescripcion;
                dgvInventario.Rows[i].Cells["columnaSerie"].Value = ListaInventario[i].ProductoSerie;
                dgvInventario.Rows[i].Cells["columnaColor"].Value = ListaInventario[i].ProductoColor;
                dgvInventario.Rows[i].Cells["columnaFechaAd"].Value = ListaInventario[i].ProductoFechaAd;
                dgvInventario.Rows[i].Cells["columnaTipoAd"].Value = ListaInventario[i].ProductoTipoAd;
                dgvInventario.Rows[i].Cells["columnaObservaciones"].Value = ListaInventario[i].ProductoObservaciones;
                dgvInventario.Rows[i].Cells["columnaArea"].Value = ListaInventario[i].ProductoArea;
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmAgregarEditarInventario agregarEditarInventario = new FrmAgregarEditarInventario(this);
            agregarEditarInventario.Show();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvInventario.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvInventario.SelectedRows[0];
                if (!selectedRow.IsNewRow)
                {
                    // Obtener valores de las celdas
                    int productoID = Convert.ToInt32(selectedRow.Cells["columnaId"].Value);
                    string nombreCorto = selectedRow.Cells["columnaNombre"].Value.ToString();
                    string descripcion = selectedRow.Cells["columnaDescripcion"].Value.ToString();
                    string serie = selectedRow.Cells["columnaSerie"].Value.ToString();
                    string color = selectedRow.Cells["columnaColor"].Value.ToString();
                    DateTime fechaAdquisicion = Convert.ToDateTime(selectedRow.Cells["columnaFechaAd"].Value);
                    string tipoAdquisicion = selectedRow.Cells["columnaTipoAd"].Value.ToString();
                    string observaciones = selectedRow.Cells["columnaObservaciones"].Value.ToString();
                    int areaId = Convert.ToInt32(selectedRow.Cells["columnaArea"].Value);
                    FrmAgregarEditarInventario agregarEditarProducto = new FrmAgregarEditarInventario(productoID, nombreCorto, descripcion, serie, color, fechaAdquisicion, tipoAdquisicion, observaciones, areaId, this);
                    agregarEditarProducto.Show();
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
        public void ActualizarListaInventario()
        {
            // Limpiar el DataGridView
            dgvInventario.Rows.Clear();
            // Volver a cargar la lista y asignarla al DataSource del DataGridView
            ListaInventario = productoDAO.ObtenerProductosInventario();
            for (int i = 0; i < ListaInventario.Count; i++)
            {
                dgvInventario.Rows.Add();
                dgvInventario.Rows[i].Cells["columnaId"].Value = ListaInventario[i].ProductoID;
                dgvInventario.Rows[i].Cells["columnaNombre"].Value = ListaInventario[i].ProductoNombre;
                dgvInventario.Rows[i].Cells["columnaDescripcion"].Value = ListaInventario[i].ProductoDescripcion;
                dgvInventario.Rows[i].Cells["columnaSerie"].Value = ListaInventario[i].ProductoSerie;
                dgvInventario.Rows[i].Cells["columnaColor"].Value = ListaInventario[i].ProductoColor;
                dgvInventario.Rows[i].Cells["columnaFechaAd"].Value = ListaInventario[i].ProductoFechaAd;
                dgvInventario.Rows[i].Cells["columnaTipoAd"].Value = ListaInventario[i].ProductoTipoAd;
                dgvInventario.Rows[i].Cells["columnaObservaciones"].Value = ListaInventario[i].ProductoObservaciones;
                dgvInventario.Rows[i].Cells["columnaArea"].Value = ListaInventario[i].ProductoArea;
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvInventario.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvInventario.SelectedRows[0];
                if (!selectedRow.IsNewRow)
                {
                    int productoID = Convert.ToInt32(selectedRow.Cells["columnaId"].Value);
                    try
                    {
                        productoDAO.EliminarProducto(productoID);
                        MessageBox.Show("Eliminación completa", "Listo");
                        dgvInventario.Rows.RemoveAt(selectedRow.Index);
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
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            //FrmMenu menu = FrmMenu.ObtenerInstancia();

            menu.Visible = true;
            this.Dispose();
            // this.Close();  // Cierra el formulario actual
        }
        private void FrmInventario_FormClosing(object sender, FormClosingEventArgs e)
        {
            //FrmMenu menu = FrmMenu.ObtenerInstancia();
            menu.Visible = true;
            this.Dispose(); // Puedes eliminar esta línea si no es necesario
            //this.Close();
        }
    }
}
