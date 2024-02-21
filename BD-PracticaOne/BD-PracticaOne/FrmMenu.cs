using System;
using System.Linq;
using System.Windows.Forms;
namespace BD_PracticaOne
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // Instancia estática de FrmMenu
        private static FrmMenu instancia;
        // Método estático para obtener la instancia (o crearla si no existe)
        public static FrmMenu ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed || instancia.Visible == false)
            {
                instancia = new FrmMenu();
            }
            return instancia;
        }

        private void btnAreas_Click(object sender, EventArgs e)
        {
            this.Hide();

            FrmAreas areas = new FrmAreas(this);
            
            areas.Show();
        }
        private void btnInventario_Click(object sender, EventArgs e)
        {
            //FrmInventario inventario = FrmInventario.ObtenerInstancia();
            FrmInventario inventario = new FrmInventario(this);
            inventario.Show();
            this.Hide();
        }
        private void lblSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void FrmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
