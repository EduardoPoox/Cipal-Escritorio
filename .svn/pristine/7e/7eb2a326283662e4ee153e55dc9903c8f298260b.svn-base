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

using cipal.entidades;
using cipal.negocios;

using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Channels;
using System.Web;
using System.Xml;
using System.Diagnostics;
using System.IO.Compression;

namespace cipal.descargas
{
    public partial class frmdescargas : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;
        private int _idconfig;


        static byte[] pfx;
        static string password;

        static string urlAutentica = "https://cfdidescargamasivasolicitud.clouda.sat.gob.mx/Autenticacion/Autenticacion.svc";
        static string urlAutenticaAction = "http://DescargaMasivaTerceros.gob.mx/IAutenticacion/Autentica";

        static string urlSolicitud = "https://cfdidescargamasivasolicitud.clouda.sat.gob.mx/SolicitaDescargaService.svc";
        static string urlSolicitudAction = "http://DescargaMasivaTerceros.sat.gob.mx/ISolicitaDescargaService/SolicitaDescarga";

        static string urlVerificarSolicitud = "https://cfdidescargamasivasolicitud.clouda.sat.gob.mx/VerificaSolicitudDescargaService.svc";
        static string urlVerificarSolicitudAction = "http://DescargaMasivaTerceros.sat.gob.mx/IVerificaSolicitudDescargaService/VerificaSolicitudDescarga";

        static string urlDescargarSolicitud = "https://cfdidescargamasiva.clouda.sat.gob.mx/DescargaMasivaService.svc";
        static string urlDescargarSolicitudAction = "http://DescargaMasivaTerceros.sat.gob.mx/IDescargaMasivaTercerosService/Descargar";

        static string RfcEmisor;
        static string RfcReceptor;
        static string RfcSolicitante;
        static string FechaInicial;
        static string FechaFinal;

        empresa oempresa = null;
        parametros oparametros = null;

        string[] ejercicios = { "2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028" };

