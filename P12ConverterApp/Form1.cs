using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ConvertP12App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            // Obtener la ruta del archivo .p12
            string pin = txt_pin.Text.Trim();
            if (!string.IsNullOrEmpty(pin))
            {
                string p12FilePath = txtFilePath.Text.Trim();
                if (!string.IsNullOrEmpty(p12FilePath))
                {
                    string folderPath = Path.GetDirectoryName(p12FilePath);

                    // Verificar si el archivo existe
                    if (!File.Exists(p12FilePath))
                    {
                        txtLog.AppendText(" No se encontró un archivo .p12 en la ruta especificada" + Environment.NewLine);
                    }
                    else
                    {
                        // Obtener el nombre del archivo sin extensión
                        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(p12FilePath);

                        // Paso 1: Extraer el certificado y la clave privada en un archivo .pem
                        string pemFile = Path.Combine(folderPath, "certificado_y_clave.pem");
                        string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
                        string opensslPath = Path.Combine(appDirectory, "openssl","bin", "openssl.exe");
                        txtLog.AppendText(opensslPath);
                        string extractCommand = $"{opensslPath} pkcs12 -in {p12FilePath} -out {pemFile} -nodes -passin pass:{pin}";
                        bool result = ExecuteCommand(extractCommand, 1);
                        if (result == true)
                        {
                            //Paso 2: Crear un nuevo archivo .p12 con algoritmos modernos
                            string newP12File = Path.Combine(folderPath, $"{fileNameWithoutExtension}_new.p12");
                            string createCommand = $"{opensslPath} pkcs12 -export -out {newP12File} " +
                               $"-inkey {pemFile} -in {pemFile} " +
                               $"-certpbe AES-256-CBC -keypbe AES-256-CBC -macalg sha256 -passout pass:{pin}";

                            bool result2 = ExecuteCommand(createCommand, 2);
                            if (result2 == true)
                            {
                                txtLog.AppendText(" Certificado actualizado exitosamente" + Environment.NewLine);
                            }
                            else
                            {
                                txtLog.AppendText(" Paso 2 finalizado con errores" + Environment.NewLine);
                                if (Directory.Exists(folderPath))
                                {
                                    Process.Start("explorer.exe", folderPath);
                                }
                            }
                        }
                        else
                        {
                            txtLog.AppendText(" Paso 1 finalizado con errores" + Environment.NewLine);
                        }
                        // Eliminar el archivo temporal .pem
                        if (File.Exists(pemFile))
                        {
                            File.Delete(pemFile);
                        }
                    }
                }
                else
                {
                    txtLog.AppendText(" Especifica una ruta para continuar." + Environment.NewLine);
                }
            }
            else
            {
                txtLog.AppendText(" Debe digitar un pin para poder continuar" + Environment.NewLine);
            }
        }

        private bool ExecuteCommand(string command, int paso)
        {
            bool result = false;
            if (paso == 1)
            {
                txtLog.Text = "";
                txtLog.AppendText(" Paso 1: Extrayendo información del certificado..." + Environment.NewLine);
            }
            else
            {
                txtLog.AppendText(" Paso 2: Exportando certificado con algoritmos modernos..." + Environment.NewLine);
            }

            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/C {command}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            // Modificar el PATH temporalmente
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string opensslPath = Path.Combine(appDirectory, "openssl", "bin", "openssl.exe");
            string originalPath = Environment.GetEnvironmentVariable("PATH");
            Environment.SetEnvironmentVariable("PATH", $"{opensslPath};{originalPath}");

            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();

            // Restaurar el PATH original
            Environment.SetEnvironmentVariable("PATH", originalPath);

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            if (!string.IsNullOrEmpty(error))
            {
                txtLog.AppendText($" Error (Código {process.ExitCode}): {error}" + Environment.NewLine);
                result = false;
            }
            else
            {
                txtLog.AppendText(" Listo" + Environment.NewLine);
                result = true;
            }
            KillOpenSSLProcesses();
            return result;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos P12 (*.p12)|*.p12";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = openFileDialog.FileName;
                }
            }
        }
        private void KillOpenSSLProcesses()
        {
            // Obtener todos los procesos con el nombre especificado
            Process[] processes = Process.GetProcessesByName("openssl");

            // Cerrar cada proceso de OpenSSL
            foreach (Process process in processes)
            {
                try
                {
                    process.Kill(); // Finalizar el proceso
                    process.WaitForExit(); // Esperar a que el proceso se cierre
                    Console.WriteLine($"Proceso de OpenSSL cerrado: {process.Id}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al cerrar el proceso de OpenSSL: {ex.Message}");
                }
            }
        }
    }
}