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
using cipal.egresos;

using Infragistics.Win;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Drawing.Imaging;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using MessagingToolkit.QRCode.Codec;

namespace cipal.descargas
{
    public partial class frmdocumentodigitalconsulta : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;
        private int _idconfig;
        parametros oparametros = null;

        private DataTable DTTipoXML = null;

        string[] ejercicios = { "2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028" };

        public frmdocumentodigitalconsulta(int id, int idconfig, int idusuario, string connexionstring)
        {
            InitializeComponent();
            this._idusuario = idusuario;
            this._connexionstring = connexionstring;
            this._id = id;
            this._idconfig = idconfig;


            DateTime _fechainicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime _fechafinal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            this.cmbfechainicial.Value = _fechainicial;
            this.cmbfechafinal.Value = _fechafinal;
            oparametros = parametronc.getparametro(this._idconfig, this._connexionstring);

            string[] tipoxml = Enum.GetNames(typeof(genericas.enums.etipoxml));

            DTTipoXML = new DataTable("tipoxml");
            DTTipoXML.Columns.Add(new DataColumn("tipo", typeof(string)));
            DTTipoXML.Columns.Add(new DataColumn("nombre", typeof(string)));

            foreach (string tipo in tipoxml)
            {
                DataRow orow = DTTipoXML.NewRow();
                switch (tipo)
                {
                    case "Ingreso":
                        orow["tipo"] = "I";
                        orow["nombre"] = "Ingreso";
                        break;
                    case "Egreso":
                        orow["tipo"] = "E";
                        orow["nombre"] = "Egreso";
                        break;
                    case "Pago":
                        orow["tipo"] = "P";
                        orow["nombre"] = "Pago";
                        break;
                    case "Traslado":
                        orow["tipo"] = "T";
                        orow["nombre"] = "Traslado";
                        break;
                    case "Nomina":
                        orow["tipo"] = "N";
                        orow["nombre"] = "Nomina";
                        break;
                }
                DTTipoXML.Rows.Add(orow);
            }

            this.cmbtipoxml.DataSource = DTTipoXML;
            this.cmbtipoxml.ValueMember = "tipo";
            this.cmbtipoxml.DisplayMember = "nombre";
            this.cmbtipoxml.SelectedIndex = 0;



            this.cmbejercicios.SetDataBinding(ejercicios, null);
            this.cmbejercicios.Text = DateTime.Now.Year.ToString();

            this.cmbperiodo.SetDataBinding(Enum.GetNames(typeof(genericas.enums.emeses)), null);
            this.cmbperiodo.Text = genericas.enums.emeses.enero.ToString();


        }

        private void frmdocumentodigitalconsulta_Load(object sender, EventArgs e)
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

