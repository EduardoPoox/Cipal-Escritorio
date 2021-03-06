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

namespace cipal.gestion
{
    public partial class frmapoyodetalle : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _idapoyo;
        private int _iddetapoyo;

        public bool _update = false;

        public detapoyos _odetapoyo;
        public frmapoyodetalle(int idapoyo, int iddetcompra, int idusuario, string connexionstring)
        {
            try
            {
                InitializeComponent();
                this._connexionstring = connexionstring;
                this._idusuario = idusuario;
                this._idapoyo = idapoyo;
                this._iddetapoyo = iddetcompra;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmapoyodetalle_Load(object sender, EventArgs e)
        {
            try
            {
                cargainfo();
                cargaconceptos();
                cargaunidades();
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
                if (this._iddetapoyo > 0)
                {
                    _odetapoyo = detapoyonc.getdetapoyo(this._iddetapoyo, this._connexionstring);
                    this.cmbidconcepto.Value = _odetapoyo.idconcepto;
                    this.txtdescripcion.Text = _odetapoyo.descripcion;
                    this.txtcatidad.Value = Convert.ToDecimal(_odetapoyo.cantidad);
                    this.cmbidunidad.Value = _odetapoyo.idunidad;                   

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
                if (this._iddetapoyo == 0)
                {
                    _odetapoyo = new detapoyos();
                    _odetapoyo.idapoyo = this._idapoyo;
                    

                    _odetapoyo.iddetapoyo = 0;
                    _odetapoyo.idconcepto = Convert.ToInt32(this.cmbidconcepto.Value);
                    _odetapoyo.descripcion = this.txtdescripcion.Text;
                    _odetapoyo.cantidad = Convert.ToDecimal(this.txtcatidad.Value);
                    _odetapoyo.idunidad = Convert.ToInt32(this.cmbidunidad.Value);
                    _odetapoyo.usuario = this._idusuario.ToString();
                    _odetapoyo.baja = false;
                }
                else
                {
                    _odetapoyo.idconcepto = Convert.ToInt32(this.cmbidconcepto.Value);
                    _odetapoyo.descripcion = this.txtdescripcion.Text;
                    _odetapoyo.cantidad = Convert.ToDecimal(this.txtcatidad.Value);
                    _odetapoyo.idunidad = Convert.ToInt32(this.cmbidunidad.Value);
                    _odetapoyo.usuario = this._idusuario.ToString();
                    _odetapoyo.baja = false;
                    
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

        private void gbgeneral_Click(object sender, EventArgs e)
        {

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

        private void cmbidunidad_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbidunidad.Text != "")
                {
                    int idunidad = Convert.ToInt32(this.cmbidunidad.Value);
                    unidades ounidad = unidadnc.getunidad(idunidad, this._connexionstring);
                    this.txtsimbologia.Text = ounidad.simbologia;
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
    }
}
