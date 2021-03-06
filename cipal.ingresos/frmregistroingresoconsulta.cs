using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using cipal.catalogos;
using cipal.entidades;
using cipal.negocios;
using cipal.egresos;

namespace cipal.ingresos
{
    public partial class frmregistroingresoconsulta : Form
    {
        private string _connexionstring;
        private int _id;
        private int _idconfig;
        private int _idusuario;
        

        string[] ejercicios = { "2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028" };

        parametros oparametros = null;
        empresa oempresa = null;
        public frmregistroingresoconsulta(int id,int idconfig,int idusuario, string connexionstring)
        {
            InitializeComponent();
            this._id = id;
            this._idconfig = idconfig;
            this._idusuario = idusuario;
            this._connexionstring = connexionstring;

            this.cmbejercicios.SetDataBinding(ejercicios, null);
            this.cmbejercicios.Text = DateTime.Now.Year.ToString();

            this.cmbperiodo.SetDataBinding(Enum.GetNames(typeof(genericas.enums.emeses)), null);
            this.cmbperiodo.Text = genericas.enums.emeses.enero.ToString();
        }

        private void frmingresoconsulta_Load(object sender, EventArgs e)
        {
            try
            {
                cargainfo();
                cargartiposingresos();
                consultar();
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
                oempresa = empresanc.getempresa(this._id, this._connexionstring);
                oparametros = parametronc.getparametro(this._idconfig, this._connexionstring);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void cargartiposingresos()
        {
            try
            {
                List<cipal.entidades.tipoingresos> olisttiposingresos = cipal.negocios.tipoingresonc.gettipoingresos(this._connexionstring);

                DataTable DT = genericas.helpers.ToDataTable(olisttiposingresos);
                DataRow oRow = DT.NewRow();
                oRow["idtipoingreso"] = 0;
                oRow["nombre"] = "TODOS";
                oRow["usuario"] = this._idusuario.ToString();
                oRow["baja"] = (false).ToString();
                DT.Rows.Add(oRow);

                this.cmbidtipoingreso.SetDataBinding(DT, null);
                this.cmbidtipoingreso.ValueMember = "idtipoingreso";
                this.cmbidtipoingreso.DisplayMember = "nombre";
                this.cmbidtipoingreso.SelectedText = "TODOS";
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void consultar()
        {
            try
            {
                int idtipoingreso = Convert.ToInt32(cmbidtipoingreso.Value);
                DateTime fi = Convert.ToDateTime(this.cmbfechainicial.Value);
                DateTime ff = Convert.ToDateTime(this.cmbfechafinal.Value);
                string folio = this.txtfolio.Text;
          
                List<vingresos> olistingresos = vingresonc.getingresosbyparams(idtipoingreso,fi,ff,folio, this._connexionstring);
                this.grdingresos.SetDataBinding(olistingresos, null);
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grdingresos.DisplayLayout.Bands[0].Columns)
                {
                    oColumn.Hidden = true;
                }

                this.grdingresos.DisplayLayout.Bands[0].Columns["tipoingreso"].Hidden = false;
                this.grdingresos.DisplayLayout.Bands[0].Columns["folio"].Hidden = false;
                this.grdingresos.DisplayLayout.Bands[0].Columns["fecha"].Hidden = false;
                this.grdingresos.DisplayLayout.Bands[0].Columns["rfc"].Hidden = false;
                this.grdingresos.DisplayLayout.Bands[0].Columns["nombrecontribuyente"].Hidden = false;
                this.grdingresos.DisplayLayout.Bands[0].Columns["correo"].Hidden = false;
                this.grdingresos.DisplayLayout.Bands[0].Columns["telefono"].Hidden = false;
                this.grdingresos.DisplayLayout.Bands[0].Columns["movil"].Hidden = false;
                this.grdingresos.DisplayLayout.Bands[0].Columns["domicilio"].Hidden = false;
                this.grdingresos.DisplayLayout.Bands[0].Columns["descripcion"].Hidden = false;
                this.grdingresos.DisplayLayout.Bands[0].Columns["importe"].Hidden = false;
                //this.grdingresos.DisplayLayout.Bands[0].Columns["nombrecompleto"].Hidden = false;

                this.grdingresos.DisplayLayout.Bands[0].Columns["tipoingreso"].Header.Caption = "Tipo de ingreso";
                this.grdingresos.DisplayLayout.Bands[0].Columns["folio"].Header.Caption = "Folio";
                this.grdingresos.DisplayLayout.Bands[0].Columns["fecha"].Header.Caption = "Fecha";
                this.grdingresos.DisplayLayout.Bands[0].Columns["rfc"].Header.Caption = "RFC";
                this.grdingresos.DisplayLayout.Bands[0].Columns["nombrecontribuyente"].Header.Caption = "Contribuyente";
                this.grdingresos.DisplayLayout.Bands[0].Columns["correo"].Header.Caption = "Correo Electrónico";
                this.grdingresos.DisplayLayout.Bands[0].Columns["telefono"].Header.Caption = "Teléfono";
                this.grdingresos.DisplayLayout.Bands[0].Columns["movil"].Header.Caption = "Móvil";
                this.grdingresos.DisplayLayout.Bands[0].Columns["domicilio"].Header.Caption = "Domicilio";
                this.grdingresos.DisplayLayout.Bands[0].Columns["descripcion"].Header.Caption = "Descripcion";
                this.grdingresos.DisplayLayout.Bands[0].Columns["importe"].Header.Caption = "Importe";
                //this.grdingresos.DisplayLayout.Bands[0].Columns["nombrecompleto"].Header.Caption = "Empleado";

                this.grdingresos.DisplayLayout.Bands[0].Columns["fecha"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                this.grdingresos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
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
                int id = 0; //REGISTRO NUEVO
                frmregistroingreso ofrmingreso = new frmregistroingreso(id,this._idconfig, this._idusuario, this._connexionstring);
                ofrmingreso.ShowDialog();
                if (ofrmingreso._update)
                {
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
                int id = Convert.ToInt32(this.grdingresos.ActiveRow.Cells["idingreso"].Value);
                if (MessageBox.Show("¿Esta seguro de borrar el registro", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cipal.entidades.ingresos oingreso = cipal.negocios.ingresonc.getingreso(id, this._connexionstring);
                    oingreso.baja = true;
                    cipal.negocios.ingresonc.update(oingreso, this._connexionstring);

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
                if (this.grdingresos.ActiveRow != null)
                {
                    int id = Convert.ToInt32(this.grdingresos.ActiveRow.Cells["idingreso"].Value);
                    frmregistroingreso ofrmingreso = new frmregistroingreso(id,this._idconfig, this._idusuario, this._connexionstring);
                    ofrmingreso.ShowDialog();
                    if (ofrmingreso._update)
                    {
                        consultar();
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdingresos_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            try
            {
                btneditar_Click(null, null);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gbgeneral_Click(object sender, EventArgs e)
        {

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
                string dirfile = oconfig.direxportaciones + @"\ingresos.xlsx";
                this.ugExcel.Export(grdingresos, dirfile);
                System.Diagnostics.Process.Start(dirfile);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

         //Metodo para el boton VISUALIZAR Reporte
        private void btnvisualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if(grdingresos.ActiveRow !=null)
                {
                    int id = Convert.ToInt32(this.grdingresos.ActiveRow.Cells["idingreso"].Value);
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
                cipal.entidades.ingresos oingreso = ingresonc.getingreso(id, this._connexionstring);
                contribuyentes ocontribuyentes = contribuyentenc.getcontribuyentes((int)oingreso.idcontribuyente, this._connexionstring);
                tipoingresos otipoingreso = tipoingresonc.gettipoingreso((int)oingreso.idtipoingreso, this._connexionstring);
                empleados oempleado = empleadonc.getempleado((int)oingreso.idempleado, this._connexionstring);
               

                //seccion de reporte
                DataSet dsIngresos = (DataSet)new datasets.dsingresos();
                DataRow dataRow = dsIngresos.Tables["dtEncabezado"].NewRow();
                dataRow["nombreempresa"] = oempresa.nombre;
                dataRow["rfc"] = oempresa.rfc;
                dataRow["domicilio"] = string.Empty;
                dataRow["telefono"] = string.Empty;
                dataRow["logo1"] = oparametros.logoizquierdo;
                dataRow["logo2"] = oparametros.logoderecho;
                dataRow["titulo"] = "Recibo";
                dataRow["subtitulo"] = oparametros.leyenda1;
                dsIngresos.Tables["dtEncabezado"].Rows.Add(dataRow);

                dataRow = dsIngresos.Tables["dtfirmas"].NewRow();
                dataRow["fnombre1"] = oparametros.presidente;
                dataRow["fpuesto1"] = "Presidente Municipal";
                dataRow["fnombre2"] = oparametros.tesorero;
                dataRow["fpuesto2"] = "Tesorero Municipal";
                dataRow["fnombresolicita"] = oempleado.nombres + " " + oempleado.apellidopaterno + " " + oempleado.apellidomaterno;
                dsIngresos.Tables["dtfirmas"].Rows.Add(dataRow);

                dataRow = dsIngresos.Tables["dtRecibo"].NewRow();
                dataRow["fecha"] = oingreso.fecha;
                dataRow["folio"] = oingreso.folio;
                dataRow["nombrecontribuyente"] = ocontribuyentes.nombre;
                dataRow["rfcontribuyente"] = ocontribuyentes.rfc;
                dataRow["tipoingreso"] = oingreso.tipoingreso;
                dataRow["total"] = oingreso.importe;
                //dataRow["descripcion"] = oingreso.descripcion;
                //dataRow["fnombresolicita"] = oempleado.nombres + " " + oempleado.apellidopaterno + " " + oempleado.apellidomaterno;
                //dataRow["fpuestosolicitda"] = odepartamento.nombre;
                dsIngresos.Tables["dtRecibo"].Rows.Add(dataRow);

                String reportpath = Application.StartupPath + "\\Formatos\\rptrecibo.rpt";
                ReportDocument reportDocument = new ReportDocument();
                reportDocument.Load(reportpath, OpenReportMethod.OpenReportByTempCopy);
                reportDocument.SetDataSource(dsIngresos);

                frmvisualizadoregresos frmVisualizador = new frmvisualizadoregresos(reportDocument);
                frmVisualizador.Name = "Visualizador" + base.Name;
                frmVisualizador.Text = "Recibo";
                frmVisualizador.ShowDialog();
                reportDocument.Dispose();

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
