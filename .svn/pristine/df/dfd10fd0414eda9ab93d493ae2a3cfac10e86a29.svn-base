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

namespace cipal.ingresos
{
    public partial class frmcobropredial : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;

        public bool _update = false;
        public frmcobropredial(int id, int idusuario, string connexionstring)
        {
            InitializeComponent();
            this._connexionstring = connexionstring;
            this._idusuario = idusuario;
            this._id = id;
        }

        private void frmcobropredial_Load(object sender, EventArgs e)
        {
            try
            {
                List<contribuyentes> olistcontribuyentes = contribuyentenc.getcontribuyentes(this._connexionstring);
                this.cmbidcontribuyente.SetDataBinding(olistcontribuyentes, null);
                this.cmbidcontribuyente.ValueMember = "idcontribuyente";
                this.cmbidcontribuyente.DisplayMember = "nombre";

                cargainfo();
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
                if (this._id > 0)
                {
                    cobropredial ocobropredial = cobropredialnc.getcobropredial(this._id, this._connexionstring);
                    this.cmbidcontribuyente.Value = ocobropredial.idcontribuyente;
                    this.txtvalorcatastral.Value = Convert.ToDecimal(ocobropredial.valorcatrastral);
                    this.txtlimiteinferior.Value = Convert.ToDecimal(ocobropredial.limiteinferior);
                    this.txtfactorexcedentelimite.Value = Convert.ToDecimal(ocobropredial.factorexcedentelimite);
                    this.txtcuotafija.Value = Convert.ToDecimal(ocobropredial.cuotafija);
                    this.txttotal.Value = Convert.ToDecimal(ocobropredial.total);
                }

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
                    cobropredial ocobropredial = cobropredialnc.getcobropredial(this._id, this._connexionstring);
                    ocobropredial.idcontribuyente = Convert.ToInt32(this.cmbidcontribuyente.Value);
                    ocobropredial.valorcatrastral = Convert.ToDecimal(this.txtvalorcatastral.Value);
                    ocobropredial.limiteinferior = Convert.ToDecimal(this.txtlimiteinferior.Value);
                    ocobropredial.factorexcedentelimite = Convert.ToDecimal(this.txtfactorexcedentelimite.Value);
                    ocobropredial.cuotafija = Convert.ToDecimal(this.txtcuotafija.Value);
                    ocobropredial.total = Convert.ToDecimal(this.txttotal.Value);
                    cobropredialnc.update(ocobropredial, this._connexionstring);
                }
                else
                {
                    cobropredial ocobropredial = new cobropredial();
                    ocobropredial.idcobropredial = cobropredialnc.getid(this._connexionstring);
                    ocobropredial.idcontribuyente = Convert.ToInt32(this.cmbidcontribuyente.Value);
                    ocobropredial.valorcatrastral = Convert.ToDecimal(this.txtvalorcatastral.Value);
                    ocobropredial.limiteinferior = Convert.ToDecimal(this.txtlimiteinferior.Value);
                    ocobropredial.factorexcedentelimite = Convert.ToDecimal(this.txtfactorexcedentelimite.Value);
                    ocobropredial.cuotafija = Convert.ToDecimal(this.txtcuotafija.Value);
                    ocobropredial.total = Convert.ToDecimal(this.txttotal.Value);
                    //ocobropredial.usuario = this._idusuario.ToString();
                    //ocobropredial.baja = false;
                    cobropredialnc.save(ocobropredial, this._connexionstring);

                }
                this._update = true;
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
