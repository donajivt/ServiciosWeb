using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using puntosVenta.ServiceReference1;

namespace puntosVenta
{
    public partial class Form1 : Form

    {

        private ServiceReferenceOperaciones.WebServiceOperacionesSoapClient operacionWeb = null;
        private Dictionary<string, decimal> impuestosProductos = new Dictionary<string, decimal>();
        private Dictionary<string, string> descripcionesCategorias = new Dictionary<string, string>();
        private List<string> productosAlcohol = new List<string> { "Tequila", "Whiskey", "Cerveza", "Coñac" };
        WebServiceOperacionesSoapClient operacion = new WebServiceOperacionesSoapClient();

        public Form1()
        {
            InitializeComponent();
            operacionWeb = new ServiceReferenceOperaciones.WebServiceOperacionesSoapClient();
            this.KeyUp += Form1_KeyUp;
            InitializeMedidaComboBox();

            //Aqui añadimos las categorias
            cmbCategorias.Items.Add("Alcohol");
            cmbCategorias.Items.Add("Medicamentos");
            cmbCategorias.Items.Add("Comestibles");
            cmbCategorias.Items.Add("Electrónicos"); // Nueva categoría
            cmbCategorias.Items.Add("Ropa"); // Nueva categoría

            cmbDescPromocion.Items.Add("0%");
            cmbDescPromocion.Items.Add("5%");
            cmbDescPromocion.Items.Add("10%");
            cmbDescPromocion.Items.Add("15%");
            cmbDescPromocion.Items.Add("20%"); // Nueva categoría
            cmbDescPromocion.Items.Add("25%");
            cmbDescPromocion.Items.Add("30%");
            cmbDescPromocion.Items.Add("35%");
            cmbDescPromocion.Items.Add("40%");
            cmbDescPromocion.Items.Add("45%");
            cmbDescPromocion.Items.Add("50%");


            //Aqui van las descripciones de las categorias
            descripcionesCategorias["Alcohol"] = "Productos de tipo Alcohol.";
            descripcionesCategorias["Medicamentos"] = "Medicinas para el cuerpo.";
            descripcionesCategorias["Comestibles"] = "Comida para comer.";
            descripcionesCategorias["Electrónicos"] = "Dispositivos electrónicos.";
            descripcionesCategorias["Ropa"] = "Prendas de vestir.";
            cmbCategorias.SelectedIndexChanged += (sender, e) =>
            {
                string selectedCategoria = cmbCategorias.SelectedItem as string;

                if (selectedCategoria == "Comestibles")
                {
                    // Configura el autocompletado con una lista de productos de comestibles
                    AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
                    autoCompleteCollection.AddRange(new string[] { "Arroz", "Frijoles", "Manzana", "Pasta" });

                    txtNombre.AutoCompleteCustomSource = autoCompleteCollection;
                    txtNombre.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtNombre.AutoCompleteSource = AutoCompleteSource.CustomSource;

                    // Habilita la edición del campo de texto txtNombre
                    txtNombre.Enabled = true;
                    txtDescripcionProducto.Enabled = true;
                    txtCompra.Enabled = true;
                    txtStock.Enabled = true;
                    txtMedida.Enabled = true;
                    cmbDescPromocion.Enabled = true;
                }
                else if (selectedCategoria == "Alcohol")
                {
                    // Configura el autocompletado con una lista de productos de alcohol
                    AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
                    autoCompleteCollection.AddRange(new string[] { "Tequila", "Whiskey", "Cerveza", "Coñac" });

                    txtNombre.AutoCompleteCustomSource = autoCompleteCollection;
                    txtNombre.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtNombre.AutoCompleteSource = AutoCompleteSource.CustomSource;

                    // Habilita la edición del campo de texto txtNombre
                    txtNombre.Enabled = true;
                    txtDescripcionProducto.Enabled = true;
                    txtCompra.Enabled = true;
                    txtStock.Enabled = true;
                    txtMedida.Enabled = true;
                    cmbDescPromocion.Enabled = true;
                }
                else if (selectedCategoria == "Medicamentos")
                {
                    // Configura el autocompletado con una lista de productos de medicamentos
                    AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
                    autoCompleteCollection.AddRange(new string[] { "Aspirina", "Ibuprofeno", "Paracetamol", "Antihistamínico" });

                    txtNombre.AutoCompleteCustomSource = autoCompleteCollection;
                    txtNombre.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtNombre.AutoCompleteSource = AutoCompleteSource.CustomSource;

                    // Habilita la edición del campo de texto txtNombre
                    txtNombre.Enabled = true;
                    txtDescripcionProducto.Enabled = true;
                    txtCompra.Enabled = true;
                    txtStock.Enabled = true;
                    txtMedida.Enabled = true;
                    cmbDescPromocion.Enabled = true;
                }
                else if (selectedCategoria == "Electrónicos")
                {
                    // Configura el autocompletado con una lista de productos de electrónicos
                    AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
                    autoCompleteCollection.AddRange(new string[] { "Teléfono", "Laptop", "Tableta", "Televisor" });

                    txtNombre.AutoCompleteCustomSource = autoCompleteCollection;
                    txtNombre.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtNombre.AutoCompleteSource = AutoCompleteSource.CustomSource;

                    // Habilita la edición del campo de texto txtNombre
                    txtNombre.Enabled = true;
                    txtDescripcionProducto.Enabled = true;
                    txtCompra.Enabled = true;
                    txtStock.Enabled = true;
                    txtMedida.Enabled = true;
                    cmbDescPromocion.Enabled = true;
                }
                else if (selectedCategoria == "Ropa")
                {
                    // Configura el autocompletado con una lista de productos de ropa
                    AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
                    autoCompleteCollection.AddRange(new string[] { "Camiseta", "Pantalón", "Vestido", "Chaqueta" });

                    txtNombre.AutoCompleteCustomSource = autoCompleteCollection;
                    txtNombre.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtNombre.AutoCompleteSource = AutoCompleteSource.CustomSource;

                    // Habilita la edición del campo de texto txtNombre
                    txtNombre.Enabled = true;
                    txtDescripcionProducto.Enabled = true;
                    txtCompra.Enabled = true;
                    txtStock.Enabled = true;
                    txtMedida.Enabled = true;
                    cmbDescPromocion.Enabled = true;
                }
                else
                {
                    // Deshabilita el autocompletado y la edición del campo txtNombre para otras categorías
                    txtNombre.AutoCompleteCustomSource = null;
                    txtNombre.AutoCompleteMode = AutoCompleteMode.None;
                    txtNombre.AutoCompleteSource = AutoCompleteSource.None;

                    // Habilita la edición del campo de texto txtNombre
                    txtNombre.Enabled = true;
                    txtDescripcionProducto.Enabled = true;
                    txtCompra.Enabled = true;
                    txtStock.Enabled = true;
                    txtMedida.Enabled = true;
                    cmbDescPromocion.Enabled = true;
                }

                // Restablece el texto en txtNombre cuando cambia la categoría
                txtNombre.Text = string.Empty;
                txtDescripcionProducto.Text = string.Empty;
                txtCompra.Text = string.Empty;
                txtStock.Text = string.Empty;   
                txtMedida.Text = string.Empty;
                txtPrecioVenta.Text = string.Empty;
                txtGranel.Text = string.Empty;
                cmbDescPromocion.Text = string.Empty;
                txtDescMayoreo.Text = string.Empty;
                txtTotal.Text = string.Empty;
                txtISR.Text = string.Empty;
                txtIVA.Text = string.Empty;
                txtIVAex.Text = string.Empty;
            };


            cmbCategorias.SelectedIndexChanged += (sender, e) =>
            {
                string selectdCategoria = cmbCategorias.SelectedItem as string;

                if (selectdCategoria == "Comestibles")
                {
                    // Configura el autocompletado con una lista de productos de medicamentos
                    AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
                    autoCompleteCollection.AddRange(new string[] { "Arroz", "Frijoles", "Manzana", "Pasta" });

                    txtNombre.AutoCompleteCustomSource = autoCompleteCollection;
                    txtNombre.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtNombre.AutoCompleteSource = AutoCompleteSource.CustomSource;

                    // Habilita la edición del campo de texto txtNombre
                    txtNombre.Enabled = true;
                    txtDescripcionProducto.Enabled = true;
                    txtCompra.Enabled = true;
                    txtStock.Enabled = true;
                    txtMedida.Enabled = true;
                }
                else
                {
                    // Deshabilita el autocompletado y la edición del campo txtNombre para otras categorías
                    txtNombre.AutoCompleteCustomSource = null;
                    txtNombre.AutoCompleteMode = AutoCompleteMode.None;
                    txtNombre.AutoCompleteSource = AutoCompleteSource.None;

                    // Habilita la edición del campo de texto txtNombre
                    txtNombre.Enabled = true;
                }
            };
            cmbCategorias.SelectedIndexChanged += (sender, e) =>
            {
                string selectedCategoria = cmbCategorias.SelectedItem as string;

                if (selectedCategoria == "Alcohol")
                {
                    // Configura el autocompletado con una lista de productos de alcohol
                    AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
                    autoCompleteCollection.AddRange(new string[] { "Tequila", "Whiskey", "Cerveza", "Coñac" });

                    txtNombre.AutoCompleteCustomSource = autoCompleteCollection;
                    txtNombre.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtNombre.AutoCompleteSource = AutoCompleteSource.CustomSource;

                    // Habilita la edición del campo de texto txtNombre
                    txtNombre.Enabled = true;
                }
                else if (selectedCategoria == "Medicamentos")
                {
                    // Configura el autocompletado con una lista de productos de medicamentos
                    AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
                    autoCompleteCollection.AddRange(new string[] { "Aspirina", "Ibuprofeno", "Paracetamol", "Antihistamínico" });

                    txtNombre.AutoCompleteCustomSource = autoCompleteCollection;
                    txtNombre.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtNombre.AutoCompleteSource = AutoCompleteSource.CustomSource;

                    // Habilita la edición del campo de texto txtNombre
                    txtNombre.Enabled = true;
                }
                else
                {
                    // Deshabilita el autocompletado y la edición del campo txtNombre para otras categorías
                    txtNombre.AutoCompleteCustomSource = null;
                    txtNombre.AutoCompleteMode = AutoCompleteMode.None;
                    txtNombre.AutoCompleteSource = AutoCompleteSource.None;

                    // Habilita la edición del campo de texto txtNombre
                    txtNombre.Enabled = true;
                }
            };



            cmbCategorias.SelectedIndexChanged += (sender, e) =>
            {
                string selectedCategoria = cmbCategorias.SelectedItem as string;
                if (selectedCategoria != null && descripcionesCategorias.ContainsKey(selectedCategoria))
                {
                    txtDescripcion.Text = descripcionesCategorias[selectedCategoria];
                }
                else
                {
                    txtDescripcion.Text = string.Empty; // Limpiar el campo de descripción si no hay una categoría seleccionada o no se encuentra una descripción.
                }

                // Limpiar el campo txtNombre cuando cambia la categoría
                txtNombre.Text = string.Empty;
            };
           

          
        }

