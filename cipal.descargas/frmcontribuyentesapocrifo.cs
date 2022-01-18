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

namespace cipal.descargas
{
    public partial class frmcontribuyentesapocrifo : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;

        public bool _update = false;
        public frmcontribuyentesapocrifo(int id, int idusuario, string connexionstring)
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

        private void frmcontribuyentesapocrifo_Load(object sender, EventArgs e)
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
                    contribuyentesapocrifos ocontribuyentesapocrifos = contribuyentesapocrifonc.getcontribuyentesapocrifo(this._id, this._connexionstring);
                    this.txtrfc.Text = ocontribuyentesapocrifos.rfc;
                    this.txtnombre.Text = ocontribuyentesapocrifos.nombre;
                    this.txtsituacion.Text = ocontribuyentesapocrifos.situacion;
                    this.txtoficiosat.Text = ocontribuyentesapocrifos.oficiosat;
                    this.dtfechasat.DateTime = (DateTime)ocontribuyentesapocrifos.fechasat;
                    this.txtoficiodof.Text = ocontribuyentesapocrifos.oficiodof;
                    this.dtfechadof.DateTime = (DateTime)ocontribuyentesapocrifos.fechadof;

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
                if (this._id >0)
                {
                    contribuyentesapocrifos ocontribuyentesapocrifo = contribuyentesapocrifonc.getcontribuyentesapocrifo(this._id, this._connexionstring);
                    ocontribuyentesapocrifo.rfc = this.txtrfc.Text;
                    ocontribuyentesapocrifo.nombre = this.txtnombre.Text;
                    ocontribuyentesapocrifo.situacion = this.txtsituacion.Text;
                    ocontribuyentesapocrifo.oficiosat = this.txtoficiosat.Text;
                    ocontribuyentesapocrifo.fechasat = this.dtfechasat.DateTime;
                    ocontribuyentesapocrifo.oficiodof = this.txtoficiodof.Text;
                    ocontribuyentesapocrifo.fechadof = this.dtfechadof.DateTime;
                    contribuyentesapocrifonc.update(ocontribuyentesapocrifo, this._connexionstring);
                }
                else
                {
                    contribuyentesapocrifos ocontribuyentesapocrifos = new contribuyentesapocrifos();
                    ocontribuyentesapocrifos.idcontribuyenteapocrifo = contribuyentesapocrifonc.getid(this._connexionstring);
                    ocontribuyentesapocrifos.rfc = this.txtrfc.Text;
                    ocontribuyentesapocrifos.nombre = this.txtnombre.Text;
                    ocontribuyentesapocrifos.situacion = this.txtsituacion.Text;
                    ocontribuyentesapocrifos.oficiosat = this.txtoficiosat.Text;
                    ocontribuyentesapocrifos.fechasat = this.dtfechasat.DateTime;
                    ocontribuyentesapocrifos.oficiodof = this.txtoficiodof.Text;
                    ocontribuyentesapocrifos.fechadof = this.dtfechadof.DateTime;
                    ocontribuyentesapocrifos.usuario = this._idusuario.ToString();
                    ocontribuyentesapocrifos.baja = false;
                    contribuyentesapocrifonc.save(ocontribuyentesapocrifos, this._connexionstring);
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
