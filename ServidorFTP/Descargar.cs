using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServidorFTP
{
    public partial class Descargar : Form
    {
        public Descargar()
        {
            InitializeComponent();
        }
        Form1 form1 = new Form1();
        
        private void btnDescargar_Click(object sender, EventArgs e)
        {
            string nombreArchivoSeleccionado = listBoxDocumentos.SelectedItem as string;

            if (nombreArchivoSeleccionado != null)
            {
                string rutaLocalDescarga = Path.Combine(Environment.GetFolderPath(Environment.
                    SpecialFolder.Desktop), nombreArchivoSeleccionado);

                
                form1.DescargarArchivoDesdeFtp(nombreArchivoSeleccionado, rutaLocalDescarga);
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un archivo para descargar.", "Advertencia", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void MostrarDocumentos(List<string> documentosEnServidor)
        {
            listBoxDocumentos.Items.Clear();

            foreach (string documento in documentosEnServidor)
            {
                listBoxDocumentos.Items.Add(documento);
            }
        }
    }
}
