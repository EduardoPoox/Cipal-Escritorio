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
    public partial class frmmantenimientoconsulta : Form
    {
        private string _connexionstring;
        private int _id;
        private int _idconfig;
        private int _idusuario;
        string[] ejercicios = { "2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028" };

        parametros oparametros = null;
        empresa oempresa = null;
        public frmmantenimientoconsulta(int id, int idconfig,int idusuario, string connexionstring)
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

        private void frmmantenimientoconsulta_Load(object sender, EventArgs e)
        {
            try
            {
                cargainfo();
                cargardepartamentos();
                cargarvehiculos();
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
        private void cargardepartamentos()
        {
            try
            {
                List<departamentos> olistdepartamentos = departamentonc.getdepartamentos(this._connexionstring);

                DataTable DT = genericas.helpers.ToDataTable(olistdepartamentos);
                DataRow oRow = DT.NewRow();
                oRow["iddepartamento"] = 0;
                oRow["nombre"] = "TODOS";
                oRow["usuario"] = this._idusuario.ToString();
                oRow["baja"] = (false).ToString();
                DT.Rows.Add(oRow);

                this.cmbdepartamentos.SetDataBinding(DT, null);
                this.cmbdepartamentos.ValueMember = "iddepartamento";
                this.cmbdepartamentos.DisplayMember = "nombre";
                this.cmbdepartamentos.SelectedText = "TODOS";

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void cargarvehiculos()
        {
            try
            {
                List<vehiculos> olistvehiculos = vehiculonc.getvehiculos(this._connexionstring);

                DataTable DT = genericas.helpers.ToDataTable(olistvehiculos);
                DataRow oRow = DT.NewRow();
                oRow["idvehiculo"] = 0;
                oRow["nombre"] = "TODOS";
                oRow["usuario"] = this._idusuario.ToString();
                oRow["baja"] = (false).ToString();
                DT.Rows.Add(oRow);

                this.cmbvehiculos.SetDataBinding(DT, null);
                this.cmbvehiculos.ValueMember = "idvehiculo";
                this.cmbvehiculos.DisplayMember = "nombre";
                this.cmbvehiculos.SelectedText = "TODOS";
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
                int iddepartamento = Convert.ToInt32(cmbdepartamentos.Value);
                int idvehiculo = Convert.ToInt32(cmbvehiculos.Value);
                DateTime fi = Convert.ToDateTime(this.cmbfechainicial.Value);
                DateTime ff = Convert.ToDateTime(this.cmbfechafinal.Value);
                string folio = this.txtfolio.Text;

                List<vmantenimientos> olistmantenimientos = vmantenimientonc.getvmantenimientosbyparams(iddepartamento, idvehiculo,folio,fi,ff, this._connexionstring);
                this.grdmantenimientos.SetDataBinding(olistmantenimientos, null);
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grdmantenimientos.DisplayLayout.Bands[0].Columns)
                {
                    oColumn.Hidden = true;
                }

                this.grdmantenimientos.DisplayLayout.Bands[0].Columns["folio"].Hidden = false;
                this.grdmantenimientos.DisplayLayout.Bands[0].Columns["fecha"].Hidden = false;
                this.grdmantenimientos.DisplayLayout.Bands[0].Columns["nombredepartamento"].Hidden = false;
                this.grdmantenimientos.DisplayLayout.Bands[0].Columns["nombrecompleto"].Hidden = false;
                this.grdmantenimientos.DisplayLayout.Bands[0].Columns["puesto"].Hidden = false;
                this.grdmantenimientos.DisplayLayout.Bands[0].Columns["nombrevehiculo"].Hidden = false;
                this.grdmantenimientos.DisplayLayout.Bands[0].Columns["placa"].Hidden = false;
                this.grdmantenimientos.DisplayLayout.Bands[0].Columns["marca"].Hidden = false;
                this.grdmantenimientos.DisplayLayout.Bands[0].Columns["modelo"].Hidden = false;
                this.grdmantenimientos.DisplayLayout.Bands[0].Columns["rendimiento"].Hidden = false;
                this.grdmantenimientos.DisplayLayout.Bands[0].Columns["comentarios"].Hidden = false;

                this.grdmantenimientos.DisplayLayout.Bands[0].Columns["folio"].Header.Caption = "Folio";
                this.grdmantenimientos.DisplayLayout.Bands[0].Columns["fecha"].Header.Caption = "Fecha";
                this.grdmantenimientos.DisplayLayout.Bands[0].Columns["nombredepartamento"].Header.Caption = "Departamento";
                this.grdmantenimientos.DisplayLayout.Bands[0].Columns["nombrecompleto"].Header.Caption = "Empleado";
                this.grdmantenimientos.DisplayLayout.Bands[0].Columns["puesto"].Header.Caption = "Puesto";
                this.grdmantenimientos.DisplayLayout.Bands[0].Columns["nombrevehiculo"].Header.Caption = "Vehículo";
                this.grdmantenimientos.DisplayLayout.Bands[0].Columns["placa"].Header.Caption = "Placa";
                this.grdmantenimientos.DisplayLayout.Bands[0].Columns["marca"].Header.Caption = "Marca";
                this.grdmantenimientos.DisplayLayout.Bands[0].Columns["modelo"].Header.Caption = "Modelo";
                this.grdmantenimientos.DisplayLayout.Bands[0].Columns["rendimiento"].Header.Caption = "Rendimiento";
                this.grdmantenimientos.DisplayLayout.Bands[0].Columns["comentarios"].Header.Caption = "Comentarios";

                this.grdmantenimientos.DisplayLayout.Bands[0].Columns["fecha"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                this.grdmantenimientos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
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
                frmmantenimiento ofrmmantenimiento = new frmmantenimiento(id, this._idusuario, this._connexionstring);
                ofrmmantenimiento.ShowDialog();
                if (ofrmmantenimiento._update)
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
                int id = Convert.ToInt32(this.grdmantenimientos.ActiveRow.Cells["idmantenimiento"].Value);
                if (MessageBox.Show("¿Esta seguro de borrar el registro", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    mantenimientos omantenimiento = mantenimientonc.getmantenimiento(id, this._connexionstring);
                    omantenimiento.baja = true;
                    mantenimientonc.update(omantenimiento, this._connexionstring);

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
                int id = Convert.ToInt32(this.grdmantenimientos.ActiveRow.Cells["idmantenimiento"].Value);
                frmmantenimiento ofrmmantenimiento = new frmmantenimiento(id, this._idusuario, this._connexionstring);
                ofrmmantenimiento.ShowDialog();
                if (ofrmmantenimiento._update)
                {
                    consultar();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdmantenimientos_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
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

        private void btnvisualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdmantenimientos.ActiveRow != null)
                {
                    int id = Convert.ToInt32(this.grdmantenimientos.ActiveRow.Cells["idmantenimiento"].Value);
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
                mantenimientos omantenimiento = mantenimientonc.getmantenimiento(id, this._connexionstring);
                empleados oempleado = empleadonc.getempleado((int)omantenimiento.idempleado, this._connexionstring);
                departamentos odepartamento = departamentonc.getdepartamento((int)omantenimiento.iddepartamento, this._connexionstring);
                vmantenimientos ovmantenimiento = vmantenimientonc.getvmantenimiento(id, this._connexionstring);

                //IMPUESTOS DEL CFDI
                string query = "Select";
                query += " isnull(unidades.simbologia,'SN') as unidad,";
                query += " detmantenimientos.* ";
                query += " From detmantenimientos ";
                query += " Left Join unidades on detmantenimientos.idunidad = unidades.idunidad";
                query += " where detmantenimientos.idmantenimiento = " + omantenimiento.idmantenimiento.ToString();
                DataTable dtDetalle = genericas.generales.executeDS(query, this._connexionstring).Tables[0];


                DataSet dsEgresos = (DataSet)new datasets.dsegresosmantenimientos();
                DataRow dataRow = dsEgresos.Tables["dtEncabezado"].NewRow();
                dataRow["nombreempresa"] = oempresa.nombre;
                dataRow["rfc"] = oempresa.rfc;
                dataRow["domicilio"] = string.Empty;
                dataRow["telefono"] = string.Empty;
                dataRow["logo1"] = oparametros.logoizquierdo;
                dataRow["logo2"] = oparametros.logoderecho;
                dataRow["titulo"] = "BITACORA DE MANTENIMIENTO"; 
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
                dataRow["fecha"] = omantenimiento.fecha;
                dataRow["folio"] = omantenimiento.folio;
                dataRow["nombreproveedor"] = string.Empty;
                dataRow["rfcproveedor"] = string.Empty;
                dataRow["comentarios"] = omantenimiento.comentarios;
                dataRow["subtotal"] = 0;
                dataRow["iva"] = 0;
                dataRow["ieps"] = 0;
                dataRow["ivaretenido"] = 0;
                dataRow["isr"] = 0;
                dataRow["trasladoslocales"] = 0;
                dataRow["retencioneslocales"] = 0;
                dataRow["total"] = 0;
                dataRow["comentarios"] = string.Empty;

                dataRow["vehiculo"] = ovmantenimiento.nombrevehiculo;
                dataRow["marca"] = ovmantenimiento.marca;
                dataRow["placas"] = ovmantenimiento.placa;
                dataRow["modelo"] = ovmantenimiento.modelo;
                dataRow["rendimiento"] = ovmantenimiento.rendimiento;
                dataRow["notas"] = "";
                dataRow["departamento"] = ovmantenimiento.nombredepartamento;

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

                String reportpath = Application.StartupPath + "\\Formatos\\rptmantenimiento.rpt";
                ReportDocument reportDocument = new ReportDocument();
                reportDocument.Load(reportpath, OpenReportMethod.OpenReportByTempCopy);
                reportDocument.SetDataSource(dsEgresos);


                frmvisualizadoregresos frmVisualizador = new frmvisualizadoregresos(reportDocument);
                frmVisualizador.Name = "Visualizador" + base.Name;
                frmVisualizador.Text = "Bitácora de Mantenimiento";
                frmVisualizador.ShowDialog();
                reportDocument.Dispose();

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void btnexportar_Click(object sender, EventArgs e)
        {
            try
            {
                parametros oconfig = parametronc.getparametro(this._idconfig, this._connexionstring);
                string dirfile = oconfig.direxportaciones + @"\mantenimientos.xlsx";
                this.ugExcel.Export(grdmantenimientos, dirfile);
                System.Diagnostics.Process.Start(dirfile);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
