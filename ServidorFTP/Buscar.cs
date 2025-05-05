using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace ServidorFTP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string urlFtp = $"ftp://ftpupload.net/if0_35765986";
        string usuario = "if0_35765986";
        string contraseña = "nY2A2u2so2xXy";

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private string carpetaSeleccionada;
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Seleccionar carpeta";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    // Obtiene la ruta de la carpeta seleccionada
                    carpetaSeleccionada = folderDialog.SelectedPath;
                    txtRuta.Text = carpetaSeleccionada;
                }
            }
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(carpetaSeleccionada))
            {

                SubirCarpetaAlFtp(carpetaSeleccionada, urlFtp, usuario, contraseña);

                MessageBox.Show("Carpeta subida con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una carpeta antes de intentar subirla.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        static void SubirCarpetaAlFtp(string carpetaLocal, string urlFtp, string usuario, string contraseña)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(urlFtp);
            request.Method = WebRequestMethods.Ftp.MakeDirectory;
            request.Credentials = new NetworkCredential(usuario, contraseña);

            try
            {
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    Console.WriteLine($"Carpeta remota creada: {urlFtp}");
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine($"La carpeta remota ya existe: {urlFtp}");
            }

            string[] archivos = Directory.GetFiles(carpetaLocal);

            foreach (string archivoLocal in archivos)
            {
                string nombreArchivo = Path.GetFileName(archivoLocal);

                string urlArchivoRemoto = $"{urlFtp}/{nombreArchivo}";

                SubirArchivoAlFtp(archivoLocal, urlArchivoRemoto, usuario, contraseña);
            }
        }
        static void SubirArchivoAlFtp(string archivoLocal, string urlArchivoRemoto, string usuario, string contraseña)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(urlArchivoRemoto);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(usuario, contraseña);

            byte[] contenidoArchivo = File.ReadAllBytes(archivoLocal);

            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(contenidoArchivo, 0, contenidoArchivo.Length);
            }

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                Console.WriteLine($"Archivo subido con éxito: {urlArchivoRemoto}");
            }
        }
        public List<string> ObtenerDocumentosEnServidorFTP()
        {
            List<string> documentos = new List<string>();

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(urlFtp);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(usuario, contraseña);

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    while (!reader.EndOfStream)
                    {
                        string nombreDocumento = reader.ReadLine();
                        documentos.Add(nombreDocumento);
                    }
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show($"Error al obtener la lista de documentos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return documentos;
        }

        private void btnVisualizarDocumentos_Click(object sender, EventArgs e)
        {
            List<string> documentosEnServidor = ObtenerDocumentosEnServidorFTP();

            Descargar descargar = new Descargar();
            descargar.MostrarDocumentos(documentosEnServidor);
            descargar.Visible = true;
        }
        public void DescargarArchivoDesdeFtp(string nombreArchivo, string rutaLocal)
        {
            string urlArchivoRemoto = $"{urlFtp}/{nombreArchivo}";

            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(usuario, contraseña);
                    client.DownloadFile(urlArchivoRemoto, rutaLocal);
                    MessageBox.Show($"Archivo descargado con éxito: {rutaLocal}", "Éxito", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show($"Error al descargar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

    }
}
