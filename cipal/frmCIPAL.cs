using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinListView;
using Infragistics.Win.UltraWinSchedule;
using System.Resources;

using cipal.catalogos;
using cipal.descargas;
using cipal.configuraciones;
using cipal.ingresos;
using cipal.egresos;
using cipal.gestion;

using DevExpress.XtraSplashScreen;

namespace cipal
{
    public partial class frmCIPAL : Form
    {

        private string _token;
        private string _tokendecript;

        private string _cnn;
        private string _cnndecript;

        private string _tipodeinstalacion;
        private string _servidor;
        private string _instancia;
        private string _username;
        private string _password;

        //PARAMETROS GLOBALES DE CONTROL DE ACCESO
        private string _usuario = "";
        private string _dbempresa = "";
        private string _conexionString = "";

        private int _idusuario;
        private int _id = 0; //IDENTIFICADOR DE LA EMPRESA ACTIVA
        private int _idconfig = 0; //IDENTIFICADOR DE PARAMETROS DE EMPRESA
        //FIN DE PARAMETROS GLOBALES DE CONTROL DE ACCESO

        private void AddFormInPanel(Form fh, Infragistics.Win.UltraWinTabControl.UltraTabPageControl pcontainer)
        {
            pcontainer.Controls.Clear();
            fh.WindowState = FormWindowState.Normal;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            pcontainer.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            pcontainer.Controls.Add(fh);
            pcontainer.Tag = fh;
            fh.BringToFront();
            fh.Show();
        }


        public frmCIPAL(string token, string cnn)
        {
            try
            {
                InitializeComponent();
                this._conexionString = cnn;
                this._id = 1;
                this._idconfig = 1;

                this._idusuario = 0;
                if (this._idusuario == 0)
                {
                    this._usuario = "";
                }


                _token = token;
                _tokendecript = genericas.generales.desencriptar(_token);

                _cnn = cnn;
                _cnndecript = genericas.generales.desencriptar(_cnn);

                string[] _cnnsplit = _cnndecript.Split('|');
                _tipodeinstalacion = _cnnsplit[0];
                _servidor = _cnnsplit[1];
                _instancia = _cnnsplit[2];
                _username = _cnnsplit[3];
                _password = genericas.generales.desencriptar(_cnnsplit[4]);

                SplashScreenManager.CloseForm();
                if (_usuario == "")
                {
                    componentes.seguridad.frmLogin ofrmLogin = new componentes.seguridad.frmLogin(_token, _cnn);
                    ofrmLogin.ShowDialog();
                    if (ofrmLogin.username != "")
                    {
                        _usuario = ofrmLogin.username;
                        if (_dbempresa == "")
                        {
                            componentes.empresas.frmListadoEmpresas ofrmListadoEmpresas = new componentes.empresas.frmListadoEmpresas(_token, _cnn);
                            ofrmListadoEmpresas.ShowDialog();
                            if (ofrmListadoEmpresas.dbname != "")
                            {
                                _dbempresa = ofrmListadoEmpresas.dbname;
                                _conexionString = genericas.generales.getconnexionstring(_tipodeinstalacion, _servidor, _instancia, _username, _password, _dbempresa);
                            }
                            else
                            {
                                //Formatear MDI Sin Usuario Ni Empresa

                            }
                        }

                    }
                    else
                    {
                        //Formatear MDI Sin Usuario

                    }

                }

                //CADENA DE CONEXIÓN MONOUSUARIO
                //this._connexionstring = @"Data Source=DESKTOP-JBJ6MI3\SQLSERVER2012;Initial Catalog=cipal_aaa010101aaa_municipio_de_merida;Integrated Security=true";
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!this.DesignMode)
            {
                Infragistics.Win.Office2013ColorTable.ColorScheme = Infragistics.Win.Office2013ColorScheme.DarkGray;
            }
        }


        private void frmCIPAL_Load(object sender, EventArgs e)
        {
            tabcatalogos.SelectedTab = null;
            tabingresos.SelectedTab = null;
            tabegresos.SelectedTab = null;
            tabgestion.SelectedTab = null;
           
        }

        private void utcmain_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {

        }