        public frmdescargas(int id, int idconfig, int idusuario, string connexionstring)
        {
            try
            {
                InitializeComponent();
                this._connexionstring = connexionstring;
                this._idusuario = idusuario;
                this._id = id;
                this._idconfig = idconfig;

                DateTime _fechainicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime _fechafinal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                this.cmbfechainicial.Value = _fechainicial;
                this.cmbfechafinal.Value = _fechafinal;


                oempresa = empresanc.getempresa(this._id, this._connexionstring);
                oparametros = parametronc.getparametro(this._idconfig, this._connexionstring);


                this.cmbejercicios.SetDataBinding(ejercicios, null);
                this.cmbejercicios.Text = DateTime.Now.Year.ToString();

                this.cmbperiodo.SetDataBinding(Enum.GetNames(typeof(genericas.enums.emeses)), null);
                this.cmbperiodo.Text = genericas.enums.emeses.enero.ToString();



            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmdescargas_Load(object sender, EventArgs e)
        {
            try
            {
                this.cargainformacion();
                this.cargasolicitudesdescargas();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cargainformacion()
        {
            try
            {

                string filepfx = oparametros.archivocer.Replace(".cer", ".pfx");
                pfx = File.ReadAllBytes(filepfx);
                password = oparametros.efirmapassword;
                RfcSolicitante = oempresa.rfc;
                this.txtrfcsolicitante.Text = RfcSolicitante;
                this.optipodescargas_ValueChanged(null, null);

                this.txtcertificado.Text = oparametros.archivocer;
                this.txtllaveprivada.Text = oparametros.archivokey;
                this.txtpassword.Text = oparametros.efirmapassword;
                this.txtpfx.Text = filepfx;

                

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }



        private void optipodescargas_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.optipodescargas.CheckedIndex == 0)
                {
                    RfcEmisor = RfcSolicitante;
                    RfcReceptor = "";
                    this.txtrfcemisor.Text = RfcEmisor;
                    this.txtrfcreceptor.Text = "";
                }
                else
                {
                    RfcEmisor = "";
                    RfcReceptor = RfcSolicitante;
                    this.txtrfcreceptor.Text = RfcReceptor;
                    this.txtrfcemisor.Text = "";
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btngenerarsolicitud_Click(object sender, EventArgs e)
        {
            try
            {
                password = this.txtpassword.Text.Trim();
                RfcEmisor = this.txtrfcemisor.Text.Trim().ToUpper();
                RfcReceptor = this.txtrfcreceptor.Text.Trim().ToUpper();
                RfcSolicitante = this.txtrfcsolicitante.Text.Trim().ToUpper();

                DateTime fi = Convert.ToDateTime(this.cmbfechainicial.Value);
                DateTime ff = Convert.ToDateTime(this.cmbfechafinal.Value);
                FechaInicial = fi.Year.ToString("0000") + "-" + fi.Month.ToString("00") + "-" + fi.Day.ToString("00");
                FechaFinal = ff.Year.ToString("0000") + "-" + ff.Month.ToString("00") + "-" + ff.Day.ToString("00");


                //INICIA PROCESO DE PETICIÓN

                //Obtener Certificados
                X509Certificate2 certificate = ObtenerX509Certificado(pfx);

                //Obtener Token
                string token = ObtenerToken(certificate);
                string autorization = String.Format("WRAP access_token=\"{0}\"", HttpUtility.UrlDecode(token));


                //Generar Solicitud
                string idSolicitud = GenerarSolicitud(certificate, autorization);
               
                if (idSolicitud != "")
                {
                    solicitudesdescargas osolicituddescarga = new solicitudesdescargas();
                    osolicituddescarga.idsolicituddescarga = solicituddescarganc.getid(this._connexionstring);
                    osolicituddescarga.fechainicial = Convert.ToDateTime(FechaInicial);
                    osolicituddescarga.fechafinal = Convert.ToDateTime(FechaFinal);
                    osolicituddescarga.rfcemisor = RfcEmisor;
                    osolicituddescarga.rfcreceptor = RfcReceptor;
                    osolicituddescarga.rfcsolicitante = RfcSolicitante;
                    osolicituddescarga.tiposolicitud = this.optipodescargas.CheckedItem.DisplayText.ToString();
                    osolicituddescarga.idsolicitud = idSolicitud;
                    osolicituddescarga.estatus = "Aceptada";
                    osolicituddescarga.mensaje = "Solicitud Aceptada";
                    osolicituddescarga.idpaquetes = "";
                    osolicituddescarga.numerocfdis = "0";
                    osolicituddescarga.usuario = this._idusuario.ToString();
                    osolicituddescarga.baja = false;

                    solicituddescarganc.save(osolicituddescarga, this._connexionstring);

                    MessageBox.Show("¡Solicitud procesada correctamente!", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargasolicitudesdescargas();
                }








                //FINALIZA PROCESO DE PETICIÓN
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargasolicitudesdescargas()
        {
            try
            {
                List<solicitudesdescargas> olist;

                if (this.txtfoliosolicitud.Text.Trim() !="")
                {
                    olist = solicituddescarganc.getsolicitudesdescargasbyidsolicitud(this.txtfoliosolicitud.Text.Trim(),this._connexionstring);
                }
                else
                {
                    olist = solicituddescarganc.getsolicitudesdescargasportiposolicitud(this.optipodescargasconsulta.Value.ToString(),this._connexionstring);
                }




                this.gridsolicitudes.SetDataBinding(olist,null);
                foreach(Infragistics.Win.UltraWinGrid.UltraGridColumn ocolumn in this.gridsolicitudes.DisplayLayout.Bands[0].Columns)
                {
                    ocolumn.Hidden = true;
                }

                this.gridsolicitudes.DisplayLayout.Bands[0].Columns["fechainicial"].Hidden = false;
                this.gridsolicitudes.DisplayLayout.Bands[0].Columns["fechafinal"].Hidden = false;
                this.gridsolicitudes.DisplayLayout.Bands[0].Columns["tiposolicitud"].Hidden = false;
                this.gridsolicitudes.DisplayLayout.Bands[0].Columns["idsolicitud"].Hidden = false;
                this.gridsolicitudes.DisplayLayout.Bands[0].Columns["estatus"].Hidden = false;
                this.gridsolicitudes.DisplayLayout.Bands[0].Columns["mensaje"].Hidden = false;
                this.gridsolicitudes.DisplayLayout.Bands[0].Columns["idpaquetes"].Hidden = false;
                this.gridsolicitudes.DisplayLayout.Bands[0].Columns["numerocfdis"].Hidden = false;

                this.gridsolicitudes.DisplayLayout.Bands[0].Columns["fechainicial"].Header.Caption = "Fecha de Inicio";
                this.gridsolicitudes.DisplayLayout.Bands[0].Columns["fechafinal"].Header.Caption = "Fecha Final";
                this.gridsolicitudes.DisplayLayout.Bands[0].Columns["tiposolicitud"].Header.Caption = "Tipo de Descarga";
                this.gridsolicitudes.DisplayLayout.Bands[0].Columns["idsolicitud"].Header.Caption = "Folio de Solicitud";
                this.gridsolicitudes.DisplayLayout.Bands[0].Columns["estatus"].Header.Caption = "Estado de Solicitud";
                this.gridsolicitudes.DisplayLayout.Bands[0].Columns["mensaje"].Header.Caption = "Mensaje de Solicitud";
                this.gridsolicitudes.DisplayLayout.Bands[0].Columns["idpaquetes"].Header.Caption = "Folio de Descarga";
                this.gridsolicitudes.DisplayLayout.Bands[0].Columns["numerocfdis"].Header.Caption = "CFDIs";


                this.gridsolicitudes.DisplayLayout.Bands[0].Columns["fechainicial"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                this.gridsolicitudes.DisplayLayout.Bands[0].Columns["fechafinal"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                this.gridsolicitudes.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        private void btnconsultar_Click(object sender, EventArgs e)
        {
            try
            {
                cargasolicitudesdescargas();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btngenerarpfx_Click(object sender, EventArgs e)
        {
            try
            {
                //pkcs8 -inform DER -in llave.key -passin pass:a0123456789 -out llave.pem
                Process _prockey = new Process();
                string filekeypem = this.txtllaveprivada.Text.Replace(".key", "_key.pem");
                _prockey.StartInfo.FileName = oparametros.diropenssl;
                _prockey.StartInfo.Arguments = "pkcs8 -inform DER -in \"" + this.txtllaveprivada.Text.Trim() + "\" -passin pass:" + this.txtpassword.Text.Trim() + " -out \"" + filekeypem + "\"";
                _prockey.StartInfo.WorkingDirectory = oparametros.diropenssl;
                _prockey.Start();
                _prockey.WaitForExit();


                //x509 -inform DER -in certificado.cer -out certificado.pem
                Process _proccer = new Process();
                string filecerpem = this.txtcertificado.Text.Trim().Replace(".cer", "_cer.pem");
                _proccer.StartInfo.FileName = oparametros.diropenssl;
                _proccer.StartInfo.Arguments = "x509 -inform DER -in \"" + this.txtcertificado.Text.Trim() + "\" -out \"" + filecerpem + "\"";
                _proccer.StartInfo.WorkingDirectory = oparametros.diropenssl;
                _proccer.Start();
                _proccer.WaitForExit();



                //pkcs12 -export -out archivopfx.pfx -inkey llave.pem -in certificado.pem -passout pass:clavedesalida
                Process _procpfx = new Process();
                string filepfx = this.txtcertificado.Text.Trim().Replace(".cer", ".pfx");
                _procpfx.StartInfo.FileName = oparametros.diropenssl;
                _procpfx.StartInfo.Arguments = "pkcs12 -export -out \"" + filepfx + "\" -inkey \"" + filekeypem + "\" -in \"" + filecerpem + "\" -passout pass:" + this.txtpassword.Text.Trim();
                _procpfx.StartInfo.WorkingDirectory = oparametros.diropenssl;
                _procpfx.Start();
                _procpfx.WaitForExit();


                MessageBox.Show("¡PFX generada correctamente!", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnguardarinformacion_Click(object sender, EventArgs e)
        {
            try
            {
                oparametros.archivocer = this.txtcertificado.Text;
                oparametros.archivokey = this.txtllaveprivada.Text;
                oparametros.efirmapassword = this.txtpassword.Text;
                parametronc.update(this.oparametros, this._connexionstring);
                MessageBox.Show("¡Información guardada correctamente!", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnverificarsolicitudes_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener Certificados
                X509Certificate2 certificate = ObtenerX509Certificado(pfx);

                //Obtener Token
                string token = ObtenerToken(certificate);
                string autorization = String.Format("WRAP access_token=\"{0}\"", HttpUtility.UrlDecode(token));

                foreach(Infragistics.Win.UltraWinGrid.UltraGridRow oRow in this.gridsolicitudes.Rows)
                {
                    int idsolicituddescarga = Convert.ToInt32(oRow.Cells["idsolicituddescarga"].Value);
                    string idSolicitud = oRow.Cells["idsolicitud"].Value.ToString().ToUpper();
                    string idPaquete = ValidarSolicitud(certificate, autorization, idSolicitud);
                    if (idPaquete !="")
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(idPaquete);
                        if (idPaquete.Contains("IdsPaquetes"))
                        {
                            string IdsPaquetes = xmlDoc.GetElementsByTagName("IdsPaquetes")[0].InnerXml;
                            string NumeroCFDIs = xmlDoc.GetElementsByTagName("VerificaSolicitudDescargaResult")[0].Attributes["NumeroCFDIs"].Value.ToString();

                            solicitudesdescargas osolicituddescarga = solicituddescarganc.getsolicituddescarga(idsolicituddescarga, this._connexionstring);
                            osolicituddescarga.estatus = "Completada";
                            osolicituddescarga.mensaje = "Solicitud Completada";
                            osolicituddescarga.idpaquetes = IdsPaquetes;
                            osolicituddescarga.numerocfdis = NumeroCFDIs;
                            solicituddescarganc.update(osolicituddescarga, this._connexionstring);
                        }
                    }
                }

                MessageBox.Show("¡Verificación de solicitudes realizada correctamente!", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cargasolicitudesdescargas();
                
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btndescargarsolicitudes_Click(object sender, EventArgs e)
        {
            try
            {

                //Obtener Certificados
                X509Certificate2 certificate = ObtenerX509Certificado(pfx);

                //Obtener Token
                string token = ObtenerToken(certificate);
                string autorization = String.Format("WRAP access_token=\"{0}\"", HttpUtility.UrlDecode(token));

                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow oRow in this.gridsolicitudes.Rows)
                {
                    string idPaquete = oRow.Cells["idpaquetes"].Value.ToString();
                    string tiposolicitud = oRow.Cells["tiposolicitud"].Value.ToString();
                    if (idPaquete != "")
                    {
                        string descargaResponse = DescargarSolicitud(certificate, autorization, idPaquete);
                        GuardarSolicitud(idPaquete, tiposolicitud, descargaResponse);
                    }

                }

                MessageBox.Show("¡Descarga de solicitudes disponibles realizada correctamente!", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        #region metodos de descargas sat


        private static X509Certificate2 ObtenerX509Certificado(byte[] pfx)
        {
            return new X509Certificate2(pfx, password, X509KeyStorageFlags.MachineKeySet |
                            X509KeyStorageFlags.PersistKeySet |
                            X509KeyStorageFlags.Exportable);
        }

        private static void GuardarSolicitud(string idPaquete, string tiposolicitud, string descargaResponse)
        {

            string path = @"C:/cipal/paquetes/" + tiposolicitud + @"/";
            byte[] file = Convert.FromBase64String(descargaResponse);

            if (file.Length > 0)
            {
                Directory.CreateDirectory(path);
                using (FileStream fs = File.Create(path + idPaquete + ".zip", file.Length))
                {
                    fs.Write(file, 0, file.Length);
                }
            }
        }

        private static string DescargarSolicitud(X509Certificate2 certifcate, string autorization, string idPaquete)
        {
            DescargarSolicitud descargarSolicitud = new DescargarSolicitud(urlDescargarSolicitud, urlDescargarSolicitudAction);
            string xmlDescarga = descargarSolicitud.Generate(certifcate, RfcSolicitante, idPaquete);
            return descargarSolicitud.Send(autorization);
        }

        private static string ValidarSolicitud(X509Certificate2 certificate, string autorization, string idSolicitud)
        {
            VerificaSolicitud verifica = new VerificaSolicitud(urlVerificarSolicitud, urlVerificarSolicitudAction);
            string xmlVerifica = verifica.Generate(certificate, RfcSolicitante, idSolicitud);
            return verifica.Send(autorization);
        }

        private static string GenerarSolicitud(X509Certificate2 certificate, string autorization)
        {
            Solicitud solicitud = new Solicitud(urlSolicitud, urlSolicitudAction);
            string xmlSolicitud = solicitud.Generate(certificate, RfcEmisor, RfcReceptor, RfcSolicitante, FechaInicial, FechaFinal);
            return solicitud.Send(autorization);
        }

        private static string ObtenerToken(X509Certificate2 certificate)
        {
            Autenticacion service = new Autenticacion(urlAutentica, urlAutenticaAction);
            string xml = service.Generate(certificate);
            return service.Send();
        }

        #endregion

        private void btncambiarcertificado_Click(object sender, EventArgs e)
        {
            try
            {
                ofdialog.InitialDirectory = oparametros.dirdefault;
                ofdialog.RestoreDirectory = true;
                ofdialog.Title = "Búsqueda de archivos";
                ofdialog.DefaultExt = ".cer";
                ofdialog.FileName = ".cer";
                ofdialog.Filter = "Archivos de certificado (*.cer)|*.cer";
                ofdialog.FilterIndex = 1;
                ofdialog.CheckFileExists = true;
                ofdialog.CheckPathExists = true;
                ofdialog.ReadOnlyChecked = true;
                ofdialog.ShowReadOnly = true;

                if (ofdialog.ShowDialog() == DialogResult.OK)
                {
                    
                    string file = ofdialog.FileName;
                    string filedestino = this.oparametros.dirrecursoscfdi + @"\" + file.Split('\\')[file.Split('\\').Length - 1];
                    System.IO.File.Copy(file, filedestino, true);
                    this.txtcertificado.Text = filedestino;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btncambiarllaveprivada_Click(object sender, EventArgs e)
        {
            try
            {
                ofdialog.InitialDirectory = oparametros.dirdefault;
                ofdialog.RestoreDirectory = true;
                ofdialog.Title = "Búsqueda de archivos";
                ofdialog.DefaultExt = ".key";
                ofdialog.FileName = ".key";
                ofdialog.Filter = "Archivos de certificado (*.key)|*.key";
                ofdialog.FilterIndex = 1;
                ofdialog.CheckFileExists = true;
                ofdialog.CheckPathExists = true;
                ofdialog.ReadOnlyChecked = true;
                ofdialog.ShowReadOnly = true;

                if (ofdialog.ShowDialog() == DialogResult.OK)
                {
                    string file = ofdialog.FileName;
                    string filedestino = this.oparametros.dirrecursoscfdi + @"\" + file.Split('\\')[file.Split('\\').Length - 1];
                    System.IO.File.Copy(file, filedestino, true);
                    this.txtllaveprivada.Text = filedestino;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnreiniciarsolicitudes_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Esta completamente seguro de realizar el reinicio de solicitudes realizadas?","Mensaje de Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    solicituddescarganc.clear(this._connexionstring);
                    cargasolicitudesdescargas();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void optipodescargasconsulta_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.btnconsultar_Click(null, null);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnborrarsolicitud_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridsolicitudes.ActiveRow != null)
                {
                    int idsolicituddescarga = Convert.ToInt32(this.gridsolicitudes.ActiveRow.Cells["idsolicituddescarga"].Value);
                    solicitudesdescargas osolicituddescarga = solicituddescarganc.getsolicituddescarga(idsolicituddescarga, this._connexionstring);
                    solicituddescarganc.delete(osolicituddescarga,this._connexionstring);

                    MessageBox.Show("¡Solicitud borrada correctamente!", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    cargasolicitudesdescargas();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btncargarpaquetes_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridsolicitudes.ActiveRow != null)
                {
                    string tiposolicitud = gridsolicitudes.ActiveRow.Cells["tiposolicitud"].Value.ToString();
                    string[] files = System.IO.Directory.GetFiles(oparametros.dirpaquetes + @"/" + tiposolicitud,"*.zip");
                    string idsolicitud = gridsolicitudes.ActiveRow.Cells["idsolicitud"].Value.ToString().ToUpper();
                    foreach(string filename in files)
                    {
                        if (filename.Contains(idsolicitud))
                        {
                            string dirdestino = oparametros.dirtmp;
                            System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(dirdestino);
                            foreach (System.IO.FileInfo file in directory.GetFiles()) file.Delete();
  
                            ZipFile.ExtractToDirectory(filename, dirdestino);

                            string[] filesxml = System.IO.Directory.GetFiles(dirdestino,"*.xml");

                            foreach (string filexml in filesxml)
                            {
                                XmlDocument xmldoc = new XmlDocument();
                                xmldoc.Load(filexml);

                                XmlNodeList comprobanteNode = xmldoc.GetElementsByTagName("cfdi:Comprobante");
                                XmlNodeList timbrefiscaldigitalNode = xmldoc.GetElementsByTagName("tfd:TimbreFiscalDigital");
                                XmlNodeList emisorNode = xmldoc.GetElementsByTagName("cfdi:Emisor");
                                XmlNodeList receptorNode = xmldoc.GetElementsByTagName("cfdi:Receptor");

                                XmlNodeList impuestosNode = xmldoc.GetElementsByTagName("cfdi:Impuestos");
                                XmlNodeList conceptosNode = xmldoc.GetElementsByTagName("cfdi:Concepto");
                                XmlNodeList impuestoslocalesNode = xmldoc.GetElementsByTagName("implocal:ImpuestosLocales");

                                string tipoxml = genericas.helpers.GetXMLAttributeValue(comprobanteNode, "TipoDeComprobante");
                                string serie = genericas.helpers.GetXMLAttributeValue(comprobanteNode, "Serie");
                                string folio = genericas.helpers.GetXMLAttributeValue(comprobanteNode, "Folio");
                                string uuid = genericas.helpers.GetXMLAttributeValue(timbrefiscaldigitalNode, "UUID");
                                string rfcemisor = genericas.helpers.GetXMLAttributeValue(emisorNode, "Rfc");
                                string nombreemisor = genericas.helpers.GetXMLAttributeValue(emisorNode, "Nombre");
                                string rfcreceptor = genericas.helpers.GetXMLAttributeValue(receptorNode, "Rfc");
                                string nombrereceptor = genericas.helpers.GetXMLAttributeValue(receptorNode, "Nombre");
                                string rfcpac = genericas.helpers.GetXMLAttributeValue(timbrefiscaldigitalNode, "RfcProvCertif");
                                string fechaemision = genericas.helpers.GetXMLAttributeValue(comprobanteNode, "Fecha");
                                string fechacertificacionsat = genericas.helpers.GetXMLAttributeValue(timbrefiscaldigitalNode, "FechaTimbrado");
                                string subtotal = genericas.helpers.GetXMLAttributeValue(comprobanteNode, "SubTotal");
                                string monto = genericas.helpers.GetXMLAttributeValue(comprobanteNode, "Total");


                                //VERIFICA ESTATUS
                                string send = @"?re=" + rfcemisor + "&rr=" + rfcreceptor + "&tt=" + monto + "&id=" + uuid;
                                string estatus = "Vigente";
                                string codigoestatus = "";
                                string escancelable = "";
                                string estatuscancelacion = "";
                                string validacionefos = "";
                                using (consultaestatus.ConsultaCFDIServiceClient client = new consultaestatus.ConsultaCFDIServiceClient("BasicHttpBinding_IConsultaCFDIService"))
                                {
                                    consultaestatus.Acuse acuse = client.Consulta(send);
                                    if (acuse != null)
                                    {
                                        estatus = acuse.Estado;
                                        codigoestatus = acuse.CodigoEstatus;
                                        escancelable = acuse.EsCancelable;
                                        estatuscancelacion = acuse.EstatusCancelacion;
                                        validacionefos = acuse.ValidacionEFOS;
                                    }
                                }



                                //FIN VERIFICA ESTATUS
                                if (!documentodigitalnc.existeuuid(uuid, this._connexionstring))
                                {
                                    List<documentosdigitalesconceptos> odocumentosdigitalesconceptos = new List<documentosdigitalesconceptos>();
                                    List<documentosdigitalesimpuestos> odocumentosdigitalesimpuestos = new List<documentosdigitalesimpuestos>();

                                    documentosdigitales odoc = new documentosdigitales();
                                    odoc.iddocumentodigital = documentodigitalnc.getid(this._connexionstring);
                                    odoc.tiposolicitud = tiposolicitud;
                                    odoc.serie = serie;
                                    odoc.folio = folio;
                                    odoc.tipoxml = tipoxml;
                                    odoc.uuid = uuid.ToString().ToUpper();
                                    odoc.rfcemisor = rfcemisor;
                                    odoc.nombreemisor = nombreemisor;
                                    odoc.rfcreceptor = rfcreceptor;
                                    odoc.nombrereceptor = nombrereceptor;
                                    odoc.rfcpac = rfcpac;
                                    odoc.fechaemision = Convert.ToDateTime(fechaemision);
                                    odoc.fechacertificacionsat = Convert.ToDateTime(fechacertificacionsat);
                                    odoc.subtotal = Convert.ToDecimal(subtotal);
                                    odoc.totaltrasladados = 0;
                                    odoc.totalretenidos = 0;
                                    odoc.totaltrasladadoslocales = 0;
                                    odoc.totalretenidoslocales = 0;
                                    odoc.monto = Convert.ToDecimal(monto);
                                    odoc.ejercicio = Convert.ToDateTime(fechaemision).Year;
                                    odoc.periodo = Convert.ToDateTime(fechaemision).Month;
                                    odoc.estatus = estatus;
                                    odoc.fechacancelacion = new DateTime(1900, 1, 1);

                                    string xmlcontent = System.IO.File.ReadAllText(filexml, Encoding.UTF8);
                                    byte[] xmlbytes = Encoding.UTF8.GetBytes(xmlcontent);
                                    odoc.xml = xmlbytes;

                                    odoc.codigoestatus = codigoestatus;
                                    odoc.escancelable = escancelable;
                                    odoc.estatuscancelacion = estatuscancelacion;
                                    odoc.validacionefos = validacionefos;
                                    odoc.clasificador = "";
                                    odoc.id = 0;
                                    odoc.usuario = this._idusuario.ToString();
                                    odoc.baja = false;



                                    for (int x = 0; x <= impuestosNode.Count - 1; x++)
                                    {
                                        XmlNode impuestoNode = impuestosNode[x];
                                        if (impuestoNode.OuterXml.Contains("TotalImpuestosTrasladados"))
                                        {
                                            object totalimpuestostrasladados = genericas.helpers.GetAttributeValue(impuestoNode, "TotalImpuestosTrasladados") == DBNull.Value ? 0 : genericas.helpers.GetAttributeValue(impuestoNode, "TotalImpuestosTrasladados");
                                            odoc.totaltrasladados = Convert.ToDecimal(totalimpuestostrasladados);
                                        }
                                        if (impuestoNode.OuterXml.Contains("TotalImpuestosRetenidos"))
                                        {
                                            object totalimpuestosretenidos = genericas.helpers.GetAttributeValue(impuestoNode, "TotalImpuestosRetenidos") == DBNull.Value ? 0 : genericas.helpers.GetAttributeValue(impuestoNode, "TotalImpuestosRetenidos");
                                            odoc.totalretenidos = Convert.ToDecimal(totalimpuestosretenidos);
                                        }
                                    }

                                    if (impuestoslocalesNode.Count > 0)
                                    {
                                        object totalimpuestoslocalestrasladados = genericas.helpers.GetAttributeValue(impuestoslocalesNode[0], "TotaldeTraslados") == DBNull.Value ? 0 : genericas.helpers.GetAttributeValue(impuestoslocalesNode[0], "TotaldeTraslados");
                                        odoc.totaltrasladadoslocales = Convert.ToDecimal(totalimpuestoslocalestrasladados);
                                        object totalimpuestoslocalesretenidos = genericas.helpers.GetAttributeValue(impuestoslocalesNode[0], "TotaldeRetenciones") == DBNull.Value ? 0 : genericas.helpers.GetAttributeValue(impuestoslocalesNode[0], "TotaldeRetenciones");
                                        odoc.totalretenidoslocales = Convert.ToDecimal(totalimpuestoslocalesretenidos);
                                    }


                                    documentodigitalnc.save(odoc, this._connexionstring);
                                    documentosdigitalesconceptos odocconcepto = null;
                                    for (int x = 0; x <= conceptosNode.Count - 1; x++)
                                    {
                                        XmlNode conceptoNode = conceptosNode[x];
                                        object cantidad = genericas.helpers.GetAttributeValue(conceptoNode, "Cantidad") == DBNull.Value ? 0 : genericas.helpers.GetAttributeValue(conceptoNode, "Cantidad");
                                        object noidentificacion = genericas.helpers.GetAttributeValue(conceptoNode, "NoIdentificacion") == null ? "" : genericas.helpers.GetAttributeValue(conceptoNode, "NoIdentificacion");
                                        object unidad = genericas.helpers.GetAttributeValue(conceptoNode, "Unidad");
                                        object claveunidad = genericas.helpers.GetAttributeValue(conceptoNode, "ClaveUnidad");
                                        object descripcion = genericas.helpers.GetAttributeValue(conceptoNode, "Descripcion");
                                        object valorunitario = genericas.helpers.GetAttributeValue(conceptoNode, "ValorUnitario") == DBNull.Value ? 0 : genericas.helpers.GetAttributeValue(conceptoNode, "ValorUnitario");
                                        object importe = genericas.helpers.GetAttributeValue(conceptoNode, "Importe") == DBNull.Value ? 0 : genericas.helpers.GetAttributeValue(conceptoNode, "Importe");
                                        object claveprodserv = genericas.helpers.GetAttributeValue(conceptoNode, "ClaveProdServ");

                                        odocconcepto = new documentosdigitalesconceptos();
                                        odocconcepto.iddocumentodigital = odoc.iddocumentodigital;
                                        odocconcepto.iddocumentodigitalconcepto = documentodigitalconceptonc.getid(this._connexionstring);
                                        odocconcepto.cantidad = Convert.ToDecimal(cantidad);
                                        odocconcepto.noidentificacion = noidentificacion.ToString();
                                        odocconcepto.unidad = unidad.ToString();
                                        odocconcepto.claveunidad = claveunidad.ToString();
                                        odocconcepto.descripcion = descripcion.ToString();
                                        odocconcepto.valorunitario = Convert.ToDecimal(valorunitario);
                                        odocconcepto.importe = Convert.ToDecimal(importe);
                                        odocconcepto.claveprodserv = claveprodserv.ToString();
                                        odocconcepto.destino01 = "";
                                        odocconcepto.destino02 = "";
                                        odocconcepto.destino03 = "";
                                        odocconcepto.destino04 = "";
                                        odocconcepto.baja = false;

                                        //odocumentosdigitalesconceptos.Add(odocconcepto);
                                        documentodigitalconceptonc.save(odocconcepto, this._connexionstring);

                                        if (conceptoNode.ChildNodes.Count > 0)
                                        {
                                            documentosdigitalesimpuestos odocimpuesto = null;
                                            for (int y = 0; y <= conceptoNode.ChildNodes[0].ChildNodes.Count - 1; y++)
                                            {
                                                XmlNode grupoimpuestosNode = conceptoNode.ChildNodes[0].ChildNodes[y];

                                                string tipoimpuesto = "";
                                                if (grupoimpuestosNode.OuterXml.Contains("Traslados"))
                                                {
                                                    tipoimpuesto = "Trasladado";
                                                }
                                                else
                                                {
                                                    tipoimpuesto = "Retenido";
                                                }

                                                for (int z = 0; z <= grupoimpuestosNode.ChildNodes.Count - 1; z++)
                                                {
                                                    XmlNode impuestoNode = grupoimpuestosNode.ChildNodes[z];

                                                    object _base = genericas.helpers.GetAttributeValue(impuestoNode, "Base") == DBNull.Value ? 0 : genericas.helpers.GetAttributeValue(impuestoNode, "Base");
                                                    object _impuesto = genericas.helpers.GetAttributeValue(impuestoNode, "Impuesto") == DBNull.Value ? "" : genericas.helpers.GetAttributeValue(impuestoNode, "Impuesto");
                                                    object _tipofactor = genericas.helpers.GetAttributeValue(impuestoNode, "TipoFactor") == DBNull.Value ? "" : genericas.helpers.GetAttributeValue(impuestoNode, "TipoFactor");
                                                    object _tasaocuota = genericas.helpers.GetAttributeValue(impuestoNode, "TasaOCuota") == DBNull.Value ? 0 : genericas.helpers.GetAttributeValue(impuestoNode, "TasaOCuota");
                                                    object _importe = genericas.helpers.GetAttributeValue(impuestoNode, "Importe") == DBNull.Value ? 0 : genericas.helpers.GetAttributeValue(impuestoNode, "Importe");

                                                    odocimpuesto = new documentosdigitalesimpuestos();
                                                    odocimpuesto.iddocumentodigital = odoc.iddocumentodigital;
                                                    odocimpuesto.iddocumentodigitalconcepto = odocconcepto.iddocumentodigitalconcepto;
                                                    odocimpuesto.iddocumentodigitalimpuesto = documentodigitalimpuestonc.getid(this._connexionstring);
                                                    odocimpuesto.baseimpuesto = Convert.ToDecimal(_base);
                                                    odocimpuesto.tipoimpuesto = tipoimpuesto;
                                                    odocimpuesto.impuesto = _impuesto.ToString();
                                                    odocimpuesto.tipofactor = _tipofactor.ToString();
                                                    odocimpuesto.tasaocuota = Convert.ToDecimal(_tasaocuota);
                                                    odocimpuesto.importe = Convert.ToDecimal(_importe);
                                                    odocimpuesto.baja = false;

                                                    //odocumentosdigitalesimpuestos.Add(odocimpuesto);
                                                    documentodigitalimpuestonc.save(odocimpuesto, this._connexionstring);
                                                }

                                            }
                                        }

                                    }




                                    //documentodigitalnc.odocumentosdigitalesconceptos = odocumentosdigitalesconceptos;
                                    //documentodigitalnc.odocumentosdigitalesimpuestos = odocumentosdigitalesimpuestos;
                                    //string msg = documentodigitalnc.savetransaction(odoc, this._connexionstring);
                                    //if (msg != "") throw new System.Exception(msg);
                                }
                            }

                            foreach (System.IO.FileInfo file in directory.GetFiles()) file.Delete();
                            break;
                        }
                    }


                    MessageBox.Show("¡Paquete cargado correctamente a Almacén de Documentos!", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btncargartodoslospaquetes_Click(object sender, EventArgs e)
        {
            try
            {
                foreach(Infragistics.Win.UltraWinGrid.UltraGridRow oRow in this.gridsolicitudes.Rows)
                {
                    string tiposolicitud = oRow.Cells["tiposolicitud"].Value.ToString();
                    string[] files = System.IO.Directory.GetFiles(oparametros.dirpaquetes + @"/" + tiposolicitud, "*.zip");
                    string idsolicitud = oRow.Cells["idsolicitud"].Value.ToString().ToUpper();
                    foreach (string filename in files)
                    {
                        if (filename.Contains(idsolicitud))
                        {
                            string dirdestino = oparametros.dirtmp;
                            System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(dirdestino);
                            foreach (System.IO.FileInfo file in directory.GetFiles()) file.Delete();

                            ZipFile.ExtractToDirectory(filename, dirdestino);

                            string[] filesxml = System.IO.Directory.GetFiles(dirdestino, "*.xml");

                            foreach (string filexml in filesxml)
                            {
                                XmlDocument xmldoc = new XmlDocument();
                                xmldoc.Load(filexml);

                                XmlNodeList comprobanteNode = xmldoc.GetElementsByTagName("cfdi:Comprobante");
                                XmlNodeList timbrefiscaldigitalNode = xmldoc.GetElementsByTagName("tfd:TimbreFiscalDigital");
                                XmlNodeList emisorNode = xmldoc.GetElementsByTagName("cfdi:Emisor");
                                XmlNodeList receptorNode = xmldoc.GetElementsByTagName("cfdi:Receptor");

                                XmlNodeList impuestosNode = xmldoc.GetElementsByTagName("cfdi:Impuestos");
                                XmlNodeList conceptosNode = xmldoc.GetElementsByTagName("cfdi:Concepto");
                                XmlNodeList impuestoslocalesNode = xmldoc.GetElementsByTagName("implocal:ImpuestosLocales");

                                string tipoxml = genericas.helpers.GetXMLAttributeValue(comprobanteNode, "TipoDeComprobante");
                                string serie = genericas.helpers.GetXMLAttributeValue(comprobanteNode, "Serie");
                                string folio = genericas.helpers.GetXMLAttributeValue(comprobanteNode, "Folio");
                                string uuid = genericas.helpers.GetXMLAttributeValue(timbrefiscaldigitalNode, "UUID");
                                string rfcemisor = genericas.helpers.GetXMLAttributeValue(emisorNode, "Rfc");
                                string nombreemisor = genericas.helpers.GetXMLAttributeValue(emisorNode, "Nombre");
                                string rfcreceptor = genericas.helpers.GetXMLAttributeValue(receptorNode, "Rfc");
                                string nombrereceptor = genericas.helpers.GetXMLAttributeValue(receptorNode, "Nombre");
                                string rfcpac = genericas.helpers.GetXMLAttributeValue(timbrefiscaldigitalNode, "RfcProvCertif");
                                string fechaemision = genericas.helpers.GetXMLAttributeValue(comprobanteNode, "Fecha");
                                string fechacertificacionsat = genericas.helpers.GetXMLAttributeValue(timbrefiscaldigitalNode, "FechaTimbrado");
                                string subtotal = genericas.helpers.GetXMLAttributeValue(comprobanteNode, "SubTotal");
                                string monto = genericas.helpers.GetXMLAttributeValue(comprobanteNode, "Total");


                                //VERIFICA ESTATUS
                                string send = @"?re=" + rfcemisor + "&rr=" + rfcreceptor + "&tt=" + monto + "&id=" + uuid;
                                string estatus = "Vigente";
                                string codigoestatus = "";
                                string escancelable = "";
                                string estatuscancelacion = "";
                                string validacionefos = "";
                                using (consultaestatus.ConsultaCFDIServiceClient client = new consultaestatus.ConsultaCFDIServiceClient("BasicHttpBinding_IConsultaCFDIService"))
                                {
                                    consultaestatus.Acuse acuse = client.Consulta(send);
                                    if (acuse != null)
                                    {
                                        estatus = acuse.Estado;
                                        codigoestatus = acuse.CodigoEstatus;
                                        escancelable = acuse.EsCancelable;
                                        estatuscancelacion = acuse.EstatusCancelacion;
                                        validacionefos = acuse.ValidacionEFOS;
                                    }
                                }





                                if (!documentodigitalnc.existeuuid(uuid, this._connexionstring))
                                {
                                    List<documentosdigitalesconceptos> odocumentosdigitalesconceptos = new List<documentosdigitalesconceptos>();
                                    List<documentosdigitalesimpuestos> odocumentosdigitalesimpuestos = new List<documentosdigitalesimpuestos>();

                                    documentosdigitales odoc = new documentosdigitales();
                                    odoc.iddocumentodigital = documentodigitalnc.getid(this._connexionstring);
                                    odoc.tiposolicitud = tiposolicitud;
                                    odoc.serie = serie;
                                    odoc.folio = folio;
                                    odoc.tipoxml = tipoxml;
                                    odoc.uuid = uuid.ToString().ToUpper();
                                    odoc.rfcemisor = rfcemisor;
                                    odoc.nombreemisor = nombreemisor;
                                    odoc.rfcreceptor = rfcreceptor;
                                    odoc.nombrereceptor = nombrereceptor;
                                    odoc.rfcpac = rfcpac;
                                    odoc.fechaemision = Convert.ToDateTime(fechaemision);
                                    odoc.fechacertificacionsat = Convert.ToDateTime(fechacertificacionsat);
                                    odoc.subtotal = Convert.ToDecimal(subtotal);
                                    odoc.totaltrasladados = 0;
                                    odoc.totalretenidos = 0;
                                    odoc.totaltrasladadoslocales = 0;
                                    odoc.totalretenidoslocales = 0;
                                    odoc.monto = Convert.ToDecimal(monto);
                                    odoc.ejercicio = Convert.ToDateTime(fechaemision).Year;
                                    odoc.periodo = Convert.ToDateTime(fechaemision).Month;
                                    odoc.estatus = estatus;
                                    odoc.fechacancelacion = new DateTime(1900, 1, 1);

                                    //odoc.xml = System.IO.File.ReadAllBytes(filename);
                                    string xmlcontent = System.IO.File.ReadAllText(filexml, Encoding.UTF8);
                                    byte[] xmlbytes = Encoding.UTF8.GetBytes(xmlcontent);
                                    odoc.xml = xmlbytes;

                                    odoc.codigoestatus = codigoestatus;
                                    odoc.escancelable = escancelable;
                                    odoc.estatuscancelacion = estatuscancelacion;
                                    odoc.validacionefos = validacionefos;
                                    odoc.clasificador = "";
                                    odoc.id = 0;
                                    odoc.usuario = this._idusuario.ToString();
                                    odoc.baja = false;




                                    for (int x = 0; x <= impuestosNode.Count - 1; x++)
                                    {
                                        XmlNode impuestoNode = impuestosNode[x];
                                        if (impuestoNode.OuterXml.Contains("TotalImpuestosTrasladados"))
                                        {
                                            object totalimpuestostrasladados = genericas.helpers.GetAttributeValue(impuestoNode, "TotalImpuestosTrasladados") == DBNull.Value ? 0 : genericas.helpers.GetAttributeValue(impuestoNode, "TotalImpuestosTrasladados");
                                            odoc.totaltrasladados = Convert.ToDecimal(totalimpuestostrasladados);
                                        }
                                        if (impuestoNode.OuterXml.Contains("TotalImpuestosRetenidos"))
                                        {
                                            object totalimpuestosretenidos = genericas.helpers.GetAttributeValue(impuestoNode, "TotalImpuestosRetenidos") == DBNull.Value ? 0 : genericas.helpers.GetAttributeValue(impuestoNode, "TotalImpuestosRetenidos");
                                            odoc.totalretenidos = Convert.ToDecimal(totalimpuestosretenidos);
                                        }
                                    }


                                    if (impuestoslocalesNode.Count > 0)
                                    {
                                        object totalimpuestoslocalestrasladados = genericas.helpers.GetAttributeValue(impuestoslocalesNode[0], "TotaldeTraslados") == DBNull.Value ? 0 : genericas.helpers.GetAttributeValue(impuestoslocalesNode[0], "TotaldeTraslados");
                                        odoc.totaltrasladadoslocales = Convert.ToDecimal(totalimpuestoslocalestrasladados);
                                        object totalimpuestoslocalesretenidos = genericas.helpers.GetAttributeValue(impuestoslocalesNode[0], "TotaldeRetenciones") == DBNull.Value ? 0 : genericas.helpers.GetAttributeValue(impuestoslocalesNode[0], "TotaldeRetenciones");
                                        odoc.totalretenidoslocales = Convert.ToDecimal(totalimpuestoslocalesretenidos);
                                    }


                                    documentodigitalnc.save(odoc, this._connexionstring);
                                    documentosdigitalesconceptos odocconcepto = null;
                                    for (int x = 0; x <= conceptosNode.Count - 1; x++)
                                    {
                                        XmlNode conceptoNode = conceptosNode[x];
                                        object cantidad = genericas.helpers.GetAttributeValue(conceptoNode, "Cantidad") == DBNull.Value ? 0 : genericas.helpers.GetAttributeValue(conceptoNode, "Cantidad");
                                        object noidentificacion = genericas.helpers.GetAttributeValue(conceptoNode, "NoIdentificacion") == null ? "" : genericas.helpers.GetAttributeValue(conceptoNode, "NoIdentificacion");
                                        object unidad = genericas.helpers.GetAttributeValue(conceptoNode, "Unidad");
                                        object claveunidad = genericas.helpers.GetAttributeValue(conceptoNode, "ClaveUnidad");
                                        object descripcion = genericas.helpers.GetAttributeValue(conceptoNode, "Descripcion");
                                        object valorunitario = genericas.helpers.GetAttributeValue(conceptoNode, "ValorUnitario") == DBNull.Value ? 0 : genericas.helpers.GetAttributeValue(conceptoNode, "ValorUnitario");
                                        object importe = genericas.helpers.GetAttributeValue(conceptoNode, "Importe") == DBNull.Value ? 0 : genericas.helpers.GetAttributeValue(conceptoNode, "Importe");
                                        object claveprodserv = genericas.helpers.GetAttributeValue(conceptoNode, "ClaveProdServ");

                                        odocconcepto = new documentosdigitalesconceptos();
                                        odocconcepto.iddocumentodigital = odoc.iddocumentodigital;
                                        odocconcepto.iddocumentodigitalconcepto = documentodigitalconceptonc.getid(this._connexionstring);
                                        odocconcepto.cantidad = Convert.ToDecimal(cantidad);
                                        odocconcepto.noidentificacion = noidentificacion.ToString();
                                        odocconcepto.unidad = unidad.ToString();
                                        odocconcepto.claveunidad = claveunidad.ToString();
                                        odocconcepto.descripcion = descripcion.ToString();
                                        odocconcepto.valorunitario = Convert.ToDecimal(valorunitario);
                                        odocconcepto.importe = Convert.ToDecimal(importe);
                                        odocconcepto.claveprodserv = claveprodserv.ToString();
                                        odocconcepto.destino01 = "";
                                        odocconcepto.destino02 = "";
                                        odocconcepto.destino03 = "";
                                        odocconcepto.destino04 = "";
                                        odocconcepto.baja = false;

                                        //odocumentosdigitalesconceptos.Add(odocconcepto);
                                        documentodigitalconceptonc.save(odocconcepto, this._connexionstring);

                                        if (conceptoNode.ChildNodes.Count > 0)
                                        {
                                            documentosdigitalesimpuestos odocimpuesto = null;
                                            for (int y = 0; y <= conceptoNode.ChildNodes[0].ChildNodes.Count - 1; y++)
                                            {
                                                XmlNode grupoimpuestosNode = conceptoNode.ChildNodes[0].ChildNodes[y];

                                                string tipoimpuesto = "";
                                                if (grupoimpuestosNode.OuterXml.Contains("Traslados"))
                                                {
                                                    tipoimpuesto = "Trasladado";
                                                }
                                                else
                                                {
                                                    tipoimpuesto = "Retenido";
                                                }

                                                for (int z = 0; z <= grupoimpuestosNode.ChildNodes.Count - 1; z++)
                                                {
                                                    XmlNode impuestoNode = grupoimpuestosNode.ChildNodes[z];

                                                    object _base = genericas.helpers.GetAttributeValue(impuestoNode, "Base") == DBNull.Value ? 0 : genericas.helpers.GetAttributeValue(impuestoNode, "Base");
                                                    object _impuesto = genericas.helpers.GetAttributeValue(impuestoNode, "Impuesto") == DBNull.Value ? "" : genericas.helpers.GetAttributeValue(impuestoNode, "Impuesto");
                                                    object _tipofactor = genericas.helpers.GetAttributeValue(impuestoNode, "TipoFactor") == DBNull.Value ? "" : genericas.helpers.GetAttributeValue(impuestoNode, "TipoFactor");
                                                    object _tasaocuota = genericas.helpers.GetAttributeValue(impuestoNode, "TasaOCuota") == DBNull.Value ? 0 : genericas.helpers.GetAttributeValue(impuestoNode, "TasaOCuota");
                                                    object _importe = genericas.helpers.GetAttributeValue(impuestoNode, "Importe") == DBNull.Value ? 0 : genericas.helpers.GetAttributeValue(impuestoNode, "Importe");

                                                    odocimpuesto = new documentosdigitalesimpuestos();
                                                    odocimpuesto.iddocumentodigital = odoc.iddocumentodigital;
                                                    odocimpuesto.iddocumentodigitalconcepto = odocconcepto.iddocumentodigitalconcepto;
                                                    odocimpuesto.iddocumentodigitalimpuesto = documentodigitalimpuestonc.getid(this._connexionstring);
                                                    odocimpuesto.baseimpuesto = Convert.ToDecimal(_base);
                                                    odocimpuesto.tipoimpuesto = tipoimpuesto;
                                                    odocimpuesto.impuesto = _impuesto.ToString();
                                                    odocimpuesto.tipofactor = _tipofactor.ToString();
                                                    odocimpuesto.tasaocuota = Convert.ToDecimal(_tasaocuota);
                                                    odocimpuesto.importe = Convert.ToDecimal(_importe);
                                                    odocimpuesto.baja = false;

                                                    //odocumentosdigitalesimpuestos.Add(odocimpuesto);
                                                    documentodigitalimpuestonc.save(odocimpuesto, this._connexionstring);
                                                }

                                            }
                                        }

                                    }


                                    //documentodigitalnc.odocumentosdigitalesconceptos = odocumentosdigitalesconceptos;
                                    //documentodigitalnc.odocumentosdigitalesimpuestos = odocumentosdigitalesimpuestos;
                                    //string msg = documentodigitalnc.savetransaction(odoc, this._connexionstring);
                                    //if (msg != "") throw new System.Exception(msg);
                                }
                            }

                            foreach (System.IO.FileInfo file in directory.GetFiles()) file.Delete();
                        }
                    }
                }

                MessageBox.Show("¡Paquetes cargados correctamente a Almacén de Documentos!", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbperiodo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string periodo = this.cmbperiodo.Text.Trim();
                switch (this.cmbperiodo.Text.Trim())
                {
                    case "enero": periodo = "01"; break;
                    case "febrero": periodo = "02"; break;
                    case "marzo": periodo = "03"; break;
                    case "abril": periodo = "04"; break;
                    case "mayo": periodo = "05"; break;
                    case "junio": periodo = "06"; break;
                    case "julio": periodo = "07"; break;
                    case "agosto": periodo = "08"; break;
                    case "septiembre": periodo = "09"; break;
                    case "octubre": periodo = "10"; break;
                    case "noviembre": periodo = "11"; break;
                    case "diciembre": periodo = "12"; break;
                }
                DateTime fi = new DateTime(Convert.ToInt32(this.cmbejercicios.Text), Convert.ToInt32(periodo), 1);
                DateTime ff = fi.AddMonths(1).AddSeconds(-1);

                this.cmbfechainicial.Value = fi;
                this.cmbfechafinal.Value = ff;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
