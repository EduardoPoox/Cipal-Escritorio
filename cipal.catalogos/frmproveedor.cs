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
    public partial class frmproveedor : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;

        public bool _update = false;

        public int idproveedornuevo = 0;
        public frmproveedor(int id, int idusuario, string connexionstring)
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

        private void frmprovedor_Load(object sender, EventArgs e)
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
                    proveedores oproveedores = proveedornc.getproveedor(this._id, this._connexionstring);
                    this.txtrfc.Text = oproveedores.rfc;
                    this.txtnombre.Text = oproveedores.nombre;
                    this.txtcorreo.Text = oproveedores.correo;
                    this.txttelefono.Text = oproveedores.telefono;
                    this.txtcontacto.Text = oproveedores.contacto;
                    this.txtmovil.Text = oproveedores.movil;
                    this.txtdomicilio.Text = oproveedores.domicilio;
                }

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        private void lbltelefono_Click(object sender, EventArgs e)
        {

        }

        private void ultraTextEditor1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void gbgeneral_Click(object sender, EventArgs e)
        {

        }

        private void btnagregar_Click(object sender, EventArgs e)
        {

        }

       
        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this._id > 0)
                {
                    proveedores oproveedores = proveedornc.getproveedor(this._id, this._connexionstring);
                    oproveedores.rfc = this.txtrfc.Text;
                    oproveedores.nombre = this.txtnombre.Text;
                    oproveedores.correo = this.txtcorreo.Text;
                    oproveedores.telefono = this.txttelefono.Text;
                    oproveedores.contacto = this.txtcontacto.Text;
                    oproveedores.movil = this.txtmovil.Text;
                    oproveedores.domicilio = this.txtdomicilio.Text;
                    proveedornc.update(oproveedores, this._connexionstring);
                }
                else
                {
                    proveedores oproveedores = new proveedores();
                    oproveedores.idproveedor = proveedornc.getid(this._connexionstring);
                    oproveedores.rfc = this.txtrfc.Text;
                    oproveedores.nombre = this.txtnombre.Text;
                    oproveedores.correo = this.txtcorreo.Text;
                    oproveedores.telefono = this.txttelefono.Text;
                    oproveedores.contacto = this.txtcontacto.Text;
                    oproveedores.movil = this.txtmovil.Text;
                    oproveedores.domicilio = this.txtdomicilio.Text;
                    oproveedores.usuario = this._idusuario.ToString();
                    oproveedores.baja = false;
                    proveedornc.save(oproveedores, this._connexionstring);

                    this.idproveedornuevo = oproveedores.idproveedor;
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