        private void tabcatalogos_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {

            if (e.Tab != null)
            {
                switch (e.Tab.Key)
                {
                    case "c0":
                        cipal.catalogos.frmtipoingreso ofrmtipodeingresos = new cipal.catalogos.frmtipoingreso(this._id, this._idusuario, this._conexionString);
                        AddFormInPanel(ofrmtipodeingresos, tiposdeingresos);
                        break;
                    case "c1":
                        cipal.catalogos.frmcontribuyenteconsulta ofrmcontribuyenteconsulta = new cipal.catalogos.frmcontribuyenteconsulta(this._idusuario, this._conexionString);
                        AddFormInPanel(ofrmcontribuyenteconsulta, contribuyentes);
                        break;
                    case "c2":
                        cipal.catalogos.frmtipoapoyo ofrmtipoapoyo = new cipal.catalogos.frmtipoapoyo(this._id, this._idusuario, this._conexionString);
                        AddFormInPanel(ofrmtipoapoyo, tiposdeapoyo);
                        break;

                    case "c3":
                        cipal.catalogos.frmbeneficiarioconsulta ofrmbeneficiarioconsulta = new cipal.catalogos.frmbeneficiarioconsulta(this._idusuario, this._conexionString);
                        AddFormInPanel(ofrmbeneficiarioconsulta, beneficiarios);
                        break;
                    case "c4":
                        cipal.catalogos.frmproveedorconsulta ofrmproveedorconsulta = new cipal.catalogos.frmproveedorconsulta(this._idusuario, this._conexionString);
                        AddFormInPanel(ofrmproveedorconsulta, proveedores);
                        break;

                    case "c5":
                        cipal.catalogos.frmdepartamentos ofrmdepartamentos = new cipal.catalogos.frmdepartamentos(this._id,this._idusuario, this._conexionString);
                        AddFormInPanel(ofrmdepartamentos, departamentos);
                        break;
                    case "c6":
                        cipal.catalogos.frmempleadoconsulta ofrmempleadoconsulta = new cipal.catalogos.frmempleadoconsulta(this._idusuario, this._conexionString);
                        AddFormInPanel(ofrmempleadoconsulta, empleados);
                        break;
                    case "c7":
                        cipal.catalogos.frmpuestos ofrmpuestos = new cipal.catalogos.frmpuestos(this._id,this._idusuario, this._conexionString);
                        AddFormInPanel(ofrmpuestos, puestos);
                        break;
                    case "c8":
                        cipal.catalogos.frmvehiculos ofrmvehiculos = new cipal.catalogos.frmvehiculos(this._id, this._idusuario, this._conexionString);
                        AddFormInPanel(ofrmvehiculos, vehiculos);
                        break;
                    case "c9":
                        cipal.catalogos.frmunidades ofrmunidades = new cipal.catalogos.frmunidades(this._id, this._idusuario, this._conexionString);
                        AddFormInPanel(ofrmunidades, unidades);
                        break;
                    case "c10":
                        cipal.catalogos.frmimpuestos ofrmimpuestos = new cipal.catalogos.frmimpuestos(this._id, this._idusuario, this._conexionString);
                        AddFormInPanel(ofrmimpuestos, impuestos);
                        break;
                    case "c11":
                        cipal.catalogos.frmconceptoconsulta ofrmconceptoconsulta = new cipal.catalogos.frmconceptoconsulta(this._idusuario, this._conexionString);
                        AddFormInPanel(ofrmconceptoconsulta, conceptos);
                        break;
                }
            }
        }

        private void tabegresos_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (e.Tab != null)
            {
                switch (e.Tab.Key)
                {
                    case "e0":
                        cipal.egresos.frmsolicitudconsulta ofrmsolicitudesconsulta = new cipal.egresos.frmsolicitudconsulta(this._id, this._idusuario, this._idconfig, this._conexionString);
                        AddFormInPanel(ofrmsolicitudesconsulta, solicitudes);
                        break;
                    case "e1":
                        cipal.egresos.frmordenconsulta ofrmordenconsulta = new cipal.egresos.frmordenconsulta(this._id, this._idusuario, this._idconfig, this._conexionString);
                        AddFormInPanel(ofrmordenconsulta, ordenes);
                        break;
                    case "e2":
                        cipal.egresos.frmpedidoconsulta ofrmpedidoconsulta = new cipal.egresos.frmpedidoconsulta(this._id, this._idusuario, this._idconfig, this._conexionString);
                        AddFormInPanel(ofrmpedidoconsulta, pedidos);
                        break;

                    case "e3":
                        cipal.egresos.frmconstanciaconsulta ofrmconstanciaconsulta = new cipal.egresos.frmconstanciaconsulta(this._id, this._idusuario, this._idconfig, this._conexionString);
                        AddFormInPanel(ofrmconstanciaconsulta, constancias);
                        break;
                    case "e4":
                        cipal.egresos.frminformeconsulta ofrminformeconsulta = new cipal.egresos.frminformeconsulta(this._id, this._idusuario, this._idconfig, this._conexionString);
                        AddFormInPanel(ofrminformeconsulta, informes);
                        break;

                    case "e5":
                        cipal.egresos.frmgasolinaconsulta ofrmgasolinaconsulta = new cipal.egresos.frmgasolinaconsulta(this._id, this._idusuario, this._idconfig, this._conexionString);
                        AddFormInPanel(ofrmgasolinaconsulta, bitacorascombustibles);
                        break;
                    case "e6":
                        cipal.egresos.frmmantenimientoconsulta ofrmmantenimientoconsulta = new cipal.egresos.frmmantenimientoconsulta(this._id, this._idusuario, this._idconfig, this._conexionString);
                        AddFormInPanel(ofrmmantenimientoconsulta, bitacorasmantenimiento);
                        break;

                }
            }
        }

