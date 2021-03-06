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
using cipal.entidades;
using cipal.negocios;

namespace cipal.egresos
{
    public partial class frmpedidoconsulta : Form
    {
        private string _connexionstring;
        private int _idusuario;

        private int _idconfig;
        private int _idempresa;

        string[] ejercicios = { "2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028" };

        parametros oparametros = null;
        empresa oempresa = null;
        

        public frmpedidoconsulta(int idusuario, int idconfig, int idempresa, string connexionstring)
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
               departamentos();
               proveedores();
               consultar();
               oparametros = parametronc.getparametro(this._idconfig, this._connexionstring);
               oempresa = empresanc.getempresa(this._idempresa, this._connexionstring);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void departamentos()
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
                
                this.cmbiddepartamento.SetDataBinding(DT, null);
                this.cmbiddepartamento.ValueMember = "iddepartamento";
                this.cmbiddepartamento.DisplayMember = "nombre";
                this.cmbiddepartamento.SelectedText = "TODOS";
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void proveedores()
        {
            try
            {
                List<proveedores> olistproveedores = proveedornc.getproveedores(this._connexionstring);

                DataTable DT = genericas.helpers.ToDataTable(olistproveedores);
                DataRow oRow = DT.NewRow();
                oRow["idproveedor"] = 0;
                oRow["nombre"] = "TODOS";
                oRow["usuario"] = this._idusuario.ToString();
                oRow["baja"] = (false).ToString();
                DT.Rows.Add(oRow);

                this.cmbidproveedor.SetDataBinding(DT, null);
                this.cmbidproveedor.ValueMember = "idproveedor";
                this.cmbidproveedor.DisplayMember = "nombre";
                this.cmbidproveedor.SelectedText = "TODOS";
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
                string folio = this.txtfolio.Text;

                int iddepartamento = Convert.ToInt32(cmbiddepartamento.Value);
                DateTime fi = Convert.ToDateTime(this.cmbfechainicial.Value);
                DateTime ff = Convert.ToDateTime(this.cmbfechafinal.Value);

                List<vpedidos> olistpedidos = vpedidonc.getvpedidosbyparams(folio, iddepartamento, 0,fi,ff, this._connexionstring);
              
                this.grdpedidos.SetDataBinding(olistpedidos, null);
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grdpedidos.DisplayLayout.Bands[0].Columns)
                {
                    oColumn.Hidden = true;
                }

                this.grdpedidos.DisplayLayout.Bands[0].Columns["folio"].Hidden = false;
                this.grdpedidos.DisplayLayout.Bands[0].Columns["fecha"].Hidden = false;
                this.grdpedidos.DisplayLayout.Bands[0].Columns["nombredepartamento"].Hidden = false;
                this.grdpedidos.DisplayLayout.Bands[0].Columns["nombrecompleto"].Hidden = false;
                this.grdpedidos.DisplayLayout.Bands[0].Columns["puesto"].Hidden = false;
                this.grdpedidos.DisplayLayout.Bands[0].Columns["nombreproveedor"].Hidden = false;
                this.grdpedidos.DisplayLayout.Bands[0].Columns["domicilio"].Hidden = false;
                this.grdpedidos.DisplayLayout.Bands[0].Columns["comentarios"].Hidden = false;
                this.grdpedidos.DisplayLayout.Bands[0].Columns["subtotal"].Hidden = false;
                this.grdpedidos.DisplayLayout.Bands[0].Columns["impuestostrasladados"].Hidden = false;
                this.grdpedidos.DisplayLayout.Bands[0].Columns["impuestosretenidos"].Hidden = false;
                this.grdpedidos.DisplayLayout.Bands[0].Columns["total"].Hidden = false;

                this.grdpedidos.DisplayLayout.Bands[0].Columns["folio"].Header.Caption = "Folio";
                this.grdpedidos.DisplayLayout.Bands[0].Columns["fecha"].Header.Caption = "Fecha";
                this.grdpedidos.DisplayLayout.Bands[0].Columns["nombredepartamento"].Header.Caption = "Departamento";
                this.grdpedidos.DisplayLayout.Bands[0].Columns["nombrecompleto"].Header.Caption = "Empleado";
                this.grdpedidos.DisplayLayout.Bands[0].Columns["puesto"].Header.Caption = "Puesto";
                this.grdpedidos.DisplayLayout.Bands[0].Columns["nombreproveedor"].Header.Caption = "Proveedor";
                this.grdpedidos.DisplayLayout.Bands[0].Columns["domicilio"].Header.Caption = "Domicilio";
                this.grdpedidos.DisplayLayout.Bands[0].Columns["comentarios"].Header.Caption = "Comentarios";
                this.grdpedidos.DisplayLayout.Bands[0].Columns["subtotal"].Header.Caption = "Subtotal";
                this.grdpedidos.DisplayLayout.Bands[0].Columns["impuestostrasladados"].Header.Caption = "Impuestos Trasladados";
                this.grdpedidos.DisplayLayout.Bands[0].Columns["impuestosretenidos"].Header.Caption = "Impuestos Retenidos";
                this.grdpedidos.DisplayLayout.Bands[0].Columns["total"].Header.Caption = "Total";

                this.grdpedidos.DisplayLayout.Bands[0].Columns["fecha"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                this.grdpedidos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
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
                frmpedido ofrmpedido = new frmpedido(0, this._idusuario, this._idconfig, this._connexionstring);
                ofrmpedido.ShowDialog();
                if (ofrmpedido._update)
                {
                    int id = ofrmpedido._id;
                    if(id>0)
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
                int id = Convert.ToInt32(this.grdpedidos.ActiveRow.Cells["idpedido"].Value);
                if (MessageBox.Show("¿Esta seguro de borrar el registro", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    pedidos opedido = pedidonc.getpedido(id, this._connexionstring);
                    opedido.baja = true;
                    pedidonc.update(opedido, this._connexionstring);

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
                int id = Convert.ToInt32(this.grdpedidos.ActiveRow.Cells["idpedido"].Value);
                frmpedido ofrmpedido = new frmpedido(id, this._idusuario, this._idconfig, this._connexionstring);
                ofrmpedido.ShowDialog();
                if (ofrmpedido._update)
                {
                    consultar();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdordenes_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
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

        private void btnvisualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if(grdpedidos.ActiveRow != null)
                {
                    int id = Convert.ToInt32(this.grdpedidos.ActiveRow.Cells["idpedido"].Value);
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
                pedidos opedidido = pedidonc.getpedido(id, this._connexionstring);
                proveedores oproveedor = proveedornc.getproveedor((int)opedidido.idproveedor, this._connexionstring);
                empleados oempleado = empleadonc.getempleado((int)opedidido.idempleado, this._connexionstring);
                departamentos odepartamento = departamentonc.getdepartamento((int)opedidido.iddepartamento, this._connexionstring);

                string query = "Select";
                query += " impdetpedidos.idimpuesto, ";
                query += " impuestos.tipoimpuesto,";
                query += " impdetpedidos.nombre, ";
                query += " impdetpedidos.tasa, ";
                query += " impdetpedidos.cveimpuesto, ";
                query += " impdetpedidos.importe ";
                query += " From impdetpedidos ";
                query += " Left Join impuestos on impdetpedidos.idimpuesto = impuestos.idimpuesto";
                query += " where impdetpedidos.idpedido = " + id.ToString();
                DataTable dtimpuestos = genericas.generales.executeDS(query, this._connexionstring).Tables[0];


                //IMPUESTOS DEL CFDI
                query = "Select";
                query += " isnull(unidades.simbologia,'SN') as unidad,";
                query += " detpedidos.* ";
                query += " From detpedidos ";
                query += " Left Join unidades on detpedidos.idunidad = unidades.idunidad";
                query += " where detpedidos.idpedido = " + opedidido.idpedido.ToString();
                DataTable dtDetalle = genericas.generales.executeDS(query, this._connexionstring).Tables[0];

                decimal IVA = 0;
                decimal IEPS = 0;
                decimal ISR = 0;
                decimal IVARETENIDO = 0;
                decimal TRASLADOSLOCALES = (decimal)opedidido.impuestostrasladadoslocales;
                decimal RETENCIONESLOCALES = (decimal)opedidido.impuestosretenidoslocales;
                if (dtimpuestos.Rows.Count > 0)
                {
                    for (int x = 0; x < dtimpuestos.Rows.Count; x++)
                    {
                        if (Convert.ToString(dtimpuestos.Rows[x]["tipoimpuesto"]) == genericas.enums.etipodeimpuesto.trasladado.ToString())
                        {
                            if (Convert.ToString(dtimpuestos.Rows[x]["cveimpuesto"]) == "002")
                                IVA += Convert.ToDecimal(dtimpuestos.Rows[x]["importe"]);
                            else if (Convert.ToString(dtimpuestos.Rows[x]["impuesto"]) == "003")
                                IEPS += Convert.ToDecimal(dtimpuestos.Rows[x]["importe"]);
                        }
                        else
                        {
                            if (Convert.ToString(dtimpuestos.Rows[x]["cveimpuesto"]) == "002")
                                IVARETENIDO += Convert.ToDecimal(dtimpuestos.Rows[x]["importe"]);
                            else if (Convert.ToString(dtimpuestos.Rows[x]["impuesto"]) == "001")
                                ISR += Convert.ToDecimal(dtimpuestos.Rows[x]["importe"]);
                        }
                    }
                }
                else
                {
                    IVA = (decimal)opedidido.impuestostrasladados;
                    IVARETENIDO = (decimal)opedidido.impuestosretenidos;
                }

                // seccion para los reportes
                DataSet dsEgresos = (DataSet)new datasets.dsegresos();
                DataRow dataRow = dsEgresos.Tables["dtEncabezado"].NewRow();
                dataRow["nombreempresa"] = oempresa.nombre;
                dataRow["rfc"] = oempresa.rfc;
                dataRow["domicilio"] = string.Empty;
                dataRow["telefono"] = string.Empty;
                dataRow["logo1"] = oparametros.logoizquierdo;
                dataRow["logo2"] = oparametros.logoderecho;
                dataRow["titulo"] = "PEDIDO";  
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
                dataRow["fecha"] = opedidido.fecha;
                dataRow["folio"] = opedidido.folio;
                dataRow["nombreproveedor"] = oproveedor.nombre;
                dataRow["rfcproveedor"] = oproveedor.rfc;
                dataRow["comentarios"] = opedidido.comentarios;
                dataRow["subtotal"] = opedidido.subtotal;
                dataRow["iva"] = IVA;
                dataRow["ieps"] = IEPS;
                dataRow["ivaretenido"] = IVARETENIDO;
                dataRow["isr"] = ISR;
                dataRow["trasladoslocales"] = TRASLADOSLOCALES;
                dataRow["retencioneslocales"] = RETENCIONESLOCALES;
                dataRow["total"] = opedidido.total;
                dataRow["comentarios"] = opedidido.comentarios;
                //dataRow["fnombresolicita"] = oempleado.nombres + " " + oempleado.apellidopaterno + " " + oempleado.apellidomaterno;
                //dataRow["fpuestosolicitda"] = odepartamento.nombre;
                dsEgresos.Tables["dtDocumento"].Rows.Add(dataRow);

                for (int x = 0; x < dtDetalle.Rows.Count; x++)
                {
                    dataRow = dsEgresos.Tables["dtDocumentoDetalle"].NewRow();
                    dataRow["unidad"] = Convert.ToString(dtDetalle.Rows[x]["unidad"]);
                    dataRow["cantidad"] = Convert.ToDecimal(dtDetalle.Rows[x]["cantidad"]);
                    dataRow["descripcion"] = Convert.ToString(dtDetalle.Rows[x]["descripcion"]);
                    dataRow["preciounitario"] = Convert.ToDecimal(dtDetalle.Rows[x]["preciounitario"]);
                    dataRow["importe"] = Convert.ToDecimal(dtDetalle.Rows[x]["subtotal"]);
                    dsEgresos.Tables["dtDocumentoDetalle"].Rows.Add(dataRow);
                }

                dsEgresos.AcceptChanges();

                String reportpath = Application.StartupPath + "\\Formatos\\rptpedido.rpt";
                ReportDocument reportDocument = new ReportDocument();
                reportDocument.Load(reportpath, OpenReportMethod.OpenReportByTempCopy);
                reportDocument.SetDataSource(dsEgresos);
                

                frmvisualizadoregresos frmVisualizador = new frmvisualizadoregresos(reportDocument);
                frmVisualizador.Name = "Visualizador" + base.Name;
                frmVisualizador.Text = "Pedido";
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
                string dirfile = oconfig.direxportaciones + @"\pedidos.xlsx";
                this.ugExcel.Export(grdpedidos, dirfile);
                System.Diagnostics.Process.Start(dirfile);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
