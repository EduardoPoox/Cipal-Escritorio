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
    public partial class frmvalorcatastral : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;

        public bool _update = false;
        public frmvalorcatastral(int id, int idusuario, string connexionstring)
        {
            InitializeComponent();
            this._connexionstring = connexionstring;
            this._idusuario = idusuario;
            this._id = id;
        }

        private void frmvalorcatastral_Load(object sender, EventArgs e)
        {
            try
            {
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
                    valorpredial ovalorpredial = valorpredialnc.getvalorpredial(this._id, this._connexionstring);
                    this.txtlimiteinferior.Value = Convert.ToDecimal(ovalorpredial.limiteinferior);
                    this.txtlimitesuperior.Value = Convert.ToDecimal(ovalorpredial.limitesuperior);
                    this.txtcuotafijaanual.Value = Convert.ToDecimal(ovalorpredial.cuotafijanual);
                    this.txtfacturaexcedentelimite.Value = Convert.ToDecimal(ovalorpredial.factorexcedentelimite);

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
                    valorpredial ovalorpredial = valorpredialnc.getvalorpredial(this._id, this._connexionstring);
                    ovalorpredial.limiteinferior = Convert.ToDecimal(this.txtlimiteinferior.Value);
                    ovalorpredial.limitesuperior = Convert.ToDecimal(this.txtlimitesuperior.Value);
                    ovalorpredial.cuotafijanual = Convert.ToDecimal(this.txtcuotafijaanual.Value);
                    ovalorpredial.factorexcedentelimite = Convert.ToDecimal(this.txtfacturaexcedentelimite.Value);
                    valorpredialnc.update(ovalorpredial, this._connexionstring);
                }
                else
                {
                    valorpredial ovalorpredial = new valorpredial();
                    ovalorpredial.idvalorcatastral = valorpredialnc.getid(this._connexionstring);
                    ovalorpredial.limiteinferior = Convert.ToDecimal(this.txtlimiteinferior.Value);
                    ovalorpredial.limitesuperior = Convert.ToDecimal(this.txtlimitesuperior.Value);
                    ovalorpredial.cuotafijanual = Convert.ToDecimal(this.txtcuotafijaanual.Value);
                    ovalorpredial.factorexcedentelimite = Convert.ToDecimal(this.txtfacturaexcedentelimite.Value);
                    //ovalorpredial.usuario = this._idusuario.ToString();
                    //ovalorpredial.baja = false;
                    valorpredialnc.save(ovalorpredial, this._connexionstring);

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
