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
using cipal.descargas;
using cipal.configuraciones;
using cipal.ingresos;
using cipal.egresos;
using cipal.gestion;
using DevExpress.XtraSplashScreen;

namespace cipal
{
    public partial class frmMDI : Form
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
        private int _id; //IDENTIFICADOR DE LA EMPRESA ACTIVA
        private int _idconfig; //IDENTIFICADOR DE PARAMETROS DE EMPRESA
        //FIN DE PARAMETROS GLOBALES DE CONTROL DE ACCESO




        public frmMDI(string token,string cnn)
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
        private void frmMDI_Load(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnempleados_Click(object sender, EventArgs e)
        {
            
            try
            {
                //frmempleado ofrmempleado = new frmempleado();
                //ofrmempleado.ShowDialog();
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void utbMDI_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {

                switch (e.Tool.Key)
                {
                    //MDI PRINCIPAL
                    case "btnparametros":
                        frmconfiguraciones ofrmconfig = new frmconfiguraciones(this._id, this._idconfig, this._idusuario, this._conexionString, this._cnn);
                        ofrmconfig.ShowDialog();
                        break;

                    case "btnempresa":
                        frminfoempresa ofrmempresa = new frminfoempresa(this._id, this._idusuario, this._conexionString);
                        ofrmempresa.ShowDialog();
                        break;

                    case "btncambiarempresa":
                        componentes.empresas.frmListadoEmpresas ofrmListadoEmpresas = new componentes.empresas.frmListadoEmpresas(_token, _cnn);
                        ofrmListadoEmpresas.ShowDialog();
                        if (ofrmListadoEmpresas.dbname != "")
                        {
                            _dbempresa = ofrmListadoEmpresas.dbname;
                            _conexionString = genericas.generales.getconnexionstring(_tipodeinstalacion, _servidor, _instancia, _username, _password, _dbempresa);
                        }
                        break;

                    case "btncerrarempresa":
                        //DESHABILITAR BOTONES
                        break;

                    case "btncambiarusuario":
                        componentes.seguridad.frmLogin ofrmLogin = new componentes.seguridad.frmLogin(_token, _cnn);
                        ofrmLogin.ShowDialog();
                        if (ofrmLogin.username != "")
                        {
                            _usuario = ofrmLogin.username;
                        }
                        break;

                    case "btnsalir":
                        this.Close();
                        break;


                    //CATÁLOGOS
                    case "btntiposdeingresos":
                        frmtipoingreso ofrmtipoingreso = new frmtipoingreso(this._id, this._idusuario, this._conexionString);
                        ofrmtipoingreso.ShowDialog();
                        break;
                    case "btncontribuyentes":
                        frmcontribuyenteconsulta ofrmcontribuyenteconsulta = new frmcontribuyenteconsulta(this._idusuario, this._conexionString);
                        ofrmcontribuyenteconsulta.MdiParent = this;
                        ShowForms(ofrmcontribuyenteconsulta);
                        break;
                    case "btntiposdeapoyos":
                        frmtipoapoyo ofrmtipoapoyo = new frmtipoapoyo(this._id, this._idusuario, this._conexionString);
                        ofrmtipoapoyo.ShowDialog();
                        break;
                    case "btnbeneficiarios":
                        frmbeneficiarioconsulta ofrmbeneficiario = new frmbeneficiarioconsulta(this._idusuario, this._conexionString);
                        ofrmbeneficiario.MdiParent = this;
                        ShowForms(ofrmbeneficiario);
                        break;
                    case "btnproveedores":
                        frmproveedorconsulta ofrmproveedorconsulta = new frmproveedorconsulta(this._idusuario, this._conexionString);
                        ofrmproveedorconsulta.MdiParent = this;
                        ShowForms(ofrmproveedorconsulta);
                        break;
                    case "btndepartamentos":
                        frmdepartamentos ofrmdepartamento = new frmdepartamentos(this._id, this._idusuario, this._conexionString);
                        ofrmdepartamento.ShowDialog();
                        break;
                    case "btnempleados":
                        frmempleadoconsulta ofrmempleadoconsulta = new frmempleadoconsulta(this._idusuario, this._conexionString);
                        ofrmempleadoconsulta.MdiParent = this;
                        ShowForms(ofrmempleadoconsulta);
                        break;
                    case "btnpuestos":
                        frmpuestos ofrmpuesto = new frmpuestos(this._id, this._idusuario, this._conexionString);
                        ofrmpuesto.ShowDialog();
                        break;
                    case "btnvehiculos":
                        frmvehiculos ofrmvehiculo = new frmvehiculos(this._id, this._idusuario, this._conexionString);
                        ofrmvehiculo.ShowDialog();
                        break;
                    case "btnunidades":
                        frmunidades ofrmunidad = new frmunidades(this._id, this._idusuario, this._conexionString);
                        ofrmunidad.ShowDialog();
                        break;
                    case "btnimpuestos":
                        frmimpuestos ofrmimpuesto = new frmimpuestos(this._id, this._idusuario, this._conexionString);
                        ofrmimpuesto.ShowDialog();
                        break;
                    case "btnconceptos":
                        frmconceptoconsulta ofrmconcepto = new frmconceptoconsulta(this._idusuario, this._conexionString);
                        ofrmconcepto.MdiParent = this;
                        ShowForms(ofrmconcepto);
                        break;


                    //INGRESOS
                    case "btningresos":
                        frmregistroingresoconsulta ofrmingresoconsulta = new frmregistroingresoconsulta(this._id,this._idconfig,this._idusuario, this._conexionString);
                        ofrmingresoconsulta.MdiParent = this;
                        ShowForms(ofrmingresoconsulta);
                        break;


                    //EGRESOS
                    case "btnsolicitudes":
                        frmsolicitudconsulta ofrmsolicitudconsulta = new frmsolicitudconsulta(this._idusuario, this._idconfig, this._id,  this._conexionString);
                        ofrmsolicitudconsulta.MdiParent = this;
                        ShowForms(ofrmsolicitudconsulta);
                        break;
                    case "btnordenes":
                        frmordenconsulta ofrmordenconsulta = new frmordenconsulta(this._idusuario, this._idconfig, this._id, this._conexionString);
                        ofrmordenconsulta.MdiParent = this;
                        ShowForms(ofrmordenconsulta);
                        break;
                    case "btnpedidos":
                        frmpedidoconsulta ofrmpedidoconsulta = new frmpedidoconsulta(this._idusuario, this._idconfig, this._id, this._conexionString);
                        ofrmpedidoconsulta.MdiParent = this;
                        ShowForms(ofrmpedidoconsulta);
                        break;

                    case "btnconstancias":
                        frmconstanciaconsulta ofrmconstanciaconsulta = new frmconstanciaconsulta(this._idusuario, this._idconfig, this._id, this._conexionString);
                        ofrmconstanciaconsulta.MdiParent = this;
                        ShowForms(ofrmconstanciaconsulta);
                        break;

                    case "btninformes":
                        frminformeconsulta ofrminformeconsulta = new frminformeconsulta(this._idusuario, this._idconfig, this._id, this._conexionString);
                        ofrminformeconsulta.MdiParent = this;
                        ShowForms(ofrminformeconsulta);
                        break;

                    case "btnmantenimientos":
                        frmmantenimientoconsulta ofrmmantenimientoconsulta = new frmmantenimientoconsulta(this._id,this._idconfig,this._idusuario, this._conexionString);
                        ofrmmantenimientoconsulta.MdiParent = this;
                        ShowForms(ofrmmantenimientoconsulta);
                        break;
                    case "btngasolinas":
                        frmgasolinaconsulta ofrmgasolinaconsulta = new frmgasolinaconsulta(this._id,this._idconfig,this._idusuario, this._conexionString);
                        ofrmgasolinaconsulta.MdiParent = this;
                        ShowForms(ofrmgasolinaconsulta);
                        break;


                    //GESTION
                    case "btnconfdapempleados":
                        frmconfdapempleadosconsulta ofrmconfdapempleado = new frmconfdapempleadosconsulta(this._idusuario, this._conexionString);
                        ofrmconfdapempleado.MdiParent = this;
                        ShowForms(ofrmconfdapempleado);
                        break;
                    case "btninventarios":
                        frminventarioconsulta ofrminventarioconsulta = new frminventarioconsulta(this._idusuario, this._conexionString);
                        ofrminventarioconsulta.MdiParent = this;
                        ShowForms(ofrminventarioconsulta);
                        break;
                    case "btnapoyos":
                        frmapoyoconsulta ofrmapoyoconsulta = new frmapoyoconsulta(this._id,this._idconfig,this._idusuario, this._conexionString);
                        ofrmapoyoconsulta.MdiParent = this;
                        ShowForms(ofrmapoyoconsulta);
                        break;
                    case "btncontribuyentesapocrifos":
                        frmcontribuyentesapocrifoconsulta ofrmcontribuyentesapocrifoconsulta = new frmcontribuyentesapocrifoconsulta(_id, _idconfig, this._idusuario, this._conexionString);
                        ofrmcontribuyentesapocrifoconsulta.MdiParent = this;
                        ShowForms(ofrmcontribuyentesapocrifoconsulta);
                        break;
                    case "btndocumentosdigitales":
                        frmdocumentodigitalconsulta ofrmdocumentodigitalconsulta = new frmdocumentodigitalconsulta(this._id,this._idconfig,this._idusuario, this._conexionString);
                        ofrmdocumentodigitalconsulta.MdiParent = this;
                        ShowForms(ofrmdocumentodigitalconsulta);
                        break;
                    case "keyvalidaciondocumentos":
                        frmdocumentodigitalverificacion ofrmdocumentodigitalverificacion = new frmdocumentodigitalverificacion(this._id, this._idconfig, this._idusuario, this._conexionString);
                        ofrmdocumentodigitalverificacion.MdiParent = this;
                        ShowForms(ofrmdocumentodigitalverificacion);
                        break;


                        
                    case "btnsolicitudesdedescargas":
                        frmdescargas ofrmdescargas = new frmdescargas(this._id,this._idconfig, this._idusuario, this._conexionString);
                        ofrmdescargas.MdiParent = this;
                        ShowForms(ofrmdescargas);
                        break;


                    //OTROS
                    case "btncontroldeinventario":
                        //frminventario ofrminventario = new frminventario(this._id, this._idusuario, this._conexionString);
                        //ofrminventario.ShowDialog();
                        break;


                }

                string form = this.Text;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowForms(Form Formulario)
        {
            Formulario.MdiParent = this;
           
            if (!isFormOpen(Formulario.Text))
            {
                Formulario.Show();
            }
        }

        private void ShowForms(Form Formulario, String FormText)
        {
            Formulario.MdiParent = this;
            if (!isFormOpen(Formulario.Name, FormText))
            {
                Formulario.Show();
            }
        }
        private Boolean isFormOpen(String FormName)
        {
            try
            {
                for (int m = 0; m < this.utMDI.TabGroups.Count; m++)
                {
                    for (int x = 0; x < utMDI.TabGroups[m].Tabs.Count; x++)
                    {
                        if (utMDI.TabGroups[0].Tabs[x].Form.Text == FormName)
                        {
                            //if (FormName == "frmReporte")
                            //{
                            //    return false;
                            //}
                            utMDI.TabGroups[0].Tabs[x].Form.Activate();
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        private Boolean isFormOpen(String FormName, String FormText)
        {
            try
            {
                for (int m = 0; m < utMDI.TabGroups.Count; m++)
                {
                    for (int x = 0; x < utMDI.TabGroups[m].Tabs.Count; x++)
                    {
                        if (utMDI.TabGroups[0].Tabs[x].Form.Name == FormName)
                        {
                            if (utMDI.TabGroups[0].Tabs[x].Form.Text == FormText)
                            {
                                utMDI.TabGroups[0].Tabs[x].Form.Close();
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void utMDI_TabClosed(object sender, Infragistics.Win.UltraWinTabbedMdi.MdiTabEventArgs e)
        {
            try
            {
               
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMDI_Shown(object sender, EventArgs e)
        {
            try
            {
               if( string.IsNullOrEmpty(_dbempresa))
                {
                    this.Close();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
    }
}
