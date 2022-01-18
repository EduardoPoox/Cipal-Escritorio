using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;


using cipal.entidades;
using cipal.negocios;

namespace cipal.configuraciones
{
    public partial class frmconfiguraciones : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;
        private int _idconfig;


        private string _cnn;
        private string _cnndecript;

        private string _tipodeinstalacion;
        private string _servidor;
        private string _instancia;
        private string _username;
        private string _password;


        public frmconfiguraciones(int id, int idconfig, int idusuario, string connexionstring, string cnnparams)
        {
            InitializeComponent();
            this._connexionstring = connexionstring;
            this._idusuario = idusuario;
            this._idconfig = idconfig;
            this._id = id;



            _cnn = cnnparams;
            _cnndecript = genericas.generales.desencriptar(_cnn);

            string[] _cnnsplit = _cnndecript.Split('|');
            _tipodeinstalacion = _cnnsplit[0];
            _servidor = _cnnsplit[1];
            _instancia = _cnnsplit[2];
            _username = _cnnsplit[3];
            _password = genericas.generales.desencriptar(_cnnsplit[4]);

        }

        private void frmconfiguraciones_Load(object sender, EventArgs e)
        {
            try
            {
                cargainfo();
                cargaseriesfoliacion();
                cargaformatosemitidos();
                cargaformatosrecibidos();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargainfo()
        {
            try
            {
                if (this._tipodeinstalacion == genericas.enums.etipoinstalacion.monousuario.ToString())
                {
                    this.txtdirpredeteminado.Text = @"c:\cipal";
                    this.txtdirectoriotemporales.Text = @"c:\cipal\tmp";
                    this.txtdirectoriopaquetes.Text = @"c:\cipal\paquetes";
                }
                else
                {
                    this.txtdirpredeteminado.Text = @"\\"+this._servidor+@"\cipal";
                    this.txtdirectoriotemporales.Text = @"\\" + this._servidor + @"\cipal\tmp";
                    this.txtdirectoriopaquetes.Text = @"\\" + this._servidor + @"\cipal\paquetes";
                }


                if (this._id > 0)
                {
                    empresa oempresa = empresanc.getempresa(this._id, this._connexionstring);
                    this.txtrfc.Text = oempresa.rfc;
                    this.txtnombre.Text = oempresa.nombre;
                }


                if (this._idconfig > 0)
                {
                    parametros oparametros = parametronc.getparametro(this._idconfig, this._connexionstring);

                    this.txtpresidentemunicipal.Text = oparametros.presidente;
                    this.txttesoreromunicipal.Text = oparametros.tesorero;
                    this.txtsupervisor.Text = oparametros.supervisor;
                    this.txtresponsable.Text = oparametros.responsable;
                    this.txtarchivocer.Text = oparametros.archivocer;
                    this.txtarchivokey.Text = oparametros.archivokey;
                    this.txtcontraseniaefirma.Text = oparametros.efirmapassword;
                    this.txtcontraseniaciec.Text = oparametros.ciecpassword;
                    if (oparametros.logoizquierdo != null)
                    {
                        this.pblogoizquierdo.Image = genericas.generales.byteArrayToImage(oparametros.logoizquierdo);
                    }
                    if (oparametros.logoderecho != null)
                    {
                        this.pblogoderecho.Image = genericas.generales.byteArrayToImage(oparametros.logoderecho);
                    }


                    this.txtdirpredeteminado.Text = oparametros.dirdefault;
                    this.txtdirbackup.Text = oparametros.dirbackup;
                    this.txtdirxml.Text = oparametros.dirxml;
                    this.txtdirpdf.Text = oparametros.dirpdf;
                    this.txtdirinformes.Text = oparametros.dirinformes;
                    this.txtdirrecursoscfdi.Text = oparametros.dirrecursoscfdi;
                    this.txtdirexportaciones.Text = oparametros.direxportaciones;
                    this.txtdirectoriotemporales.Text = oparametros.dirtmp;
                    this.txtdirectoriopaquetes.Text = oparametros.dirpaquetes;
                    this.txtdirectorioopenssl.Text = oparametros.diropenssl;


                    this.txtleyenda1.Text = oparametros.leyenda1;
                    this.txtleyenda2.Text = oparametros.leyenda2;
                    this.txtleyenda3.Text = oparametros.leyenda3;
                    this.txtleyenda4.Text = oparametros.leyenda4;

                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
     
        private void cargaseriesfoliacion()
        {
            try
            {
                List<seriesfoliacion> olistseriefoliacion = seriefoliacionnc.getseriesfoliacion(this._connexionstring);
                this.gridseriesfoliacion.SetDataBinding(olistseriefoliacion, null);
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.gridseriesfoliacion.DisplayLayout.Bands[0].Columns)
                {
                    oColumn.Hidden = true;
                }
                this.gridseriesfoliacion.DisplayLayout.Bands[0].Columns["tiposerie"].Hidden = false;
                this.gridseriesfoliacion.DisplayLayout.Bands[0].Columns["serie"].Hidden = false;
                this.gridseriesfoliacion.DisplayLayout.Bands[0].Columns["inicial"].Hidden = false;
                this.gridseriesfoliacion.DisplayLayout.Bands[0].Columns["actual"].Hidden = false;
                this.gridseriesfoliacion.DisplayLayout.Bands[0].Columns["vigente"].Hidden = false;

                this.gridseriesfoliacion.DisplayLayout.Bands[0].Columns["tiposerie"].Header.Caption = "Tipo de Serie";
                this.gridseriesfoliacion.DisplayLayout.Bands[0].Columns["serie"].Header.Caption = "Serie";
                this.gridseriesfoliacion.DisplayLayout.Bands[0].Columns["inicial"].Header.Caption = "Inicial";
                this.gridseriesfoliacion.DisplayLayout.Bands[0].Columns["actual"].Header.Caption = "Actual";
                this.gridseriesfoliacion.DisplayLayout.Bands[0].Columns["vigente"].Header.Caption = "Estado";


                this.gridseriesfoliacion.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        private void cargaformatosemitidos()
        {
            try
            {
                List<formatos> olistformato = formatonc.getformatosbygrupogeneral(genericas.enums.egrupoformatosgeneral.emitidos.ToString(), this._connexionstring);
                this.gridformatosemitidos.SetDataBinding(olistformato, null);
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.gridformatosemitidos.DisplayLayout.Bands[0].Columns)
                {
                    oColumn.Hidden = true;
                }
                this.gridformatosemitidos.DisplayLayout.Bands[0].Columns["tipogeneral"].Hidden = false;
                this.gridformatosemitidos.DisplayLayout.Bands[0].Columns["clasificador"].Hidden = false;
                this.gridformatosemitidos.DisplayLayout.Bands[0].Columns["tipo"].Hidden = false;
                this.gridformatosemitidos.DisplayLayout.Bands[0].Columns["nombre"].Hidden = false;
                this.gridformatosemitidos.DisplayLayout.Bands[0].Columns["vigente"].Hidden = false;

                this.gridformatosemitidos.DisplayLayout.Bands[0].Columns["tipogeneral"].Header.Caption = "Grupo General";
                this.gridformatosemitidos.DisplayLayout.Bands[0].Columns["clasificador"].Header.Caption = "Grupo de Formatos";
                this.gridformatosemitidos.DisplayLayout.Bands[0].Columns["tipo"].Header.Caption = "Tipo de Formato";
                this.gridformatosemitidos.DisplayLayout.Bands[0].Columns["nombre"].Header.Caption = "Nombre del Formato";
                this.gridformatosemitidos.DisplayLayout.Bands[0].Columns["vigente"].Header.Caption = "Estado";


                this.gridformatosemitidos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        private void cargaformatosrecibidos()
        {
            try
            {
                List<formatos> olistformato = formatonc.getformatosbygrupogeneral(genericas.enums.egrupoformatosgeneral.recibidos.ToString(), this._connexionstring);
                this.gridformatosrecibidos.SetDataBinding(olistformato, null);
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.gridformatosrecibidos.DisplayLayout.Bands[0].Columns)
                {
                    oColumn.Hidden = true;
                }
                this.gridformatosrecibidos.DisplayLayout.Bands[0].Columns["tipogeneral"].Hidden = false;
                this.gridformatosrecibidos.DisplayLayout.Bands[0].Columns["clasificador"].Hidden = false;
                this.gridformatosrecibidos.DisplayLayout.Bands[0].Columns["tipo"].Hidden = false;
                this.gridformatosrecibidos.DisplayLayout.Bands[0].Columns["nombre"].Hidden = false;
                this.gridformatosrecibidos.DisplayLayout.Bands[0].Columns["vigente"].Hidden = false;

                this.gridformatosrecibidos.DisplayLayout.Bands[0].Columns["tipogeneral"].Header.Caption = "Grupo General";
                this.gridformatosrecibidos.DisplayLayout.Bands[0].Columns["clasificador"].Header.Caption = "Grupo de Formatos";
                this.gridformatosrecibidos.DisplayLayout.Bands[0].Columns["tipo"].Header.Caption = "Tipo de Formato";
                this.gridformatosrecibidos.DisplayLayout.Bands[0].Columns["nombre"].Header.Caption = "Nombre del Formato";
                this.gridformatosrecibidos.DisplayLayout.Bands[0].Columns["vigente"].Header.Caption = "Estado";


                this.gridformatosrecibidos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }



        private void btncancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnarchivocer_Click(object sender, EventArgs e)
        {
            try
            {
                ofdialog.InitialDirectory = this.txtdirpredeteminado.Text;
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
                    string filedestino = this.txtdirrecursoscfdi.Text.Trim()  + @"\" + file.Split('\\')[file.Split('\\').Length - 1];
                    System.IO.File.Copy(file, filedestino,true);
                    this.txtarchivocer.Text = filedestino;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnarchivokey_Click(object sender, EventArgs e)
        {
            try
            {
                ofdialog.InitialDirectory = this.txtdirpredeteminado.Text;
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
                    string filedestino = this.txtdirrecursoscfdi.Text.Trim() + @"\" + file.Split('\\')[file.Split('\\').Length - 1];
                    System.IO.File.Copy(file, filedestino,true);

                    this.txtarchivokey.Text = filedestino;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btndirpredeterminado_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btndirbackup_Click(object sender, EventArgs e)
        {
            try
            {
                fbdialog.SelectedPath = this.txtdirpredeteminado.Text;
                fbdialog.RootFolder = Environment.SpecialFolder.MyComputer;
                fbdialog.Description = "Búsqueda de directorio";

                if (fbdialog.ShowDialog() == DialogResult.OK)
                {
                    this.txtdirbackup.Text = fbdialog.SelectedPath.ToString();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btndirxml_Click(object sender, EventArgs e)
        {
            try
            {
                fbdialog.SelectedPath = this.txtdirpredeteminado.Text;
                fbdialog.RootFolder = Environment.SpecialFolder.MyComputer;
                fbdialog.Description = "Búsqueda de directorio";

                if (fbdialog.ShowDialog() == DialogResult.OK)
                {
                    this.txtdirxml.Text = fbdialog.SelectedPath.ToString();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btndirpdf_Click(object sender, EventArgs e)
        {
            try
            {
                fbdialog.SelectedPath = this.txtdirpredeteminado.Text;
                fbdialog.RootFolder = Environment.SpecialFolder.MyComputer;
                fbdialog.Description = "Búsqueda de directorio";

                if (fbdialog.ShowDialog() == DialogResult.OK)
                {
                    this.txtdirpdf.Text = fbdialog.SelectedPath.ToString();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btndirinformes_Click(object sender, EventArgs e)
        {
            try
            {
                fbdialog.SelectedPath = this.txtdirpredeteminado.Text;
                fbdialog.RootFolder = Environment.SpecialFolder.MyComputer;
                fbdialog.Description = "Búsqueda de directorio";

                if (fbdialog.ShowDialog() == DialogResult.OK)
                {
                    this.txtdirinformes.Text = fbdialog.SelectedPath.ToString();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btndirrecursoscfdi_Click(object sender, EventArgs e)
        {
            try
            {
                fbdialog.SelectedPath = this.txtdirpredeteminado.Text;
                fbdialog.RootFolder = Environment.SpecialFolder.MyComputer;
                fbdialog.Description = "Búsqueda de directorio";

                if (fbdialog.ShowDialog() == DialogResult.OK)
                {
                    this.txtdirrecursoscfdi.Text = fbdialog.SelectedPath.ToString();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btndirexportaciones_Click(object sender, EventArgs e)
        {
            try
            {
                fbdialog.SelectedPath = this.txtdirpredeteminado.Text;
                fbdialog.RootFolder = Environment.SpecialFolder.MyComputer;
                fbdialog.Description = "Búsqueda de directorio";

                if (fbdialog.ShowDialog() == DialogResult.OK)
                {
                    this.txtdirexportaciones.Text = fbdialog.SelectedPath.ToString();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                parametros oparametros;
                if (this._idconfig > 0)
                {
                    oparametros = parametronc.getparametro(this._idconfig, this._connexionstring);
                }
                else
                {
                    oparametros = new parametros();
                    oparametros.idparametro = parametronc.getid(this._connexionstring);
                    oparametros.usuario = this._idusuario.ToString();
                    oparametros.fechacreacion = DateTime.Now;
                    oparametros.baja = false;
                }

                oparametros.presidente = this.txtpresidentemunicipal.Text;
                oparametros.tesorero = this.txttesoreromunicipal.Text;
                oparametros.supervisor = this.txtsupervisor.Text;
                oparametros.responsable = this.txtresponsable.Text;

                if (pblogoizquierdo.Image != null)
                {
                    oparametros.logoizquierdo = genericas.generales.imageToByteArray(pblogoizquierdo.Image);
                }
                if (pblogoderecho.Image != null)
                {
                    oparametros.logoderecho = genericas.generales.imageToByteArray(pblogoderecho.Image);
                }

                oparametros.marcadeagua = null;

                oparametros.archivocer = this.txtarchivocer.Text;
                oparametros.archivokey = this.txtarchivokey.Text;
                oparametros.efirmapassword = this.txtcontraseniaefirma.Text;
                oparametros.ciecpassword = this.txtcontraseniaciec.Text;


                oparametros.dirdefault = this.txtdirpredeteminado.Text;
                oparametros.dirbackup = this.txtdirbackup.Text;
                oparametros.dirxml = this.txtdirxml.Text;
                oparametros.dirpdf = this.txtdirpdf.Text;
                oparametros.dirinformes = this.txtdirinformes.Text;
                oparametros.dirrecursoscfdi = this.txtdirrecursoscfdi.Text;
                oparametros.direxportaciones = this.txtdirexportaciones.Text;
                oparametros.dirtmp = this.txtdirectoriotemporales.Text;
                oparametros.dirpaquetes = this.txtdirectoriopaquetes.Text;
                oparametros.diropenssl = this.txtdirectorioopenssl.Text;


                oparametros.leyenda1 = this.txtleyenda1.Text;
                oparametros.leyenda2 = this.txtleyenda2.Text;
                oparametros.leyenda3 = this.txtleyenda3.Text;
                oparametros.leyenda4 = this.txtleyenda4.Text;

                if (this._idconfig > 0)
                {
                    parametronc.update(oparametros, this._connexionstring);
                }
                else
                {
                    parametronc.save(oparametros, this._connexionstring);
                }

                this.Close();
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
                string filekeypem = this.txtarchivokey.Text.Trim().Replace(".key", "_key.pem");
                _prockey.StartInfo.FileName = this.txtdirectorioopenssl.Text.Trim();
                _prockey.StartInfo.Arguments = "pkcs8 -inform DER -in \"" + this.txtarchivokey.Text.Trim() + "\" -passin pass:"+ this.txtcontraseniaefirma.Text.Trim() + " -out \"" + filekeypem + "\"";
                _prockey.StartInfo.WorkingDirectory = this.txtdirectorioopenssl.Text.Trim();
                _prockey.Start();
                _prockey.WaitForExit();


                //x509 -inform DER -in certificado.cer -out certificado.pem
                Process _proccer = new Process();
                string filecerpem = this.txtarchivocer.Text.Trim().Replace(".cer", "_cer.pem");
                _proccer.StartInfo.FileName = this.txtdirectorioopenssl.Text.Trim();
                _proccer.StartInfo.Arguments = "x509 -inform DER -in \"" + this.txtarchivocer.Text.Trim() + "\" -out \"" + filecerpem + "\"";
                _proccer.StartInfo.WorkingDirectory = this.txtdirectorioopenssl.Text.Trim();
                _proccer.Start();
                _proccer.WaitForExit();



                //pkcs12 -export -out archivopfx.pfx -inkey llave.pem -in certificado.pem -passout pass:clavedesalida
                Process _procpfx = new Process();
                string filepfx = this.txtarchivocer.Text.Trim().Replace(".cer", ".pfx");
                _procpfx.StartInfo.FileName = this.txtdirectorioopenssl.Text.Trim();
                _procpfx.StartInfo.Arguments = "pkcs12 -export -out \"" + filepfx + "\" -inkey \"" + filekeypem + "\" -in \"" + filecerpem + "\" -passout pass:" + this.txtcontraseniaefirma.Text.Trim();
                _procpfx.StartInfo.WorkingDirectory = this.txtdirectorioopenssl.Text.Trim();
                _procpfx.Start();
                _procpfx.WaitForExit();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btndirectorioopenssl_Click(object sender, EventArgs e)
        {
            try
            {
                ofdialog.InitialDirectory = this.txtdirpredeteminado.Text;
                ofdialog.RestoreDirectory = true;
                ofdialog.Title = "Búsqueda de archivos";
                ofdialog.DefaultExt = ".exe";
                ofdialog.FileName = ".exe";
                ofdialog.Filter = "Archivos ejecutable openssl (*.exe)|*.exe";
                ofdialog.FilterIndex = 1;
                ofdialog.CheckFileExists = true;
                ofdialog.CheckPathExists = true;
                ofdialog.ReadOnlyChecked = true;
                ofdialog.ShowReadOnly = true;

                if (ofdialog.ShowDialog() == DialogResult.OK)
                {
                    string file = ofdialog.FileName;
                    this.txtdirectorioopenssl.Text = file;
                    if (this.txtdirectorioopenssl.Text != "")
                    {
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnlogotipoizquierdo_Click(object sender, EventArgs e)
        {
            try
            {
                ofdialog.InitialDirectory = this.txtdirpredeteminado.Text;
                ofdialog.RestoreDirectory = true;
                ofdialog.Title = "Búsqueda de archivos de imágen";
                ofdialog.DefaultExt = ".png";
                ofdialog.FileName = ".png";
                ofdialog.Filter = "Archivos de Imágen (*.png)|*.png";
                ofdialog.FilterIndex = 1;
                ofdialog.CheckFileExists = true;
                ofdialog.CheckPathExists = true;
                ofdialog.ReadOnlyChecked = true;
                ofdialog.ShowReadOnly = true;

                if (ofdialog.ShowDialog() == DialogResult.OK)
                {
                    pblogoizquierdo.ImageLocation = ofdialog.FileName;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnlogotipoderecho_Click(object sender, EventArgs e)
        {
            try
            {
                ofdialog.InitialDirectory = this.txtdirpredeteminado.Text;
                ofdialog.RestoreDirectory = true;
                ofdialog.Title = "Búsqueda de archivos de imágen";
                ofdialog.DefaultExt = ".png";
                ofdialog.FileName = ".png";
                ofdialog.Filter = "Archivos de Imágen (*.png)|*.png";
                ofdialog.FilterIndex = 1;
                ofdialog.CheckFileExists = true;
                ofdialog.CheckPathExists = true;
                ofdialog.ReadOnlyChecked = true;
                ofdialog.ShowReadOnly = true;

                if (ofdialog.ShowDialog() == DialogResult.OK)
                {
                    pblogoderecho.ImageLocation = ofdialog.FileName;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnagregarseriesfoliacion_Click(object sender, EventArgs e)
        {
            try
            {
                frmseriefoliacion ofrmseriefoliacion = new frmseriefoliacion(0,this._idconfig, this._idusuario,this._connexionstring);
                ofrmseriefoliacion.ShowDialog();
                if (ofrmseriefoliacion.update)
                {
                    cargaseriesfoliacion();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnquitarseriesfoliacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridseriesfoliacion.ActiveRow != null)
                {
                    if (MessageBox.Show("¿Esta seguro de eliminar el documento digital seleccionado?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int idseriefoliacion = Convert.ToInt32(this.gridseriesfoliacion.ActiveRow.Cells["idseriefoliacion"].Value);
                        seriesfoliacion oseriefoliacion = seriefoliacionnc.getseriefoliacion(idseriefoliacion, this._connexionstring);
                        oseriefoliacion.baja = true;
                        seriefoliacionnc.update(oseriefoliacion, this._connexionstring);
                        cargaseriesfoliacion();
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnquitarformatosingresos_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridformatosemitidos.ActiveRow != null)
                {
                    if (MessageBox.Show("¿Esta seguro de eliminar el formato de documentos recibidos?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int idformato = Convert.ToInt32(this.gridformatosemitidos.ActiveRow.Cells["idformato"].Value);
                        formatos oformato = formatonc.getformato(idformato, this._connexionstring);
                        oformato.baja = true;
                        formatonc.update(oformato, this._connexionstring);
                        cargaformatosemitidos();
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnagregarformatosingresos_Click(object sender, EventArgs e)
        {
            try
            {
                frmformato ofrmformato = new frmformato(0, this._idconfig, this._idusuario,genericas.enums.egrupoformatosgeneral.emitidos.ToString(), this._connexionstring);
                ofrmformato.ShowDialog();
                if (ofrmformato.update)
                {
                    cargaformatosemitidos();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnquitarformatosegresos_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridformatosrecibidos.ActiveRow != null)
                {
                    if (MessageBox.Show("¿Esta seguro de eliminar el formato de documentos recibidos?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int idformato = Convert.ToInt32(this.gridformatosrecibidos.ActiveRow.Cells["idformato"].Value);
                        formatos oformato = formatonc.getformato(idformato, this._connexionstring);
                        oformato.baja = true;
                        formatonc.update(oformato, this._connexionstring);
                        cargaformatosrecibidos();
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnagregarformatosegresos_Click(object sender, EventArgs e)
        {
            try
            {
                frmformato ofrmformato = new frmformato(0, this._idconfig, this._idusuario, genericas.enums.egrupoformatosgeneral.recibidos.ToString(), this._connexionstring);
                ofrmformato.ShowDialog();
                if (ofrmformato.update)
                {
                    cargaformatosrecibidos();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridseriesfoliacion_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.gridseriesfoliacion.ActiveRow != null)
                {
                    int idseriefoliacion = Convert.ToInt32(this.gridseriesfoliacion.ActiveRow.Cells["idseriefoliacion"].Value);
                    frmseriefoliacion ofrmseriefoliacion = new frmseriefoliacion(idseriefoliacion, this._idconfig, this._idusuario, this._connexionstring);
                    ofrmseriefoliacion.ShowDialog();
                    if (ofrmseriefoliacion.update)
                    {
                        cargaseriesfoliacion();
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridformatosemitidos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.gridformatosemitidos.ActiveRow != null)
                {
                    int idformato = Convert.ToInt32(this.gridformatosemitidos.ActiveRow.Cells["idformato"].Value);
                    frmformato ofrmformato = new frmformato(idformato, this._idconfig, this._idusuario, genericas.enums.egrupoformatosgeneral.emitidos.ToString(), this._connexionstring);
                    ofrmformato.ShowDialog();
                    if (ofrmformato.update)
                    {
                        cargaformatosemitidos();
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridformatosrecibidos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.gridformatosrecibidos.ActiveRow != null)
                {
                    int idformato = Convert.ToInt32(this.gridformatosrecibidos.ActiveRow.Cells["idformato"].Value);
                    frmformato ofrmformato = new frmformato(idformato, this._idconfig, this._idusuario, genericas.enums.egrupoformatosgeneral.recibidos.ToString(), this._connexionstring);
                    ofrmformato.ShowDialog();
                    if (ofrmformato.update)
                    {
                        cargaformatosrecibidos();
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