        private void consultar()
        {
            try
            {
                string tiposolicitud = this.optipodescargas.Value.ToString();
                string tipoxml = this.cmbtipoxml.Value.ToString();
                DateTime fi = Convert.ToDateTime(this.cmbfechainicial.Value);
                DateTime ff = Convert.ToDateTime(this.cmbfechafinal.Value);

                fi = new DateTime(fi.Year, fi.Month, fi.Day);
                ff = new DateTime(ff.Year, ff.Month, ff.Day).AddDays(1).AddSeconds(-1);

                string rfc = this.txtrfc.Text;
                string nombre = this.txtnombre.Text;

                List<documentosdigitales> olistdocumentosdigitales =
                    documentodigitalnc.getdocumentosdigitalesbyparams(tiposolicitud, tipoxml, fi, ff, rfc, nombre, this._connexionstring).Where(a => a.estatus == "Vigente").ToList();




                List<documentosdigitalesconceptos> olistdocumentosdigitalesconceptos = new List<documentosdigitalesconceptos>();
                foreach (documentosdigitales odoc in olistdocumentosdigitales)
                {
                    olistdocumentosdigitalesconceptos.AddRange(documentodigitalconceptonc.getdocumentosdigitalesconceptosbyiddocumentodigital(odoc.iddocumentodigital, this._connexionstring));
                }

                DataTable DT = genericas.helpers.ToDataTable(olistdocumentosdigitales);

                DT.Columns.Add("solicitud", typeof(int));
                DT.Columns.Add("orden", typeof(int));
                DT.Columns.Add("pedido", typeof(int));
                DT.Columns.Add("constancia", typeof(int));
                DT.Columns.Add("informe", typeof(int));
                DT.Columns.Add("gasolina", typeof(int));
                DT.Columns.Add("mantenimiento", typeof(int));
                DT.Columns.Add("activofijo", typeof(int));

                DataTable DTDetalle = genericas.helpers.ToDataTable(olistdocumentosdigitalesconceptos);
                foreach (DataRow orow in DT.Rows)
                {
                    string vtipoxml = orow["tipoxml"].ToString();
                    switch (vtipoxml)
                    {
                        case "I": orow["tipoxml"] = "I-Ingreso"; break;
                        case "E": orow["tipoxml"] = "E-Egreso"; break;
                        case "P": orow["tipoxml"] = "P-Pago"; break;
                        case "T": orow["tipoxml"] = "T-Traslado"; break;
                        case "N": orow["tipoxml"] = "N-Nomina"; break;
                    }

                    string grupoformatos = orow["clasificador"].ToString().Trim();


                    if (grupoformatos == "")
                    {
                        if (tiposolicitud == "recibidos")
                        {
                            orow["clasificador"] = genericas.enums.egrupoformatorecibido.ninguno.ToString();
                        }
                        else
                        {
                            orow["clasificador"] = genericas.enums.egrupoformatoemitido.ninguno.ToString();
                        }

                    }

                    string validacionefos = orow["validacionefos"].ToString().Trim();
                    if (validacionefos == "200")
                    {
                        orow["validacionefos"] = "Negativo";
                    }
                    else
                    {
                        orow["validacionefos"] = "Positivo";
                    }


                    int iddocumentodigital = Convert.ToInt32(orow["iddocumentodigital"]);

                    orow["solicitud"] = solicitudnc.getsolicitudesgenerados(iddocumentodigital, this._connexionstring); ;
                    orow["orden"] = ordennc.getordenesgenerados(iddocumentodigital, this._connexionstring);
                    orow["pedido"] = pedidonc.getpedidosgenerados(iddocumentodigital, this._connexionstring);
                    orow["constancia"] = constancianc.getconstanciasgenerados(iddocumentodigital, this._connexionstring); 
                    orow["informe"] = informenc.getinformesgenerados(iddocumentodigital, this._connexionstring);
                    orow["gasolina"] = gasolinanc.getgasolinasgenerados(iddocumentodigital, this._connexionstring);
                    orow["mantenimiento"] = mantenimientonc.getmantenimientosgenerados(iddocumentodigital, this._connexionstring);
                    orow["activofijo"] = 0;

                }
                DT.AcceptChanges();

                DT.TableName = "documentosdigitales";
                DTDetalle.TableName = "documentosdigitalesconceptos";
                DataSet DS = new DataSet();
                DS.Tables.Add(DT);
                DS.Tables.Add(DTDetalle);
                DS.Relations.Add("doc", DS.Tables["documentosdigitales"].Columns["iddocumentodigital"], DS.Tables["documentosdigitalesconceptos"].Columns["iddocumentodigital"]);



                this.grddocumentosdigitales.SetDataBinding(DS, null);
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns)
                {
                    oColumn.Hidden = true;
                }

                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["serie"].Hidden = false;
                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["folio"].Hidden = false;
                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["tipoxml"].Hidden = false;
                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["uuid"].Hidden = false;

                if (tiposolicitud == "recibidos")
                {
                    this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["clasificador"].Hidden = false;
                    this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["rfcemisor"].Hidden = false;
                    this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["nombreemisor"].Hidden = false;

                    this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["solicitud"].Hidden = false;
                    this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["orden"].Hidden = false;
                    this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["pedido"].Hidden = false;
                    this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["constancia"].Hidden = false;
                    this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["informe"].Hidden = false;
                    this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["gasolina"].Hidden = false;
                    this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["mantenimiento"].Hidden = false;

                    this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["solicitud"].Header.Caption = "S";
                    this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["orden"].Header.Caption = "O";
                    this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["pedido"].Header.Caption = "P";
                    this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["constancia"].Header.Caption = "C";
                    this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["informe"].Header.Caption = "I";
                    this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["gasolina"].Header.Caption = "G";
                    this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["mantenimiento"].Header.Caption = "M";
                }
                else
                {
                    //this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["clasificador"].Hidden = false;
                    this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["rfcreceptor"].Hidden = false;
                    this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["nombrereceptor"].Hidden = false;

                    //this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["activofijo"].Hidden = false;
                    //this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["activofijo"].Header.Caption = "AF";
                }



                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["fechaemision"].Hidden = false;
                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["monto"].Hidden = false;
                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["estatus"].Hidden = false;
               
                //this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["escancelable"].Hidden = false;
                //this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["estatuscancelacion"].Hidden = false;
                //this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["validacionefos"].Hidden = false;


                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["serie"].Header.Caption = "Serie";
                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["folio"].Header.Caption = "Folio";
                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["tipoxml"].Header.Caption = "Tipo de XML";
                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["uuid"].Header.Caption = "UUID";
                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["rfcemisor"].Header.Caption = "RFC del Emisor";
                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["nombreemisor"].Header.Caption = "Nombre del Emisor";
                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["rfcreceptor"].Header.Caption = "RFC del Receptor";
                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["nombrereceptor"].Header.Caption = "Nombre del Receptor";
                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["fechaemision"].Header.Caption = "Fecha de Emisión";
                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["monto"].Header.Caption = "Total";
                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["estatus"].Header.Caption = "Estado";
                //this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["escancelable"].Header.Caption = "Es Cancelable";
                //this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["estatuscancelacion"].Header.Caption = "Estatus de Cancelación";
                //this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["validacionefos"].Header.Caption = "RFC en Lista Negra";

                //Parte para el grupo de formatos
                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["clasificador"].Header.Caption = "Tipo de Formatos";
                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["clasificador"].ValueList = GetValueListGrupoFormatos(tiposolicitud);
                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["clasificador"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["clasificador"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["clasificador"].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;

                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["fechaemision"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["fechacertificacionsat"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;


                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grddocumentosdigitales.DisplayLayout.Bands[1].Columns)
                {
                    oColumn.Hidden = true;
                }
                this.grddocumentosdigitales.DisplayLayout.Bands[1].Columns["cantidad"].Hidden = false;
                this.grddocumentosdigitales.DisplayLayout.Bands[1].Columns["noidentificacion"].Hidden = false;
                this.grddocumentosdigitales.DisplayLayout.Bands[1].Columns["unidad"].Hidden = false;
                this.grddocumentosdigitales.DisplayLayout.Bands[1].Columns["claveunidad"].Hidden = false;
                this.grddocumentosdigitales.DisplayLayout.Bands[1].Columns["descripcion"].Hidden = false;
                this.grddocumentosdigitales.DisplayLayout.Bands[1].Columns["valorunitario"].Hidden = false;
                this.grddocumentosdigitales.DisplayLayout.Bands[1].Columns["importe"].Hidden = false;
                this.grddocumentosdigitales.DisplayLayout.Bands[1].Columns["claveprodserv"].Hidden = false;

                this.grddocumentosdigitales.DisplayLayout.Bands[1].Columns["cantidad"].Header.Caption = "Cantidad";
                this.grddocumentosdigitales.DisplayLayout.Bands[1].Columns["noidentificacion"].Header.Caption = "No. de Identificación";
                this.grddocumentosdigitales.DisplayLayout.Bands[1].Columns["unidad"].Header.Caption = "Unidad";
                this.grddocumentosdigitales.DisplayLayout.Bands[1].Columns["claveunidad"].Header.Caption = "Clave de Unidad SAT";
                this.grddocumentosdigitales.DisplayLayout.Bands[1].Columns["descripcion"].Header.Caption = "Descripción";
                this.grddocumentosdigitales.DisplayLayout.Bands[1].Columns["valorunitario"].Header.Caption = "Precio Unitario";
                this.grddocumentosdigitales.DisplayLayout.Bands[1].Columns["importe"].Header.Caption = "Importe";
                this.grddocumentosdigitales.DisplayLayout.Bands[1].Columns["claveprodserv"].Header.Caption = "Clave Producto/Servicio SAT";



                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["gasolina"].CellAppearance.BackColor = Color.DarkCyan;
                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["mantenimiento"].CellAppearance.BackColor = Color.DarkCyan;


                this.grddocumentosdigitales.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;



                this.grddocumentosdigitales_Click(null, null);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private ValueList GetValueListGrupoFormatos(string tiposolicitud)
        {
            try
            {

                ValueList ovaluelist = new ValueList();

                string[] evalues = null;
                if (tiposolicitud == "recibidos")
                {
                    evalues = Enum.GetNames(typeof(genericas.enums.egrupoformatorecibido));
                }
                else
                {
                    evalues = Enum.GetNames(typeof(genericas.enums.egrupoformatoemitido));
                }
                
                foreach (string value in evalues)
                {
                    ovaluelist.ValueListItems.Add(value, value);
                }

                ovaluelist.Appearance.BackColor = Color.LightSteelBlue;
                ovaluelist.Appearance.BackColor2 = Color.MediumBlue;
                return ovaluelist;
            }
            catch (System.Exception ex)
            {
                throw ex;
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
                if (this.grddocumentosdigitales.ActiveRow != null)
                {
                    if (MessageBox.Show("¿Esta seguro de eliminar el documento digital seleccionado?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int iddocumentodigital = Convert.ToInt32(this.grddocumentosdigitales.ActiveRow.Cells["iddocumentodigital"].Value);
                        documentosdigitales odoc = documentodigitalnc.getgetdocumentodigital(iddocumentodigital, this._connexionstring);
                        odoc.baja = true; 
                        documentodigitalnc.update(odoc, this._connexionstring);
                        consultar();
                    }
                     
                }
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
                if (this.grddocumentosdigitales.ActiveRow != null)
                {
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridRow oRow in this.grddocumentosdigitales.Rows)
                    {
                        int iddocumentodigital = Convert.ToInt32(oRow.Cells["iddocumentodigital"].Value);
                        string uuid = oRow.Cells["uuid"].Value.ToString();
                        string grupoformato = oRow.Cells["clasificador"].Value.ToString();

                        documentosdigitales odoc = documentodigitalnc.getgetdocumentodigital(iddocumentodigital, this._connexionstring);
                        odoc.clasificador = grupoformato;
                        documentodigitalnc.update(odoc, this._connexionstring);

                    }

                    MessageBox.Show("¡Grupo de formatos almacenados correctamente!", "Mensaje de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    consultar();


                }
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
                string dirfile = oconfig.direxportaciones + @"\documentosdigitales.xlsx";
                this.ugExcel.Export(grddocumentosdigitales, dirfile);
                System.Diagnostics.Process.Start(dirfile);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnpdf_Click(object sender, EventArgs e)
        {
            try
            {
                if (grddocumentosdigitales.ActiveRow != null)
                {
                    int iddocumentodigital = Convert.ToInt32(grddocumentosdigitales.ActiveRow.Cells["iddocumentodigital"].Value);
                    obtenerreportdocument(iddocumentodigital);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void obtenerreportdocument(int iddocumentodigital)
        {
            try
            {
                //Carga catálogos del SAT
                string query = "select clave as 'value', descripcion as 'name' from dbo.cfdiformapago where dbo.cfdiformapago.baja=0";
                DataTable dtformapago = genericas.generales.executeDS(query, this._connexionstring).Tables[0];

                query = "select clave as 'value', descripcion as 'name' from dbo.cfdimetodopago where dbo.cfdimetodopago.baja=0";
                DataTable dtmetodopago = genericas.generales.executeDS(query, this._connexionstring).Tables[0];

                query = "select clave as 'value', descripcion  as 'name' from dbo.cfdiuso where dbo.cfdiuso.baja=0";
                DataTable dtusocfdi = genericas.generales.executeDS(query, this._connexionstring).Tables[0];

                query = "select clave as 'value', descripcion as 'name' from dbo.cfditiporelacionfiscal where dbo.cfditiporelacionfiscal.baja=0";
                DataTable dttiporelacionfiscal = genericas.generales.executeDS(query, this._connexionstring).Tables[0];

                query = "select clave as 'value', descripcion as 'name',0 as applied,* from dbo.cfditasaimpuesto where dbo.cfditasaimpuesto.baja=0 and dbo.cfditasaimpuesto.traslado=1 ";
                DataTable dttraslados = genericas.generales.executeDS(query, this._connexionstring).Tables[0];

                query = "select clave as 'value', descripcion as 'name',0 as applied,* from dbo.cfditasaimpuesto where dbo.cfditasaimpuesto.baja=0 and dbo.cfditasaimpuesto.traslado=0 ";
                DataTable dtretenciones = genericas.generales.executeDS(query, this._connexionstring).Tables[0];

                query = "select clave as 'value', descripcion as 'name',* from dbo.cfdiregimenfiscal where dbo.cfdiregimenfiscal.baja=0";
                DataTable dtregimenfiscal = genericas.generales.executeDS(query, this._connexionstring).Tables[0];

                //catalogos de nomina
                query = "select clave as 'value', descripcion as 'name' from dbo.cfditiporegimen where dbo.cfditiporegimen.baja=0";
                DataTable dttiporegimen = genericas.generales.executeDS(query, this._connexionstring).Tables[0];

                query = "select clave as 'value', descripcion as 'name' from dbo.cfditiponomina where dbo.cfditiponomina.baja=0";
                DataTable dttiponomina = genericas.generales.executeDS(query, this._connexionstring).Tables[0];

                query = "select clave as 'value', descripcion as 'name' from dbo.cfditipojornada where dbo.cfditipojornada.baja=0";
                DataTable dttipojornada = genericas.generales.executeDS(query, this._connexionstring).Tables[0];

                query = "select clave as 'value', descripcion as 'name' from dbo.cfditipocontrato where dbo.cfditipocontrato.baja=0";
                DataTable dttipocontrato = genericas.generales.executeDS(query, this._connexionstring).Tables[0];

                query = "select clave as 'value', descripcion as 'name' from dbo.cfdiriesgopuesto where dbo.cfdiriesgopuesto.baja=0";
                DataTable dtriesgopuesto = genericas.generales.executeDS(query, this._connexionstring).Tables[0];

                query = "select clave as 'value', descripcion as 'name' from dbo.cfdiperiodicidad where dbo.cfdiperiodicidad.baja=0";
                DataTable dtperiodicidad = genericas.generales.executeDS(query, this._connexionstring).Tables[0];

                query = "select clave as 'value', descripcion as 'name' from dbo.cfdiorigenrecurso where dbo.cfdiorigenrecurso.baja=0";
                DataTable dtorigenrecurso = genericas.generales.executeDS(query, this._connexionstring).Tables[0];


                documentosdigitales odoc = documentodigitalnc.getgetdocumentodigital(iddocumentodigital, this._connexionstring);
                //carga el xml en un dataset
                String _NewCFDIPath = oparametros.dirtmp + "\\tempTFDGetFile.xml";
                File.WriteAllBytes(_NewCFDIPath, odoc.xml);

                string xml = Encoding.UTF8.GetString(odoc.xml);
                XmlDocument oxml = new XmlDocument();
                oxml.LoadXml(xml);

                DataSet dataSet = new DataSet();
                dataSet.ReadXml(_NewCFDIPath);

                bool flagNomina = false;
                DataSet dsImpresion = null;
                if (dataSet.Tables.Contains("nomina12"))
                {
                    flagNomina = true;
                    dsImpresion = (DataSet)new datasets.dsImpresionNomina12v33();
                }
                else
                    dsImpresion = (DataSet)new datasets.dsImpresion33();


                string[] parametros = LoadRepImpresaParams(oxml, odoc, _NewCFDIPath);
                Image image = QRGen(parametros[0].Replace("Ñ", "N").Replace("ñ", "n"));

                DataRow dataRow = dsImpresion.Tables["Impresion"].NewRow();
                dataRow["CBB"] = ImageToByteArray(image);
                dataRow["CadenaSat"] = parametros[2];
                dataRow["Logotipo"] = null;
                dataRow["CantidadLetras"] = parametros[3];
                dataRow["Comentarios"] = "Versión de la representación Impresa Generada por ContaFast";
                dsImpresion.Tables["Impresion"].Rows.Add(dataRow);
                if (flagNomina)
                {
                    int num = 0;
                    int num2 = 0;
                    for (int i = 0; i < dataSet.Tables.Count; i++)
                    {
                        if (dataSet.Tables[i].TableName.ToLower() == "emisor")
                        {
                            num++;
                            if (num == 2)
                            {
                                DataTable dataTable = dataSet.Tables[i];
                                dataTable.TableName = "EmisorNomina";
                            }
                        }
                        if (dataSet.Tables[i].TableName.ToLower() == "receptor")
                        {
                            num2++;
                            if (num2 == 2)
                            {
                                DataTable dataTable2 = dataSet.Tables[i];
                                dataTable2.TableName = "ReceptorNomina";
                            }
                        }
                    }
                }

                dsImpresion.Merge(dataSet, true, MissingSchemaAction.Ignore);
                dsImpresion.AcceptChanges();

                string reportpath = string.Empty;
                if (odoc.tipoxml == "P")
                {
                    SetDescripcionCatalogo(dsImpresion, "Comprobante", dtmetodopago, "value", "MetodoPago", "", "", "name", "MetodoPago");
                    SetDescripcionCatalogo(dsImpresion, "Comprobante", dtformapago, "value", "FormaPago", "", "", "name", "FormaPago");
                    SetDescripcionCatalogo(dsImpresion, "Pago", dtformapago, "value", "FormaDePagoP", "", "", "name", "FormaDePagoP");
                    SetDescripcionCatalogo(dsImpresion, "DoctoRelacionado", dtmetodopago, "value", "MetodoDePagoDR", "", "", "name", "MetodoDePagoDR");
                    SetDescripcionCatalogo(dsImpresion, "Receptor", dtusocfdi, "value", "UsoCFDI", "", "", "name", "UsoCFDI");
                    SetDescripcionCatalogo(dsImpresion, "Emisor", dtregimenfiscal, "value", "RegimenFiscal", "", "", "name", "RegimenFiscal");
                    SetDescripcionCatalogo(dsImpresion, "CfdiRelacionados", dttiporelacionfiscal, "value", "TipoRelacion", "", "", "name", "TipoRelacion");
                    reportpath = Application.StartupPath + "\\Formatos\\rptComplementoPago.rpt";

                }
                else if (odoc.tipoxml == "N")
                {
                    SetDescripcionCatalogo(dsImpresion, "Comprobante", dtmetodopago, "value", "MetodoPago", "", "", "name", "MetodoPago");
                    SetDescripcionCatalogo(dsImpresion, "Comprobante", dtformapago, "value", "FormaPago", "", "", "name", "FormaPago");
                    SetDescripcionCatalogo(dsImpresion, "Receptor", dtusocfdi, "value", "UsoCFDI", "", "", "name", "UsoCFDI");
                    SetDescripcionCatalogo(dsImpresion, "Emisor", dtregimenfiscal, "value", "RegimenFiscal", "", "", "name", "RegimenFiscal");
                    SetDescripcionCatalogo(dsImpresion, "CfdiRelacionados", dttiporelacionfiscal, "value", "TipoRelacion", "", "", "name", "TipoRelacion");
                    SetDescripcionCatalogo(dsImpresion, "Retencion", dtretenciones, "value", "Impuesto", "tasacuota", "TasaOCuota", "name", "Impuesto", "applied");
                    SetDescripcionImpuestosGrales(dsImpresion, "Retencion", dtretenciones);
                    SetDescripcionCatalogo(dsImpresion, "ReceptorNomina", dtperiodicidad, "value", "PeriodicidadPago", "", "", "name", "PeriodicidadPago");
                    SetDescripcionCatalogo(dsImpresion, "ReceptorNomina", dtriesgopuesto, "value", "RiesgoPuesto", "", "", "name", "RiesgoPuesto");
                    SetDescripcionCatalogo(dsImpresion, "ReceptorNomina", dttipocontrato, "value", "TipoContrato", "", "", "name", "TipoContrato");
                    SetDescripcionCatalogo(dsImpresion, "ReceptorNomina", dttipojornada, "value", "TipoJornada", "", "", "name", "TipoJornada");
                    SetDescripcionCatalogo(dsImpresion, "ReceptorNomina", dttiporegimen, "value", "TipoRegimen", "", "", "name", "TipoRegimen");
                    reportpath = Application.StartupPath + "\\Formatos\\rptReciboNomina.rpt";
                }
                else
                {
                    SetDescripcionCatalogo(dsImpresion, "Comprobante", dtmetodopago, "value", "MetodoPago", "", "", "name", "MetodoPago");
                    SetDescripcionCatalogo(dsImpresion, "Comprobante", dtformapago, "value", "FormaPago", "", "", "name", "FormaPago");
                    SetDescripcionCatalogo(dsImpresion, "Receptor", dtusocfdi, "value", "UsoCFDI", "", "", "name", "UsoCFDI");
                    SetDescripcionCatalogo(dsImpresion, "Emisor", dtregimenfiscal, "value", "RegimenFiscal", "", "", "name", "RegimenFiscal");
                    SetDescripcionCatalogo(dsImpresion, "CfdiRelacionados", dttiporelacionfiscal, "value", "TipoRelacion", "", "", "name", "TipoRelacion");
                    SetDescripcionCatalogo(dsImpresion, "DoctoRelacionado", dtmetodopago, "value", "MetodoDePagoDR", "", "", "name", "MetodoDePagoDR");
                    SetDescripcionCatalogo(dsImpresion, "Traslado", dttraslados, "value", "Impuesto", "tasacuota", "TasaOCuota", "name", "Impuesto", "applied");
                    SetDescripcionCatalogo(dsImpresion, "Retencion", dtretenciones, "value", "Impuesto", "tasacuota", "TasaOCuota", "name", "Impuesto", "applied");
                    SetDescripcionImpuestosGrales(dsImpresion, "Traslado", dttraslados);
                    SetDescripcionImpuestosGrales(dsImpresion, "Retencion", dtretenciones);
                    reportpath = Application.StartupPath + "\\Formatos\\rptFactura.rpt";

                }

                ReportDocument reportDocument = new ReportDocument();
                reportDocument.Load(reportpath, OpenReportMethod.OpenReportByTempCopy);
                reportDocument.SetDataSource(dsImpresion);
                if (!flagNomina)
                {
                    reportDocument.SetParameterValue("Ret", odoc.totaltrasladados > 0);
                    reportDocument.SetParameterValue("Tras", odoc.totaltrasladados > 0);
                    reportDocument.SetParameterValue("DetalleIVA", false);
                    reportDocument.SetParameterValue("Vigente", odoc.estatus.ToLower() == "vigente");
                    reportDocument.SetParameterValue("Header", "COMPROBANTE FISCAL DIGITAL");
                }

                frmvisualizadorcfdi frmVisualizador = new frmvisualizadorcfdi(reportDocument);
                frmVisualizador.Name = "Visualizador" + base.Name;
                frmVisualizador.Text = "Comprobante Fiscal";
                frmVisualizador.ShowDialog();
                reportDocument.Dispose();

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private String[] LoadRepImpresaParams(XmlDocument document, documentosdigitales odoc, String pathxml)
        {
            try
            {
                String[] parametros = new String[4];
                DataSet dsTemp = new DataSet();
                XmlNodeList listComprobante = document.GetElementsByTagName("cfdi:Comprobante");
                XmlNodeList TimbreFiscal = document.GetElementsByTagName("tfd:TimbreFiscalDigital");
                String TotalCBB = Convert.ToString(genericas.helpers.GetXMLAttributeValue(listComprobante, "Total"));
                String Moneda = Convert.ToString(genericas.helpers.GetXMLAttributeValue(listComprobante, "Moneda"));
                String Sello = Convert.ToString(genericas.helpers.GetXMLAttributeValue(listComprobante, "Sello"));

                //Imagen CBB y Cadena SAT
                string cbbText = odoc.monto.ToString();
                if (cbbText.IndexOf(".") > 0)
                {
                    string stringtext = cbbText.Substring(cbbText.IndexOf(".") + 1);
                    if (stringtext.Length < 6)
                    {
                        cbbText = cbbText.Replace("." + stringtext, "");
                        stringtext = stringtext.PadRight(6, '0');
                        cbbText = cbbText + "." + stringtext;
                    }
                }

                string str2 = "https://verificacfdi.facturaelectronica.sat.gob.mx/default.aspx";
                str2 = str2 + "?&id=" + odoc.uuid;
                str2 = str2 + "&re=" + odoc.rfcemisor;
                str2 = str2 + "&rr=" + odoc.rfcreceptor;
                str2 = str2 + "&tt=" + cbbText;
                str2 = str2 + "&fe=" + RightString((Sello).Replace("==", ""), 8);


                parametros[0] = str2;//cadena cbb
                parametros[1] = Sello;//cadena cbb
                parametros[2] = GenerarCadenaTimbreFiscal(pathxml, document); //cadena
                parametros[3] = enletras(odoc.monto.ToString(), Moneda, "M.N."); //cantidad en letra
                return parametros;



            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        public String GenerarCadenaTimbreFiscal(String FileName, XmlDocument xmlDocument)
        {
            try
            {
                String FileNameTimbre = oparametros.dirtmp + @"\tempTFD.xml";
                XmlDocument xmlDocument2 = new XmlDocument();
                foreach (XmlNode childNode in xmlDocument.DocumentElement.ChildNodes)
                {
                    if (childNode.Name.Replace("cfdi:", "") == "Complemento")
                    {
                        foreach (XmlNode childNode2 in childNode.ChildNodes)
                        {
                            if (childNode2.Name.Replace("tfd:", "") == "TimbreFiscalDigital")
                            {
                                XmlNode newChild = xmlDocument2.ImportNode(childNode2, true);
                                xmlDocument2.AppendChild(newChild);
                            }
                        }
                    }
                }
                xmlDocument2.Save(FileNameTimbre);


                String AppStartupPath = Application.StartupPath;
                String XSLT = AppStartupPath + @"\xslt\cadenaoriginal_TFD_1_1.xslt";
                String ArchivoCadena = oparametros.dirtmp + @"\txtCadenaTF.txt";
                //String ArchivoCadenaUTF8 = AppStartupPath + @"\txtCadenaTFUTF8.txt";

                XslCompiledTransform transformador = new XslCompiledTransform();
                transformador.Load(XSLT);
                transformador.Transform(FileNameTimbre, ArchivoCadena);

                String CadenaOriginal = System.IO.File.ReadAllText(ArchivoCadena);
                System.IO.File.Delete(ArchivoCadena);
                System.IO.File.Delete(FileName);
                System.IO.File.Delete(FileNameTimbre);
                return CadenaOriginal;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        public string enletras(string num, String MonedaDesc, String MNtext)
        {

            try
            {
                string res, dec = String.Empty;
                Int64 entero;
                int decimales;
                double nro;
                try
                {
                    nro = Convert.ToDouble(num);
                }
                catch
                {
                    return String.Empty;
                }

                entero = Convert.ToInt64(Math.Truncate(nro));
                decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));
                if (decimales > 0)
                    dec = decimales.ToString() + "/100";
                else
                    dec = "00/100";
                if (entero >= 1000 && entero <= 1999)
                    res = " UN " + toText(Convert.ToDouble(entero)) + " " + MonedaDesc + " " + dec;
                else
                    res = toText(Convert.ToDouble(entero)) + "  " + MonedaDesc + "  " + dec;
                return (res + " " + MNtext.ToString()).ToUpper();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        private string toText(double value)
        {

            try
            {
                string Num2Text = "";

                value = Math.Truncate(value);

                if (value == 0) Num2Text = "CERO";

                else if (value == 1) Num2Text = "UNO";

                else if (value == 2) Num2Text = "DOS";

                else if (value == 3) Num2Text = "TRES";

                else if (value == 4) Num2Text = "CUATRO";

                else if (value == 5) Num2Text = "CINCO";

                else if (value == 6) Num2Text = "SEIS";

                else if (value == 7) Num2Text = "SIETE";

                else if (value == 8) Num2Text = "OCHO";

                else if (value == 9) Num2Text = "NUEVE";

                else if (value == 10) Num2Text = "DIEZ";

                else if (value == 11) Num2Text = "ONCE";

                else if (value == 12) Num2Text = "DOCE";

                else if (value == 13) Num2Text = "TRECE";

                else if (value == 14) Num2Text = "CATORCE";

                else if (value == 15) Num2Text = "QUINCE";

                else if (value < 20) Num2Text = "DIECI" + toText(value - 10);

                else if (value == 20) Num2Text = "VEINTE";

                else if (value < 30) Num2Text = "VEINTI" + toText(value - 20);

                else if (value == 30) Num2Text = "TREINTA";

                else if (value == 40) Num2Text = "CUARENTA";

                else if (value == 50) Num2Text = "CINCUENTA";

                else if (value == 60) Num2Text = "SESENTA";

                else if (value == 70) Num2Text = "SETENTA";

                else if (value == 80) Num2Text = "OCHENTA";

                else if (value == 90) Num2Text = "NOVENTA";

                else if (value < 100) Num2Text = toText(Math.Truncate(value / 10) * 10) + " Y " + toText(value % 10);

                else if (value == 100) Num2Text = "CIEN";

                else if (value < 200) Num2Text = "CIENTO " + toText(value - 100);

                else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = toText(Math.Truncate(value / 100)) + "CIENTOS";

                else if (value == 500) Num2Text = "QUINIENTOS";

                else if (value == 700) Num2Text = "SETECIENTOS";

                else if (value == 900) Num2Text = "NOVECIENTOS";

                else if (value < 1000) Num2Text = toText(Math.Truncate(value / 100) * 100) + " " + toText(value % 100);

                else if (value == 1000) Num2Text = "MIL";

                else if (value < 2000) Num2Text = "MIL " + toText(value % 1000);

                else if (value < 1000000)
                {

                    Num2Text = toText(Math.Truncate(value / 1000)) + " MIL";

                    if ((value % 1000) > 0) Num2Text = Num2Text + " " + toText(value % 1000);

                }

                else if (value == 1000000) Num2Text = "UN MILLON";

                else if (value < 2000000) Num2Text = "UN MILLON " + toText(value % 1000000);

                else if (value < 1000000000000)
                {

                    Num2Text = toText(Math.Truncate(value / 1000000)) + " MILLONES ";

                    if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000) * 1000000);

                }

                else if (value == 1000000000000) Num2Text = "UN BILLON";

                else if (value < 2000000000000) Num2Text = "UN BILLON " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);

                else
                {

                    Num2Text = toText(Math.Truncate(value / 1000000000000)) + " BILLONES";

                    if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);

                }

                return Num2Text;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }
        public string RightString(string param, int length)
        {
            int value = param.Length - length;
            string result = param.Substring(value, length);
            return result;
        }
        public byte[] ImageToByteArray(Image imageIn)
        {
            MemoryStream memoryStream = new MemoryStream();
            imageIn.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            return memoryStream.ToArray();
        }

        public Image QRGen(string input)
        {

            string toenc = input;

            MessagingToolkit.QRCode.Codec.QRCodeEncoder qe = new MessagingToolkit.QRCode.Codec.QRCodeEncoder();

            qe.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;

            qe.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;

            //qe.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.Q; // - Using LOW for more storage

            qe.QRCodeVersion = 8;

            System.Drawing.Bitmap bm = qe.Encode(toenc);

            return bm;

        }



        private void SetDescripcionImpuestosGrales(DataSet ds, string tablename, DataTable dtCatalogo)
        {
            if (ds.Tables.Contains(tablename))
            {

                DataTable dtCatalogoSort = dtCatalogo.Copy();
                dtCatalogoSort.DefaultView.RowFilter = "applied=1";
                dtCatalogoSort = dtCatalogoSort.DefaultView.ToTable();

                DataTable dataTable = ds.Tables[tablename];

                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["tasaocuota"] != null)
                    {
                        for (int cnt = 0; cnt < dtCatalogoSort.Rows.Count; cnt++)
                        {
                            if (dtCatalogoSort.Rows[cnt]["value"].ToString().Trim() == row["impuesto"].ToString().Trim())
                                row["impuesto"] = dtCatalogoSort.Rows[cnt]["name"];
                        }
                    }
                }
            }
        }
        private void SetDescripcionCatalogo(DataSet ds, string tablename, DataTable dtCatalogo, string sKeyCatalogo, string ValueKey1, string iKeyCatalogo, string ValueKey2, string sDescCatalogo, string fieldUpdate, string appliedfield = null)
        {
            if (ds.Tables.Contains(tablename))
            {
                DataTable dataTable = ds.Tables[tablename];
                string value = string.Empty;
                decimal value2 = 0m;
                string valuefull = string.Empty;
                foreach (DataRow row in dataTable.Rows)
                {
                    if (dataTable.Columns.Contains(ValueKey1))
                    {
                        value = Convert.ToString(row[ValueKey1]);
                    }
                    if (dataTable.Columns.Contains(ValueKey2))
                    {
                        value2 = Convert.ToDecimal(row[ValueKey2]);
                    }

                    if (!string.IsNullOrEmpty(iKeyCatalogo) && row[ValueKey2] == null)
                        row[fieldUpdate] = row[fieldUpdate];
                    else
                    {
                        row[fieldUpdate] = SelectDescripcionValue(dtCatalogo, sKeyCatalogo, value, iKeyCatalogo, value2, sDescCatalogo, appliedfield);


                    }

                }
            }
        }

        private string SelectDescripcionValue(DataTable dt, string sKey, string value1, string iKey, decimal value2, string fieldselect, string appliedfield)
        {
            string result = string.Empty;
            if (dt != null)
            {
                DataRow[] array = null;
                if (!string.IsNullOrEmpty(sKey) && !string.IsNullOrEmpty(iKey))
                {
                    array = dt.Select(sKey + "='" + value1 + "' AND " + iKey + "=" + value2.ToString());
                }
                else if (!string.IsNullOrEmpty(sKey))
                {
                    array = dt.Select(sKey + "='" + value1 + "'");
                }
                if (!string.IsNullOrEmpty(iKey))
                {
                    array = dt.Select(iKey + "=" + value2.ToString());
                }
                if (array != null && array.Length > 0)
                {
                    result = Convert.ToString(array[0][fieldselect]);

                    if (!string.IsNullOrEmpty(appliedfield))
                    {
                        array[0][appliedfield] = 1;
                        dt.AcceptChanges();
                    }

                }
            }
            return result;
        }

        private void grddocumentosdigitales_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (grddocumentosdigitales.ActiveRow != null)
                {
                    if (grddocumentosdigitales.ActiveRow.Band.Index == 0)
                    {
                        string grupoformato = grddocumentosdigitales.ActiveRow.Cells["clasificador"].Value.ToString();

                        if (grupoformato != "ninguno")
                        {
                            int iddocumentodigital = Convert.ToInt32(grddocumentosdigitales.ActiveRow.Cells["iddocumentodigital"].Value);
                            string tiposolicitud = grddocumentosdigitales.ActiveRow.Cells["tiposolicitud"].Value.ToString();

                            if (tiposolicitud == "Emitidos")
                            {
                                frmopcionesemitidos ofrmopcionesemitidos = new frmopcionesemitidos(iddocumentodigital, this._idconfig, this._idusuario, this._connexionstring);
                                ofrmopcionesemitidos.ShowDialog();
                                if (ofrmopcionesemitidos.update)
                                {

                                }
                            }
                            else
                            {
                                string clasificador = grddocumentosdigitales.ActiveRow.Cells["clasificador"].Value.ToString();
                                if (clasificador == "combustible" || clasificador == "mantenimiento")
                                {
                                    frmimpresionmultiplesregistros ofrmregistrosmultiples = new frmimpresionmultiplesregistros(iddocumentodigital, this._idconfig, this._idusuario,clasificador, this._connexionstring);
                                    ofrmregistrosmultiples.ShowDialog();
                                    if (ofrmregistrosmultiples.update)
                                    {

                                    }
                                }
                                else
                                {
                                    frmopcionesrecibidos ofrmopcionesrecibidos = new frmopcionesrecibidos(iddocumentodigital, this._idconfig, this._idusuario, this._connexionstring);
                                    ofrmopcionesrecibidos.ShowDialog();
                                    if (ofrmopcionesrecibidos.update)
                                    {

                                    }
                                }

                            }


                        }
                        //else
                        //{
                        //    MessageBox.Show("Es necesario indicar un grupo de formato para poder continuar", "Mensaje de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}
                    }
                }
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

        private void btngenerardocumentos_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Este procedimiento generará los archivos PDF de los formatos configurados del periodo correspondiente a " + this.cmbperiodo.Text.Trim() + " " + this.cmbejercicios.Text.Trim() + " en el directorio configurado." + Environment.NewLine + "¿Desea continuar?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    foreach (Infragistics.Win.UltraWinGrid.UltraGridRow orow in this.grddocumentosdigitales.Rows)
                    {
                        if (orow.Cells["clasificador"].Value.ToString() != "ninguno")
                        {

                        }
                    }

                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnregistrardocumentos_Click(object sender, EventArgs e)
        {
            try
            {
                if (grddocumentosdigitales.ActiveRow != null)
                {
                    if (grddocumentosdigitales.ActiveRow.Band.Index == 0)
                    {
                        Infragistics.Win.UltraWinGrid.UltraGridRow orow = grddocumentosdigitales.ActiveRow;


                        string clasificador = orow.Cells["clasificador"].Value.ToString();

                        if (clasificador != "ninguno")
                        {

                            if (MessageBox.Show("Este procedimiento generará los registros para los formatos configurados para el documento: " + Environment.NewLine + Environment.NewLine + orow.Cells["uuid"].Value + Environment.NewLine + " correspondiente al periodo " + this.cmbperiodo.Text.Trim() + " " + this.cmbejercicios.Text.Trim() + "." + Environment.NewLine + Environment.NewLine + "¿Desea continuar?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {

                                int iddepartamento = 0;
                                int idempleado = 0;
                    

                                frmparametrosdocumentos ofrmparams = new frmparametrosdocumentos(this._id, this._idconfig, this._idusuario, this._connexionstring);
                                ofrmparams.ShowDialog();
                                if (ofrmparams.update)
                                {
                                    iddepartamento = ofrmparams.iddepartamentoseleccionado;
                                    idempleado = ofrmparams.idempleadoseleccionado;
  

                                    string foliointerno = orow.Cells["serie"].Value.ToString() + orow.Cells["folio"].Value.ToString();
                                    string uuid = orow.Cells["uuid"].Value.ToString();
                                    int iddocumentodigital = Convert.ToInt32(orow.Cells["iddocumentodigital"].Value);

                                    int solicitudes = Convert.ToInt32(orow.Cells["solicitud"].Value);
                                    int pedidos = Convert.ToInt32(orow.Cells["pedido"].Value);
                                    int ordenes = Convert.ToInt32(orow.Cells["orden"].Value);
                                    int informes = Convert.ToInt32(orow.Cells["informe"].Value);
                                    int constancias = Convert.ToInt32(orow.Cells["constancia"].Value);
                                    int gasolinas = Convert.ToInt32(orow.Cells["gasolina"].Value);
                                    int mantenimientos = Convert.ToInt32(orow.Cells["mantenimiento"].Value);

                                    if (solicitudes == 0)
                                    {
                                        generarsolicitud(iddocumentodigital, foliointerno, uuid, iddepartamento, idempleado);
                                    }

                                    if (pedidos == 0)
                                    {
                                        generarpedido(iddocumentodigital, foliointerno, uuid, iddepartamento, idempleado);
                                    }
                                    if (ordenes == 0)
                                    {
                                        generarorden(iddocumentodigital, foliointerno, uuid, iddepartamento, idempleado);
                                    }
                                    if (informes == 0)
                                    {
                                        generarinforme(iddocumentodigital, foliointerno, uuid, iddepartamento, idempleado);
                                    }
                                    if (constancias == 0)
                                    {
                                        generarconstancia(iddocumentodigital, foliointerno, uuid, iddepartamento, idempleado);
                                    }



                                    MessageBox.Show("¡Documentos generados correctamente!", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    consultar();
                                }
                            }
                        }

               
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void generarsolicitud(int iddocumentodigital,string foliointerno, string uuid, int iddepartamento, int idempleado)
        {
            try
            {
                seriesfoliacion oseriefoliacion = seriefoliacionnc.getseriefoliacionvigentebytiposerie(genericas.enums.etiposerie.solicitud.ToString(), this._connexionstring);

                documentosdigitales odoc = documentodigitalnc.getgetdocumentodigital(iddocumentodigital, this._connexionstring);
                List<documentosdigitalesconceptos> oconceptos = documentodigitalconceptonc.getdocumentosdigitalesconceptosbyiddocumentodigital(iddocumentodigital,this._connexionstring);
                solicitudes osolicitud = new solicitudes();
                osolicitud.idempleado = idempleado;
                osolicitud.iddepartamento = iddepartamento;
                osolicitud.iddocumentodigital = iddocumentodigital;
                osolicitud.idsolicitud = solicitudnc.getid(this._connexionstring);
                osolicitud.folio = oseriefoliacion.serie.ToUpper() + (oseriefoliacion.actual + 1).ToString().PadLeft(4, '0');
                osolicitud.fecha = odoc.fechaemision;
                osolicitud.comentarios = "Solicitud generada";
                osolicitud.fechacreacion = DateTime.Now;
                osolicitud.usuario = this._idusuario.ToString();
                osolicitud.baja = false;
                solicitudnc.save(osolicitud,this._connexionstring);


                detsolicitudes oconceptosolicitud;
                foreach(documentosdigitalesconceptos oconcepto in oconceptos)
                {

                    if (oconcepto.unidad == "")
                    {
                        string query = "select descripcion from dbo.cfdiunidad where dbo.cfdiunidad.clave = '" + oconcepto.claveunidad + "'";
                        DataTable DT = genericas.generales.executeDS(query, this._connexionstring).Tables[0];
                        if (DT.Rows.Count > 0)
                        {
                            oconcepto.unidad = DT.Rows[0][0].ToString();
                        }
                    }
                    documentodigitalconceptonc.update(oconcepto, this._connexionstring);

                    unidades ounidad;
                    if (!unidadnc.existeunidad(oconcepto.claveunidad, this._connexionstring))
                    {
                        ounidad = new unidades();
                        ounidad.idunidad = unidadnc.getid(this._connexionstring);
                        ounidad.nombre = oconcepto.unidad;
                        ounidad.cveunidad = oconcepto.claveunidad;
                        ounidad.simbologia = oconcepto.claveunidad;
                        ounidad.idorigen = oconcepto.iddocumentodigitalconcepto;
                        ounidad.usuario = this._idusuario.ToString();
                        ounidad.baja = false;
                        unidadnc.save(ounidad, this._connexionstring);
                    }
                    else
                    {
                        ounidad = unidadnc.getunidadbyclaveunidad(oconcepto.claveunidad,this._connexionstring);
                    }

                    conceptos oconceptodigital;
                    if (!conceptonc.existeconcepto(oconcepto.claveprodserv, this._connexionstring))
                    {
                        oconceptodigital = new conceptos();
                        oconceptodigital.idconcepto = conceptonc.getid(this._connexionstring);
                        oconceptodigital.idunidad = ounidad.idunidad;
                        oconceptodigital.idorigen = oconcepto.iddocumentodigitalconcepto;
                        oconceptodigital.grupo = genericas.enums.egrupoconcepto.externo.ToString();
                        oconceptodigital.descripcion = oconcepto.descripcion;
                        oconceptodigital.cvesat = oconcepto.claveprodserv;
                        oconceptodigital.nombre = oconcepto.descripcion;

                        string cad = oconcepto.claveprodserv.Substring(0, 2);
                        if (Convert.ToInt32(cad) >= 70)
                        {
                            if (Convert.ToInt32(cad) <= 94)
                            {
                                oconceptodigital.tipoconcepto = genericas.enums.etipoconcepto.servicio.ToString();
                                oconceptodigital.inventario = false;
                            }
                            else
                            {
                                oconceptodigital.tipoconcepto = genericas.enums.etipoconcepto.producto.ToString();
                                oconceptodigital.inventario = true;
                            }
                        }
                        else
                        {
                            oconceptodigital.tipoconcepto = genericas.enums.etipoconcepto.producto.ToString();
                            oconceptodigital.inventario = true;
                        }

                        oconceptodigital.usuario = this._idusuario.ToString();
                        oconceptodigital.baja = false;

                        conceptonc.save(oconceptodigital, this._connexionstring);
                    }
                    else
                    {
                        oconceptodigital = conceptonc.getconceptobyclavesat(oconcepto.claveprodserv, this._connexionstring);
                    }

                    oconceptosolicitud = new detsolicitudes();
                    oconceptosolicitud.idsolicitud = osolicitud.idsolicitud;
                    oconceptosolicitud.iddetsolicitud = detsolicitudnc.getid(this._connexionstring);
                    oconceptosolicitud.descripcion = oconcepto.descripcion;
                    oconceptosolicitud.idunidad = ounidad.idunidad;
                    oconceptosolicitud.idconcepto = oconceptodigital.idconcepto;
                    oconceptosolicitud.cantidad = oconcepto.cantidad;
                    oconceptosolicitud.fecha = odoc.fechaemision;
                    oconceptosolicitud.usuario = this._idusuario.ToString();
                    oconceptosolicitud.fechacreacion = DateTime.Now;
                    oconceptosolicitud.baja = false;
                    detsolicitudnc.save(oconceptosolicitud, this._connexionstring);
                }


                oseriefoliacion.actual = (oseriefoliacion.actual + 1);
                seriefoliacionnc.update(oseriefoliacion, this._connexionstring);

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        private void generarpedido(int iddocumentodigital, string foliointerno, string uuid, int iddepartamento, int idempleado)
        {
            try
            {
                seriesfoliacion oseriefoliacion = seriefoliacionnc.getseriefoliacionvigentebytiposerie(genericas.enums.etiposerie.pedido.ToString(), this._connexionstring);

                documentosdigitales odoc = documentodigitalnc.getgetdocumentodigital(iddocumentodigital, this._connexionstring);
                List<documentosdigitalesconceptos> oconceptos = documentodigitalconceptonc.getdocumentosdigitalesconceptosbyiddocumentodigital(iddocumentodigital, this._connexionstring);



                proveedores oproveedor;
                if (!proveedornc.existeproveedor(odoc.rfcemisor, this._connexionstring))
                {
                    oproveedor = new proveedores();
                    oproveedor.idproveedor = proveedornc.getid(this._connexionstring);
                    oproveedor.rfc = odoc.rfcemisor;
                    oproveedor.nombre = odoc.nombreemisor;
                    oproveedor.contacto = "";
                    oproveedor.correo = "";
                    oproveedor.domicilio = "";
                    oproveedor.movil = "";
                    oproveedor.telefono = "";
                    oproveedor.usuario = this._idusuario.ToString();
                    oproveedor.baja = false;
                    proveedornc.save(oproveedor, this._connexionstring);
                }
                else
                {
                    oproveedor = proveedornc.getproveedorbyrfc(odoc.rfcemisor, this._connexionstring);
                }




                pedidos opedido = new pedidos();
                opedido.idempleado = idempleado;
                opedido.iddepartamento = iddepartamento;
                opedido.iddocumentodigital = iddocumentodigital;
                opedido.idpedido = pedidonc.getid(this._connexionstring);
                opedido.idproveedor = oproveedor.idproveedor;
                opedido.folio = oseriefoliacion.serie.ToUpper() + (oseriefoliacion.actual + 1).ToString().PadLeft(4, '0');
                opedido.fecha = odoc.fechaemision;
                opedido.comentarios = "Pedido generado";
                opedido.fechacreacion = DateTime.Now;
                opedido.usuario = this._idusuario.ToString();
                

                opedido.subtotal = odoc.subtotal;
                opedido.total = odoc.monto;
                opedido.impuestostrasladados = odoc.totaltrasladados;
                opedido.impuestosretenidos = odoc.totalretenidos;
                opedido.impuestostrasladadoslocales = odoc.totaltrasladadoslocales;
                opedido.impuestosretenidoslocales = odoc.totalretenidoslocales;

                opedido.baja = false;

                pedidonc.save(opedido, this._connexionstring);

                detpedidos oconceptopedido;
                foreach (documentosdigitalesconceptos oconcepto in oconceptos)
                {

                    //CARGANDO IMPUESTOS DEL CONCEPTO
                    List<documentosdigitalesimpuestos> olistdocumentodigitalimpuestos =
                        documentodigitalimpuestonc.getdocumentodigitalimpuestosbyiddocumentodigitalconcepto(iddocumentodigital, oconcepto.iddocumentodigitalconcepto, this._connexionstring);





                    if (oconcepto.unidad == "")
                    {
                        string query = "select descripcion from dbo.cfdiunidad where dbo.cfdiunidad.clave = '" + oconcepto.claveunidad + "'";
                        DataTable DT = genericas.generales.executeDS(query, this._connexionstring).Tables[0];
                        if (DT.Rows.Count > 0)
                        {
                            oconcepto.unidad = DT.Rows[0][0].ToString();
                        }
                    }
                    documentodigitalconceptonc.update(oconcepto, this._connexionstring);

                    unidades ounidad;
                    if (!unidadnc.existeunidad(oconcepto.claveunidad, this._connexionstring))
                    {
                        ounidad = new unidades();
                        ounidad.idunidad = unidadnc.getid(this._connexionstring);
                        ounidad.nombre = oconcepto.unidad;
                        ounidad.cveunidad = oconcepto.claveunidad;
                        ounidad.simbologia = oconcepto.claveunidad;
                        ounidad.idorigen = oconcepto.iddocumentodigitalconcepto;
                        ounidad.usuario = this._idusuario.ToString();
                        ounidad.baja = false;
                        unidadnc.save(ounidad, this._connexionstring);
                    }
                    else
                    {
                        ounidad = unidadnc.getunidadbyclaveunidad(oconcepto.claveunidad, this._connexionstring);
                    }

                    conceptos oconceptodigital;
                    if (!conceptonc.existeconcepto(oconcepto.claveprodserv, this._connexionstring))
                    {
                        oconceptodigital = new conceptos();
                        oconceptodigital.idconcepto = conceptonc.getid(this._connexionstring);
                        oconceptodigital.idunidad = ounidad.idunidad;
                        oconceptodigital.idorigen = oconcepto.iddocumentodigitalconcepto;
                        oconceptodigital.grupo = genericas.enums.egrupoconcepto.externo.ToString();
                        oconceptodigital.descripcion = oconcepto.descripcion;
                        oconceptodigital.cvesat = oconcepto.claveprodserv;
                        oconceptodigital.nombre = oconcepto.descripcion;

                        string cad = oconcepto.claveprodserv.Substring(0, 2);
                        if (Convert.ToInt32(cad) >= 70)
                        {
                            if (Convert.ToInt32(cad) <= 94)
                            {
                                oconceptodigital.tipoconcepto = genericas.enums.etipoconcepto.servicio.ToString();
                                oconceptodigital.inventario = false;
                            }
                            else
                            {
                                oconceptodigital.tipoconcepto = genericas.enums.etipoconcepto.producto.ToString();
                                oconceptodigital.inventario = true;
                            }
                        }
                        else
                        {
                            oconceptodigital.tipoconcepto = genericas.enums.etipoconcepto.producto.ToString();
                            oconceptodigital.inventario = true;
                        }

                        oconceptodigital.usuario = this._idusuario.ToString();
                        oconceptodigital.baja = false;

                        conceptonc.save(oconceptodigital, this._connexionstring);
                    }
                    else
                    {
                        oconceptodigital = conceptonc.getconceptobyclavesat(oconcepto.claveprodserv, this._connexionstring);
                    }


                    oconceptopedido = new detpedidos();
                    oconceptopedido.idpedido = opedido.idpedido;
                    oconceptopedido.iddetpedido = detpedidonc.getid(this._connexionstring);
                    oconceptopedido.descripcion = oconcepto.descripcion;
                    oconceptopedido.idunidad = ounidad.idunidad;
                    oconceptopedido.idconcepto = oconceptodigital.idconcepto;
                    oconceptopedido.cantidad = oconcepto.cantidad;
                    oconceptopedido.usuario = this._idusuario.ToString();
                    oconceptopedido.fechacreacion = DateTime.Now;
                    oconceptopedido.baja = false;
                    oconceptopedido.comentarios = "Concepto de pedido generado";
                    oconceptopedido.iddocumentodigital = oconcepto.iddocumentodigitalconcepto;

                    oconceptopedido.preciounitario = oconcepto.valorunitario;
                    oconceptopedido.subtotal = oconcepto.importe;
                    oconceptopedido.total = oconcepto.importe;
                    oconceptopedido.descuentos = 0;
                    oconceptopedido.impuestostrasladados = 0;
                    oconceptopedido.impuestosretenidos = 0;
                    oconceptopedido.impuestostrasladadoslocales = 0;
                    oconceptopedido.impuestosretenidoslocales = 0;

                    detpedidonc.save(oconceptopedido, this._connexionstring);


                    foreach(documentosdigitalesimpuestos odocumentodigitalimpuesto in olistdocumentodigitalimpuestos)
                    {
                        impuestos oimpuesto = impuestonc.getimpuestobyparams(odocumentodigitalimpuesto.tipoimpuesto.ToLower(), odocumentodigitalimpuesto.impuesto, Convert.ToDecimal(odocumentodigitalimpuesto.tasaocuota*100),this._connexionstring);

                        impdetpedidos oimpdetpedido = new impdetpedidos();
                        oimpdetpedido.idimpdetpedido = impdetpedidonc.getid(this._connexionstring);
                        oimpdetpedido.idpedido = opedido.idpedido;
                        oimpdetpedido.iddetpedido = opedido.idpedido;
                        oimpdetpedido.idimpuesto = oimpuesto.idimpuesto;
                        oimpdetpedido.importe = odocumentodigitalimpuesto.importe;
                        oimpdetpedido.tasa = odocumentodigitalimpuesto.tasaocuota;
                        oimpdetpedido.nombre = oimpuesto.nombre;
                        oimpdetpedido.usuario = this._idusuario.ToString();
                        oimpdetpedido.cveimpuesto = odocumentodigitalimpuesto.impuesto;
                        oimpdetpedido.baja = false;
                        impdetpedidonc.save(oimpdetpedido, this._connexionstring);
                    }


                }


                oseriefoliacion.actual = (oseriefoliacion.actual + 1);
                seriefoliacionnc.update(oseriefoliacion, this._connexionstring);

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        private void generarorden(int iddocumentodigital, string foliointerno, string uuid, int iddepartamento, int idempleado)
        {
            try
            {
                seriesfoliacion oseriefoliacion = seriefoliacionnc.getseriefoliacionvigentebytiposerie(genericas.enums.etiposerie.orden.ToString(), this._connexionstring);

                documentosdigitales odoc = documentodigitalnc.getgetdocumentodigital(iddocumentodigital, this._connexionstring);
                List<documentosdigitalesconceptos> oconceptos = documentodigitalconceptonc.getdocumentosdigitalesconceptosbyiddocumentodigital(iddocumentodigital, this._connexionstring);
                ordenes oorden = new ordenes();
                oorden.idempleado = idempleado;
                oorden.iddepartamento = iddepartamento;
                oorden.iddocumentodigital = iddocumentodigital;
                oorden.idorden = ordennc.getid(this._connexionstring);
                oorden.folio = oseriefoliacion.serie.ToUpper() + (oseriefoliacion.actual + 1).ToString().PadLeft(4, '0');
                oorden.fecha = odoc.fechaemision;
                oorden.comentarios = "Solicitud generada";
                oorden.fechacreacion = DateTime.Now;
                oorden.usuario = this._idusuario.ToString();
                oorden.baja = false;
                ordennc.save(oorden, this._connexionstring);


                detordenes oconceptoorden;
                foreach (documentosdigitalesconceptos oconcepto in oconceptos)
                {

                    if (oconcepto.unidad == "")
                    {
                        string query = "select descripcion from dbo.cfdiunidad where dbo.cfdiunidad.clave = '" + oconcepto.claveunidad + "'";
                        DataTable DT = genericas.generales.executeDS(query, this._connexionstring).Tables[0];
                        if (DT.Rows.Count > 0)
                        {
                            oconcepto.unidad = DT.Rows[0][0].ToString();
                        }
                    }
                    documentodigitalconceptonc.update(oconcepto, this._connexionstring);

                    unidades ounidad;
                    if (!unidadnc.existeunidad(oconcepto.claveunidad, this._connexionstring))
                    {
                        ounidad = new unidades();
                        ounidad.idunidad = unidadnc.getid(this._connexionstring);
                        ounidad.nombre = oconcepto.unidad;
                        ounidad.cveunidad = oconcepto.claveunidad;
                        ounidad.simbologia = oconcepto.claveunidad;
                        ounidad.idorigen = oconcepto.iddocumentodigitalconcepto;
                        ounidad.usuario = this._idusuario.ToString();
                        ounidad.baja = false;
                        unidadnc.save(ounidad, this._connexionstring);
                    }
                    else
                    {
                        ounidad = unidadnc.getunidadbyclaveunidad(oconcepto.claveunidad, this._connexionstring);
                    }

                    conceptos oconceptodigital;
                    if (!conceptonc.existeconcepto(oconcepto.claveprodserv, this._connexionstring))
                    {
                        oconceptodigital = new conceptos();
                        oconceptodigital.idconcepto = conceptonc.getid(this._connexionstring);
                        oconceptodigital.idunidad = ounidad.idunidad;
                        oconceptodigital.idorigen = oconcepto.iddocumentodigitalconcepto;
                        oconceptodigital.grupo = genericas.enums.egrupoconcepto.externo.ToString();
                        oconceptodigital.descripcion = oconcepto.descripcion;
                        oconceptodigital.cvesat = oconcepto.claveprodserv;
                        oconceptodigital.nombre = oconcepto.descripcion;

                        string cad = oconcepto.claveprodserv.Substring(0, 2);
                        if (Convert.ToInt32(cad) >= 70)
                        {
                            if (Convert.ToInt32(cad) <= 94)
                            {
                                oconceptodigital.tipoconcepto = genericas.enums.etipoconcepto.servicio.ToString();
                                oconceptodigital.inventario = false;
                            }
                            else
                            {
                                oconceptodigital.tipoconcepto = genericas.enums.etipoconcepto.producto.ToString();
                                oconceptodigital.inventario = true;
                            }
                        }
                        else
                        {
                            oconceptodigital.tipoconcepto = genericas.enums.etipoconcepto.producto.ToString();
                            oconceptodigital.inventario = true;
                        }

                        oconceptodigital.usuario = this._idusuario.ToString();
                        oconceptodigital.baja = false;

                        conceptonc.save(oconceptodigital, this._connexionstring);
                    }
                    else
                    {
                        oconceptodigital = conceptonc.getconceptobyclavesat(oconcepto.claveprodserv, this._connexionstring);
                    }

                    oconceptoorden = new detordenes();
                    oconceptoorden.idorden = oorden.idorden;
                    oconceptoorden.iddetorden = detordennc.getid(this._connexionstring);
                    oconceptoorden.descripcion = oconcepto.descripcion;
                    oconceptoorden.idunidad = ounidad.idunidad;
                    oconceptoorden.idconcepto = oconceptodigital.idconcepto;
                    oconceptoorden.cantidad = oconcepto.cantidad;
                    oconceptoorden.fecha = odoc.fechaemision;
                    oconceptoorden.usuario = this._idusuario.ToString();
                    oconceptoorden.fechacreacion = DateTime.Now;
                    oconceptoorden.baja = false;
                    detordennc.save(oconceptoorden, this._connexionstring);
                }


                oseriefoliacion.actual = (oseriefoliacion.actual + 1);
                seriefoliacionnc.update(oseriefoliacion, this._connexionstring);

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        private void generarinforme(int iddocumentodigital, string foliointerno, string uuid, int iddepartamento, int idempleado)
        {
            try
            {
                seriesfoliacion oseriefoliacion = seriefoliacionnc.getseriefoliacionvigentebytiposerie(genericas.enums.etiposerie.informe.ToString(), this._connexionstring);

                documentosdigitales odoc = documentodigitalnc.getgetdocumentodigital(iddocumentodigital, this._connexionstring);
                List<documentosdigitalesconceptos> oconceptos = documentodigitalconceptonc.getdocumentosdigitalesconceptosbyiddocumentodigital(iddocumentodigital, this._connexionstring);
                informes oinforme = new informes();
                oinforme.idempleado = idempleado;
                oinforme.iddepartamento = iddepartamento;
                oinforme.iddocumentodigital = iddocumentodigital;
                oinforme.idinforme = informenc.getid(this._connexionstring);
                oinforme.folio = oseriefoliacion.serie.ToUpper() + (oseriefoliacion.actual + 1).ToString().PadLeft(4, '0');
                oinforme.fecha = odoc.fechaemision;
                oinforme.comentarios = "Solicitud generada";
                oinforme.fechacreacion = DateTime.Now;
                oinforme.usuario = this._idusuario.ToString();
                oinforme.baja = false;
                informenc.save(oinforme, this._connexionstring);


                detinformes oconceptoinforme;
                foreach (documentosdigitalesconceptos oconcepto in oconceptos)
                {

                    if (oconcepto.unidad == "")
                    {
                        string query = "select descripcion from dbo.cfdiunidad where dbo.cfdiunidad.clave = '" + oconcepto.claveunidad + "'";
                        DataTable DT = genericas.generales.executeDS(query, this._connexionstring).Tables[0];
                        if (DT.Rows.Count > 0)
                        {
                            oconcepto.unidad = DT.Rows[0][0].ToString();
                        }
                    }
                    documentodigitalconceptonc.update(oconcepto, this._connexionstring);

                    unidades ounidad;
                    if (!unidadnc.existeunidad(oconcepto.claveunidad, this._connexionstring))
                    {
                        ounidad = new unidades();
                        ounidad.idunidad = unidadnc.getid(this._connexionstring);
                        ounidad.nombre = oconcepto.unidad;
                        ounidad.cveunidad = oconcepto.claveunidad;
                        ounidad.simbologia = oconcepto.claveunidad;
                        ounidad.idorigen = oconcepto.iddocumentodigitalconcepto;
                        ounidad.usuario = this._idusuario.ToString();
                        ounidad.baja = false;
                        unidadnc.save(ounidad, this._connexionstring);
                    }
                    else
                    {
                        ounidad = unidadnc.getunidadbyclaveunidad(oconcepto.claveunidad, this._connexionstring);
                    }

                    conceptos oconceptodigital;
                    if (!conceptonc.existeconcepto(oconcepto.claveprodserv, this._connexionstring))
                    {
                        oconceptodigital = new conceptos();
                        oconceptodigital.idconcepto = conceptonc.getid(this._connexionstring);
                        oconceptodigital.idunidad = ounidad.idunidad;
                        oconceptodigital.idorigen = oconcepto.iddocumentodigitalconcepto;
                        oconceptodigital.grupo = genericas.enums.egrupoconcepto.externo.ToString();
                        oconceptodigital.descripcion = oconcepto.descripcion;
                        oconceptodigital.cvesat = oconcepto.claveprodserv;
                        oconceptodigital.nombre = oconcepto.descripcion;

                        string cad = oconcepto.claveprodserv.Substring(0, 2);
                        if (Convert.ToInt32(cad) >= 70)
                        {
                            if (Convert.ToInt32(cad) <= 94)
                            {
                                oconceptodigital.tipoconcepto = genericas.enums.etipoconcepto.servicio.ToString();
                                oconceptodigital.inventario = false;
                            }
                            else
                            {
                                oconceptodigital.tipoconcepto = genericas.enums.etipoconcepto.producto.ToString();
                                oconceptodigital.inventario = true;
                            }
                        }
                        else
                        {
                            oconceptodigital.tipoconcepto = genericas.enums.etipoconcepto.producto.ToString();
                            oconceptodigital.inventario = true;
                        }

                        oconceptodigital.usuario = this._idusuario.ToString();
                        oconceptodigital.baja = false;

                        conceptonc.save(oconceptodigital, this._connexionstring);
                    }
                    else
                    {
                        oconceptodigital = conceptonc.getconceptobyclavesat(oconcepto.claveprodserv, this._connexionstring);
                    }

                    oconceptoinforme = new detinformes();
                    oconceptoinforme.idinforme = oinforme.idinforme;
                    oconceptoinforme.iddetinforme = detinformenc.getid(this._connexionstring);
                    oconceptoinforme.descripcion = oconcepto.descripcion;
                    oconceptoinforme.idunidad = ounidad.idunidad;
                    oconceptoinforme.idconcepto = oconceptodigital.idconcepto;
                    oconceptoinforme.cantidad = oconcepto.cantidad;
                    oconceptoinforme.fecha = odoc.fechaemision;
                    oconceptoinforme.usuario = this._idusuario.ToString();
                    oconceptoinforme.fechacreacion = DateTime.Now;
                    oconceptoinforme.baja = false;
                    detinformenc.save(oconceptoinforme, this._connexionstring);
                }


                oseriefoliacion.actual = (oseriefoliacion.actual + 1);
                seriefoliacionnc.update(oseriefoliacion, this._connexionstring);

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        private void generarconstancia(int iddocumentodigital, string foliointerno, string uuid, int iddepartamento, int idempleado)
        {
            try
            {
                seriesfoliacion oseriefoliacion = seriefoliacionnc.getseriefoliacionvigentebytiposerie(genericas.enums.etiposerie.constancia.ToString(), this._connexionstring);

                documentosdigitales odoc = documentodigitalnc.getgetdocumentodigital(iddocumentodigital, this._connexionstring);
                List<documentosdigitalesconceptos> oconceptos = documentodigitalconceptonc.getdocumentosdigitalesconceptosbyiddocumentodigital(iddocumentodigital, this._connexionstring);
                constancias oconstancia = new constancias();
                oconstancia.idempleado = idempleado;
                oconstancia.iddepartamento = iddepartamento;
                oconstancia.iddocumentodigital = iddocumentodigital;
                oconstancia.idconstancia = constancianc.getid(this._connexionstring);
                oconstancia.folio = oseriefoliacion.serie.ToUpper() + (oseriefoliacion.actual + 1).ToString().PadLeft(4, '0');
                oconstancia.fecha = odoc.fechaemision;
                oconstancia.comentarios = "Solicitud generada";
                oconstancia.fechacreacion = DateTime.Now;
                oconstancia.usuario = this._idusuario.ToString();
                oconstancia.baja = false;
                constancianc.save(oconstancia, this._connexionstring);


                detconstancias oconceptoconstancia;
                foreach (documentosdigitalesconceptos oconcepto in oconceptos)
                {

                    if (oconcepto.unidad == "")
                    {
                        string query = "select descripcion from dbo.cfdiunidad where dbo.cfdiunidad.clave = '" + oconcepto.claveunidad + "'";
                        DataTable DT = genericas.generales.executeDS(query, this._connexionstring).Tables[0];
                        if (DT.Rows.Count > 0)
                        {
                            oconcepto.unidad = DT.Rows[0][0].ToString();
                        }
                    }
                    documentodigitalconceptonc.update(oconcepto, this._connexionstring);

                    unidades ounidad;
                    if (!unidadnc.existeunidad(oconcepto.claveunidad, this._connexionstring))
                    {
                        ounidad = new unidades();
                        ounidad.idunidad = unidadnc.getid(this._connexionstring);
                        ounidad.nombre = oconcepto.unidad;
                        ounidad.cveunidad = oconcepto.claveunidad;
                        ounidad.simbologia = oconcepto.claveunidad;
                        ounidad.idorigen = oconcepto.iddocumentodigitalconcepto;
                        ounidad.usuario = this._idusuario.ToString();
                        ounidad.baja = false;
                        unidadnc.save(ounidad, this._connexionstring);
                    }
                    else
                    {
                        ounidad = unidadnc.getunidadbyclaveunidad(oconcepto.claveunidad, this._connexionstring);
                    }

                    conceptos oconceptodigital;
                    if (!conceptonc.existeconcepto(oconcepto.claveprodserv, this._connexionstring))
                    {
                        oconceptodigital = new conceptos();
                        oconceptodigital.idconcepto = conceptonc.getid(this._connexionstring);
                        oconceptodigital.idunidad = ounidad.idunidad;
                        oconceptodigital.idorigen = oconcepto.iddocumentodigitalconcepto;
                        oconceptodigital.grupo = genericas.enums.egrupoconcepto.externo.ToString();
                        oconceptodigital.descripcion = oconcepto.descripcion;
                        oconceptodigital.cvesat = oconcepto.claveprodserv;
                        oconceptodigital.nombre = oconcepto.descripcion;

                        string cad = oconcepto.claveprodserv.Substring(0, 2);
                        if (Convert.ToInt32(cad) >= 70)
                        {
                            if (Convert.ToInt32(cad) <= 94)
                            {
                                oconceptodigital.tipoconcepto = genericas.enums.etipoconcepto.servicio.ToString();
                                oconceptodigital.inventario = false;
                            }
                            else
                            {
                                oconceptodigital.tipoconcepto = genericas.enums.etipoconcepto.producto.ToString();
                                oconceptodigital.inventario = true;
                            }
                        }
                        else
                        {
                            oconceptodigital.tipoconcepto = genericas.enums.etipoconcepto.producto.ToString();
                            oconceptodigital.inventario = true;
                        }

                        oconceptodigital.usuario = this._idusuario.ToString();
                        oconceptodigital.baja = false;

                        conceptonc.save(oconceptodigital, this._connexionstring);
                    }
                    else
                    {
                        oconceptodigital = conceptonc.getconceptobyclavesat(oconcepto.claveprodserv, this._connexionstring);
                    }

                    oconceptoconstancia = new detconstancias();
                    oconceptoconstancia.idconstancia = oconstancia.idconstancia;
                    oconceptoconstancia.iddetconstancia = detconstancianc.getid(this._connexionstring);
                    oconceptoconstancia.descripcion = oconcepto.descripcion;
                    oconceptoconstancia.idunidad = ounidad.idunidad;
                    oconceptoconstancia.idconcepto = oconceptodigital.idconcepto;
                    oconceptoconstancia.cantidad = oconcepto.cantidad;
                    oconceptoconstancia.fecha = odoc.fechaemision;
                    oconceptoconstancia.usuario = this._idusuario.ToString();
                    oconceptoconstancia.fechacreacion = DateTime.Now;
                    oconceptoconstancia.baja = false;
                    detconstancianc.save(oconceptoconstancia, this._connexionstring);
                }


                oseriefoliacion.actual = (oseriefoliacion.actual + 1);
                seriefoliacionnc.update(oseriefoliacion, this._connexionstring);

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void grddocumentosdigitales_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnregistrarbitacoragasolina.Enabled = false;
                this.btnregistrarmantenimiento.Enabled = false;

                this.btnregistrardocumentos.Enabled = false;

                if (grddocumentosdigitales.ActiveRow != null)
                {
                    if (grddocumentosdigitales.ActiveRow.Band.Index == 0)
                    {
                        string clasificador = grddocumentosdigitales.ActiveRow.Cells["clasificador"].Value.ToString();
                        if (clasificador == "mantenimiento")
                        {
                            this.btnregistrarmantenimiento.Enabled = true;
                            this.btnregistrardocumentos.Enabled = true;
                        }
                        else if (clasificador == "combustible")
                        {
                            this.btnregistrarbitacoragasolina.Enabled = true;
                            this.btnregistrardocumentos.Enabled = true;
                        }
                        else
                        {
                            if (clasificador != "ninguno")
                            {
                                this.btnregistrardocumentos.Enabled = true;
                            }
                        }

                        
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btnverificarconceptos_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet DS = ((DataSet)this.grddocumentosdigitales.DataSource).Copy();

                foreach(DataRow orowheader in DS.Tables["documentosdigitales"].Rows)
                {
                    string rfcemisor = orowheader["rfcemisor"].ToString();
                    string nombreemisor= orowheader["nombreemisor"].ToString();
                    string rfcreceptor = orowheader["rfcreceptor"].ToString();
                    string nombrereceptor = orowheader["nombrereceptor"].ToString();

                    if (optipodescargas.Value.ToString() == "recibidos")
                    {
                        proveedores oproveedor;
                        if (!proveedornc.existeproveedor(rfcemisor, this._connexionstring))
                        {
                            oproveedor = new proveedores();
                            oproveedor.idproveedor = proveedornc.getid(this._connexionstring);
                            oproveedor.rfc = rfcemisor;
                            oproveedor.nombre = nombreemisor;
                            oproveedor.contacto = "";
                            oproveedor.correo = "";
                            oproveedor.domicilio = "";
                            oproveedor.movil = "";
                            oproveedor.telefono = "";
                            oproveedor.usuario = this._idusuario.ToString();
                            oproveedor.baja = false;
                            proveedornc.save(oproveedor, this._connexionstring);
                        }

                    }

                }






                foreach (DataRow orow in DS.Tables["documentosdigitalesconceptos"].Rows)
                {
                    string unidad = orow["unidad"].ToString().Trim();
                    string descripcion = orow["descripcion"].ToString().Trim();
                    string claveprodserv = orow["claveprodserv"].ToString();
                    string claveunidad = orow["claveunidad"].ToString();
                    int iddocumentodigitalconcepto = Convert.ToInt32(orow["iddocumentodigitalconcepto"]);

                    if (unidad == "")
                    {
                        string query = "select descripcion from dbo.cfdiunidad where dbo.cfdiunidad.clave = '" + claveunidad + "'";
                        DataTable DT = genericas.generales.executeDS(query, this._connexionstring).Tables[0];
                        if (DT.Rows.Count > 0)
                        {
                            unidad = DT.Rows[0][0].ToString();
                        }
                    }
                    documentosdigitalesconceptos oconceptodigital = documentodigitalconceptonc.getdocumentodigitalconcepto(iddocumentodigitalconcepto, this._connexionstring);
                    oconceptodigital.unidad = unidad;
                    documentodigitalconceptonc.update(oconceptodigital, this._connexionstring);

                    unidades ounidad;
                    if (!unidadnc.existeunidad(claveunidad, this._connexionstring))
                    {
                        ounidad = new unidades();
                        ounidad.idunidad = unidadnc.getid(this._connexionstring);
                        ounidad.nombre = unidad;
                        ounidad.cveunidad = claveunidad;
                        ounidad.simbologia = claveunidad;
                        ounidad.idorigen = iddocumentodigitalconcepto;
                        ounidad.usuario = this._idusuario.ToString();
                        ounidad.baja = false;
                        unidadnc.save(ounidad, this._connexionstring);
                    }
                    else
                    {
                        ounidad = unidadnc.getunidadbyclaveunidad(claveunidad, this._connexionstring);
                    }

                    if (!conceptonc.existeconcepto(claveprodserv, this._connexionstring))
                    {
                        conceptos oconcepto = new conceptos();
                        oconcepto.idconcepto = conceptonc.getid(this._connexionstring);
                        oconcepto.idunidad = ounidad.idunidad;
                        oconcepto.idorigen = iddocumentodigitalconcepto;
                        oconcepto.grupo = genericas.enums.egrupoconcepto.externo.ToString();
                        oconcepto.descripcion = descripcion;
                        oconcepto.cvesat = claveprodserv;
                        oconcepto.nombre = descripcion;

                        string cad = claveprodserv.Substring(0, 2);
                        if (Convert.ToInt32(cad)>=70)
                        {
                            if (Convert.ToInt32(cad) <= 94)
                            {
                                oconcepto.tipoconcepto = genericas.enums.etipoconcepto.servicio.ToString();
                                oconcepto.inventario = false;
                            }
                            else
                            {
                                oconcepto.tipoconcepto = genericas.enums.etipoconcepto.producto.ToString();
                                oconcepto.inventario = true;
                            }
                        }
                        else
                        {
                            oconcepto.tipoconcepto = genericas.enums.etipoconcepto.producto.ToString();
                            oconcepto.inventario = true;
                        }
                      
                        oconcepto.usuario = this._idusuario.ToString();
                        oconcepto.baja = false;

                        conceptonc.save(oconcepto, this._connexionstring);
                    }

                }

                MessageBox.Show("¡Verificación de catálogos realizada correctamente!", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnregistrarbitacoragasolina_Click(object sender, EventArgs e)
        {
            try
            {
                if (grddocumentosdigitales.ActiveRow != null)
                {
                    if (grddocumentosdigitales.ActiveRow.Band.Index == 0)
                    {

                        int iddocumentodigital = Convert.ToInt32(grddocumentosdigitales.ActiveRow.Cells["iddocumentodigital"].Value);
                        frmgasolina ofrmgasolina = new frmgasolina(0, this._idusuario, this._connexionstring);
                        ofrmgasolina._iddocumentodigital = iddocumentodigital;
                        ofrmgasolina.ShowDialog();
                        if (ofrmgasolina._update)
                        {
                            consultar();
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnregistrarmantenimiento_Click(object sender, EventArgs e)
        {
            try
            {
                if (grddocumentosdigitales.ActiveRow != null)
                {
                    if (grddocumentosdigitales.ActiveRow.Band.Index == 0)
                    {

                        int iddocumentodigital = Convert.ToInt32(grddocumentosdigitales.ActiveRow.Cells["iddocumentodigital"].Value);
                        frmmantenimiento ofrmmantenimiento = new frmmantenimiento(0, this._idusuario, this._connexionstring);
                        ofrmmantenimiento._iddocumentodigital = iddocumentodigital;
                        ofrmmantenimiento.ShowDialog();
                        if (ofrmmantenimiento._update)
                        {
                            consultar();
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnxml_Click(object sender, EventArgs e)
        {
            try
            {
                if (grddocumentosdigitales.ActiveRow != null)
                {
                    if (grddocumentosdigitales.ActiveRow.Band.Index == 0)
                    {
                        int iddocumentodigital = Convert.ToInt32(grddocumentosdigitales.ActiveRow.Cells["iddocumentodigital"].Value);
                        documentosdigitales odoc = documentodigitalnc.getgetdocumentodigital(iddocumentodigital, this._connexionstring);

                        string xmldoc = Encoding.UTF8.GetString(odoc.xml, 0, odoc.xml.Length);
                        string dirfile = oparametros.direxportaciones + @"\"+odoc.uuid+@".xml";
                        System.IO.File.WriteAllText(dirfile, xmldoc);
                        System.Diagnostics.Process.Start(dirfile);

                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
