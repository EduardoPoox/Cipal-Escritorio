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
    public partial class frmempleado : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;

        public bool _update = false;


        public int idempleadonuevo = 0;
        public frmempleado(int id, int idusuario, string connexionstring)
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

        private void frmempleado_Load(object sender, EventArgs e)
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
                    empleados oempledo = empleadonc.getempleado(this._id, this._connexionstring);
                    this.txtnombre.Text = oempledo.nombres;
                    this.txtapellidopaterno.Text = oempledo.apellidopaterno;
                    this.txtapellidomaterno.Text = oempledo.apellidomaterno;
                    this.txtrfc.Text = oempledo.rfc;
                    this.txtcurp.Text = oempledo.curp;
                    this.txtcorreo.Text = oempledo.correo;
                    this.txttelefono.Text = oempledo.telefono;
                    this.txtMovil.Text = oempledo.movil;
                }
                
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void lblrfc_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtnombre_ValueChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtapellidopaterno_ValueChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtapellidomaterno_ValueChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtcurp_ValueChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtcorreo_ValueChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txttelefono_ValueChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMovil_ValueChanged(object sender, EventArgs e)
        {
            try
            {

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
                    empleados oempledo = empleadonc.getempleado(this._id, this._connexionstring);
                    oempledo.nombres = this.txtnombre.Text;
                    oempledo.apellidopaterno = this.txtapellidopaterno.Text;
                    oempledo.apellidomaterno = this.txtapellidomaterno.Text;
                    oempledo.rfc = this.txtrfc.Text;
                    oempledo.curp = this.txtcurp.Text;
                    oempledo.correo = this.txtcorreo.Text;
                    oempledo.telefono = this.txttelefono.Text;
                    oempledo.movil = this.txtMovil.Text;
                    empleadonc.update(oempledo, this._connexionstring);
                }
                else
                {
                    empleados oempledo = new empleados();
                    oempledo.idempleado = empleadonc.getid(this._connexionstring);
                    oempledo.nombres = this.txtnombre.Text;
                    oempledo.apellidopaterno = this.txtapellidopaterno.Text;
                    oempledo.apellidomaterno = this.txtapellidomaterno.Text;
                    oempledo.rfc = this.txtrfc.Text;
                    oempledo.curp = this.txtcurp.Text;
                    oempledo.correo = this.txtcorreo.Text;
                    oempledo.telefono = this.txttelefono.Text;
                    oempledo.movil = this.txtMovil.Text;
                    oempledo.usuario = this._idusuario.ToString();
                    oempledo.baja = false;
                    empleadonc.save(oempledo, this._connexionstring);

                    this.idempleadonuevo = oempledo.idempleado;
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