        private void tabingresos_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (e.Tab != null)
            {
                switch (e.Tab.Key)
                {
                    case "i0":
                        cipal.ingresos.frmregistroingresoconsulta ofrmregistroingresoconsulta = new cipal.ingresos.frmregistroingresoconsulta(this._id, this._idusuario, this._idconfig, this._conexionString);
                        AddFormInPanel(ofrmregistroingresoconsulta, registrodeingresos);
                        break;
                }
            }
        }

        private void tabgestion_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (e.Tab != null)
            {
                switch (e.Tab.Key)
                {
                    case "g0":
                        cipal.gestion.frmconfdapempleadosconsulta ofrmconfdapempleadosconsulta = new cipal.gestion.frmconfdapempleadosconsulta(this._idusuario,  this._conexionString);
                        AddFormInPanel(ofrmconfdapempleadosconsulta, puestosdeempleados);
                        break;
                    case "g1":
                        cipal.gestion.frmapoyoconsulta ofrmapoyoconsulta = new cipal.gestion.frmapoyoconsulta(this._id,this._idconfig,this._idusuario, this._conexionString);
                        AddFormInPanel(ofrmapoyoconsulta, registrodeapoyos);
                        break;
                    case "g2":
                        cipal.descargas.frmcontribuyentesapocrifoconsulta ofrmcontribuyentesapocrifoconsulta = new cipal.descargas.frmcontribuyentesapocrifoconsulta(this._id, this._idconfig, this._idusuario, this._conexionString);
                        AddFormInPanel(ofrmcontribuyentesapocrifoconsulta, contribuyentesapocrifos);
                        break;
                    case "g3":
                        cipal.descargas.frmdocumentodigitalconsulta ofrmdocumentodigitalconsulta = new cipal.descargas.frmdocumentodigitalconsulta(this._id, this._idconfig, this._idusuario, this._conexionString);
                        AddFormInPanel(ofrmdocumentodigitalconsulta, documentosdigitalesxml);
                        break;
                    case "g4":
                        cipal.descargas.frmdocumentodigitalverificacion ofrmdocumentodigitalverificacion = new cipal.descargas.frmdocumentodigitalverificacion(this._id, this._idconfig, this._idusuario, this._conexionString);
                        AddFormInPanel(ofrmdocumentodigitalverificacion, validaciondocumentosdigitalesxml);
                        break;
                    case "g5":
                        cipal.descargas.frmdescargas ofrmdescargas = new cipal.descargas.frmdescargas(this._id, this._idconfig, this._idusuario, this._conexionString);
                        AddFormInPanel(ofrmdescargas, descargadedocumentos);
                        break;
                }
            }
        }

        

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnconfiguraciones_Click(object sender, EventArgs e)
        {
            frmconfiguraciones ofrmconfig = new frmconfiguraciones(this._id, this._idconfig, this._idusuario, this._conexionString, this._cnn);
            ofrmconfig.ShowDialog();
        }

        private void btnempresa_Click(object sender, EventArgs e)
        {
            frminfoempresa ofrmempresa = new frminfoempresa(this._id, this._idusuario, this._conexionString);
            ofrmempresa.ShowDialog();
        }

        private void btnsolicitudesdescargas_Click(object sender, EventArgs e)
        {
            frmdocumentodigitalconsulta ofrmdocumentodigitalconsulta = new frmdocumentodigitalconsulta(this._id, this._idconfig, this._idusuario, this._conexionString);
            ofrmdocumentodigitalconsulta.ShowDialog();
        }

        private void btndocumentosxml_Click(object sender, EventArgs e)
        {
            frmdocumentodigitalconsulta ofrmdocumentodigitalconsulta = new frmdocumentodigitalconsulta(this._id, this._idconfig, this._idusuario, this._conexionString);
            ofrmdocumentodigitalconsulta.ShowDialog();
        }

        private void btnvalidaciondedocumentos_Click(object sender, EventArgs e)
        {
            frmdocumentodigitalverificacion ofrmdocumentodigitalverificacion = new frmdocumentodigitalverificacion(this._id, this._idconfig, this._idusuario, this._conexionString);
            ofrmdocumentodigitalverificacion.ShowDialog();
        }

        private void btningresos_Click(object sender, EventArgs e)
        {
            frmregistroingresoconsulta ofrmregistroingresoconsulta = new frmregistroingresoconsulta(this._id, this._idusuario, this._idconfig, this._conexionString);
            ofrmregistroingresoconsulta.ShowDialog();
        }

        
    }
  
}
