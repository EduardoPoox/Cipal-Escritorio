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

namespace cipal.catalogos
{
    public partial class frmbeneficiario : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;

        public bool _update = false;

        public int idbeneficiarionuevo;
        public frmbeneficiario(int id, int idusuario, string connexionstring)
        {
            try
            {
                InitializeComponent();
                this._connexionstring = connexionstring;
                this._idusuario = idusuario;
                this._id = id;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmbeneficiario_Load(object sender, EventArgs e)
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
                    beneficiarios obeneficiario = beneficiarionc.getbeneficiario(this._id, this._connexionstring);
                    this.txtrfc.Text = obeneficiario.rfc;
                    this.txtnombre.Text = obeneficiario.nombre;
                    this.txtcorreo.Text = obeneficiario.correo;
                    this.txttelefono.Text = obeneficiario.telefono;
                    this.txtcontacto.Text = obeneficiario.contacto;
                    this.txtMovil.Text = obeneficiario.movil;
                    this.txtcurp.Text = obeneficiario.curp;
                    this.txtine.Text = obeneficiario.ine;
                    this.txtdomicilio.Text = obeneficiario.domicilio;

                }
                
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnquitar_Click(object sender, EventArgs e)
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

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this._id > 0)
                {
                    beneficiarios obeneficiarios = beneficiarionc.getbeneficiario(this._id, this._connexionstring);
                    obeneficiarios.rfc = this.txtrfc.Text;
                    obeneficiarios.nombre = this.txtnombre.Text;
                    obeneficiarios.correo = this.txtcorreo.Text;
                    obeneficiarios.telefono = this.txttelefono.Text;
                    obeneficiarios.contacto = this.txtcontacto.Text;
                    obeneficiarios.movil = this.txtMovil.Text;
                    obeneficiarios.curp = this.txtcurp.Text;
                    obeneficiarios.ine = this.txtine.Text;
                    obeneficiarios.domicilio = this.txtdomicilio.Text;
                    beneficiarionc.update(obeneficiarios, this._connexionstring);
                }
                else
                {
                    beneficiarios obeneficiarios = new beneficiarios();
                    obeneficiarios.idbeneficiario = beneficiarionc.getid(this._connexionstring);
                    obeneficiarios.rfc = this.txtrfc.Text;
                    obeneficiarios.nombre = this.txtnombre.Text;
                    obeneficiarios.correo = this.txtcorreo.Text;
                    obeneficiarios.telefono = this.txttelefono.Text;
                    obeneficiarios.contacto = this.txtcontacto.Text;
                    obeneficiarios.movil = this.txtMovil.Text;
                    obeneficiarios.curp = this.txtcurp.Text;
                    obeneficiarios.ine = this.txtine.Text;
                    obeneficiarios.domicilio = this.txtdomicilio.Text;
                    obeneficiarios.usuario = this._idusuario.ToString();
                    obeneficiarios.baja = false;
                    beneficiarionc.save(obeneficiarios, this._connexionstring);

                    this.idbeneficiarionuevo = obeneficiarios.idbeneficiario;
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

        private void gbgeneral_Click(object sender, EventArgs e)
        {

        }

    }
}
