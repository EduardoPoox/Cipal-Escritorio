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
    public partial class frmcontribuyente : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;

        public bool _update = false;

        public int idempleadonuevo = 0;
        public frmcontribuyente(int id, int idusuario, string connexionstring)
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

        private void frmcontribuyente_Load(object sender, EventArgs e)
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
                    contribuyentes ocontribuyente = contribuyentenc.getcontribuyentes(this._id, this._connexionstring);
                    this.txtrfc.Text = ocontribuyente.rfc;
                    this.txtnombre.Text = ocontribuyente.nombre;
                    this.txtcorreo.Text = ocontribuyente.correo;
                    this.txttelefono.Text = ocontribuyente.telefono;
                    this.txtcontacto.Text = ocontribuyente.contacto;
                    this.txtmovil.Text = ocontribuyente.movil;
                    this.txtdomicilio.Text = ocontribuyente.domicilio;

                }
                else
                {
                    //REGISTRO EXISTENTE

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
                if(this._id >0)
                {
                    contribuyentes ocontribuyentes = contribuyentenc.getcontribuyentes(this._id, this._connexionstring);
                    ocontribuyentes.rfc = this.txtrfc.Text;
                    ocontribuyentes.nombre = this.txtnombre.Text;
                    ocontribuyentes.correo = this.txtcorreo.Text;
                    ocontribuyentes.telefono = this.txttelefono.Text;
                    ocontribuyentes.contacto = this.txtcontacto.Text;
                    ocontribuyentes.movil = this.txtmovil.Text;
                    ocontribuyentes.domicilio = this.txtdomicilio.Text;
                    contribuyentenc.update(ocontribuyentes, this._connexionstring);
                }
                else
                {
                    contribuyentes ocontribuyentes = new contribuyentes();
                    ocontribuyentes.idcontribuyente = contribuyentenc.getid(this._connexionstring);
                    ocontribuyentes.rfc = this.txtrfc.Text;
                    ocontribuyentes.nombre = this.txtnombre.Text;
                    ocontribuyentes.correo = this.txtcorreo.Text;
                    ocontribuyentes.telefono = this.txttelefono.Text;
                    ocontribuyentes.contacto = this.txtcontacto.Text;
                    ocontribuyentes.movil = this.txtmovil.Text;
                    ocontribuyentes.domicilio = this.txtdomicilio.Text;
                    ocontribuyentes.usuario = this._idusuario.ToString();
                    ocontribuyentes.baja = false;
                    contribuyentenc.save(ocontribuyentes, this._connexionstring);

                    this.idempleadonuevo = ocontribuyentes.idcontribuyente;
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
