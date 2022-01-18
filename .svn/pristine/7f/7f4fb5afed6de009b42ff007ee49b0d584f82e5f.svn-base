using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using System.Net;
using cipal.licenciaparams;
namespace cipal.actualizaciones
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                LICManager.VerifyINIPath();

                string sistema = LICManager.GetSetting(LICManager.eSettings.CV1.ToString()).Replace("-", "");
                string cliente = LICManager.GetSetting(LICManager.eSettings.CV2.ToString()).Replace("-", "");
               
                if (string.IsNullOrEmpty(sistema) && string.IsNullOrEmpty(cliente))
                {
                    SplashScreenManager.ShowForm(typeof(frmSplashScreen));
                    string message = CheckVersion.VerificaryActualizar();
                    SplashScreenManager.CloseForm();

                    if (!string.IsNullOrEmpty(message))
                    {
                        MessageBox.Show(message, "Excepción del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    MessageBox.Show("Versión actualizada", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                    MessageBox.Show("No se ha cargado una licencia válida", "Excepción del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Excepción del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
