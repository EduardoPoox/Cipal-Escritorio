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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace cipal.egresos
{
    public partial class frmpedido : Form
    {
        private string _connexionstring;
        private int _idusuario;
        public int _id;
        private int _iddocumentodigital;
        private DataTable dtdettordenes;
        public bool _update = false;

        seriesfoliacion oseriesfoliacion = null;
        private int _idconfig = 0;

        private List<detpedidos> odetpedidos = new List<detpedidos>();
        public frmpedido(int id, int idusuario, int idconfig, string connexionstring)
        {
            try
            {
                InitializeComponent();
                this._connexionstring = connexionstring;
                this._idusuario = idusuario;
                this._id = id;
                this._idconfig = idconfig;
                oseriesfoliacion = seriefoliacionnc.getseriefoliacionvigentebytiposerie(genericas.enums.etiposerie.pedido.ToString(), this._connexionstring);

                cmbidproveedor.ValueChanged += cmbproveedor_ValueChanged;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbproveedor_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbidproveedor.Value != null)
                {
                    int idproveedor = Convert.ToInt32(cmbidproveedor.Value);

                    proveedores odoc = proveedornc.getproveedor(idproveedor, this._connexionstring);
                    txtnombre.Text = odoc.nombre;
                    txtrfc.Text = odoc.rfc;

                }
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
                this.cmbiddepartamento.SetDataBinding(olistdepartamentos, null);
                this.cmbiddepartamento.ValueMember = "iddepartamento";
                this.cmbiddepartamento.DisplayMember = "nombre";
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

                this.cmbidempleado.SetDataBinding(olistempleados, null);
                this.cmbidempleado.ValueMember = "idempleado";
                this.cmbidempleado.DisplayMember = "nombres";
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void cargaproveedores()
        {
            try
            {
                List<proveedores> olistproveedores = proveedornc.getproveedores(this._connexionstring);
                this.cmbidproveedor.SetDataBinding(olistproveedores, null);
                this.cmbidproveedor.ValueMember = "idproveedor";
                this.cmbidproveedor.DisplayMember = "nombre";
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        private void frmorden_Load(object sender, EventArgs e)
        {
            try
            {
                cargadepartamentos();
                cargaempleados();
                cargaproveedores();

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
                if (this._id > 0)
                {
                    pedidos opedido = pedidonc.getpedido(this._id, this._connexionstring);
                    this.txtfolio.Text = opedido.folio;
                    this.dtfecha.DateTime = (DateTime)opedido.fecha;
                    this.cmbidempleado.Value = opedido.idempleado;
                    this.cmbiddepartamento.Value = opedido.iddepartamento;
                    this.cmbidproveedor.Value = opedido.idproveedor;
                    this.txtcomentario.Text = opedido.comentarios;
                    this._iddocumentodigital = Convert.ToInt32(opedido.iddocumentodigital);

                    documentosdigitales odoc = documentodigitalnc.getgetdocumentodigital(this._iddocumentodigital, this._connexionstring);
                    txtdoctodigital.Text = odoc.folio + " - " + odoc.uuid;

                    proveedores oproveedor = proveedornc.getproveedor((int)opedido.idproveedor, this._connexionstring);
                    txtnombre.Text = oproveedor.nombre;
                    txtrfc.Text = oproveedor.rfc;

                    txtsubtotal.Value = opedido.subtotal;
                    txtdescuento.Value = opedido.descuentos;
                    txtsubtotaldescuento.Value = opedido.subtotal - opedido.descuentos;
                    txtimpuestostrasladados.Value = opedido.impuestostrasladados;
                    txtimpuestosretenidos.Value = opedido.impuestosretenidos;
                    txtimpuestostrasloc.Value = opedido.impuestostrasladadoslocales;
                    txtimpuestosretenidosloc.Value = opedido.impuestosretenidoslocales;
                    txttotal.Value = opedido.total;



                }
                else
                {
                    txtfolio.Text = oseriesfoliacion.serie.ToUpper() + (oseriesfoliacion.actual + 1).ToString().PadLeft(4, '0');
                    this._iddocumentodigital = 0;
                }
                this.cargardetalle();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        
        private void btnagregar_Click(object sender, EventArgs e)
        {
            try
            {
                frmpedidodetalle ofrmordendecompradetalle = new frmpedidodetalle(null,null, this._idusuario, this._connexionstring);
                ofrmordendecompradetalle.ShowDialog();
                if (ofrmordendecompradetalle._update)
                {
                    odetpedidos.Add(ofrmordendecompradetalle._odetpedido);

                    List<detpedidos> olist = new List<detpedidos>();
                    olist.Add(ofrmordendecompradetalle._odetpedido);
                    DataTable dtTmp = genericas.helpers.ToDataTable(olist);

                    DataRow oRow = dtdettordenes.NewRow();
                    for(int x=0;x< dtTmp.Columns.Count;x++)
                    {
                        oRow[dtTmp.Columns[x].ColumnName] = dtTmp.Rows[0][x];
                    }
                    oRow["dtimpuestos"] = ofrmordendecompradetalle.dtImpuestos.Copy();
                    dtdettordenes.Rows.Add(oRow);
                    dtdettordenes.AcceptChanges();

                    //cargardetalle();
                    CalcularTotal();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargardetalle()
        {
            try
            {
                if (this._id > 0)
                {
                    List<detpedidos> otmp = detpedidonc.getdetpedidosbyidpedido(this._id, this._connexionstring);
                    if (odetpedidos.Count == 0)
                    {
                        odetpedidos.AddRange(otmp);
                    }
                }

                dtdettordenes = genericas.helpers.ToDataTable(odetpedidos);
                dtdettordenes.Columns.Add(new DataColumn("nombreunidad", typeof(string)));
                dtdettordenes.Columns.Add(new DataColumn("dtimpuestos", typeof(DataTable)));
                dtdettordenes.Columns["nombreunidad"].AllowDBNull = true;
                dtdettordenes.Columns["dtimpuestos"].AllowDBNull = true;

                foreach (DataRow orow in dtdettordenes.Rows)
                {
                    int idunidad = Convert.ToInt32(orow["idunidad"]);

                    unidades ounidad = unidadnc.getunidad(idunidad, this._connexionstring);
                    orow["nombreunidad"] = ounidad.nombre;
                    orow["dtimpuestos"] = CargarImpuestos(Convert.ToInt32(orow["idpedido"]), Convert.ToInt32(orow["iddetpedido"]));
                }
                dtdettordenes.AcceptChanges();

                this.grddetordenes.SetDataBinding(dtdettordenes, null);
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grddetordenes.DisplayLayout.Bands[0].Columns)
                {
                    oColumn.Hidden = true;
                }
                //this.grddetordenes.DisplayLayout.Bands[0].Columns["idorden"].Hidden = false;
                //this.grddetordenes.DisplayLayout.Bands[0].Columns["idconcepto"].Hidden = false;
                //this.grddetordenes.DisplayLayout.Bands[0].Columns["cvesat"].Hidden = false;
                this.grddetordenes.DisplayLayout.Bands[0].Columns["cantidad"].Hidden = false;
                //this.grddetordenes.DisplayLayout.Bands[0].Columns["nombreunidad"].Hidden = false;
                //this.grddetordenes.DisplayLayout.Bands[0].Columns["cveunidad"].Hidden = false;
                //this.grddetordenes.DisplayLayout.Bands[0].Columns["nombre"].Hidden = false;
                //this.grddetordenes.DisplayLayout.Bands[0].Columns["simbologia"].Hidden = false;
                this.grddetordenes.DisplayLayout.Bands[0].Columns["preciounitario"].Hidden = false;
                this.grddetordenes.DisplayLayout.Bands[0].Columns["subtotal"].Hidden = false;
                this.grddetordenes.DisplayLayout.Bands[0].Columns["impuestostrasladados"].Hidden = false;
                this.grddetordenes.DisplayLayout.Bands[0].Columns["impuestosretenidos"].Hidden = false;
                this.grddetordenes.DisplayLayout.Bands[0].Columns["impuestostrasladadoslocales"].Hidden = false;
                this.grddetordenes.DisplayLayout.Bands[0].Columns["impuestosretenidoslocales"].Hidden = false;
                this.grddetordenes.DisplayLayout.Bands[0].Columns["descuentos"].Hidden = false;
                this.grddetordenes.DisplayLayout.Bands[0].Columns["total"].Hidden = false;
                this.grddetordenes.DisplayLayout.Bands[0].Columns["comentarios"].Hidden = false;

                //this.grddetordenes.DisplayLayout.Bands[0].Columns["idorden"].Header.Caption = "Orden";
                //this.grddetordenes.DisplayLayout.Bands[0].Columns["idconcepto"].Header.Caption = "Concepto";
                //this.grddetordenes.DisplayLayout.Bands[0].Columns["cvesat"].Header.Caption = "cve sat";
                this.grddetordenes.DisplayLayout.Bands[0].Columns["cantidad"].Header.Caption = "Cantidad";
                //this.grddetordenes.DisplayLayout.Bands[0].Columns["nombreunidad"].Header.Caption = "Unidad";
                //this.grddetordenes.DisplayLayout.Bands[0].Columns["cveunidad"].Header.Caption = "cve unidad";
                //this.grddetordenes.DisplayLayout.Bands[0].Columns["nombre"].Header.Caption = "Nombre";
                //this.grddetordenes.DisplayLayout.Bands[0].Columns["simbologia"].Header.Caption = "Simbología";
                this.grddetordenes.DisplayLayout.Bands[0].Columns["preciounitario"].Header.Caption = "Precio unitario";
                this.grddetordenes.DisplayLayout.Bands[0].Columns["subtotal"].Header.Caption = "Subtotal";
                this.grddetordenes.DisplayLayout.Bands[0].Columns["impuestostrasladados"].Header.Caption = "Impuestos trasladados";
                this.grddetordenes.DisplayLayout.Bands[0].Columns["impuestosretenidos"].Header.Caption = "Impuestos retenidos";
                this.grddetordenes.DisplayLayout.Bands[0].Columns["impuestostrasladadoslocales"].Header.Caption = "impuestos trasladados locales";
                this.grddetordenes.DisplayLayout.Bands[0].Columns["impuestosretenidoslocales"].Header.Caption = "impuestos retenidos locales";
                this.grddetordenes.DisplayLayout.Bands[0].Columns["descuentos"].Header.Caption = "Descuentos";
                this.grddetordenes.DisplayLayout.Bands[0].Columns["total"].Header.Caption = "Total";
                //this.grddetordenes.DisplayLayout.Bands[0].Columns["comentarios"].Header.Caption = "Comentarios";

                this.grddetordenes.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private DataTable CargarImpuestos(int idpedido, int iddetpedido)
        {
            string query = "Select";
            query += " impdetpedidos.idimpuesto, ";
            query += " impuestos.tipoimpuesto,";
            query += " impdetpedidos.nombre, ";
            query += " impdetpedidos.tasa, ";
            query += " impdetpedidos.cveimpuesto, ";
            query += " impdetpedidos.importe ";
            query += " From impdetpedidos ";
            query += " Left Join impuestos on impdetpedidos.idimpuesto = impuestos.idimpuesto";
            query += " where impdetpedidos.idpedido = " + idpedido.ToString();
            query += " and impdetpedidos.iddetpedido = " + iddetpedido.ToString();
            return genericas.generales.executeDS(query, this._connexionstring).Tables[0];
        }


        private void CalcularTotal()
        {
            try
            {
                decimal subtotal = 0;
                decimal descuento = 0;
                decimal subtotalmenosdescuento = 0;
                decimal totaltraslados = 0;
                decimal totalretenciones = 0;
                decimal totaltrasladoslocales = 0;
                decimal totalretencioneslocales = 0;
                decimal total = 0;



                for (int x = 0; x < dtdettordenes.Rows.Count; x++)
                {
                    subtotal += Convert.ToDecimal(dtdettordenes.Rows[x]["subtotal"]);
                    descuento += Convert.ToDecimal(dtdettordenes.Rows[x]["descuentos"]);

                    totaltraslados += Convert.ToDecimal(dtdettordenes.Rows[x]["impuestostrasladados"]);
                    totalretenciones += Convert.ToDecimal(dtdettordenes.Rows[x]["impuestosretenidos"]);
                    totaltrasladoslocales += Convert.ToDecimal(dtdettordenes.Rows[x]["impuestostrasladadoslocales"]);
                    totalretencioneslocales += Convert.ToDecimal(dtdettordenes.Rows[x]["impuestosretenidoslocales"]);
                }

                subtotalmenosdescuento = System.Math.Round(subtotal - descuento, 6);
                total = subtotalmenosdescuento +  totaltraslados - totalretenciones + totaltrasladoslocales - totalretencioneslocales;
                total = System.Math.Round(total, 6);

                txtsubtotal.Value = subtotal;
                txtdescuento.Value = descuento;
                txtsubtotaldescuento.Value = subtotalmenosdescuento;
                txtimpuestostrasladados.Value = totaltraslados;
                txtimpuestosretenidos.Value = totalretenciones;
                txtimpuestostrasloc.Value = totaltrasladoslocales;
                txtimpuestosretenidosloc.Value = totalretencioneslocales;
                txttotal.Value = total;

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Validar()
        {
            if (this.cmbidproveedor.Value == null)
                throw new System.Exception("Debe seleccionar el proveedor");

            if (this.dtfecha.Value == null)
                throw new System.Exception("Debe seleccionar la fecha");

            if (string.IsNullOrEmpty(this.txtfolio.Text))
                throw new System.Exception("Serie de foliación inválida");
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                int cnt = 0;
                DataTable dtimpfila = null;
                impdetpedidos oimpdetpedidos = null;

                Validar();

                if (this._id > 0)
                {
                    pedidos oorden = pedidonc.getpedido(this._id, this._connexionstring);
                    oorden.folio = this.txtfolio.Text;
                    oorden.fecha = this.dtfecha.DateTime;
                    oorden.idempleado = Convert.ToInt32(this.cmbidempleado.Value);
                    oorden.iddepartamento = Convert.ToInt32(this.cmbiddepartamento.Value);
                    oorden.iddocumentodigital = this._iddocumentodigital;
                    oorden.idproveedor = Convert.ToInt32(this.cmbidproveedor.Value);
                    oorden.comentarios = this.txtcomentario.Text;
                    oorden.usuario = this._idusuario.ToString();
                    oorden.subtotal = Convert.ToDecimal(this.txtsubtotal.Value);
                    oorden.descuentos = Convert.ToDecimal(this.txtdescuento.Value);
                    oorden.impuestostrasladados = Convert.ToDecimal(this.txtimpuestostrasladados.Value);
                    oorden.impuestosretenidos = Convert.ToDecimal(this.txtimpuestosretenidos.Value);
                    oorden.impuestostrasladadoslocales = Convert.ToDecimal(this.txtimpuestostrasloc.Value);
                    oorden.impuestosretenidoslocales = Convert.ToDecimal(this.txtimpuestosretenidosloc.Value);
                    oorden.total = Convert.ToDecimal(this.txttotal.Value);
                    pedidonc.update(oorden, this._connexionstring);

                    List<detordenes> otmp = detordennc.getdetordenesporid(oorden.idpedido, this._connexionstring);
                    foreach (detordenes odet in otmp)
                    {
                        detordennc.delete(odet, this._connexionstring);
                    }

                    //borra el detalle de impuestos por pedido
                    List<impdetpedidos> otmpimp = impdetpedidonc.getimpdetpedidoporpedido(oorden.idpedido, this._connexionstring);
                    foreach (impdetpedidos odet in otmpimp)
                    {
                        impdetpedidonc.delete(odet, this._connexionstring);
                    }

                    foreach (detpedidos odetorden in this.odetpedidos)
                    {
                        odetorden.idpedido = oorden.idpedido;
                        odetorden.iddetpedido = detapoyonc.getid(this._connexionstring);
                        detpedidonc.save(odetorden, this._connexionstring);

                        dtimpfila = (DataTable)dtdettordenes.Rows[cnt]["dtimpuestos"];
                        for(int x=0;x<dtimpfila.Rows.Count;x++)
                        {
                            oimpdetpedidos = new impdetpedidos();
                            oimpdetpedidos.idimpdetpedido = impdetpedidonc.getid(this._connexionstring);
                            oimpdetpedidos.idpedido = oorden.idpedido;
                            oimpdetpedidos.iddetpedido = odetorden.iddetpedido;
                            oimpdetpedidos.idimpuesto = Convert.ToInt32(dtimpfila.Rows[x]["idimpuesto"]);
                            oimpdetpedidos.tasa = Convert.ToDecimal(dtimpfila.Rows[x]["tasa"]);
                            oimpdetpedidos.importe = Convert.ToDecimal(dtimpfila.Rows[x]["importe"]);
                            oimpdetpedidos.cveimpuesto = Convert.ToString(dtimpfila.Rows[x]["cveimpuesto"]);
                            oimpdetpedidos.nombre = Convert.ToString(dtimpfila.Rows[x]["nombre"]);
                            impdetpedidonc.save(oimpdetpedidos, this._connexionstring);
                        }
                        cnt++;
                    }
                }
                else
                {
                    oseriesfoliacion = seriefoliacionnc.getseriefoliacionvigentebytiposerie(genericas.enums.etiposerie.pedido.ToString(), this._connexionstring);
                    oseriesfoliacion.actual = oseriesfoliacion.actual + 1;
                    seriefoliacionnc.update(oseriesfoliacion, this._connexionstring);
                    txtfolio.Text = oseriesfoliacion.serie.ToUpper() + (oseriesfoliacion.actual).ToString().PadLeft(4, '0');

                    pedidos oorden = new pedidos();
                    oorden.idpedido = pedidonc.getid(this._connexionstring);
                    oorden.folio = this.txtfolio.Text;
                    oorden.fecha = this.dtfecha.DateTime;
                    oorden.idempleado = Convert.ToInt32(this.cmbidempleado.Value);
                    oorden.iddepartamento = Convert.ToInt32(this.cmbiddepartamento.Value);
                    oorden.iddocumentodigital = this._iddocumentodigital;
                    oorden.idproveedor = Convert.ToInt32(this.cmbidproveedor.Value);
                    oorden.comentarios = this.txtcomentario.Text;
                    oorden.usuario = this._idusuario.ToString();
                    oorden.subtotal = Convert.ToDecimal(this.txtsubtotal.Value);
                    oorden.descuentos = Convert.ToDecimal(this.txtdescuento.Value);
                    oorden.impuestostrasladados = Convert.ToDecimal(this.txtimpuestostrasladados.Value);
                    oorden.impuestosretenidos = Convert.ToDecimal(this.txtimpuestosretenidos.Value);
                    oorden.impuestostrasladadoslocales = Convert.ToDecimal(this.txtimpuestostrasloc.Value);
                    oorden.impuestosretenidoslocales = Convert.ToDecimal(this.txtimpuestosretenidosloc.Value);
                    oorden.total = Convert.ToDecimal(this.txttotal.Value);
                    oorden.baja = false;
                    pedidonc.save(oorden, this._connexionstring);
                    this._id = oorden.idpedido;


                    foreach (detpedidos odetorden in this.odetpedidos)
                    {
                        odetorden.idpedido = oorden.idpedido;
                        odetorden.iddetpedido = detpedidonc.getid(this._connexionstring);
                        detpedidonc.save(odetorden, this._connexionstring);

                        dtimpfila = (DataTable)dtdettordenes.Rows[cnt]["dtimpuestos"];
                        for (int x = 0; x < dtimpfila.Rows.Count; x++)
                        {
                            oimpdetpedidos = new impdetpedidos();
                            oimpdetpedidos.idimpdetpedido = impdetpedidonc.getid(this._connexionstring);
                            oimpdetpedidos.idpedido = oorden.idpedido;
                            oimpdetpedidos.iddetpedido = odetorden.iddetpedido;
                            oimpdetpedidos.idimpuesto = Convert.ToInt32(dtimpfila.Rows[x]["idimpuesto"]);
                            oimpdetpedidos.tasa = Convert.ToDecimal(dtimpfila.Rows[x]["tasa"]);
                            oimpdetpedidos.importe = Convert.ToDecimal(dtimpfila.Rows[x]["importe"]);
                            oimpdetpedidos.cveimpuesto = Convert.ToString(dtimpfila.Rows[x]["cveimpuesto"]);
                            oimpdetpedidos.nombre = Convert.ToString(dtimpfila.Rows[x]["nombre"]);
                            impdetpedidonc.save(oimpdetpedidos, this._connexionstring);
                        }
                        cnt++;
                    }
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

        private void btnquitar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(this.grddetordenes.ActiveRow.Cells["iddetorden"].Value);
                if (MessageBox.Show("¿Esta seguro de eliminar el registro", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.odetpedidos.RemoveAt(this.grddetordenes.ActiveRow.Index);

                    this.cargardetalle();

                    CalcularTotal();
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

        private void grddetordenes_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            try
            {
                if (grddetordenes.ActiveRow != null)
                {
                    detpedidos odetorden = odetpedidos[grddetordenes.ActiveRow.Index];
                    DataTable dtimp = (DataTable)dtdettordenes.Rows[grddetordenes.ActiveRow.Index]["dtimpuestos"];
                    frmpedidodetalle ofrmordendecompradetalle = new frmpedidodetalle(odetorden, dtimp.Copy(), this._idusuario, this._connexionstring);
                    ofrmordendecompradetalle.ShowDialog();
                    if (ofrmordendecompradetalle._update)
                    {
                        odetpedidos[grddetordenes.ActiveRow.Index] = ofrmordendecompradetalle._odetpedido;

                        List<detpedidos> olist = new List<detpedidos>();
                        olist.Add(ofrmordendecompradetalle._odetpedido);
                        DataTable dtTmp = genericas.helpers.ToDataTable(olist);

                        DataRow oRow = dtdettordenes.Rows[grddetordenes.ActiveRow.Index];
                        for (int x = 0; x < dtTmp.Columns.Count; x++)
                        {
                            oRow[dtTmp.Columns[x].ColumnName] = dtTmp.Rows[0][x];
                        }

                        oRow["dtimpuestos"] = ofrmordendecompradetalle.dtImpuestos.Copy();
                        dtdettordenes.AcceptChanges();

                        //cargardetalle();

                        CalcularTotal();
                    }
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
                frmcambiarseriedefoliacion ofrmcambiarseriefoliacion = new frmcambiarseriedefoliacion(this._id, this._idconfig, this._idusuario, genericas.enums.etiposerie.solicitud.ToString(), this._connexionstring);
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

        private void btnbuscardoctodigital_Click(object sender, EventArgs e)
        {
            try
            {
                frmbuscardocumentodigital ofrmdocumentodigitalconsulta = new frmbuscardocumentodigital(this._id, this._idconfig, this._idusuario, this._connexionstring);
                ofrmdocumentodigitalconsulta.ShowDialog();
                if (ofrmdocumentodigitalconsulta.ok)
                {
                    int iddocumentodigital = ofrmdocumentodigitalconsulta.iddocumentodigital;
                    documentosdigitales odoc = documentodigitalnc.getgetdocumentodigital(iddocumentodigital, this._connexionstring);

                    string seriefolio = odoc.serie + odoc.folio;

                    if (seriefolio.Trim() != "")
                    {
                        txtdoctodigital.Text = seriefolio + " - " + odoc.uuid;
                    }
                    else
                    {
                        txtdoctodigital.Text = odoc.uuid;
                    }


                    this._iddocumentodigital = iddocumentodigital;
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
                    cargadepartamentos();
                    this.cmbiddepartamento.Value = ofrmdepartamento.iddepartamentonuevo;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnagregarproveedor_Click(object sender, EventArgs e)
        {
            try
            {
                frmproveedor ofrmproveedor = new frmproveedor(0, this._idusuario, this._connexionstring);
                ofrmproveedor.ShowDialog();
                if (ofrmproveedor._update)
                {
                    cargaproveedores();
                    this.cmbidproveedor.Value = ofrmproveedor.idproveedornuevo;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
