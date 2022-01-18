using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using cipal.entidades;
//using cipal.negocios;

namespace cipal.componentes
{
    public partial class frmempresa : Form
    {
        private string _connexionstringDefault;
        private string _connexionstringMaster;

        private string _tipoinstalacion;
        private string _servidor;
        private string _instancia;
        private string _username;
        private string _password;


        private string _eapp;
        private string _pfx;

        public bool update = false;

        private string dirbase = "";
        public frmempresa(string connexionstringDefault,string connexionstringMaster, string tipoinstalacion, string servidor,string instancia,string username,string password,string eapp,string pfx)
        {
            try
            {
                InitializeComponent();
                this._connexionstringDefault = connexionstringDefault;
                this._connexionstringMaster = connexionstringMaster;
                this._tipoinstalacion = tipoinstalacion;
                this._servidor = servidor;
                this._instancia = instancia;
                this._username = username;
                this._password = password;

                this._eapp = eapp;
                this._pfx = pfx;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmempresa_Load(object sender, EventArgs e)
        {
            try
            {
                cargainfo();
                generanombrebd();
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
                if (this._tipoinstalacion == genericas.enums.etipoinstalacion.monousuario.ToString())
                {
                    dirbase = @"C:\" + this._eapp + @"\";
                }
                else 
                {
                    dirbase = @"\\" + this._eapp + @"\";
                }

                this.txtdirbase.Text = dirbase;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                string namedb = this.txtbasededatos.Text.Trim();
                if (namedb.Length > 50) namedb.Substring(0, 50);

                if (!existdatabase(namedb))
                {

                    string querycreatedb = @"CREATE DATABASE " + namedb;
                    int id = genericas.generales.executeNonQuery(querycreatedb, this._connexionstringMaster);

                    if (id == -1)
                    {
                        //GENERAR ESTRUCTURA DE BASE DE DATOS
                        string msgcreate = generatedatabase(namedb);
                        //INSERTAR DATOS PREDETEMINADOS
                        if (msgcreate == "")
                        {
                            string connexionstringdatabase = genericas.generales.getconnexionstring(this._tipoinstalacion,this._servidor,this._instancia,this._username,this._password,namedb);
                            
                            string queryinsertempresa = "insert into dbo.empresa values("+1+",'" + this.txtrfc.Text.Trim() +"','"+this.txtnombre.Text.Trim()+"','','','','','','','','','','','','1.0.0.0','admin',getdate(),0)";
                            int idempresa = genericas.generales.executeNonQuery(queryinsertempresa, connexionstringdatabase);

                            string dirdefault = this.dirbase;
                            string dirbackup = this.dirbase;
                            string dirxml = this.dirbase + "xml";
                            string dirpdf = this.dirbase + "pdf";
                            string dirinformes = this.dirbase + "informes";
                            string dirrecursoscfdi = this.dirbase + "recursos";
                            string direxportaciones = this.dirbase + "exportaciones";

                            string dirtmp = this.dirbase + "tmp";
                            string dirpaquetes = this.dirbase + "paquetes";

                            string queryinsertparametros = "insert into dbo.parametros values("+1+",'" +dirdefault+"','"+dirbackup+"','"+ dirxml + "','"+dirpdf+"','"+ dirinformes + "','"+ dirrecursoscfdi + "','"+ direxportaciones + "','','','','','"+dirtmp+"','"+ dirpaquetes + "','','','','','','','','','',null,null,null,0,0,0,0,0,0,0,'admin',getdate(),0)";
                            int idparametro= genericas.generales.executeNonQuery(queryinsertparametros, connexionstringdatabase);

                            //INSERTA DATOS EN DEFAULT
                            string queryinsertdefault = "insert into dbo.empresas values(0,'"+this._pfx+"'," + 1 + ",'" + this.txtrfc.Text.Trim() + "','" + this.txtnombre.Text.Trim() +"','"+ dirdefault + "','"+namedb+"','1.0.0.0')";
                            int idbase = genericas.generales.executeNonQuery(queryinsertdefault, this._connexionstringDefault);










                            this.update = true;
                            this.Close();
                        }
                    }

                }
                else
                {
                    MessageBox.Show("La base de datos con nombre: "+Environment.NewLine+"'" + namedb.ToUpper() +"'"+ Environment.NewLine + " ya existe en el servidor y no se puede registrar. "+Environment.NewLine + Environment.NewLine+" Intente con un nuevo nombre cambiando el apartado 'Base de Datos'.", "Mensaje de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtbasededatos.Focus();
                }
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

        private void txtrfc_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                generanombrebd();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtnombre_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                generanombrebd();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void generanombrebd() 
        {
            try
            {
                string nombrebd = this._pfx + this.txtrfc.Text + "_" + this.txtnombre.Text.Replace(" ","_");
                this.txtbasededatos.Text = genericas.generales.cleantextcharacters(nombrebd);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }




        private bool existdatabase(string databasename)
        {
            try
            {
                bool existe = false;

                OleDbCommand ocmd = new OleDbCommand();
                string connexionstring = "Provider=SQLOLEDB;" + this._connexionstringMaster;
                OleDbConnection ocnn = new OleDbConnection(connexionstring);
                    
                ocnn.Open();
                ocmd.Connection = ocnn;
                string command = "select * from sys.databases where name = '" + @databasename + "'";
                ocmd.CommandText = command;
                System.Data.OleDb.OleDbDataReader oDataReader = ocmd.ExecuteReader();
                if (oDataReader.HasRows)
                    existe = true;
                else
                    existe = false;

                ocnn.Close();

                return existe;
            }
            catch (System.Exception ex)
            {
                throw ex;
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
                if (File.Exists(Application.StartupPath + "\\scripts\\cipal_v1000.sql"))
                {
                    msgresult = executescript(Application.StartupPath + "\\scripts\\cipal_v1000.sql", oCmd, oConn, databasename);
                }
                if (File.Exists(Application.StartupPath + "\\scripts\\cipal_v1000_config.sql"))
                {
                    msgresult = executescript(Application.StartupPath + "\\scripts\\cipal_v1000_config.sql", oCmd, oConn, databasename);
                }
                if (File.Exists(Application.StartupPath + "\\scripts\\cipal_v1000_csatfacturas.sql"))
                {
                    msgresult = executescript(Application.StartupPath + "\\scripts\\cipal_v1000_csatfacturas.sql", oCmd, oConn, databasename);
                }
                if (File.Exists(Application.StartupPath + "\\scripts\\cipal_v1000_csatnominas.sql"))
                {
                    msgresult = executescript(Application.StartupPath + "\\scripts\\cipal_v1000_csatnominas.sql", oCmd, oConn, databasename);
                }

                oConn.Close();
                return msgresult;
            }
            catch (System.Exception ex)
            {
                 return ex.Message;
            }
        }



    }
}
