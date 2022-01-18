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
using Infragistics.Win;
using System.IO;
using System.Xml;
using System.Xml.Xsl;

namespace cipal.egresos
{
    public partial class frmbuscardocumentodigital : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;
        private int _idconfig;
        parametros oparametros = null;
        public bool ok = false;
        public int iddocumentodigital = 0;

        string[] ejercicios = { "2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028" };

        private DataTable DTTipoXML = null;
        public frmbuscardocumentodigital(int id, int idconfig,int idusuario, string connexionstring)
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

            foreach(string tipo in tipoxml)
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


            this.optipodescargas.CheckedIndex = 1;
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
                    documentodigitalnc.getdocumentosdigitalesbyparams(tiposolicitud,tipoxml,fi,ff,rfc,nombre,this._connexionstring);

                List<documentosdigitalesconceptos> olistdocumentosdigitalesconceptos = new List<documentosdigitalesconceptos>();
                foreach(documentosdigitales odoc in olistdocumentosdigitales)
                {
                    olistdocumentosdigitalesconceptos.AddRange(documentodigitalconceptonc.getdocumentosdigitalesconceptosbyiddocumentodigital(odoc.iddocumentodigital, this._connexionstring));
                }

                DataTable DT = genericas.helpers.ToDataTable(olistdocumentosdigitales);
                DataTable DTDetalle = genericas.helpers.ToDataTable(olistdocumentosdigitalesconceptos);
                foreach(DataRow orow in DT.Rows)
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
                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["tipoxml"].Hidden = false;
                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["uuid"].Hidden = false;

                if (tiposolicitud == "recibidos")
                {
                    this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["rfcemisor"].Hidden = false;
                    this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["nombreemisor"].Hidden = false;
                }
                else
                {
                    this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["rfcreceptor"].Hidden = false;
                    this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["nombrereceptor"].Hidden = false;
                }
          
             

                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["fechaemision"].Hidden = false;
                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["monto"].Hidden = false;
                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["estatus"].Hidden = false;


                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["tipoxml"].Header.Caption = "Tipo de XML";
                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["uuid"].Header.Caption = "UUID";
                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["rfcemisor"].Header.Caption = "RFC del Emisor";
                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["nombreemisor"].Header.Caption = "Nombre del Emisor";
                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["rfcreceptor"].Header.Caption = "RFC del Receptor";
                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["nombrereceptor"].Header.Caption = "Nombre del Receptor";
                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["fechaemision"].Header.Caption = "Fecha de Emisión";
                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["monto"].Header.Caption = "Total";
                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["estatus"].Header.Caption = "Estado";


                this.grddocumentosdigitales.DisplayLayout.Bands[0].Columns["fechaemision"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;



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


                this.grddocumentosdigitales.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
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
        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (grddocumentosdigitales.ActiveRow != null)
                {
                    this.iddocumentodigital = Convert.ToInt32(grddocumentosdigitales.ActiveRow.Cells["iddocumentodigital"].Value);
                    this.ok = true;
                    this.Close();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grddocumentosdigitales_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.grddocumentosdigitales.ActiveRow != null)
                {
                    if (grddocumentosdigitales.ActiveRow != null)
                    {
                        this.iddocumentodigital = Convert.ToInt32(grddocumentosdigitales.ActiveRow.Cells["iddocumentodigital"].Value);
                        this.ok = true;
                        this.Close();
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
    }
}
