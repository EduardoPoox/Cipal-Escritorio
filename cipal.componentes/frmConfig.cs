using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cipal.componentes
{
    public partial class frmConfig : Form
    {
        private string _connexionstringMaster;
        private string _connexionstringDefault;

        private string _tipoinstalacion;
        private string _servidor;
        private string _instancia;
        private string _username;
        private string _password;

        private string _eapp;
        private string _eversion;
        private string _numversion;
        private string _fechaliberacion;

        private string _pathconfigini;
        //private string _guid ="";

       

        public bool update = false;
        public frmConfig(string eapp, string eversion, string numversion, string fechaliberacion,string pathconfigini)
        {
            InitializeComponent();
            _eapp = eapp;
            _eversion = eversion;
            _numversion = numversion;
            _fechaliberacion = fechaliberacion;
            _pathconfigini = pathconfigini;

           

            //_guid = "7c4e5836-aefb-11eb-8529-0242ac130003";

        }
        
        private void frmConfig_Load(object sender, EventArgs e)
        {
            try
            {

                this.txtversioninstalador.Text = _eversion;
                this.txtnumversion.Text = _numversion;
                this.txtfechaliberacion.Text = _fechaliberacion;
                this.cmbtipodeinstalacion_SelectedValueChanged(null, null);

                this.txtserialkey.Text = genericas.generales.getserialkey();

                if (this.txtversioninstalador.Text.Trim() == genericas.enums.eversion.completa.ToString())
                {
                    this.chkmultiempresa.Checked = true;
                }
                else
                {
                    this.chkmultiempresa.Checked = false;
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbtipodeinstalacion_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtusername.Enabled = true;
                this.txtpassword.Enabled = true;
                this.txtservidor.Enabled = true;
                if (!String.IsNullOrEmpty(this.cmbtipodeinstalacion.Text))
                {
                    genericas.enums.etipoinstalacion eTipoInstalacion = (genericas.enums.etipoinstalacion)Enum.Parse(typeof(genericas.enums.etipoinstalacion), this.cmbtipodeinstalacion.Text);
                    switch (eTipoInstalacion)
                    {
                        case genericas.enums.etipoinstalacion.monousuario:
                            this.txtusername.Enabled = false;
                            this.txtpassword.Enabled = false;
                            break;
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTestConnexion_Click(object sender, EventArgs e)
        {
            try
            {
                if (validacontroles())
                {
                    string test = genericas.generales.connexiontest(this.txtservidor.Text.Trim(), this.txtinstancia.Text.Trim(), this.txtusername.Text.Trim(), this.txtpassword.Text.Trim(), this.cmbtipodeinstalacion.Text.Trim());
                    if (String.IsNullOrEmpty(test))
                        MessageBox.Show("¡El sistema se ha conectado exitosamente!", "Mensaje del Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("El sistema no se ha conectado adecuadamente, verifique: " + Environment.NewLine + Environment.NewLine + test, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string executescript(string path, DbCommand ocmd, OleDbConnection ocnn, string databasename)
        {
            try
            {
                string sqlcommand = "USE " + databasename + "\n";
                string line;
                StreamReader oreader;
                string msg = "";
                bool BetweenComment = false;
                oreader = new StreamReader(path);
                while ((line = oreader.ReadLine()) != null)
                {
                    if (line.Contains("/*"))
                        BetweenComment = true;
                    if (line.Contains("*/"))
                        BetweenComment = false;
                    if (line.Trim() != "GO")
                    {
                        sqlcommand = sqlcommand + line + "\n";
                    }
                    else
                    {
                        try
                        {
                            if (!BetweenComment)
                            {
                                ocmd.CommandText = sqlcommand;
                                ocmd.ExecuteNonQuery();
                                sqlcommand = "";
                            }
                            else
                            {
                                sqlcommand = sqlcommand + line + "\n";
                            }
                        }
                        catch (System.Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
                oreader.Close();
                return msg;
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }

        private void btnIniciarAplicacion_Click(object sender, EventArgs e)
        {
            
            try
            {
                

                if (validacontroles())
                {
                    
                    string test = genericas.generales.connexiontest(this.txtservidor.Text.Trim(), this.txtinstancia.Text.Trim(), this.txtusername.Text.Trim(), this.txtpassword.Text.Trim(), this.cmbtipodeinstalacion.Text.Trim());

                    if (test == "")
                    {
                       

                        string[] contenido = new string[9];

                        contenido[0] = this.txtserialkey.Text.Trim();
                        contenido[1] = this.cmbtipodeinstalacion.Text.Trim();
                        contenido[2] = this.txtservidor.Text.Trim();
                        contenido[3] = this.txtinstancia.Text.Trim();
                        contenido[4] = this.txtusername.Text.Trim();
                        contenido[5] = genericas.generales.encriptar(this.txtpassword.Text.Trim());

                        string hashinfo = this.chkmultiempresa.Checked.ToString().Trim() + "|" + this.cmbdistribucion.Text.Trim() + "|" + this.txtversioninstalador.Text.Trim() + "|" + this.txtnumversion.Text.Trim() + "|" + this.txtfechaliberacion.Text.Trim() + "|" +
                            genericas.generales.getvolumeserialnumber() + "|" + genericas.generales.getmachinename() + "|" + DateTime.Now.ToString("s");
                        string hashinfoencriptado = genericas.generales.encriptar(hashinfo);
                        contenido[6] = hashinfoencriptado;

                        string licinfo = this._eapp +"|"+ this.txtserialkey.Text.Trim() + "|" + this.cmbtipodeinstalacion.Text.Trim() + "|" + hashinfoencriptado;
                        string licencriptado = genericas.generales.encriptar(licinfo);
                        contenido[7] = licencriptado;
                        
                        string cnninfo = this.cmbtipodeinstalacion.Text.Trim() + "|" + this.txtservidor.Text.Trim() + "|" + this.txtinstancia.Text.Trim() + "|" + this.txtusername.Text.Trim() + "|" + genericas.generales.encriptar(this.txtpassword.Text.Trim());
                        string cnninfoencriptado = genericas.generales.encriptar(cnninfo);
                        contenido[8] = cnninfoencriptado;
                        
                            
                        System.IO.File.WriteAllLines(_pathconfigini, contenido);

                        //AQUI SE AGREGA METODO PARA CREAR BASE DE DATOS "default" en dado caso de no existir.                

                        string namedb = "default";
                        string querycreatedb = @"CREATE DATABASE " + namedb;
                        int id = genericas.generales.executeNonQuery(querycreatedb, this._connexionstringMaster);
                        string msgcreate = generatedatabase(namedb);


                        this.update = true;
                        this.Close();
                    }
                    else
                    {
                        if (MessageBox.Show("Es necesario una conexión a SQL Server para poder concluir con la instalación: " + Environment.NewLine + Environment.NewLine + test + Environment.NewLine + Environment.NewLine +
                            "Descargue e instale el paquete desde el link https://www.microsoft.com/es-mx/download/details.aspx?id=56042. ¿Desea ingresar a la descarga ahora?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start("https://www.microsoft.com/es-mx/download/details.aspx?id=56042");
                        }

                    }
                    
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string generatedatabase(string databasename)
        {
            try
            {
                string connexionstringDatabase = genericas.generales.getconnexionstring(this._tipoinstalacion, this._servidor, this._instancia, this._username, this._password, databasename);
                OleDbCommand oCmd = new OleDbCommand();
                string msgresult = "";
                string connexionstring = "Provider=SQLOLEDB;" + connexionstringDatabase;
                OleDbConnection oConn = new OleDbConnection(connexionstring);
                oConn.Open();
                oCmd.Connection = oConn;
                if (File.Exists(Application.StartupPath + "\\scripts\\default.sql"))
                {
                    msgresult = executescript(Application.StartupPath + "\\scripts\\default.sql", oCmd, oConn, databasename);
                }

                oConn.Close();
                return msgresult;

            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.update = false;
                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private bool validacontroles()
        {
            try
            {
                bool valid = true;

                err.Clear();
                if (string.IsNullOrEmpty(this.txtservidor.Text))
                {
                    this.err.SetError(this.txtservidor, "Se requiere un 'servidor' para establecer una conexión");
                    valid = false;
                }

                if (string.IsNullOrEmpty(this.txtinstancia.Text))
                {
                    this.err.SetError(this.txtinstancia, "Se requiere una 'instancia' para establecer una conexión");
                    valid = false;
                }


                if (this.cmbtipodeinstalacion.Text.Trim() != genericas.enums.etipoinstalacion.monousuario.ToString())
                {
                    if (string.IsNullOrEmpty(this.txtusername.Text))
                    {
                        this.err.SetError(this.txtusername, "Se requiere un 'username' para establecer una conexión");
                        valid = false;
                    }
                    if (string.IsNullOrEmpty(this.txtpassword.Text))
                    {
                        this.err.SetError(this.txtpassword, "Se requiere un 'password' para establecer una conexión");
                        valid = false;
                    }
                }

                return valid;
            }
            catch
            {
                return false;
            }
        }
    }
}