        private void cmbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategoria = cmbCategorias.SelectedItem as string;
            if (selectedCategoria != null && descripcionesCategorias.ContainsKey(selectedCategoria))
            {
                txtDescripcion.Text = descripcionesCategorias[selectedCategoria];
            }
            else
            {
                txtDescripcion.Text = string.Empty; 
            }
            string selectdCategoria = cmbCategorias.SelectedItem as string;

            // Configurar las unidades de medida según la categoría seleccionada
            switch (selectedCategoria)
            {
                case "Alcohol":
                    ConfigureMedidaComboBox(new List<string> { "ml", "litros" });
                    break;
                case "Medicamentos":
                    ConfigureMedidaComboBox(new List<string> { "mg", "gr" });
                    break;
                case "Comestibles":
                    ConfigureMedidaComboBox(new List<string> { "gr", "kg" });
                    break;
                case "Electrónicos":
                    ConfigureMedidaComboBox(new List<string> { "px"});
                    break;
                case "Ropa":
                    ConfigureMedidaComboBox(new List<string> { "L", "S", "M" });
                    break;
                default:
                    // Si no se selecciona ninguna categoría válida, deshabilita las unidades de medida
                    ConfigureMedidaComboBox(new List<string>());
                    break;
            }

            if (selectedCategoria != null && descripcionesCategorias.ContainsKey(selectedCategoria))
            {
                txtDescripcion.Text = descripcionesCategorias[selectedCategoria];
            }
            else
            {
                txtDescripcion.Text = string.Empty;
            }
        }

