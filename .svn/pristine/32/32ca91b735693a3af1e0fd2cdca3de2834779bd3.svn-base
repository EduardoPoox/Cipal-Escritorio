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

namespace cipal.ingresos
{
    public partial class frmregistroingreso : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _idconfig;
        private int _id;

        public bool _update = false;

        seriesfoliacion oseriesfoliacion = null;
        public frmregistroingreso(int id, int idconfig,int idusuario, string connexionstring)
        {
            InitializeComponent();
            this._connexionstring = connexionstring;
            this._idusuario = idusuario;
            this._id = id;
            this._idconfig = idconfig;
        }

        private void frmingreso_Load(object sender, EventArgs e)
        {
            try
            {
                cargainfo();
                cargacontribuyente();
                cargatipoingreso();
                cargaempleado();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargacontribuyente()
        {
            try
            {
                List<contribuyentes> olistcontribuyentes = contribuyentenc.getcontribuyentes(this._connexionstring);
                this.cmbidcontribuyente.SetDataBinding(olistcontribuyentes, null);
                this.cmbidcontribuyente.ValueMember = "idcontribuyente";
                this.cmbidcontribuyente.DisplayMember = "nombre";
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void cargatipoingreso()
        {
            try
            {
                List<tipoingresos> olisttipoingresos = tipoingresonc.gettipoingresos(this._connexionstring);
                this.cmbtipoingreso.SetDataBinding(olisttipoingresos, null);
                this.cmbtipoingreso.ValueMember = "idtipoingreso";
                this.cmbtipoingreso.DisplayMember = "nombre";
                this.cmbtipoingreso.Value = genericas.enums.etipoingreso.predial.ToString();
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
                this.cmbidempleado.SetDataBinding(olistempleados, null);
                this.cmbidempleado.ValueMember = "idempleado";
                this.cmbidempleado.DisplayMember = "nombres";
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
                    cipal.entidades.ingresos oingreso = cipal.negocios.ingresonc.getingreso(this._id, this._connexionstring);
                    this.txtfolio.Text = oingreso.folio;
                    this.dtfecha.DateTime = (DateTime)oingreso.fecha;
                    this.cmbidcontribuyente.Value = oingreso.idcontribuyente;
                    this.cmbtipoingreso.Value = oingreso.tipoingreso;
                    this.cmbidempleado.Value = oingreso.idempleado;
                    this.txtdescripcion.Text = oingreso.descripcion;
                    this.txtimporte.Value = Convert.ToDecimal(oingreso.importe);

                    txtfolio.Text = oseriesfoliacion.serie.ToUpper() + (oseriesfoliacion.actual + 1).ToString().PadLeft(4, '0');

                }

                this.cmbidtipoingreso_ValueChanged(null, null);
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
                    cipal.entidades.ingresos oingreso = cipal.negocios.ingresonc.getingreso(this._id, this._connexionstring);
                    oingreso.folio = this.txtfolio.Text;
                    oingreso.fecha = this.dtfecha.DateTime;
                    oingreso.idcontribuyente = Convert.ToInt32(this.cmbidcontribuyente.Value);
                    oingreso.idtipoingreso = Convert.ToInt32( this.cmbtipoingreso.Value);
                    oingreso.tipoingreso = this.cmbtipoingreso.Text.ToString();
                    oingreso.idempleado = Convert.ToInt32(this.cmbidempleado.Value);
                    oingreso.descripcion = this.txtdescripcion.Text;
                    oingreso.importe = Convert.ToDecimal(this.txtimporte.Value);
                    ingresonc.update(oingreso, this._connexionstring);
                }
                else
                {
                    cipal.entidades.ingresos oingreso = new cipal.entidades.ingresos();
                    oingreso.idingreso = ingresonc.getid(this._connexionstring);
                    oingreso.folio = this.txtfolio.Text;
                    oingreso.fecha = this.dtfecha.DateTime;
                    oingreso.idcontribuyente = Convert.ToInt32(this.cmbidcontribuyente.Value);
                    oingreso.idtipoingreso = Convert.ToInt32(this.cmbtipoingreso.Value);
                    oingreso.tipoingreso = this.cmbtipoingreso.Text.ToString();
                    oingreso.idempleado = Convert.ToInt32(this.cmbidempleado.Value);
                    oingreso.descripcion = this.txtdescripcion.Text;
                    oingreso.importe = Convert.ToDecimal(this.txtimporte.Value); 
                    oingreso.usuario = this._idusuario.ToString();
                    oingreso.baja = false;
                    ingresonc.save(oingreso, this._connexionstring);

                    oseriesfoliacion.actual = (oseriesfoliacion.actual + 1);
                    seriefoliacionnc.update(oseriesfoliacion, this._connexionstring);

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

        private void btnagregarcontribuyente_Click(object sender, EventArgs e)
        {
            try
            {
                frmcontribuyente ofrmcontribuyente = new frmcontribuyente(0, this._idusuario, this._connexionstring);
                ofrmcontribuyente.ShowDialog();
                if (ofrmcontribuyente._update)
                {
                    cargacontribuyente();
                    this.cmbidcontribuyente.Value = ofrmcontribuyente.idempleadonuevo;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btncambiarfolio_Click(object sender, EventArgs e)
        {
            try
            {
                string tiposerieingreso = this.cmbtipoingreso.Text.Trim();
                frmcambiarseriedefoliacion ofrmcambiarseriefoliacion = new frmcambiarseriedefoliacion(this._id, this._idconfig, this._idusuario,tiposerieingreso, this._connexionstring);
                ofrmcambiarseriefoliacion.ShowDialog();
                if (ofrmcambiarseriefoliacion.ok)
                {
                    oseriesfoliacion = seriefoliacionnc.getseriefoliacion(ofrmcambiarseriefoliacion.idseriefoliacion, this._connexionstring);

                    txtfolio.Text = oseriesfoliacion.serie.ToUpper() + (oseriesfoliacion.actual + 1).ToString().PadLeft(4, '0');
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbidtipoingreso_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbtipoingreso.Text.Trim() != "")
                {
                    oseriesfoliacion = seriefoliacionnc.getseriefoliacionvigentebytiposerie(this.cmbtipoingreso.Text.Trim(), this._connexionstring);

                    txtfolio.Text = oseriesfoliacion.serie.ToUpper() + (oseriesfoliacion.actual + 1).ToString().PadLeft(4, '0');
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
