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
    public partial class frmgasolinaconsulta : Form
    {
        private string _connexionstring;
        private int _id;
        private int _idconfig;
        private int _idusuario;
        string[] ejercicios = { "2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028" };


        parametros oparametros = null;
        empresa oempresa = null;
        public frmgasolinaconsulta(int id, int idconfig,int idusuario, string connexionstring)
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

        private void frmgasolinaconsulta_Load(object sender, EventArgs e)
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

                List<vgasolinas> olistgasolinas = vgasolinanc.getgasolinasbyparams(iddepartamento, idvehiculo,folio, fi, ff, this._connexionstring);
                this.grdgasolinas.SetDataBinding(olistgasolinas, null);
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grdgasolinas.DisplayLayout.Bands[0].Columns)
                {
                    oColumn.Hidden = true;
                }

                this.grdgasolinas.DisplayLayout.Bands[0].Columns["folio"].Hidden = false;
                this.grdgasolinas.DisplayLayout.Bands[0].Columns["fecha"].Hidden = false;
                this.grdgasolinas.DisplayLayout.Bands[0].Columns["nombredepartamento"].Hidden = false;
                this.grdgasolinas.DisplayLayout.Bands[0].Columns["nombrecompleto"].Hidden = false;
                this.grdgasolinas.DisplayLayout.Bands[0].Columns["puesto"].Hidden = false;
                this.grdgasolinas.DisplayLayout.Bands[0].Columns["nombrevehiculo"].Hidden = false;
                this.grdgasolinas.DisplayLayout.Bands[0].Columns["placa"].Hidden = false;
                this.grdgasolinas.DisplayLayout.Bands[0].Columns["marca"].Hidden = false;
                this.grdgasolinas.DisplayLayout.Bands[0].Columns["modelo"].Hidden = false;
                this.grdgasolinas.DisplayLayout.Bands[0].Columns["rendimiento"].Hidden = false;
                this.grdgasolinas.DisplayLayout.Bands[0].Columns["comentarios"].Hidden = false;

                this.grdgasolinas.DisplayLayout.Bands[0].Columns["folio"].Header.Caption = "Folio";
                this.grdgasolinas.DisplayLayout.Bands[0].Columns["fecha"].Header.Caption = "Fecha";
                this.grdgasolinas.DisplayLayout.Bands[0].Columns["nombredepartamento"].Header.Caption = "Departamento";
                this.grdgasolinas.DisplayLayout.Bands[0].Columns["nombrecompleto"].Header.Caption = "Empleado";
                this.grdgasolinas.DisplayLayout.Bands[0].Columns["puesto"].Header.Caption = "Puesto";
                this.grdgasolinas.DisplayLayout.Bands[0].Columns["nombrevehiculo"].Header.Caption = "Vehículo";
                this.grdgasolinas.DisplayLayout.Bands[0].Columns["placa"].Header.Caption = "Placa";
                this.grdgasolinas.DisplayLayout.Bands[0].Columns["marca"].Header.Caption = "Marca";
                this.grdgasolinas.DisplayLayout.Bands[0].Columns["modelo"].Header.Caption = "Modelo";
                this.grdgasolinas.DisplayLayout.Bands[0].Columns["rendimiento"].Header.Caption = "Rendimiento";
                this.grdgasolinas.DisplayLayout.Bands[0].Columns["comentarios"].Header.Caption = "Comentarios";

                this.grdgasolinas.DisplayLayout.Bands[0].Columns["fecha"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                this.grdgasolinas.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
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
                frmgasolina ofrmgasolina = new frmgasolina(id, this._idusuario, this._connexionstring);
                ofrmgasolina.ShowDialog();
                if (ofrmgasolina._update)
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
                int id = Convert.ToInt32(this.grdgasolinas.ActiveRow.Cells["idgasolina"].Value);
                if (MessageBox.Show("¿Esta seguro de borrar el registro", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    gasolinas ogasolina = gasolinanc.getgasolina(id, this._connexionstring);
                    ogasolina.baja = true;
                    gasolinanc.update(ogasolina, this._connexionstring);

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
                int id = Convert.ToInt32(this.grdgasolinas.ActiveRow.Cells["idgasolina"].Value);
                frmgasolina ofrmgasolina = new frmgasolina(id,this._idusuario, this._connexionstring);
                ofrmgasolina.ShowDialog();
                if (ofrmgasolina._update)
                {
                    consultar();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdgasolinas_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
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
                if (grdgasolinas.ActiveRow != null)
                {
                    int id = Convert.ToInt32(this.grdgasolinas.ActiveRow.Cells["idgasolina"].Value);
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
                gasolinas ogasolina = gasolinanc.getgasolina(id, this._connexionstring);
                empleados oempleado = empleadonc.getempleado((int)ogasolina.idempleado, this._connexionstring);
                departamentos odepartamento = departamentonc.getdepartamento((int)ogasolina.iddepartamento, this._connexionstring);
                vgasolinas ovgasolina = vgasolinanc.getgasolina(id, this._connexionstring);

                //IMPUESTOS DEL CFDI
                string query = "Select";
                query += " ('NA') as unidad,";
                query += " detgasolinas.* ";
                query += " From detgasolinas ";
                //query += " Left Join unidades on detgasolinas.idunidad = unidades.idunidad";
                query += " where detgasolinas.idgasolina = " + ogasolina.idgasolina.ToString();
                DataTable dtDetalle = genericas.generales.executeDS(query, this._connexionstring).Tables[0];


                DataSet dsEgresos = (DataSet)new datasets.dsegresosgasolinas();
                DataRow dataRow = dsEgresos.Tables["dtEncabezado"].NewRow();
                dataRow["nombreempresa"] = oempresa.nombre;
                dataRow["rfc"] = oempresa.rfc;
                dataRow["domicilio"] = string.Empty;
                dataRow["telefono"] = string.Empty;
                dataRow["logo1"] = oparametros.logoizquierdo;
                dataRow["logo2"] = oparametros.logoderecho;
                dataRow["titulo"] = "BITÁCORA DE COMBUSTIBLE"; 
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
                dataRow["fecha"] = ogasolina.fecha;
                dataRow["folio"] = ogasolina.folio;
                dataRow["nombreproveedor"] = string.Empty;
                dataRow["rfcproveedor"] = string.Empty;
                dataRow["comentarios"] = ogasolina.comentarios;
                dataRow["subtotal"] = 0;
                dataRow["iva"] = 0;
                dataRow["ieps"] = 0;
                dataRow["ivaretenido"] = 0;
                dataRow["isr"] = 0;
                dataRow["trasladoslocales"] = 0;
                dataRow["retencioneslocales"] = 0;
                dataRow["total"] = 0;
                dataRow["comentarios"] = string.Empty;

                dataRow["vehiculo"] = ovgasolina.nombrevehiculo;
                dataRow["marca"] = ovgasolina.marca;
                dataRow["placas"] =ovgasolina.placa;
                dataRow["modelo"] = ovgasolina.modelo;
                dataRow["rendimiento"] = ovgasolina.rendimiento;
                dataRow["notas"] = "NOTA: No funciona el kilometraje";
                dataRow["departamento"] = ovgasolina.nombredepartamento;

                dsEgresos.Tables["dtDocumento"].Rows.Add(dataRow);

                for (int x = 0; x < dtDetalle.Rows.Count; x++)
                {
                    dataRow = dsEgresos.Tables["dtDocumentoDetalle"].NewRow();

                    dataRow["unidad"] = Convert.ToString(dtDetalle.Rows[x]["unidad"]);
                    dataRow["cantidad"] = 1;
                    dataRow["descripcion"] = "";
                    dataRow["preciounitario"] = 0;
                    dataRow["importe"] = 0;
                    dataRow["destino01"] = "";
                    dataRow["destino02"] = "";
                    dataRow["destino03"] = "";
                    dataRow["destino04"] = "";
                    dataRow["fecha"] = Convert.ToDateTime(dtDetalle.Rows[x]["fecha"]);
                    dataRow["kminicial"] = Convert.ToDecimal(dtDetalle.Rows[x]["kminicial"]).ToString("#######.##");
                    dataRow["kmfinal"] = Convert.ToDecimal(dtDetalle.Rows[x]["kmfinal"]).ToString("#######.##");
                    dataRow["origen"] = Convert.ToString(dtDetalle.Rows[x]["origen"]);
                    dataRow["destino"] = Convert.ToString(dtDetalle.Rows[x]["destino"]);
                    dataRow["kmrecorridos"] = Convert.ToDecimal(dtDetalle.Rows[x]["kmrecorridos"]).ToString("#######.##");
                    dataRow["litros"] = Convert.ToDecimal(dtDetalle.Rows[x]["litros"]).ToString("#######.##");
                    dataRow["motivoviaje"] = Convert.ToString(dtDetalle.Rows[x]["motivoviaje"]);

                    dsEgresos.Tables["dtDocumentoDetalle"].Rows.Add(dataRow);
                }

                dsEgresos.AcceptChanges();

                String reportpath = Application.StartupPath + "\\Formatos\\rptgasolina.rpt";
                ReportDocument reportDocument = new ReportDocument();
                reportDocument.Load(reportpath, OpenReportMethod.OpenReportByTempCopy);
                reportDocument.SetDataSource(dsEgresos);


                frmvisualizadoregresos frmVisualizador = new frmvisualizadoregresos(reportDocument);
                frmVisualizador.Name = "Visualizador" + base.Name;
                frmVisualizador.Text = "Bitácora de Combustible";
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
                string dirfile = oconfig.direxportaciones + @"\gasolinas.xlsx";
                this.ugExcel.Export(grdgasolinas, dirfile);
                System.Diagnostics.Process.Start(dirfile);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
