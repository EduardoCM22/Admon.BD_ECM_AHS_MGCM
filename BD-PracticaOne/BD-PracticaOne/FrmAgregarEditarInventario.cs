using Datos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace BD_PracticaOne
{
    public partial class FrmAgregarEditarInventario : Form
    {
        // Instancia estática de FrmMenu
        private static FrmAgregarEditarInventario instancia;
        private FrmInventario inventario = new FrmInventario();
        // Método estático para obtener la instancia (o crearla si no existe)
        public static FrmAgregarEditarInventario ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed || instancia.Visible == false)
            {
                instancia = new FrmAgregarEditarInventario();
            }
            return instancia;
        }
        ProductoDAO productoDAO = new ProductoDAO();
        AreaDAO areaDAO = new AreaDAO();
        List<Area> ListaAreas = new List<Area>();


        public FrmAgregarEditarInventario()
        {
            // Cargar áreas desde la base de datos
            ListaAreas = areaDAO.ObtenerAreas();
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            // Agrega las áreas al ComboBox y establece las propiedades de visualización y valor
            cbxArea.DisplayMember = "Nombre"; // Propiedad que se mostrará en el ComboBox
            cbxArea.ValueMember = "Id";       // Propiedad que será el valor seleccionado
            // Agrega los elementos de la lista al ComboBox
            cbxArea.DataSource = ListaAreas;
        }
        public FrmAgregarEditarInventario(int productoID, string nombreCorto, string descripcion, string serie, string color, DateTime fechaAdquisicion, string tipoAdquisicion, string observaciones, int areaId, FrmInventario inventario)
        {
            ListaAreas.Clear();
            // Cargar áreas desde la base de datos
            ListaAreas = areaDAO.ObtenerAreas();
            try
            {
                InitializeComponent();
                this.StartPosition = FormStartPosition.CenterScreen;
                txtId.Text = productoID.ToString();
                txtId.Enabled = false;
                txtNombre.Text = nombreCorto;
                txtDescripcion.Text = descripcion;
                txtSerie.Text = serie;
                txtColor.Text = color;
                dtpFechaAdq.Value = fechaAdquisicion;
                cbxTipoAd.SelectedItem = tipoAdquisicion;
                txtObservaciones.Text = observaciones;
                // Supongamos que tienes una lista llamada ListaAreas con objetos de tipo Area
                // Asigna la lista como origen de datos para el ComboBox
                cbxArea.DataSource = ListaAreas;
                // Especifica la propiedad que se mostrará en el ComboBox
                cbxArea.DisplayMember = "Nombre"; // Cambia "Nombre" por el nombre de la propiedad que deseas mostrar
                // Especifica la propiedad que se utilizará como valor seleccionado en el ComboBox
                cbxArea.ValueMember = "AreaID"; // Cambia "AreaID" por el nombre de la propiedad que deseas usar como valor seleccionado
                Area areaSeleccionada = ListaAreas.FirstOrDefault(area => area.AreaID == areaId);
                // Si se encuentra el área, establece el área como seleccionada en el ComboBox
                if (areaSeleccionada != null)
                {
                    // Encuentra el índice correspondiente en el ComboBox basándose en el área
                    int index = cbxArea.FindStringExact(areaSeleccionada.Nombre);
                    // Si se encuentra, establece el área como seleccionada en el ComboBox
                    if (index != -1)
                    {
                        cbxArea.SelectedIndex = index;
                    }
                    else
                    {
                        MessageBox.Show("Área no encontrada en el ComboBox.", "Advertencia");
                    }
                }
                else
                {
                    MessageBox.Show("Área no encontrada en la lista.", "Advertencia");
                }
                this.inventario = inventario;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en el constructor de FrmAgregarEditarProducto: {ex.Message}", "Error");
            }
        }
        
        public FrmAgregarEditarInventario(FrmInventario frminventario):this()
        {
            inventario = frminventario;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar que el campo de área contenga solo 
            if (!EsNumero(txtId.Text))
            {
                MessageBox.Show("El campo 'ID' debe contener solo numeros.", "Advertencia");
                return;
            }
            if (txtId.Enabled)
            {
                foreach (Producto pro in FrmInventario.ListaInventario)
                {
                    if (pro.ProductoID == Convert.ToInt32(txtId.Text))
                    {
                        MessageBox.Show("Para agregar un nuevo producto el campo 'ID' no puede contener valores " +
                            "existentes en el sistema", "Advertencia");
                        return;
                    }
                }
            }
            // Validar que el campo de nombre contenga solo letras y espacios
            if (!EsLetraConEspaciosYSimbolos(txtNombre.Text))
            {
                MessageBox.Show("El campo 'Nombre Corto' debe contener solo letras, , espacios y símbolos.", "Advertencia");
                return;
            }
            // Validar que la serie contenga solo letras y  sin espacios
            if (!EsAlfanumericoSinEspacios(txtSerie.Text))
            {
                MessageBox.Show("El campo 'Serie' debe contener solo letras y  sin espacios.", "Advertencia");
                return;
            }
            // Validar que el campo de color contenga solo letras
            if (!EsLetraConEspacios(txtColor.Text))
            {
                MessageBox.Show("El campo 'Color' debe contener solo letras y espacios.", "Advertencia");
                return;
            }
            // Validar que haya un elemento seleccionado en el ComboBox de áreas
            if (cbxArea.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un valor válido para el campo 'Área'.", "Advertencia");
                return;
            }
            // Validar que haya un elemento seleccionado en el ComboBox de tipo de adquisición
            if (cbxTipoAd.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un valor válido para el campo 'Tipo de Adquisición'.", "Advertencia");
                return;
            }
            // Verificar si los campos están llenos
            if (!string.IsNullOrEmpty(txtId.Text) &&
                !string.IsNullOrEmpty(txtNombre.Text) &&
                !string.IsNullOrEmpty(txtDescripcion.Text) &&
                !string.IsNullOrEmpty(txtSerie.Text) &&
                !string.IsNullOrEmpty(txtColor.Text) &&
                !string.IsNullOrEmpty(dtpFechaAdq.Text) &&
                cbxArea.SelectedItem != null &&
                cbxTipoAd.SelectedItem != null &&
                !string.IsNullOrEmpty(txtObservaciones.Text))
            {
                // Los campos están llenos y cumplen con las validaciones específicas
                int productoID = Convert.ToInt32(txtId.Text);
                string nombreCorto = txtNombre.Text;
                string descripcion = txtDescripcion.Text;
                string serie = txtSerie.Text;
                string color = txtColor.Text;
                DateTime fechaAdquisicion = Convert.ToDateTime(dtpFechaAdq.Text);
                string tipoAdquisicion = cbxTipoAd.Text;
                string observaciones = txtObservaciones.Text;
                int areasId = ((Area)cbxArea.SelectedItem).AreaID; // Obtén el ID del área seleccionada
                                                                   // Aquí puedes llamar a tu método de agregar o actualizar producto
                productoDAO.ActualizarOInsertarProducto(productoID, nombreCorto, descripcion, serie, color, fechaAdquisicion, tipoAdquisicion, observaciones, areasId);
                MessageBox.Show("Producto agregado/actualizado con éxito");
                FrmInventario inventario = FrmInventario.ObtenerInstancia();
                inventario.ActualizarListaInventario();

                this.Hide();
                this.Close();
            }
            else
            {
                // Mostrar un mensaje o tomar alguna acción si los campos no están llenos
                MessageBox.Show("Por favor, completa todos los campos.", "Advertencia");
            }
        }
        // Función para validar si una cadena contiene solo letras y espacios
        private bool EsLetraConEspacios(string cadena)
        {
            return cadena.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }
        // Función para validar si una cadena contiene solo letras y  sin espacios
        private bool EsAlfanumericoSinEspacios(string cadena)
        {
            return cadena.All(char.IsLetterOrDigit) && !cadena.Any(char.IsWhiteSpace);
        }
        // Función para validar si una cadena contiene solo 
        private bool EsNumero(string cadena)
        {
            return int.TryParse(cadena, out _);
        }
        // Función para validar si una cadena contiene solo letras
        private bool EsLetraConEspaciosYSimbolos(string cadena)
        {
            return cadena.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || char.IsSymbol(c) || char.IsPunctuation(c));
        }

        private bool EsLetra(string cadena)
        {
            return cadena.All(char.IsLetter);
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //FrmInventario inventario = FrmInventario.ObtenerInstancia();
            inventario.Show();
            this.Dispose();
        }
      

        private void FrmAgregarEditarInventario_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            inventario.Dispose();
            FrmInventario frminventario = FrmInventario.ObtenerInstancia();
            frminventario.Show();
        }

        private void txtSerie_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtColor_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbxArea_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmAgregarEditarInventario_Load(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
