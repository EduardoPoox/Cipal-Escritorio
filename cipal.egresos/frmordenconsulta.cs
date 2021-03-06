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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace cipal.egresos
{
    public partial class frmordenconsulta : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _idconfig;
        private int _idempresa;

        string[] ejercicios = { "2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028" };


        parametros oparametros = null;
        empresa oempresa = null;

        public frmordenconsulta(int idusuario, int idconfig, int idempresa, string connexionstring)
        {
            InitializeComponent();
            this._idusuario = idusuario;
            this._connexionstring = connexionstring;
            this._idconfig = idconfig;
            this._idempresa = idempresa;

            this.cmbejercicios.SetDataBinding(ejercicios, null);
            this.cmbejercicios.Text = DateTime.Now.Year.ToString();

            this.cmbperiodo.SetDataBinding(Enum.GetNames(typeof(genericas.enums.emeses)), null);
            this.cmbperiodo.Text = genericas.enums.emeses.enero.ToString();
        }

        private void frmordenconsulta_Load(object sender, EventArgs e)
        {
            try
            {
                oparametros = parametronc.getparametro(this._idconfig, this._connexionstring);
                oempresa = empresanc.getempresa(this._idempresa, this._connexionstring);
                consultar();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void consultar()
        {
            try
            {
                string folio = this.txtfolio.Text;
                DateTime fi = genericas.generales.FormatDateWithoutHour(Convert.ToDateTime(this.cmbfechainicial.Value));
                DateTime ff = genericas.generales.FormatDateAllHour(Convert.ToDateTime(this.cmbfechafinal.Value));

                List<vordenes> olistordenes = vordennc.getvordenesbyparams(folio, fi, ff,this._connexionstring);
                this.grdordenes.SetDataBinding(olistordenes, null);
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grdordenes.DisplayLayout.Bands[0].Columns)
                {
                    oColumn.Hidden = true;
                }
                //this.grdsolicitudes.DisplayLayout.Bands[0].Columns["tipo"].Hidden = false;
                this.grdordenes.DisplayLayout.Bands[0].Columns["folio"].Hidden = false;
                this.grdordenes.DisplayLayout.Bands[0].Columns["fecha"].Hidden = false;
                this.grdordenes.DisplayLayout.Bands[0].Columns["nombrecompleto"].Hidden = false;
                this.grdordenes.DisplayLayout.Bands[0].Columns["nombredepartamento"].Hidden = false;
                this.grdordenes.DisplayLayout.Bands[0].Columns["comentarios"].Hidden = false;

                //this.grdsolicitudes.DisplayLayout.Bands[0].Columns["tipo"].Header.Caption = "Tipo de solicitud";
                this.grdordenes.DisplayLayout.Bands[0].Columns["folio"].Header.Caption = "Folio";
                this.grdordenes.DisplayLayout.Bands[0].Columns["fecha"].Header.Caption = "Fecha";
                this.grdordenes.DisplayLayout.Bands[0].Columns["nombrecompleto"].Header.Caption = "Empleado";
                this.grdordenes.DisplayLayout.Bands[0].Columns["nombredepartamento"].Header.Caption = "Departamento";
                this.grdordenes.DisplayLayout.Bands[0].Columns["comentarios"].Header.Caption = "Comentarios";

                this.grdordenes.DisplayLayout.Bands[0].Columns["fecha"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                this.grdordenes.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        private void btnregistrar_Click(object sender, EventArgs e)
        {
            try
            {            
                frmorden ofrmorden = new frmorden(0, this._idusuario, this._connexionstring);
                ofrmorden.ShowDialog();
                if (ofrmorden._update)
                {
                    int id = ofrmorden._id;
                    if (id > 0)
                        generarreporte(id);
                    consultar();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnconsultar_Click(object sender, EventArgs e)
        {
            try
            {
                consultar();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnborrar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(this.grdordenes.ActiveRow.Cells["idorden"].Value);
                if (MessageBox.Show("¿Esta seguro de borrar el registro", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ordenes oorden = ordennc.getorden(id, this._connexionstring);
                    oorden.baja = true;
                    ordennc.update(oorden, this._connexionstring);

                    consultar();

                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(this.grdordenes.ActiveRow.Cells["idorden"].Value);
                frmorden ofrmorden = new frmorden(id, this._idusuario, this._connexionstring);
                ofrmorden.ShowDialog();
                if (ofrmorden._update)
                {
                    consultar();
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

        private void btnvisualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdordenes.ActiveRow != null)
                {
                    int id = Convert.ToInt32(this.grdordenes.ActiveRow.Cells["idorden"].Value);
                    generarreporte(id);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void generarreporte(int id)
        {
            try
            {
                ordenes oorden = ordennc.getorden(id, this._connexionstring);
                empleados oempleado = empleadonc.getempleado((int)oorden.idempleado, this._connexionstring);
                departamentos odepartamento = departamentonc.getdepartamento((int)oorden.iddepartamento, this._connexionstring);

                //IMPUESTOS DEL CFDI
                string query = "Select";
                query += " isnull(unidades.simbologia,'SN') as unidad,";
                query += " detordenes.* ";
                query += " From detordenes ";
                query += " Left Join unidades on detordenes.idunidad = unidades.idunidad";
                query += " where detordenes.idorden = " + oorden.idorden.ToString();
                DataTable dtDetalle = genericas.generales.executeDS(query, this._connexionstring).Tables[0];

                DataSet dsEgresos = (DataSet)new datasets.dsegresos();
                DataRow dataRow = dsEgresos.Tables["dtEncabezado"].NewRow();
                dataRow["nombreempresa"] = oempresa.nombre;
                dataRow["rfc"] = oempresa.rfc;
                dataRow["domicilio"] = string.Empty;
                dataRow["telefono"] = string.Empty;
                dataRow["logo1"] = oparametros.logoizquierdo;
                dataRow["logo2"] = oparametros.logoderecho;
                dataRow["titulo"] = "ORDEN DE COMPRA"; 
                dataRow["subtitulo"] = oparametros.leyenda1;
                dsEgresos.Tables["dtEncabezado"].Rows.Add(dataRow);

                dataRow = dsEgresos.Tables["dtfirmas"].NewRow();
                dataRow["fnombre1"] = oparametros.presidente;
                dataRow["fpuesto1"] = "Presidente Municipal";
                dataRow["fnombre2"] = oparametros.tesorero;
                dataRow["fpuesto2"] = "Tesorero Municipal";
                dataRow["fnombresolicita"] = oempleado.nombres + " " + oempleado.apellidopaterno + " " + oempleado.apellidomaterno;
                dataRow["fpuestosolicita"] = odepartamento.nombre;
                dsEgresos.Tables["dtfirmas"].Rows.Add(dataRow);

                dataRow = dsEgresos.Tables["dtDocumento"].NewRow();
                dataRow["fecha"] = oorden.fecha;
                dataRow["folio"] = oorden.folio;
                dataRow["nombreproveedor"] = string.Empty;
                dataRow["rfcproveedor"] = string.Empty;
                dataRow["comentarios"] = oorden.comentarios;
                dataRow["subtotal"] = 0;
                dataRow["iva"] = 0;
                dataRow["ieps"] = 0;
                dataRow["ivaretenido"] = 0;
                dataRow["isr"] = 0;
                dataRow["trasladoslocales"] = 0;
                dataRow["retencioneslocales"] = 0;
                dataRow["total"] = 0;
                dataRow["comentarios"] = string.Empty;
                dsEgresos.Tables["dtDocumento"].Rows.Add(dataRow);

                for (int x = 0; x < dtDetalle.Rows.Count; x++)
                {
                    dataRow = dsEgresos.Tables["dtDocumentoDetalle"].NewRow();
                    dataRow["unidad"] = Convert.ToString(dtDetalle.Rows[x]["unidad"]);
                    dataRow["cantidad"] = Convert.ToDecimal(dtDetalle.Rows[x]["cantidad"]);
                    dataRow["descripcion"] = Convert.ToString(dtDetalle.Rows[x]["descripcion"]);
                    dsEgresos.Tables["dtDocumentoDetalle"].Rows.Add(dataRow);
                }

                dsEgresos.AcceptChanges();

                String reportpath = Application.StartupPath + "\\Formatos\\rptorden.rpt";
                ReportDocument reportDocument = new ReportDocument();
                reportDocument.Load(reportpath, OpenReportMethod.OpenReportByTempCopy);
                reportDocument.SetDataSource(dsEgresos);

                frmvisualizadoregresos frmVisualizador = new frmvisualizadoregresos(reportDocument);
                frmVisualizador.Name = "Visualizador" + base.Name;
                frmVisualizador.Text = "Orden";
                frmVisualizador.ShowDialog();
                reportDocument.Dispose();

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void cmbperiodo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string periodo = this.cmbperiodo.Text.Trim();
                switch (this.cmbperiodo.Text.Trim())
                {
                    case "enero": periodo = "01"; break;
                    case "febrero": periodo = "02"; break;
                    case "marzo": periodo = "03"; break;
                    case "abril": periodo = "04"; break;
                    case "mayo": periodo = "05"; break;
                    case "junio": periodo = "06"; break;
                    case "julio": periodo = "07"; break;
                    case "agosto": periodo = "08"; break;
                    case "septiembre": periodo = "09"; break;
                    case "octubre": periodo = "10"; break;
                    case "noviembre": periodo = "11"; break;
                    case "diciembre": periodo = "12"; break;
                }
                DateTime fi = new DateTime(Convert.ToInt32(this.cmbejercicios.Text), Convert.ToInt32(periodo), 1);
                DateTime ff = fi.AddMonths(1).AddSeconds(-1);

                this.cmbfechainicial.Value = fi;
                this.cmbfechafinal.Value = ff;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnexportar_Click(object sender, EventArgs e)
        {
            try
            {
                parametros oconfig = parametronc.getparametro(this._idconfig, this._connexionstring);
                string dirfile = oconfig.direxportaciones + @"\ordenes.xlsx";
                this.ugExcel.Export(grdordenes, dirfile);
                System.Diagnostics.Process.Start(dirfile);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
