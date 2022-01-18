using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using cipal.catalogos;
using cipal.entidades;
using cipal.negocios;

namespace cipal.egresos
{
    public partial class frmsolicituddetalle : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _idsolicitud;
        private int _iddetsolicitud;

        public bool _update = false;

        public detsolicitudes _odetsolicitud;
        public frmsolicituddetalle(int idsolicitud, int iddetsolicitud, int idusuario, string connexionstring)
        {
            try
            {
                InitializeComponent();
                this._connexionstring = connexionstring;
                this._idusuario = idusuario;
                this._idsolicitud = idsolicitud;
                this._iddetsolicitud = idsolicitud;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmsolicitudcompradetalle_Load(object sender, EventArgs e)
        {
            try
            {
                cargainfo();
                cargaconceptos();
                cargaunidades();
                cmbidconcepto.ValueChanged += cmbconcepto_ValueChanged;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbconcepto_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbidconcepto.Value != null)
                {
                    int idconcepto = Convert.ToInt32(cmbidconcepto.Value);
                    txtdescripcion.Text = cmbidconcepto.Text;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargaconceptos()
        {
            try
            {
                List<conceptos> olistconceptos = conceptonc.getconceptos(this._connexionstring);
                this.cmbidconcepto.SetDataBinding(olistconceptos, null);
                this.cmbidconcepto.ValueMember = "idconcepto";
                this.cmbidconcepto.DisplayMember = "nombre";
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void cargaunidades()
        {
            try
            {
                List<unidades> olistunidades = unidadnc.getunidades(this._connexionstring);
                this.cmbidunidad.SetDataBinding(olistunidades, null);
                this.cmbidunidad.ValueMember = "idunidad";
                this.cmbidunidad.DisplayMember = "nombre";
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void cargainfo()
        {
            try
            {
                if (this._iddetsolicitud > 0)
                {
                    _odetsolicitud = detsolicitudnc.getdetsolicitud(this._iddetsolicitud, this._connexionstring);
                    this.cmbidconcepto.Value = _odetsolicitud.idconcepto;
                    this.txtdescripcion.Text = _odetsolicitud.descripcion;
                    this.txtcantidad.Value = Convert.ToDecimal(_odetsolicitud.cantidad);
                    this.cmbidunidad.Value = _odetsolicitud.idunidad;

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
                if (this._iddetsolicitud == 0)
                {
                    _odetsolicitud = new detsolicitudes();
                    _odetsolicitud.idsolicitud = this._idsolicitud;

                    _odetsolicitud.iddetsolicitud = 0;
                    _odetsolicitud.idconcepto = Convert.ToInt32(this.cmbidconcepto.Value);
                    _odetsolicitud.idunidad = Convert.ToInt32(this.cmbidunidad.Value);
                    _odetsolicitud.cantidad = Convert.ToDecimal(this.txtcantidad.Value);
                    _odetsolicitud.descripcion = this.txtdescripcion.Text;
                    _odetsolicitud.usuario = this._idusuario.ToString();
                    _odetsolicitud.baja = false;
                }
                else
                {
                    _odetsolicitud.idconcepto = Convert.ToInt32(this.cmbidconcepto.Value);
                    _odetsolicitud.idunidad = Convert.ToInt32(this.cmbidunidad.Value);
                    _odetsolicitud.cantidad = Convert.ToDecimal(this.txtcantidad.Value);
                    _odetsolicitud.descripcion = this.txtdescripcion.Text;
                    _odetsolicitud.usuario = this._idusuario.ToString();
                    _odetsolicitud.baja = false;
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

        private void btnagregarconcepto_Click(object sender, EventArgs e)
        {
            try
            {
                frmconcepto ofrmconcepto = new frmconcepto(0, this._idusuario, this._connexionstring);
                ofrmconcepto.ShowDialog();
                if (ofrmconcepto._update)
                {
                    cargaconceptos();
                    this.cmbidconcepto.Value = ofrmconcepto.idconceptonuevo;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnagregarunidad_Click(object sender, EventArgs e)
        {
            try
            {
                frmunidad ofrmunidad = new frmunidad(0, this._idusuario, this._connexionstring);
                ofrmunidad.ShowDialog();
                if (ofrmunidad._update)
                {
                    cargaunidades();
                    this.cmbidunidad.Value = ofrmunidad.idunidadnuevo;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbidconcepto_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbidconcepto.Text != "")
                {
                    int idconcepto = Convert.ToInt32(this.cmbidconcepto.Value);
                    conceptos oconcepto = conceptonc.getconcepto(idconcepto, this._connexionstring);
                    this.cmbidunidad.Value = oconcepto.idunidad;
                    this.txtdescripcion.Text = oconcepto.nombre;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

