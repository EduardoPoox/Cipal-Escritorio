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

namespace cipal.egresos
{
    public partial class frmorigenesydestinos : Form
    {
        private string _connexionstring;
        private int _id;
        private int _idconfig;
        private int _idusuario;

        public frmorigenesydestinos(int id, int idconfig, int idusuario, string connexionstring)
        {
            InitializeComponent();
            this._connexionstring = connexionstring;
            this._id = id;
            this._idconfig = idconfig;
            this._idusuario = idusuario;
        }

        private void frmorigenesydestinos_Load(object sender, EventArgs e)
        {
            try
            {
                cargadepartamentos();
                cargaempleados();
                cargainfo();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargadepartamentos()
        {
            try
            {
                List<departamentos> olistdepartamentos = departamentonc.getdepartamentos(this._connexionstring);
                this.cmbdepartamento.SetDataBinding(olistdepartamentos, null);
                this.cmbdepartamento.ValueMember = "iddepartamento";
                this.cmbdepartamento.DisplayMember = "nombre";
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void cargaempleados()
        {
            try
            {
                List<empleados> olistempleados = empleadonc.getempleados(this._connexionstring);
                foreach (empleados oempleado in olistempleados)
                {
                    oempleado.nombres = oempleado.nombres + " " + oempleado.apellidopaterno + " " + oempleado.apellidomaterno;
                }

                this.cmbempleado.SetDataBinding(olistempleados, null);
                this.cmbempleado.ValueMember = "idempleado";
                this.cmbempleado.DisplayMember = "nombres";
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
                    informes oinforme = informenc.getinforme(this._id, this._connexionstring);
                    this.txtfolio.Text = oinforme.folio;
                    this.dtfecha.Value = oinforme.fecha;
                    this.cmbdepartamento.Value = oinforme.iddepartamento;
                    this.cmbempleado.Value = oinforme.idempleado;

                    List<detinformes> olistdetinformes = detinformenc.getdetinformesporid(this._id, this._connexionstring);
                    this.grdubicaciones.SetDataBinding(olistdetinformes, null);
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grdubicaciones.DisplayLayout.Bands[0].Columns)
                    {
                        oColumn.Hidden = true;
                    }
                    //this.grdubicaciones.DisplayLayout.Bands[0].Columns["fecha"].Hidden = false;
                    this.grdubicaciones.DisplayLayout.Bands[0].Columns["cantidad"].Hidden = false;
                    this.grdubicaciones.DisplayLayout.Bands[0].Columns["descripcion"].Hidden = false;
                    this.grdubicaciones.DisplayLayout.Bands[0].Columns["destino01"].Hidden = false;

                    //this.grdubicaciones.DisplayLayout.Bands[0].Columns["fecha"].Header.Caption = "Fecha";
                    this.grdubicaciones.DisplayLayout.Bands[0].Columns["cantidad"].Header.Caption = "Cantidad";
                    this.grdubicaciones.DisplayLayout.Bands[0].Columns["descripcion"].Header.Caption = "Descripción";
                    this.grdubicaciones.DisplayLayout.Bands[0].Columns["destino01"].Header.Caption = "Ubicación y/o Uso Final";

                    this.grdubicaciones.DisplayLayout.Bands[0].Columns["destino01"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    this.grdubicaciones.DisplayLayout.Bands[0].Columns["destino01"].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
                    this.grdubicaciones.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
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

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach(Infragistics.Win.UltraWinGrid.UltraGridRow orow in this.grdubicaciones.Rows)
                {
                    int iddetinforme = Convert.ToInt32( orow.Cells["iddetinforme"].Value);
                    detinformes odetinforme = detinformenc.getdetinforme(iddetinforme, this._connexionstring);
                    odetinforme.destino01 = orow.Cells["destino01"].Value.ToString();

                    detinformenc.update(odetinforme, this._connexionstring);
                }

                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
