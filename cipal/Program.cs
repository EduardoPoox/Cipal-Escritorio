using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using cipal.genericas;
using cipal.componentes;
using System.Net;
using System.Net.Sockets;
using DevExpress.XtraSplashScreen;
using cipal.licenciaparams;

namespace cipal
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                SplashScreenManager.ShowForm(typeof(frmSplashScreen));

                //VALIDA LA LICENCIA
                LICManager.VerifyINIPath();
                string message = CheckVersion.Verificar();
                if (!string.IsNullOrEmpty(message))
                {
                    throw new System.Exception(message);
                }

                // Load the style library
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                string styleLibraryPath = new List<string>(assembly.GetManifestResourceNames()).Find(i => i.EndsWith(".isl"));
                if (string.IsNullOrEmpty(styleLibraryPath) == false)
                {
                    using (System.IO.Stream stream = assembly.GetManifestResourceStream(styleLibraryPath))
                    {
                        if (stream != null)
                            Infragistics.Win.AppStyling.StyleManager.Load(stream);
                    }
                }
                
                 
                //PARAMETROS GENERALES DE TODA INSTALACION
                string _eapp = enums.eapp.cipal.ToString();
                string _eversion = enums.eversion.completa.ToString();
                string _numversion = Application.ProductVersion.ToString();
                string _fechaliberacion = Convert.ToDateTime("01/01/2021").ToString("s");
                //FIN DE PARAMETROS GENERALES DE TODA INSTALACION


                //Verificación de Archivo Ini de Instalación
                string pathconfigini = Application.StartupPath + @"\config.ini";
                if (System.IO.File.Exists(pathconfigini))
                {
                    string[] contenido = System.IO.File.ReadAllLines(pathconfigini);
                    string cnn = contenido[contenido.Length - 1].ToString();

                    string serie = contenido[0].ToString();
                    string token = contenido[contenido.Length - 2].ToString();
                    string data = contenido[contenido.Length - 3].ToString();

                    if (validarlicencia(token, serie, data))
                    {
                        //ofrmsplash = new frmSpashScreenoLD();
                        //ofrmsplash.ShowDialog();

                        //Application.Run(new frmMDI(token, cnn));
                        Application.Run(new frmCIPAL(token, cnn));
                    }

                }
                else
                {
                    //ofrmsplash = new frmSpashScreenoLD();
                    //ofrmsplash.ShowDialog();

                    frmConfig ofrmConfig = new frmConfig(_eapp, _eversion, _numversion, _fechaliberacion, pathconfigini);
                    ofrmConfig.ShowDialog();

                    if (ofrmConfig.update)
                    {
                        Application.Restart();
                    }
                }

            }
            catch (System.Exception ex)
            {
                try { SplashScreenManager.CloseForm(); } catch { }
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static IPAddress LocalIPAddress()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return null;
            }

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            return host
                .AddressList
                .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
        }




        public static bool validarlicencia(string token, string serie, string data)
        {
            try
            {

                string internalIP = LocalIPAddress().ToString();
                string externalip = "";
                try
                {
                    externalip = new WebClient().DownloadString("http://localhost:81/apikey/getguid.php");
                }
                catch
                {
                    externalip = "";
                }

                if (externalip == "")
                {
                    //Realizar validación local

                }
                else
                {
                    //Realizar validación online

                }


                bool valido = false;
                if (token != "")
                {
                    valido = true;

                }
                else
                {
                    valido = false;
                }


                return valido;
            }
            catch
            {
                return false;
            }
        }



    }
}
