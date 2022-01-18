using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cipal.egresos;
using cipal.entidades;
using cipal.negocios;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace cipal.descargas
{
    public partial class frmimpresionmultiplesregistros : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;
        private int _idconfig;

        public bool update = false;
        private string _tipoformato = "";


        parametros oparametros = null;
        empresa oempresa = null;
        public frmimpresionmultiplesregistros(int id, int idconfig, int idusuario,string tipoformato, string connexionstring)
        {
            InitializeComponent();
            this._connexionstring = connexionstring;
            this._idusuario = idusuario;
            this._id = id;
            this._idconfig = idconfig;
            this._tipoformato = tipoformato;
        }

        private void frmimpresionmultiplesregistros_Load(object sender, EventArgs e)
        {
            try
            {
                cargainfo();
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
                this.txtdirinformes.Text = oparametros.dirinformes;

                documentosdigitales odoc = documentodigitalnc.getgetdocumentodigital(this._id, this._connexionstring);
                this.txtfoliointerno.Text = odoc.serie + odoc.folio;
                this.txtuuid.Text = odoc.uuid;
                this.txttipoformato.Text = this._tipoformato;

                if (this._tipoformato == "combustible")
                {
                    this.btntipoformato.Text = "COMBUSTIBLE";
                    List<gasolinas> ogasolinas = gasolinanc.getgasolinasbyiddocumentodigital(odoc.iddocumentodigital,this._connexionstring);

                    DataTable DT = genericas.helpers.ToDataTable(ogasolinas);
                    DT.Columns.Add(new DataColumn("vehiculo", typeof(string)));
                    foreach(DataRow orow in DT.Rows)
                    {
                        int idvehiculo = Convert.ToInt32(orow["idvehiculo"]);
                        vehiculos ovehiculo = vehiculonc.getvehiculo(idvehiculo,this._connexionstring);
                        orow["vehiculo"] = ovehiculo.nombre;
                    }
                    DT.AcceptChanges();

                    this.grdregistrosformatos.SetDataBinding(DT, null);

                    foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grdregistrosformatos.DisplayLayout.Bands[0].Columns)
                    {
                        oColumn.Hidden = true;
                    }

                    int idsolicitud = solicitudnc.getsolicitudesgenerados(odoc.iddocumentodigital, this._connexionstring);
                    if (idsolicitud == 0)
                    {
                        this.btnsolicitud.Enabled = false;
                    }

                    int idorden = ordennc.getordenesgenerados(this._id, this._connexionstring);
                    if (idorden == 0)
                    {
                        this.btnorden.Enabled = false;
                    }

                    int idpedido = pedidonc.getpedidosgenerados(this._id, this._connexionstring);
                    if (idpedido == 0)
                    {
                        this.btnpedido.Enabled = false;
                    }

                    int idconstancia = constancianc.getconstanciasgenerados(this._id, this._connexionstring);
                    if (idconstancia == 0)
                    {
                        this.btnconstancia.Enabled = false;
                    }

                    int idinforme = informenc.getinformesgenerados(this._id, this._connexionstring);
                    if (idinforme == 0)
                    {
                        this.btninforme.Enabled = false;
                    }

                }
                else
                {
                    this.btntipoformato.Text = "MANTENIMIENTO";
                    List<mantenimientos> omantenimientos = mantenimientonc.getmantenimientosbyiddocumentodigital(odoc.iddocumentodigital, this._connexionstring);

                    DataTable DT = genericas.helpers.ToDataTable(omantenimientos);
                    DT.Columns.Add(new DataColumn("vehiculo", typeof(string)));
                    foreach (DataRow orow in DT.Rows)
                    {
                        int idvehiculo = Convert.ToInt32(orow["idvehiculo"]);
                        vehiculos ovehiculo = vehiculonc.getvehiculo(idvehiculo, this._connexionstring);
                        orow["vehiculo"] = ovehiculo.nombre;
                    }
                    DT.AcceptChanges();

                    this.grdregistrosformatos.SetDataBinding(DT, null);



                    foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grdregistrosformatos.DisplayLayout.Bands[0].Columns)
                    {
                        oColumn.Hidden = true;
                    }

                    int idsolicitud = solicitudnc.getsolicitudesgenerados(odoc.iddocumentodigital, this._connexionstring);
                    if (idsolicitud == 0)
                    {
                        this.btnsolicitud.Enabled = false;
                    }

                    int idorden = ordennc.getordenesgenerados(this._id, this._connexionstring);
                    if (idorden == 0)
                    {
                        this.btnorden.Enabled = false;
                    }

                    int idpedido = pedidonc.getpedidosgenerados(this._id, this._connexionstring);
                    if (idpedido == 0)
                    {
                        this.btnpedido.Enabled = false;
                    }

                    int idconstancia = constancianc.getconstanciasgenerados(this._id, this._connexionstring);
                    if (idconstancia == 0)
                    {
                        this.btnconstancia.Enabled = false;
                    }

                    int idinforme = informenc.getinformesgenerados(this._id, this._connexionstring);
                    if (idinforme == 0)
                    {
                        this.btninforme.Enabled = false;
                    }


                }

                this.grdregistrosformatos.DisplayLayout.Bands[0].Columns["folio"].Hidden = false;
                this.grdregistrosformatos.DisplayLayout.Bands[0].Columns["fecha"].Hidden = false;
                this.grdregistrosformatos.DisplayLayout.Bands[0].Columns["comentarios"].Hidden = false;
                this.grdregistrosformatos.DisplayLayout.Bands[0].Columns["vehiculo"].Hidden = false;

                this.grdregistrosformatos.DisplayLayout.Bands[0].Columns["folio"].Header.Caption = "Folio";
                this.grdregistrosformatos.DisplayLayout.Bands[0].Columns["fecha"].Header.Caption = "Fecha";
                this.grdregistrosformatos.DisplayLayout.Bands[0].Columns["comentarios"].Header.Caption = "Comentarios";
                this.grdregistrosformatos.DisplayLayout.Bands[0].Columns["vehiculo"].Header.Caption = "Vehículo";

                this.grdregistrosformatos.DisplayLayout.Bands[0].Columns["fecha"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                this.grdregistrosformatos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;

                this.grdregistrosformatos_Click(null, null);



            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

       

        private void btnimprimirtodos_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow orow in this.grdregistrosformatos.Rows)
                {
                    if (this._tipoformato == "combustible")
                    {


                    }
                    else
                    {

                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdregistrosformatos_Click(object sender, EventArgs e)
        {
            try
            {
                this.btntipoformato.Enabled = false;
                if (this.grdregistrosformatos.ActiveRow != null)
                {
                    this.btntipoformato.Enabled = true;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsolicitud_Click(object sender, EventArgs e)
        {
            try
            {
                solicitudes osolicitud = solicitudnc.getsolicitudgenerado(this._id, this._connexionstring);
                generarreportesolicitud(osolicitud.idsolicitud);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnpedido_Click(object sender, EventArgs e)
        {
            try
            {
                pedidos opedido = pedidonc.getpedidogenerado(this._id, this._connexionstring);
                generarreportepedido(opedido.idpedido);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnorden_Click(object sender, EventArgs e)
        {
            try
            {
                ordenes oorden = ordennc.getorden(this._id, this._connexionstring);
                generarreporteorden(oorden.idorden);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnconstancia_Click(object sender, EventArgs e)
        {
            try
            {
                constancias oconstancia = constancianc.getconstancia(this._id, this._connexionstring);
                generarreporteconstancia(oconstancia.idconstancia);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btninforme_Click(object sender, EventArgs e)
        {
            try
            {
                informes oinforme = informenc.getinformegenerado(this._id, this._connexionstring);
                generarreporteinforme(oinforme.idinforme);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public void generarreportesolicitud(int id)
        {
            try
            {
                solicitudes osolicitud = solicitudnc.getsolicitud(id, this._connexionstring);
                empleados oempleado = empleadonc.getempleado((int)osolicitud.idempleado, this._connexionstring);
                departamentos odepartamento = departamentonc.getdepartamento((int)osolicitud.iddepartamento, this._connexionstring);

                //IMPUESTOS DEL CFDI
                string query = "Select";
                query += " isnull(unidades.simbologia,'SN') as unidad,";
                query += " detsolicitudes.* ";
                query += " From detsolicitudes ";
                query += " Left Join unidades on detsolicitudes.idunidad = unidades.idunidad";
                query += " where detsolicitudes.idsolicitud = " + osolicitud.idsolicitud.ToString();
                DataTable dtDetalle = genericas.generales.executeDS(query, this._connexionstring).Tables[0];


                DataSet dsEgresos = (DataSet)new datasets.dsegresos();
                DataRow dataRow = dsEgresos.Tables["dtEncabezado"].NewRow();
                dataRow["nombreempresa"] = oempresa.nombre;
                dataRow["rfc"] = oempresa.rfc;
                dataRow["domicilio"] = string.Empty;
                dataRow["telefono"] = string.Empty;
                dataRow["logo1"] = oparametros.logoizquierdo;
                dataRow["logo2"] = oparametros.logoderecho;
                dataRow["titulo"] = "SOLICITUD DE MATERIALES";
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
                dataRow["fecha"] = osolicitud.fecha;
                dataRow["folio"] = osolicitud.folio;
                dataRow["nombreproveedor"] = string.Empty;
                dataRow["rfcproveedor"] = string.Empty;
                dataRow["comentarios"] = osolicitud.comentarios;
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

                String reportpath = Application.StartupPath + "\\Formatos\\rptsolicitud.rpt";
                ReportDocument reportDocument = new ReportDocument();
                reportDocument.Load(reportpath, OpenReportMethod.OpenReportByTempCopy);
                reportDocument.SetDataSource(dsEgresos);


                frmvisualizadoregresos frmVisualizador = new frmvisualizadoregresos(reportDocument);
                frmVisualizador.Name = "Visualizador" + base.Name;
                frmVisualizador.Text = "Solicitud";
                frmVisualizador.ShowDialog();
                reportDocument.Dispose();

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        public void generarreportepedido(int id)
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
        public void generarreporteorden(int id)
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
        public void generarreporteconstancia(int id)
        {
            try
            {
                constancias oconstancia = constancianc.getconstancia(id, this._connexionstring);
                empleados oempleado = empleadonc.getempleado((int)oconstancia.idempleado, this._connexionstring);
                departamentos odepartamento = departamentonc.getdepartamento((int)oconstancia.iddepartamento, this._connexionstring);

                //IMPUESTOS DEL CFDI
                string query = "Select";
                query += " isnull(unidades.simbologia,'SN') as unidad,";
                query += " detconstancias.* ";
                query += " From detconstancias ";
                query += " Left Join unidades on detconstancias.idunidad = unidades.idunidad";
                query += " where detconstancias.idconstancia = " + oconstancia.idconstancia.ToString();
                DataTable dtDetalle = genericas.generales.executeDS(query, this._connexionstring).Tables[0];

                DataSet dsEgresos = (DataSet)new datasets.dsegresos();
                DataRow dataRow = dsEgresos.Tables["dtEncabezado"].NewRow();
                dataRow["nombreempresa"] = oempresa.nombre;
                dataRow["rfc"] = oempresa.rfc;
                dataRow["domicilio"] = string.Empty;
                dataRow["telefono"] = string.Empty;
                dataRow["logo1"] = oparametros.logoizquierdo;
                dataRow["logo2"] = oparametros.logoderecho;
                dataRow["titulo"] = "CONSTANCIA DE ENTREGA DE MATERIALES";
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
                dataRow["fecha"] = oconstancia.fecha;
                dataRow["folio"] = oconstancia.folio;
                dataRow["nombreproveedor"] = string.Empty;
                dataRow["rfcproveedor"] = string.Empty;
                dataRow["comentarios"] = oconstancia.comentarios;
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

                String reportpath = Application.StartupPath + "\\Formatos\\rptconstancia.rpt";
                ReportDocument reportDocument = new ReportDocument();
                reportDocument.Load(reportpath, OpenReportMethod.OpenReportByTempCopy);
                reportDocument.SetDataSource(dsEgresos);

                frmvisualizadoregresos frmVisualizador = new frmvisualizadoregresos(reportDocument);
                frmVisualizador.Name = "Visualizador" + base.Name;
                frmVisualizador.Text = "Constancia de Entrega de Materiales";
                frmVisualizador.ShowDialog();
                reportDocument.Dispose();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        public void generarreporteinforme(int id)
        {
            try
            {
                informes oinformss = informenc.getinforme(id, this._connexionstring);
                empleados oempleado = empleadonc.getempleado((int)oinformss.idempleado, this._connexionstring);
                departamentos odepartamento = departamentonc.getdepartamento((int)oinformss.iddepartamento, this._connexionstring);

                //IMPUESTOS DEL CFDI
                string query = "Select";
                query += " isnull(unidades.simbologia,'SN') as unidad,";
                query += " detinformes.* ";
                query += " From detinformes ";
                query += " Left Join unidades on detinformes.idunidad = unidades.idunidad";
                query += " where detinformes.idinforme = " + oinformss.idinforme.ToString();
                DataTable dtDetalle = genericas.generales.executeDS(query, this._connexionstring).Tables[0];

                DataSet dsEgresos = (DataSet)new datasets.dsegresos();
                DataRow dataRow = dsEgresos.Tables["dtEncabezado"].NewRow();
                dataRow["nombreempresa"] = oempresa.nombre;
                dataRow["rfc"] = oempresa.rfc;
                dataRow["domicilio"] = string.Empty;
                dataRow["telefono"] = string.Empty;
                dataRow["logo1"] = oparametros.logoizquierdo;
                dataRow["logo2"] = oparametros.logoderecho;
                dataRow["titulo"] = "INFORME DE TRABAJOS REALIZADOS";
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
                dataRow["fecha"] = oinformss.fecha;
                dataRow["folio"] = oinformss.folio;
                dataRow["nombreproveedor"] = string.Empty;
                dataRow["rfcproveedor"] = string.Empty;
                dataRow["comentarios"] = oinformss.comentarios;
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
                    dataRow["destino01"] = Convert.ToString(dtDetalle.Rows[x]["destino01"]);
                    dataRow["destino02"] = Convert.ToString(dtDetalle.Rows[x]["destino02"]);
                    dataRow["destino03"] = Convert.ToString(dtDetalle.Rows[x]["destino03"]);
                    dataRow["destino04"] = Convert.ToString(dtDetalle.Rows[x]["destino04"]);
                    dsEgresos.Tables["dtDocumentoDetalle"].Rows.Add(dataRow);
                }

                dsEgresos.AcceptChanges();

                String reportpath = Application.StartupPath + "\\Formatos\\rptinforme.rpt";
                ReportDocument reportDocument = new ReportDocument();
                reportDocument.Load(reportpath, OpenReportMethod.OpenReportByTempCopy);
                reportDocument.SetDataSource(dsEgresos);

                frmvisualizadoregresos frmVisualizador = new frmvisualizadoregresos(reportDocument);
                frmVisualizador.Name = "Visualizador" + base.Name;
                frmVisualizador.Text = "Informe de Trabajos";
                frmVisualizador.ShowDialog();
                reportDocument.Dispose();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }



        private void btntipoformato_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grdregistrosformatos.ActiveRow != null)
                {
                    if (this._tipoformato == "combustible")
                    {
                        int idgasolina = Convert.ToInt32(this.grdregistrosformatos.ActiveRow.Cells["idgasolina"].Value);
                        generarreportegasolina(idgasolina);

                    }
                    else
                    {
                        int idmantenimiento = Convert.ToInt32(this.grdregistrosformatos.ActiveRow.Cells["idmantenimiento"].Value);
                        generarreportemantenimiento(idmantenimiento);
                    }
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public void generarreportegasolina(int id)
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
                dataRow["placas"] = ovgasolina.placa;
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
        public void generarreportemantenimiento(int id)
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





    }
}
