using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using cipal.entidades;
using cipal.negocios;

namespace cipal.configuraciones
{
    public partial class frmformato : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;
        private int _idconfig;
        private string _grupogeneral;

        public bool update = false;
        public frmformato(int id, int idconfig, int idusuario, string grupogeneral, string connexionstring)
        {
            InitializeComponent();
            this._connexionstring = connexionstring;
            this._idusuario = idusuario;
            this._idconfig = idconfig;
            this._id = id;
            this._grupogeneral = grupogeneral;


            if (this._grupogeneral == "emitidos")
            {
                this.cmbtipoformato.Enabled = false;
            }
            else
            {
                this.cmbtipoformato.Enabled = true;
            }



            if (this._idconfig > 0)
            {
                parametros oconfig = parametronc.getparametro(this._idconfig, this._connexionstring);
                this.txtdirectorioformato.Text = oconfig.dirinformes;
            }

           
        }

        private void frmformato_Load(object sender, EventArgs e)
        {
            try
            {
                cargagrupoformatogeneral();
                cargatiposformatos();

                this.cmbgrupogeneral.Text = this._grupogeneral;
                if (this._id > 0)
                {
                    formatos oformato = formatonc.getformato(this._id, this._connexionstring);
                    this.cmbgrupogeneral.Text = oformato.tipogeneral;
                    this.cmbgrupoformato.Text = oformato.clasificador;
                    this.cmbtipoformato.Text = oformato.tipo;
                    this.txtnombreformato.Text = oformato.nombre;
                    this.chkvigente.Checked =Convert.ToBoolean( oformato.vigente);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargagrupoformatogeneral()
        {
            try
            {
                string[] grupoformatosgeneral = Enum.GetNames(typeof(genericas.enums.egrupoformatosgeneral));
                this.cmbgrupogeneral.SetDataBinding(grupoformatosgeneral,null);
                this.cmbgrupogeneral.SelectedIndex = 0;

                cargagrupoformato(this.cmbgrupogeneral.Text);

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        private void cargagrupoformato(string grupogeneral)
        {
            try
            {
                string[] grupoformatos; 

                if (grupogeneral == "emitidos")
                {
                    grupoformatos = Enum.GetNames(typeof(genericas.enums.egrupoformatoemitido));
                }
                else
                {
                    grupoformatos = Enum.GetNames(typeof(genericas.enums.egrupoformatorecibido));
                }

                this.cmbgrupoformato.SetDataBinding(grupoformatos, null);
                this.cmbgrupoformato.SelectedIndex = 0;

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        private void cargatiposformatos()
        {
            try
            {
                string[] tiposformatos = Enum.GetNames(typeof(genericas.enums.etipoformato));
                this.cmbtipoformato.SetDataBinding(tiposformatos,null);
                this.cmbtipoformato.SelectedIndex = 0;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        private void btnbuscarformato_Click(object sender, EventArgs e)
        {
            try
            {
                ofdialog.InitialDirectory = this.txtdirectorioformato.Text;
                ofdialog.RestoreDirectory = true;
                ofdialog.Title = "Búsqueda de archivos";
                ofdialog.DefaultExt = ".rpt";
                ofdialog.FileName = ".rpt";
                ofdialog.Filter = "Archivos de Reporte de Crystal Report (*.rpt)|*.rpt";
                ofdialog.FilterIndex = 1;
                ofdialog.CheckFileExists = true;
                ofdialog.CheckPathExists = true;
                ofdialog.ReadOnlyChecked = true;
                ofdialog.ShowReadOnly = true;

                if (ofdialog.ShowDialog() == DialogResult.OK)
                {


                    string file = ofdialog.FileName;
                    string filedestino = this.txtdirectorioformato.Text.Trim() + @"\" + file.Split('\\')[file.Split('\\').Length - 1];
                    System.IO.File.Copy(file, filedestino,true);


                    this.txtnombreformato.Text = filedestino.Split('\\')[filedestino.Split('\\').Length - 1];
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
                if (this._id > 0)
                {
                    formatos oformato = formatonc.getformato(this._id, this._connexionstring);
                    oformato.tipogeneral = this.cmbgrupogeneral.Text;
                    oformato.clasificador = this.cmbgrupoformato.Text;
                    oformato.tipo = this.cmbtipoformato.Text;
                    oformato.nombre = this.txtnombreformato.Text;
                    oformato.vigente = Convert.ToBoolean(this.chkvigente.Checked);

                    formatonc.update(oformato, this._connexionstring);
                }
                else
                {
                    formatos oformato = new formatos();
                    oformato.idformato = formatonc.getid(this._connexionstring);
                    oformato.tipogeneral = this.cmbgrupogeneral.Text;
                    oformato.clasificador = this.cmbgrupoformato.Text;
                    oformato.tipo = this.cmbtipoformato.Text;
                    oformato.nombre = this.txtnombreformato.Text;
                    oformato.vigente = Convert.ToBoolean(this.chkvigente.Checked);
                    oformato.baja = false;
                    formatonc.save(oformato, this._connexionstring);
                }

                this.update = true;
                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void cmbgrupogeneral_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                cargagrupoformato(this.cmbgrupogeneral.Value.ToString());
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
