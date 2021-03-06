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
    public partial class frmconfdapempleado : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;

        public bool _update = false;
        public frmconfdapempleado(int id, int idusuario, string connexionstring)
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

        private void frmconfdapempleado_Load(object sender, EventArgs e)
        {
            try
            {
                cargainfo();
                cargadepartamento();
                cargaempleado();
                cargapuesto();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargadepartamento()
        {
            try
            {
                List<departamentos> olistdepartamentos = departamentonc.getdepartamentos(this._connexionstring);
                this.cmbiddepartamento.SetDataBinding(olistdepartamentos, null);
                this.cmbiddepartamento.ValueMember = "iddepartamento";
                this.cmbiddepartamento.DisplayMember = "nombre";
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void cargaempleado()
        {
            try
            {
                List<empleados> olistempleados = empleadonc.getempleados(this._connexionstring);
                foreach (empleados oempleado in olistempleados)
                {
                    oempleado.nombres = oempleado.nombres + " " + oempleado.apellidopaterno + " " + oempleado.apellidomaterno;
                }
                this.cmbidempleado.SetDataBinding(olistempleados, null);
                this.cmbidempleado.ValueMember = "idempleado";
                this.cmbidempleado.DisplayMember = "nombres";
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void cargapuesto()
        {
            try
            {
                List<puestos> olistpuestos = puestonc.getpuestos(this._connexionstring);
                this.cmbidpuesto.SetDataBinding(olistpuestos, null);
                this.cmbidpuesto.ValueMember = "idpuesto";
                this.cmbidpuesto.DisplayMember = "nombre";
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
                if (this._id > 0)
                {
                    confdapempleados oconfdapempleados = confdapempleadonc.getconfdaempleado(this._id, this._connexionstring);
                    this.cmbidempleado.Value = oconfdapempleados.idempleado;
                    this.cmbiddepartamento.Value = oconfdapempleados.iddepartamento;
                    this.cmbidpuesto.Value = oconfdapempleados.idpuesto;
                    this.dtfecha.DateTime = (DateTime)oconfdapempleados.fecha;
                    this.txtobservaciones.Text = oconfdapempleados.observaciones;
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
                    confdapempleados oconfdapempleado = confdapempleadonc.getconfdaempleado(this._id, this._connexionstring);
                    oconfdapempleado.idempleado = Convert.ToInt32(this.cmbidempleado.Value);
                    oconfdapempleado.iddepartamento = Convert.ToInt32(this.cmbiddepartamento.Value);
                    oconfdapempleado.idpuesto = Convert.ToInt32(this.cmbidpuesto.Value);
                    oconfdapempleado.fecha = this.dtfecha.DateTime;
                    oconfdapempleado.observaciones = this.txtobservaciones.Text;
                    oconfdapempleado.estatus = genericas.enums.econfigpuestosempleadosestatus.vigente.ToString();
                    confdapempleadonc.update(oconfdapempleado, this._connexionstring);

                }
                else
                {
                    confdapempleados oconfdapempleado = new confdapempleados();
                    oconfdapempleado.idconfdapempleado = confdapempleadonc.getid(this._connexionstring);
                    oconfdapempleado.idempleado = Convert.ToInt32(this.cmbidempleado.Value);
                    oconfdapempleado.iddepartamento = Convert.ToInt32(this.cmbiddepartamento.Value);
                    oconfdapempleado.idpuesto = Convert.ToInt32(this.cmbidpuesto.Value);
                    oconfdapempleado.fecha = this.dtfecha.DateTime;
                    oconfdapempleado.observaciones = this.txtobservaciones.Text;
                    oconfdapempleado.estatus = genericas.enums.econfigpuestosempleadosestatus.vigente.ToString();
                    oconfdapempleado.usuario = this._idusuario.ToString();
                    oconfdapempleado.baja = false;
                    confdapempleadonc.save(oconfdapempleado, this._connexionstring);

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

        private void btnagregarempleado_Click(object sender, EventArgs e)
        {
            try
            {
                frmempleado ofrmempleado = new frmempleado(0, this._idusuario, this._connexionstring);
                ofrmempleado.ShowDialog();
                if (ofrmempleado._update)
                {
                    cargaempleado();
                    this.cmbidempleado.Value = ofrmempleado.idempleadonuevo;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnagregardepartamento_Click(object sender, EventArgs e)
        {
            try
            {
                frmdepartamento ofrmdepartamento = new frmdepartamento(0, this._idusuario, this._connexionstring);
                ofrmdepartamento.ShowDialog();
                if (ofrmdepartamento._update)
                {
                    cargadepartamento();
                    this.cmbiddepartamento.Value = ofrmdepartamento.iddepartamentonuevo;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnagregarpuesto_Click(object sender, EventArgs e)
        {
            try
            {
                frmpuesto ofrmpuesto = new frmpuesto(0, this._idusuario, this._connexionstring);
                ofrmpuesto.ShowDialog();
                if (ofrmpuesto._update)
                {
                    cargapuesto();
                    this.cmbidpuesto.Value = ofrmpuesto.idpuestonuevo;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