        private void ConfigureMedidaComboBox(List<string> unidadesDeMedida)
        {
            AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
            autoCompleteCollection.AddRange(unidadesDeMedida.ToArray());

            txtMedida.AutoCompleteCustomSource = autoCompleteCollection;
            txtMedida.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtMedida.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

    



     

        private async void txtNombre_TextChanged(object sender, EventArgs e)
        {
            string selectedProducto = txtNombre.Text.Trim();

            if (!string.IsNullOrEmpty(selectedProducto))
            {
                try
                {
                    // Intenta convertir la cadena a un valor double
                    if (double.TryParse(selectedProducto, out double productoValue))
                    {
                        // Llamar al método precioVenta del servicio web y obtener el valor
                        double precioVentaDouble = await operacionWeb.precioVentaAsync(productoValue);

                        // Convertir el valor double a decimal y luego mostrarlo en txtPrecioVenta
                        decimal precioVenta = (decimal)precioVentaDouble;

                        // Actualizar el campo txtPrecioVenta con el valor obtenido
                        txtPrecioVenta.Text = precioVenta.ToString("N2");
                    }
                    else
                    {
                        // No mostrar ningún mensaje de error y simplemente dejar el campo txtPrecioVenta en blanco
                        txtPrecioVenta.Text = string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    // Manejar cualquier error que pueda ocurrir al llamar al servicio web
                    MessageBox.Show($"Error al obtener el precio de venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPrecioVenta.Text = string.Empty;
                }
            }
            else
            {
                // Si no se ha seleccionado un producto, limpiar el campo
                
            }
        }

        private void txtMedida_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCompra_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecioFinal_TextChanged(object sender, EventArgs e)
        {

        }

        private void Descripcion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecioVenta_TextChanged(object sender, EventArgs e)
        {
            txtPrecioVenta.Enabled = false;
        }

        private void txtIVA_TextChanged(object sender, EventArgs e)
        {
            txtIVA.Enabled = false;
        }

        private void txtDescMayoreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtISR_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtIVAex_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDesPromocion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGranel_TextChanged(object sender, EventArgs e)
        {

        }
        private async void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                txtIVAex.Text = (await operacionWeb.IvaExentoAsync()).ToString();
             
                
            }

        }

        private void cmbDescPromocion_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            }

