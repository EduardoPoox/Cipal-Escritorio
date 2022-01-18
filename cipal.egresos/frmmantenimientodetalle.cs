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
    public partial class frmmantenimientodetalle : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _idmantenimiento;
        private int _iddetmantenimiento;

        public bool _update = false;

        public detmantenimientos _odetmantenimiento;
        public frmmantenimientodetalle(int idmantenimiento,int iddetmantenimiento, int idusuario, string connexionstring)
        {
            try
            {
                InitializeComponent();
                this._connexionstring = connexionstring;
                this._idusuario = idusuario;
                this._idmantenimiento = idmantenimiento;
                this._iddetmantenimiento = iddetmantenimiento;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmmantenimiento_Load(object sender, EventArgs e)
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
                this.cmbconceptos.SetDataBinding(olistconceptos, null);
                this.cmbconceptos.ValueMember = "idconcepto";
                this.cmbconceptos.DisplayMember = "nombre";
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
                this.cmbunidades.SetDataBinding(olistunidades, null);
                this.cmbunidades.ValueMember = "idunidad";
                this.cmbunidades.DisplayMember = "nombre";
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
                if (this._iddetmantenimiento > 0)
                {
                    _odetmantenimiento = detmantenimientonc.getdetmantenimiento(this._iddetmantenimiento, this._connexionstring);

                    this.cmbconceptos.Value = _odetmantenimiento.idconcepto;
                    this.cmbunidades.Value = _odetmantenimiento.idunidad;
                    this.txtcantidad.Value = _odetmantenimiento.cantidad;
                    this.txtdescripcion.Text = _odetmantenimiento.descripcion;
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
                if (this._iddetmantenimiento > 0)
                {
                    _odetmantenimiento = detmantenimientonc.getdetmantenimiento(this._iddetmantenimiento, this._connexionstring);
                    _odetmantenimiento.idconcepto = Convert.ToInt32( this.cmbconceptos.Value);
                    _odetmantenimiento.idunidad = Convert.ToInt32( this.cmbunidades.Value);
                    _odetmantenimiento.cantidad = Convert.ToDecimal( this.txtcantidad.Value);
                    _odetmantenimiento.descripcion = this.txtdescripcion.Text;
                }
                else
                {
                    _odetmantenimiento = new detmantenimientos();
                    _odetmantenimiento.idmantenimiento = _idmantenimiento;
                    _odetmantenimiento.iddetmantenimiento = detmantenimientonc.getid(this._connexionstring);
                    _odetmantenimiento.idconcepto = Convert.ToInt32(this.cmbconceptos.Value);
                    _odetmantenimiento.idunidad = Convert.ToInt32(this.cmbunidades.Value);
                    _odetmantenimiento.cantidad = Convert.ToDecimal(this.txtcantidad.Value);
                    _odetmantenimiento.descripcion = this.txtdescripcion.Text;
                    _odetmantenimiento.usuario = this._idusuario.ToString();
                    _odetmantenimiento.baja = false;
                    
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

        private void btnagregarunidad_Click(object sender, EventArgs e)
        {

        }

        private void btnagregarconcepto_Click(object sender, EventArgs e)
        {

        }
    }
}
