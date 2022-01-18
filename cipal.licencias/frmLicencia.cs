using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Xml;
using AurMax.Security.Encryption;
using System.Security.Cryptography;
using cipal.licenciaparams;
namespace cipal.licencias
{
    public partial class frmLicencia : DevExpress.XtraEditors.XtraForm
    {
        public bool ok = false;
        public string CLIENTE = "";
        public string SISTEMA = "";
        public frmLicencia()
        {
            InitializeComponent();
        }

        private void frmLicencia_Load(object sender, EventArgs e)
        {

        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            try
            {
                ofdOpenFile.Title = "Seleccionar Archivo de Activación";
                ofdOpenFile.Filter = "XML|*.xml";
                ofdOpenFile.Multiselect = false;
                ofdOpenFile.FileName = string.Empty;
                ofdOpenFile.ShowDialog();
                if (!string.IsNullOrEmpty(ofdOpenFile.FileName))
                {
                    String Code = string.Empty;
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(ofdOpenFile.FileName);
                    foreach (XmlNode childNode in xmlDocument.ChildNodes)
                    {
                        if (childNode.Name == "ConfigLicence")
                        {
                            Code = childNode.Attributes["Code"].Value.ToString();
                            Code = utGeneral.Decrypt(Code.Trim());
                        }
                    }
                    try
                    {
                        string[] array = Code.Split('|');
                        if (array.Length > 0)
                        {
                            CLIENTE = array[0];
                            SISTEMA = array[1];
                            lbLicencia.Text = "LICENCIA: " + CLIENTE + " SISTEMA:" + SISTEMA;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("El archivo no corresponde a la máquina en que intenta cargarse.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(CLIENTE) && !string.IsNullOrEmpty(SISTEMA))
                {

                    LICManager.WriteSetting(LICManager.eSettings.CV1.ToString(), SISTEMA);
                    LICManager.WriteSetting(LICManager.eSettings.CV2.ToString(), CLIENTE);
                    ok = true;
                    this.Close();
                }
                else
                    MessageBox.Show("Datos inclompletos, verifique", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }
}