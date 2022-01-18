using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using cipal.entidades;
using cipal.negocios;

namespace cipal.descargas
{
    
    public partial class frmcontribuyentesapocrifoconsulta : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;
        private int _idconfig;

        private parametros _oconfig = null;
        private string _listadosat = "";
        private string _url = "http://omawww.sat.gob.mx/cifras_sat/Documents/Listado_Completo_69-B.csv";
        public frmcontribuyentesapocrifoconsulta(int id, int idconfig,int idusuario, string connexionstring)
        {
            InitializeComponent();
            this._idusuario = idusuario;
            this._connexionstring = connexionstring;
            this._id = id;
            this._idconfig = idconfig;
            _oconfig = parametronc.getparametro(this._idconfig, this._connexionstring);

            _listadosat = _oconfig.dirrecursoscfdi + @"\Listado_Completo_69-B.csv";

        }

        private void frmcontribuyentesapocrifo_Load(object sender, EventArgs e)
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
                string nombre = this.txtnombre.Text;
                string rfc = this.txtrfc.Text;

                List<contribuyentesapocrifos> olistcontribuyentesapocrifos = contribuyentesapocrifonc.getcontribuyentesapocrifosbyparams(nombre, rfc, this._connexionstring); 
                this.grdcontribuyentesapocrifos.SetDataBinding(olistcontribuyentesapocrifos, null);
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grdcontribuyentesapocrifos.DisplayLayout.Bands[0].Columns)
                {
                    oColumn.Hidden = true;
                }
                //this.grdcontribuyentesapocrifos.DisplayLayout.Bands[0].Columns["idcontribuyente"].Hidden = false;
                this.grdcontribuyentesapocrifos.DisplayLayout.Bands[0].Columns["rfc"].Hidden = false;
                this.grdcontribuyentesapocrifos.DisplayLayout.Bands[0].Columns["nombre"].Hidden = false;
                this.grdcontribuyentesapocrifos.DisplayLayout.Bands[0].Columns["situacion"].Hidden = false;
                this.grdcontribuyentesapocrifos.DisplayLayout.Bands[0].Columns["oficiosat"].Hidden = false;
                this.grdcontribuyentesapocrifos.DisplayLayout.Bands[0].Columns["fechasat"].Hidden = false;
                this.grdcontribuyentesapocrifos.DisplayLayout.Bands[0].Columns["oficiodof"].Hidden = false;
                this.grdcontribuyentesapocrifos.DisplayLayout.Bands[0].Columns["fechadof"].Hidden = false;

                this.grdcontribuyentesapocrifos.DisplayLayout.Bands[0].Columns["rfc"].Header.Caption = "RFC";
                this.grdcontribuyentesapocrifos.DisplayLayout.Bands[0].Columns["nombre"].Header.Caption = "Nombre";
                this.grdcontribuyentesapocrifos.DisplayLayout.Bands[0].Columns["situacion"].Header.Caption = "Situación";
                this.grdcontribuyentesapocrifos.DisplayLayout.Bands[0].Columns["oficiosat"].Header.Caption = "Oficio SAT";
                this.grdcontribuyentesapocrifos.DisplayLayout.Bands[0].Columns["fechasat"].Header.Caption = "Fecha SAT";
                this.grdcontribuyentesapocrifos.DisplayLayout.Bands[0].Columns["oficiodof"].Header.Caption = "Oficio DOF";
                this.grdcontribuyentesapocrifos.DisplayLayout.Bands[0].Columns["fechadof"].Header.Caption = "Fecha DOF";

                this.grdcontribuyentesapocrifos.DisplayLayout.Bands[0].Columns["fechasat"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                this.grdcontribuyentesapocrifos.DisplayLayout.Bands[0].Columns["fechadof"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                this.grdcontribuyentesapocrifos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
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
                int id = Convert.ToInt32(this.grdcontribuyentesapocrifos.ActiveRow.Cells["idcontribuyenteapocrifo"].Value);
                if (MessageBox.Show("¿Esta seguro de borrar el registro", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    contribuyentesapocrifos ocontribuyentesapocrifo = contribuyentesapocrifonc.getcontribuyentesapocrifo(id, this._connexionstring);
                    ocontribuyentesapocrifo.baja = true;
                    contribuyentesapocrifonc.update(ocontribuyentesapocrifo, this._connexionstring);

                    consultar();

                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void btncargar_Click(object sender, EventArgs e)
        {
            //int z = 0;
            //string rfcx = "";
            try
            {

                if (MessageBox.Show( "Tenga en cuenta que el documento podría venir con errores de formato de columnas por lo que se recomienda verificar antes de continuar." + Environment.NewLine + "Antes de iniciar con el procedimiento. ¿Desea realizar la descarga del listado vigente del Administración Tributaria (SAT)?.","Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    WebClient client = new WebClient();
                    client.DownloadFileAsync(new Uri(_url), _listadosat);
                }


                if (MessageBox.Show("Este procedimiento reiniciará el almacén de contribuyentes apócrifos con la versión más reciente publicada por el Servicio de Administración Tributaria (SAT). ¿Esta seguro de querer realizar este procedimiento?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    contribuyentesapocrifonc.clear(this._connexionstring);


                    string[] lineas = System.IO.File.ReadAllLines(_listadosat);
                    contribuyentesapocrifos ocontribuyente = null;

                    for (int x = 3; x < lineas.Count(); x++)
                    {
                        //z = x;
                        string linea = lineas[x].ToString();
                        if (!linea.Contains("XXXXXXXXXXXX"))
                        {
                            //ERRORES DETECTADOS
                            if (linea.Contains("Regional del Noreste del TFJFA, en el expediente")) continue;

                            if (linea.Contains("1049/15-06-02-9 y 3122/15-06-01-5 acumulados")) continue;
                            //FIN DE ERRORES DETECTADOS

                            string rfc = "";
                            string empresa = "";
                            string situacion = "";
                            string oficiosat = "";
                            string fechaoficiosat = "";
                            string oficiodof = "";
                            string fechaoficiodof = "";

                            if (linea.Contains("\""))
                            {
                                if (linea.Contains("\"\""))
                                {
                                    if (linea.Contains("\"\"\""))
                                    {
                                        //rfcx = linea.Split('\"')[0].Split(',')[1];
                                        rfc = linea.Split('\"')[0].Split(',')[1];
                                        empresa = linea.Split('\"')[3];
                                        situacion = linea.Split('\"')[linea.Split('\"').Length - 1].Split(',')[1];
                                        oficiosat = linea.Split('\"')[linea.Split('\"').Length - 1].Split(',')[2];
                                        fechaoficiosat = linea.Split('\"')[linea.Split('\"').Length - 1].Split(',')[3];
                                        oficiodof = linea.Split('\"')[linea.Split('\"').Length - 1].Split(',')[4];
                                        fechaoficiodof = linea.Split('\"')[linea.Split('\"').Length - 1].Split(',')[5];
                                    }
                                    else
                                    {
                                        //rfcx = linea.Split('\"')[0].Split(',')[1];
                                        rfc = linea.Split('\"')[0].Split(',')[1];
                                        empresa = linea.Split('\"')[3] + linea.Split('\"')[5];
                                        situacion = linea.Split('\"')[linea.Split('\"').Length - 1].Split(',')[1];
                                        oficiosat = linea.Split('\"')[linea.Split('\"').Length - 1].Split(',')[2];
                                        fechaoficiosat = linea.Split('\"')[linea.Split('\"').Length - 1].Split(',')[3];
                                        oficiodof = linea.Split('\"')[linea.Split('\"').Length - 1].Split(',')[4];
                                        fechaoficiodof = linea.Split('\"')[linea.Split('\"').Length - 1].Split(',')[5];
                                    }
                                }
                                else
                                {
                                    //rfcx = linea.Split('\"')[0].Split(',')[1];
                                    rfc = linea.Split('\"')[0].Split(',')[1];
                                    empresa = linea.Split('\"')[1];
                                    situacion = linea.Split('\"')[2].Split(',')[1];
                                    oficiosat = linea.Split('\"')[2].Split(',')[2];
                                    fechaoficiosat = linea.Split('\"')[2].Split(',')[3];
                                    oficiodof = linea.Split('\"')[2].Split(',')[4];
                                    fechaoficiodof = linea.Split('\"')[2].Split(',')[5];
                                }

                            }
                            else
                            {
                                //rfcx = linea.Split(',')[1];
                                rfc = linea.Split(',')[1];
                                empresa = linea.Split(',')[2];
                                situacion = linea.Split(',')[3];
                                oficiosat = linea.Split(',')[4];
                                fechaoficiosat = linea.Split(',')[5];
                                oficiodof = linea.Split(',')[6];
                                fechaoficiodof = linea.Split(',')[7];
                            }


                            ocontribuyente = new contribuyentesapocrifos();
                            ocontribuyente.idcontribuyenteapocrifo = contribuyentesapocrifonc.getid(this._connexionstring);
                            ocontribuyente.rfc = rfc;
                            ocontribuyente.nombre = empresa;
                            ocontribuyente.situacion = situacion;
                            ocontribuyente.oficiosat = oficiosat;

                            if (fechaoficiosat == "")
                            {
                                ocontribuyente.fechasat = new DateTime(1900, 1, 1);
                            }
                            else
                            {
                                ocontribuyente.fechasat = Convert.ToDateTime(fechaoficiosat);
                            }

                            ocontribuyente.oficiodof = oficiodof;
                            if (fechaoficiodof == "")
                            {
                                ocontribuyente.fechadof = new DateTime(1900, 1, 1);
                            }
                            else
                            {
                                ocontribuyente.fechadof = Convert.ToDateTime(fechaoficiodof);
                            }

                            ocontribuyente.usuario = this._idusuario.ToString();
                            ocontribuyente.baja = false;
                            contribuyentesapocrifonc.save(ocontribuyente, this._connexionstring);
                        }
                    }

                    MessageBox.Show("¡Carga de contribuyentes apócrifos realizada correctamente!", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    consultar();
                }
            }
            catch (System.Exception ex)
            {
                //MessageBox.Show(ex.Message + "Error en linea: " + z.ToString() + " >> rfc: " + rfcx, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
