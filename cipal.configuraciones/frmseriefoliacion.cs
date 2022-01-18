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
    public partial class frmseriefoliacion : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;
        private int _idconfig;

        public bool update = false;
        public frmseriefoliacion(int id, int idconfig, int idusuario, string connexionstring)
        {
            InitializeComponent();
            this._connexionstring = connexionstring;
            this._idusuario = idusuario;
            this._idconfig = idconfig;
            this._id = id;



        }
        private void frmseriefoliacion_Load(object sender, EventArgs e)
        {
            try
            {
                cargatiposerie();

                if (this._id > 0)
                {
                    seriesfoliacion oseriefoliacion = seriefoliacionnc.getseriefoliacion(this._id, this._connexionstring);
                    this.cmbtiposerie.Text = oseriefoliacion.tiposerie;
                    this.txtfolio.Text = oseriefoliacion.serie;
                    this.txtvalorinicial.Value = oseriefoliacion.inicial;
                    this.txtvaloractual.Value = oseriefoliacion.actual;
                    this.chkvigente.Checked = Convert.ToBoolean(oseriefoliacion.vigente);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargatiposerie()
        {
            try
            {
                string[] tiposerie = Enum.GetNames(typeof(genericas.enums.etiposerie));
                this.cmbtiposerie.SetDataBinding(tiposerie, null);
                this.cmbtiposerie.SelectedIndex = 0;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }



        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this._id > 0)
                {
                    seriesfoliacion oseriefoliacion = seriefoliacionnc.getseriefoliacion(this._id, this._connexionstring);
                    oseriefoliacion.tiposerie = this.cmbtiposerie.Value.ToString();
                    oseriefoliacion.serie = this.txtfolio.Text;
                    oseriefoliacion.inicial = Convert.ToInt32(this.txtvalorinicial.Value);
                    oseriefoliacion.actual = Convert.ToInt32(this.txtvaloractual.Value);
                    oseriefoliacion.vigente = this.chkvigente.Checked;
                    oseriefoliacion.baja = false;
                    seriefoliacionnc.update(oseriefoliacion, this._connexionstring);
                }
                else
                {
                    seriesfoliacion oseriefoliacion = new seriesfoliacion();
                    oseriefoliacion.idseriefoliacion = seriefoliacionnc.getid(this._connexionstring);
                    oseriefoliacion.tiposerie = this.cmbtiposerie.Value.ToString();
                    oseriefoliacion.serie = this.txtfolio.Text;
                    oseriefoliacion.inicial = Convert.ToInt32(this.txtvalorinicial.Value);
                    oseriefoliacion.actual = Convert.ToInt32(this.txtvaloractual.Value);
                    oseriefoliacion.vigente = this.chkvigente.Checked;
                    oseriefoliacion.baja = false;
                    seriefoliacionnc.save(oseriefoliacion, this._connexionstring);
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


    }
}
