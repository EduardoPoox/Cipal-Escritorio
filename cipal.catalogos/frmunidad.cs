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
    public partial class frmunidad : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;

        public bool _update = false;

        public int idunidadnuevo;
        public frmunidad(int id, int idusuario, string connexionstring)
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

        private void frmunidad_Load(object sender, EventArgs e)
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
                    unidades ounidad = unidadnc.getunidad(this._id, this._connexionstring);
                    this.txtnombre.Text = ounidad.nombre;
                    this.txtcvunidad.Text = ounidad.cveunidad;
                    this.txtsimbologia.Text = ounidad.simbologia;
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
                    unidades ounidad = unidadnc.getunidad(this._id, this._connexionstring);
                    ounidad.nombre = this.txtnombre.Text;
                    ounidad.cveunidad = this.txtcvunidad.Text;
                    ounidad.simbologia = this.txtsimbologia.Text;
                    ounidad.usuario = this._idusuario.ToString();
                    unidadnc.update(ounidad, this._connexionstring);
                }
                else
                {
                    unidades ounidad = new unidades();
                    ounidad.idunidad = unidadnc.getid(this._connexionstring);
                    ounidad.nombre = this.txtnombre.Text;
                    ounidad.cveunidad = this.txtcvunidad.Text;
                    ounidad.simbologia = this.txtsimbologia.Text;
                    ounidad.usuario = this._idusuario.ToString();
                    ounidad.baja = false;
                    unidadnc.save(ounidad, this._connexionstring);


                    this.idunidadnuevo = ounidad.idunidad;
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
