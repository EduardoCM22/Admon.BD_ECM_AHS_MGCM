using Datos;
using Modelo;
using System;
using System.Linq;
using System.Windows.Forms;
namespace BD_PracticaOne
{
    public partial class FrmAgregarEditarArea : Form
    {
        // Instancia estática de AgregarEditar
        private static FrmAgregarEditarArea instancia;
        private FrmAreas areas = new FrmAreas();

        // Método estático para obtener la instancia (o crearla si no existe)
        public static FrmAgregarEditarArea ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed || instancia.Visible == false)
            {
                instancia = new FrmAgregarEditarArea();
            }
            return instancia;
        }
        AreaDAO areaDAO = new AreaDAO();
        public FrmAgregarEditarArea()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            
        }
        public FrmAgregarEditarArea(int id, string nombre, string ubicacion, FrmAreas frmAreas)
        {
            try
            {
                InitializeComponent();
                this.StartPosition = FormStartPosition.CenterScreen;
                txtArea.Text =  id.ToString();
                txtArea.Enabled = false;
                txtNombre.Text = nombre;
                txtUbicacion.Text = ubicacion;
                this.areas = frmAreas;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en el constructor de FrmAgregarEditarArea: {ex.Message}", "Error");
            }
        }
        public FrmAgregarEditarArea(FrmAreas frmareas):this() 
        {
            areas = frmareas;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //FrmAreas areas= FrmAreas.ObtenerInstancia();
            areas.Show();
            this.Dispose();
            //this.Close();
        }
        private void bntAceptar_Click(object sender, EventArgs e)
        {
            if (txtArea.Enabled)
            {
                foreach (Area item in FrmAreas.ListaAreas)
                {
                    if(item.AreaID == Convert.ToInt32(txtArea.Text))
                    {
                        MessageBox.Show("Para agregar una nueva area el campo 'Área' no puede contener valores " +
                        "existentes en el sistema", "Advertencia");
                        return;
                    }
                }
            }
            // Validar que el campo de área contenga solo números
            if (!EsNumero(txtArea.Text))
            {
                MessageBox.Show("El campo 'Área' debe contener solo números.", "Advertencia");
                return;
            }
            // Validar que el campo de nombre contenga solo letras
            if (!EsLetra(txtNombre.Text))
            {
                MessageBox.Show("El campo 'Nombre' debe contener solo letras.", "Advertencia");
                return;
            }
            // Verificar si los campos están llenos
            if (!string.IsNullOrEmpty(txtArea.Text) &&
                !string.IsNullOrEmpty(txtNombre.Text) &&
                !string.IsNullOrEmpty(txtUbicacion.Text))
            {
                // Los campos están llenos y cumplen con las validaciones específicas
                int areaId = Convert.ToInt32(txtArea.Text);
                string nombre = txtNombre.Text;
                string ubicacion = txtUbicacion.Text;
                // Aquí puedes llamar a tu método de agregar o actualizar área
                areaDAO.ActualizarOInsertarArea(areaId, nombre, ubicacion);
                MessageBox.Show("Area agregada/actualizada con exito");
                this.Close();
            }
            else
            {
                // Mostrar un mensaje o tomar alguna acción si los campos no están llenos
                MessageBox.Show("Por favor, completa todos los campos.", "Advertencia");
            }
        }
        // Función para validar si una cadena contiene solo números
        private bool EsNumero(string cadena)
        {
            return int.TryParse(cadena, out _);
        }
        // Función para validar si una cadena contiene solo letras
        private bool EsLetra(string cadena)
        {
            return cadena.All(char.IsLetter);
        }
        private void FrmAgregarEditarArea_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            areas.Dispose();
            FrmAreas frmAreas = FrmAreas.ObtenerInstancia();
            frmAreas.Show();
        }
    }
}