        private void cmbDescMayoreo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void InitializeMedidaComboBox()
        {
            List<string> unidadesDeMedida = new List<string>
            {
                "kg",
                "g",
                "l",
                "ml",
                "mgr"
            };

            AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
            autoCompleteCollection.AddRange(unidadesDeMedida.ToArray());

            txtMedida.AutoCompleteCustomSource = autoCompleteCollection;
            txtMedida.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtMedida.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEjecutar_Click_1(object sender, EventArgs e)
        {
            // Obtener el precio de compra y el stock ingresados por el usuario
            if (decimal.TryParse(txtCompra.Text, out decimal precioCompra) && int.TryParse(txtStock.Text, out int stock))
            {
                // Realizar el cálculo del precio final (puedes personalizar la fórmula según tus necesidades)
                decimal precioFinal = precioCompra * stock;

                // Mostrar el resultado en el campo txtPrecioFinal
                // txtPrecioFinal.Text = precioFinal.ToString("N2"); // Formatear el precio final según tus necesidades
            }
            else
            {
                // Manejar una entrada inválida si el usuario no ingresó números válidos
                MessageBox.Show("Por favor, ingrese un precio de compra válido y una cantidad de stock válida.");
                // txtPrecioFinal.Text = string.Empty; // Limpiar el campo de precio final
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtCompra_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtStock.Text) && !string.IsNullOrEmpty(txtCompra.Text) && cmbDescPromocion.SelectedIndex != -1 && !string.IsNullOrEmpty(txtDescripcionProducto.Text) && !string.IsNullOrEmpty(txtMedida.Text))
                {
                    if(isNumero2(txtStock.Text) && isNumero(txtCompra.Text))
                    {

                        if (cmbCategorias.Text == "Alcohol")
                        {
                            if (txtNombre.Text == "Cerveza"  || txtNombre.Text == "Whiskey" || txtNombre.Text == "Tequila" || txtNombre.Text == "Coñac")
                            {


                                if (int.Parse(txtStock.Text) > 20)
                                {


                                    if (txtNombre.Text == "Cerveza")
                                    {
                                        txtDescMayoreo.Text = operacion.descuentoMayoreo(int.Parse(txtStock.Text), double.Parse(txtCompra.Text)).ToString();
                                        txtPrecioVenta.Text = operacion.precioCerveza(double.Parse(txtDescMayoreo.Text)).ToString();
                                        txtIVA.Text = operacion.impuestoIVA(double.Parse(txtDescMayoreo.Text)).ToString();
                                        txtISR.Text = operacion.impuestoCerveza(double.Parse(txtDescMayoreo.Text)).ToString();
                                        txtIVAex.Text = operacion.IvaExento().ToString();
                                        if (cmbDescPromocion.Text == "0%")
                                        {
                                            txtGranel.Text = operacion.precioCerveza(double.Parse(txtDescMayoreo.Text)).ToString(); ;
                                        }
                                        if (cmbDescPromocion.Text == "5%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion5(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "6%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion6(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "7%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion7(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "8%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion8(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "9%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion9(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "10%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        txtTotal.Text = (int.Parse(txtStock.Text) * double.Parse(txtGranel.Text)).ToString();
                                    }
                                    if (txtNombre.Text == "Coñac" )
                                    {
                                        txtDescMayoreo.Text = operacion.descuentoMayoreo(int.Parse(txtStock.Text), double.Parse(txtCompra.Text)).ToString();
                                        txtPrecioVenta.Text = operacion.precioCoñaq(double.Parse(txtDescMayoreo.Text)).ToString();
                                        txtIVA.Text = operacion.impuestoIVA(double.Parse(txtDescMayoreo.Text)).ToString();
                                        txtISR.Text = operacion.impuestoCoñaq(double.Parse(txtDescMayoreo.Text)).ToString();
                                        txtIVAex.Text = operacion.IvaExento().ToString();
                                        if (cmbDescPromocion.Text == "0%")
                                        {
                                            txtGranel.Text = operacion.precioCoñaq(double.Parse(txtDescMayoreo.Text)).ToString(); ;
                                        }
                                        if (cmbDescPromocion.Text == "5%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion5(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "6%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion6(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "7%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion7(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "8%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion8(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "9%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion9(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "10%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        txtTotal.Text = (int.Parse(txtStock.Text) * double.Parse(txtGranel.Text)).ToString();
                                    }
                                    if (txtNombre.Text == "Tequila")
                                    {
                                        txtDescMayoreo.Text = operacion.descuentoMayoreo(int.Parse(txtStock.Text), double.Parse(txtCompra.Text)).ToString();
                                        txtPrecioVenta.Text = operacion.precioTequila(double.Parse(txtDescMayoreo.Text)).ToString();
                                        txtIVA.Text = operacion.impuestoIVA(double.Parse(txtDescMayoreo.Text)).ToString();
                                        txtISR.Text = operacion.impuestoTequila(double.Parse(txtDescMayoreo.Text)).ToString();
                                        txtIVAex.Text = operacion.IvaExento().ToString();
                                        if (cmbDescPromocion.Text == "0%")
                                        {
                                            txtGranel.Text = operacion.precioTequila(double.Parse(txtDescMayoreo.Text)).ToString(); ;
                                        }
                                        if (cmbDescPromocion.Text == "5%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion5(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "10%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion6(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "15%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion7(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "20%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion8(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "25%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion9(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "30%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "35%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "40%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "45%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "50%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        txtTotal.Text = (int.Parse(txtStock.Text) * double.Parse(txtGranel.Text)).ToString();
                                    }
                                    if (txtNombre.Text == "Whiskey" )
                                    {
                                        txtDescMayoreo.Text = operacion.descuentoMayoreo(int.Parse(txtStock.Text), double.Parse(txtCompra.Text)).ToString();
                                        txtPrecioVenta.Text = operacion.precioWiskey(double.Parse(txtDescMayoreo.Text)).ToString();
                                        txtIVA.Text = operacion.impuestoIVA(double.Parse(txtDescMayoreo.Text)).ToString();
                                        txtISR.Text = operacion.impuestoWiskey(double.Parse(txtDescMayoreo.Text)).ToString();
                                        txtIVAex.Text = operacion.IvaExento().ToString();
                                        if (cmbDescPromocion.Text == "0%")
                                        {
                                            txtGranel.Text = operacion.precioTequila(double.Parse(txtDescMayoreo.Text)).ToString(); ;
                                        }
                                        if (cmbDescPromocion.Text == "5%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion5(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "10%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion6(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "15%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion7(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "20%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion8(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "25%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion9(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "30%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "35%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "40%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "45%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "50%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        txtTotal.Text = (int.Parse(txtStock.Text) * double.Parse(txtGranel.Text)).ToString();
                                    }

                                }
                                else
                                {
                                    if (txtNombre.Text == "Cerveza")
                                    {
                                        txtDescMayoreo.Text = "0.0";
                                        txtPrecioVenta.Text = operacion.precioCerveza(double.Parse(txtCompra.Text)).ToString();
                                        txtIVA.Text = operacion.impuestoIVA(double.Parse(txtCompra.Text)).ToString();
                                        txtISR.Text = operacion.impuestoCerveza(double.Parse(txtCompra.Text)).ToString();
                                        txtIVAex.Text = operacion.IvaExento().ToString();
                                        if (cmbDescPromocion.Text == "0%")
                                        {
                                            txtGranel.Text = operacion.precioTequila(double.Parse(txtCompra.Text)).ToString(); ;
                                        }
                                        if (cmbDescPromocion.Text == "5%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion5(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "10%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion6(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "15%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion7(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "20%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion8(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "25%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion9(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "30%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "35%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "40%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "45%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "50%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        txtTotal.Text = (int.Parse(txtStock.Text) * double.Parse(txtGranel.Text)).ToString();
                                    }
                                    if (txtNombre.Text == "Coñac")
                                    {
                                        txtDescMayoreo.Text = "0.0";
                                        txtPrecioVenta.Text = operacion.precioCoñaq(double.Parse(txtCompra.Text)).ToString();
                                        txtIVA.Text = operacion.impuestoIVA(double.Parse(txtCompra.Text)).ToString();
                                        txtISR.Text = operacion.impuestoCoñaq(double.Parse(txtCompra.Text)).ToString();
                                        txtIVAex.Text = operacion.IvaExento().ToString();
                                        if (cmbDescPromocion.Text == "0%")
                                        {
                                            txtGranel.Text = operacion.precioTequila(double.Parse(txtCompra.Text)).ToString(); ;
                                        }
                                        if (cmbDescPromocion.Text == "5%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion5(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "10%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion6(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "15%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion7(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "20%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion8(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "25%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion9(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "30%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "35%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "40%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "45%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "50%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        txtTotal.Text = (int.Parse(txtStock.Text) * double.Parse(txtGranel.Text)).ToString();
                                    }
                                    if (txtNombre.Text == "Tequila")
                                    {
                                        txtDescMayoreo.Text = "0.0";
                                        txtPrecioVenta.Text = operacion.precioTequila(double.Parse(txtCompra.Text)).ToString();
                                        txtIVA.Text = operacion.impuestoIVA(double.Parse(txtCompra.Text)).ToString();
                                        txtISR.Text = operacion.impuestoTequila(double.Parse(txtCompra.Text)).ToString();
                                        txtIVAex.Text = operacion.IvaExento().ToString();
                                        if (cmbDescPromocion.Text == "0%")
                                        {
                                            txtGranel.Text = operacion.precioTequila(double.Parse(txtCompra.Text)).ToString(); ;
                                        }
                                        if (cmbDescPromocion.Text == "5%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion5(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "10%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion6(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "15%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion7(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "20%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion8(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "25%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion9(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "30%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "35%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "40%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "45%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "50%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        txtTotal.Text = (int.Parse(txtStock.Text) * double.Parse(txtGranel.Text)).ToString();
                                    }
                                    if (txtNombre.Text == "Whiskey")
                                    {
                                        txtDescMayoreo.Text = "0.0";
                                        txtPrecioVenta.Text = operacion.precioWiskey(double.Parse(txtCompra.Text)).ToString();
                                        txtIVA.Text = operacion.impuestoIVA(double.Parse(txtCompra.Text)).ToString();
                                        txtISR.Text = operacion.impuestoWiskey(double.Parse(txtCompra.Text)).ToString();
                                        txtIVAex.Text = operacion.IvaExento().ToString();
                                        if (cmbDescPromocion.Text == "0%")
                                        {
                                            txtGranel.Text = operacion.precioTequila(double.Parse(txtCompra.Text)).ToString(); ;
                                        }
                                        if (cmbDescPromocion.Text == "5%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion5(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "10%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion6(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "15%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion7(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "20%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion8(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "25%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion9(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "30%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "35%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "40%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "45%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        if (cmbDescPromocion.Text == "50%")
                                        {
                                            txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                        }
                                        txtTotal.Text = (int.Parse(txtStock.Text) * double.Parse(txtGranel.Text)).ToString();
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("El producto ingresado no está en esta categoría \n Los productos disponibles en la categoría Alcohol son: \n Tequila \n Whiskey \n Coñac \n Cerveza");
                            }
                        }
                        
                        if (cmbCategorias.Text == "Medicamentos")
                        {
                            if (txtNombre.Text == "Ibuprofeno" || txtNombre.Text == "Antihistamínico" || txtNombre.Text == "Paracetamol" || txtNombre.Text == "Aspirina")
                            {

                                if (int.Parse(txtStock.Text) > 20)
                                {
                                    txtDescMayoreo.Text = operacion.descuentoMayoreo(int.Parse(txtStock.Text), double.Parse(txtCompra.Text)).ToString();
                                    txtPrecioVenta.Text = operacion.precioMedicamentos(double.Parse(txtDescMayoreo.Text)).ToString();
                                    txtIVA.Text = operacion.IvaExento().ToString();
                                    txtISR.Text = operacion.IvaExento().ToString();
                                    txtIVAex.Text = operacion.IvaExento().ToString();
                                    if (cmbDescPromocion.Text == "0%")
                                    {
                                        txtGranel.Text = operacion.precioMedicamentos(double.Parse(txtDescMayoreo.Text)).ToString(); ;
                                    }
                                    if (cmbDescPromocion.Text == "5%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion5(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "10%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion6(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "15%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion7(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "20%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion8(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "25%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion9(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "30%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "35%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "40%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "45%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "50%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    txtTotal.Text = (int.Parse(txtStock.Text) * double.Parse(txtGranel.Text)).ToString();
                                }
                                else
                                {
                                    txtDescMayoreo.Text = "0.0";
                                    txtPrecioVenta.Text = operacion.precioMedicamentos(double.Parse(txtCompra.Text)).ToString();
                                    txtIVA.Text = operacion.IvaExento().ToString();
                                    txtISR.Text = operacion.IvaExento().ToString();
                                    txtIVAex.Text = operacion.IvaExento().ToString();
                                    if (cmbDescPromocion.Text == "0%")
                                    {
                                        txtGranel.Text = operacion.precioTequila(double.Parse(txtCompra.Text)).ToString(); ;
                                    }
                                    if (cmbDescPromocion.Text == "5%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion5(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "10%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion6(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "15%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion7(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "20%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion8(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "25%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion9(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "30%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "35%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "40%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "45%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "50%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    txtTotal.Text = (int.Parse(txtStock.Text) * double.Parse(txtGranel.Text)).ToString();
                                }
                            }
                            else
                            {
                                //Antihistamínico
                                MessageBox.Show("El producto ingresado no está en esta categoría \n Los productos disponibles en la categoría Medicamentos son: \n Antihistamínico \n Paracetamol \n Ibuprofeno \n Aspirina");
                            }

                        }
                        if (cmbCategorias.Text == "Ropa")
                        {
                            if (txtNombre.Text == "Camiseta"  || txtNombre.Text == "Vestido" || txtNombre.Text == "Pantalón" || txtNombre.Text == "Chaqueta")
                            {


                                if (int.Parse(txtStock.Text) > 20)
                                {
                                    txtDescMayoreo.Text = operacion.descuentoMayoreo(int.Parse(txtStock.Text), double.Parse(txtCompra.Text)).ToString();
                                    txtPrecioVenta.Text = operacion.precioVenta(double.Parse(txtDescMayoreo.Text)).ToString();
                                    txtIVA.Text = operacion.impuestoIVA(double.Parse(txtDescMayoreo.Text)).ToString();
                                    txtISR.Text = operacion.IvaExento().ToString();
                                    txtIVAex.Text = operacion.IvaExento().ToString();
                                    if (cmbDescPromocion.Text == "0%")
                                    {
                                        txtGranel.Text = operacion.precioTequila(double.Parse(txtDescMayoreo.Text)).ToString(); ;
                                    }
                                    if (cmbDescPromocion.Text == "5%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion5(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "10%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion6(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "15%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion7(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "20%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion8(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "25%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion9(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "30%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "35%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "40%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "45%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "50%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    txtTotal.Text = (int.Parse(txtStock.Text) * double.Parse(txtGranel.Text)).ToString();
                                }
                                else
                                {
                                    txtDescMayoreo.Text = "0.0";
                                    txtPrecioVenta.Text = operacion.precioVenta(double.Parse(txtCompra.Text)).ToString();
                                    txtIVA.Text = operacion.impuestoIVA(double.Parse(txtCompra.Text)).ToString();
                                    txtISR.Text = operacion.IvaExento().ToString();
                                    txtIVAex.Text = operacion.IvaExento().ToString();
                                    if (cmbDescPromocion.Text == "0%")
                                    {
                                        txtGranel.Text = operacion.precioTequila(double.Parse(txtCompra.Text)).ToString(); ;
                                    }
                                    if (cmbDescPromocion.Text == "5%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion5(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "10%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion6(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "15%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion7(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "20%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion8(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "25%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion9(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "30%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "35%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "40%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "45%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "50%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    txtTotal.Text = (int.Parse(txtStock.Text) * double.Parse(txtGranel.Text)).ToString();
                                }
                            }
                            else
                            {
                                MessageBox.Show("El producto ingresado no está en esta categoría \n Los productos disponibles en la categoría Ropa son: \n Pantalón \n Vestido \n Camiseta \n Chaqueta");
                            }
                        }
                        if (cmbCategorias.Text == "Comestibles")
                        {
                            if (txtNombre.Text == "Arroz" || txtNombre.Text == "Frijoles" || txtNombre.Text == "Pasta" || txtNombre.Text == "Manzana")
                            {

                                if (int.Parse(txtStock.Text) > 20)
                                {
                                    txtDescMayoreo.Text = operacion.descuentoMayoreo(int.Parse(txtStock.Text), double.Parse(txtCompra.Text)).ToString();
                                    txtPrecioVenta.Text = operacion.precioVenta(double.Parse(txtDescMayoreo.Text)).ToString();
                                    txtIVA.Text = operacion.impuestoIVA(double.Parse(txtDescMayoreo.Text)).ToString();
                                    txtISR.Text = operacion.IvaExento().ToString();
                                    txtIVAex.Text = operacion.IvaExento().ToString();
                                    if (cmbDescPromocion.Text == "0%")
                                    {
                                        txtGranel.Text = operacion.precioTequila(double.Parse(txtDescMayoreo.Text)).ToString(); ;
                                    }
                                    if (cmbDescPromocion.Text == "5%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion5(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "10%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion6(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "15%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion7(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "20%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion8(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "25%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion9(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "30%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "35%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "40%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "45%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "50%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    txtTotal.Text = (int.Parse(txtStock.Text) * double.Parse(txtGranel.Text)).ToString();
                                }
                                else
                                {
                                    txtDescMayoreo.Text = "0.0";
                                    txtPrecioVenta.Text = operacion.precioVenta(double.Parse(txtCompra.Text)).ToString();
                                    txtIVA.Text = operacion.impuestoIVA(double.Parse(txtCompra.Text)).ToString();
                                    txtISR.Text = operacion.IvaExento().ToString();
                                    txtIVAex.Text = operacion.IvaExento().ToString();
                                    if (cmbDescPromocion.Text == "0%")
                                    {
                                        txtGranel.Text = operacion.precioTequila(double.Parse(txtCompra.Text)).ToString(); ;
                                    }
                                    if (cmbDescPromocion.Text == "5%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion5(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "10%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion6(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "15%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion7(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "20%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion8(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "25%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion9(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "30%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "35%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "40%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "45%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "50%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    txtTotal.Text = (int.Parse(txtStock.Text) * double.Parse(txtGranel.Text)).ToString();
                                }
                            }
                            else
                            {
                                MessageBox.Show("El producto ingresado no está en esta categoría \n Los productos disponibles en la categoría Comestibles son: \n Arroz \n Frijoles \n Pasta \n Manzana");
                            }
                        }
                        if (cmbCategorias.Text == "Electrónicos")
                        {
                            if (txtNombre.Text == "Teléfono"  || txtNombre.Text == "Laptop"  || txtNombre.Text == "Televisor"  || txtNombre.Text == "Tablet" )
                            {



                                if (int.Parse(txtStock.Text) > 20)
                                {
                                    txtDescMayoreo.Text = operacion.descuentoMayoreo(int.Parse(txtStock.Text), double.Parse(txtCompra.Text)).ToString();
                                    txtPrecioVenta.Text = operacion.precioVenta(double.Parse(txtDescMayoreo.Text)).ToString();
                                    txtIVA.Text = operacion.impuestoIVA(double.Parse(txtDescMayoreo.Text)).ToString();
                                    txtISR.Text = operacion.IvaExento().ToString();
                                    txtIVAex.Text = operacion.IvaExento().ToString();
                                    
                                    if (cmbDescPromocion.Text == "0%")
                                    {
                                        txtGranel.Text = operacion.precioTequila(double.Parse(txtDescMayoreo.Text)).ToString(); ;
                                    }
                                    if (cmbDescPromocion.Text == "5%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion5(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "10%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion6(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "15%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion7(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "20%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion8(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "25%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion9(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "30%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "35%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "40%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "45%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "50%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    txtTotal.Text = (int.Parse(txtStock.Text) * double.Parse(txtGranel.Text)).ToString();
                                }
                                else
                                {
                                    txtDescMayoreo.Text = "0.0";
                                    txtPrecioVenta.Text = operacion.precioVenta(double.Parse(txtCompra.Text)).ToString();
                                    txtIVA.Text = operacion.impuestoIVA(double.Parse(txtCompra.Text)).ToString();
                                    txtISR.Text = operacion.IvaExento().ToString();
                                    txtIVAex.Text = operacion.IvaExento().ToString();
                                    
                                    if (cmbDescPromocion.Text == "0%")
                                    {
                                        txtGranel.Text = operacion.precioTequila(double.Parse(txtCompra.Text)).ToString(); ;
                                    }
                                    if (cmbDescPromocion.Text == "5%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion5(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "10%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion6(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "15%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion7(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "20%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion8(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "25%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion9(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "30%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "35%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "40%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "45%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    if (cmbDescPromocion.Text == "50%")
                                    {
                                        txtGranel.Text = operacion.descuentoPromocion10(double.Parse(txtPrecioVenta.Text)).ToString();
                                    }
                                    txtTotal.Text = (int.Parse(txtStock.Text) * double.Parse(txtGranel.Text)).ToString();
                                }
                            }
                            else
                            {
                                MessageBox.Show("El producto ingresado no está en esta categoría \n Los productos disponibles en la categoría Electrónicos son: \n Teléfono \n Televisor \n Tablet \n Laptop");
                            }
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Ingresa valores númericos en stock y en el precio de la compra");
                    }
                }
                else
                {
                    MessageBox.Show("Completa todos los datos solicitados");
                }
            }
        }
        private Boolean isNumero(String cadena)
        {
            try
            {
                double.Parse(cadena);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        private Boolean isNumero2(String cadena)
        {
            try
            {
                int.Parse(cadena);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
