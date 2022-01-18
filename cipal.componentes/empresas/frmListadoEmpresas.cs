using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cipal.componentes.empresas
{
    public partial class frmListadoEmpresas : Form
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

        private string _conexionString;
        private string _eapp = "";
        private string _pfx = "";

        public string dbname = "";
        public frmListadoEmpresas(string token, string cnn)
        {
            InitializeComponent();
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


            _eapp = _tokendecript.Split('|')[0].ToString();

            _conexionString = genericas.generales.getconnexionstring(_tipodeinstalacion,  _servidor, _instancia, _username, _password, "default");

      
            switch (_eapp)
            {
                case "cipal":
                    _pfx = "cipal_";
                    break;
            }

        }

        private void frmListadoEmpresas_Load(object sender, EventArgs e)
        {
            try
            {
                cargarempresas();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cargarempresas()
        {
            try
            {

                string criterio = "";
                
                if (this.txtcriterio.Text.Trim() != "")
                {
                    criterio = this.txtcriterio.Text.Trim();
                }



                string query = "select prefix,rfc,nombre,dbname,version,dirbackup from dbo.empresas where dbo.empresas.prefix like '%" + _pfx+"%' and dbo.empresas.rfc like '%" + criterio + "%' and dbo.empresas.nombre like '%" + criterio + "%'";
                DataSet DS = genericas.generales.executeDS(query, _conexionString);

                gridempresas.SetDataBinding(DS, null);
                gridempresas.DisplayLayout.Bands[0].Columns["prefix"].Hidden = true;
                gridempresas.DisplayLayout.Bands[0].Columns["dirbackup"].Hidden = true;

                gridempresas.DisplayLayout.Bands[0].Columns["rfc"].Header.Caption = "RFC";
                gridempresas.DisplayLayout.Bands[0].Columns["nombre"].Header.Caption = "Nombre o Razón Social";
                gridempresas.DisplayLayout.Bands[0].Columns["dbname"].Header.Caption = "Base de Datos";
                gridempresas.DisplayLayout.Bands[0].Columns["version"].Header.Caption = "Versión";
                gridempresas.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;

            }
            catch(System.Exception ex)
            {
                throw ex;
            }
        }

        private void txtcriterio_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                cargarempresas();
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
                this.txtinfo.Text = gridempresas.ActiveRow.Cells["rfc"].Value.ToString() + "-" + gridempresas.ActiveRow.Cells["nombre"].Value.ToString();
                this.txtdirectoriorespaldos.Text = gridempresas.ActiveRow.Cells["dirbackup"].Value.ToString();
                this.txtarchivorespaldo.Text = gridempresas.ActiveRow.Cells["dbname"].Value.ToString() +"_"+ DateTime.Now.ToString("s").Replace("-","").Replace(":","") + ".back";
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }



        private void btncancelar_Click(object sender, EventArgs e)
        {
            try
            {
                dbname = "";
                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnverificarempresas_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT sys.databases.name FROM  sys.databases WHERE sys.databases.database_id > 4 and sys.databases.name like '%" + _pfx + "%'";
                DataSet DS = genericas.generales.executeDS(query, _conexionString);

                string queryDBDefault = "select prefix,rfc,nombre,dbname,version,dirbackup from dbo.empresas where dbo.empresas.prefix like '%" + _pfx + "%'"; 
                DataSet DSDBDefault = genericas.generales.executeDS(queryDBDefault, _conexionString);

                string msg = "";
                foreach (DataRow oRow in DS.Tables[0].Rows)
                {
                    string dbname = oRow["name"].ToString();
                    string cnnempresa = genericas.generales.getconnexionstring(_tipodeinstalacion,  _servidor, _instancia, _username, _password, dbname);
                    string queryempresa = "select TOP 1 rfc,idempresa,nombre,version, isnull((select TOP 1 dirbackup from dbo.parametros where dbo.parametros.baja=0),'') [dirbackup] from dbo.empresa where dbo.empresa.baja=0 order by dbo.empresa.idempresa desc";
                    DataSet DSEmpresa = genericas.generales.executeDS(queryempresa, cnnempresa);
                    if (DSEmpresa.Tables[0].Rows.Count > 0)
                    {
                        string rfcREV = DSEmpresa.Tables[0].Rows[0]["rfc"].ToString();
                        if (!existeRFC(rfcREV, DSDBDefault))
                        {
                            int idempresaREV = Convert.ToInt32(DSEmpresa.Tables[0].Rows[0]["idempresa"]);
                            string nombreREV = DSEmpresa.Tables[0].Rows[0]["nombre"].ToString();
                            string versionREV = DSEmpresa.Tables[0].Rows[0]["version"].ToString();
                            string dirbackupREV = DSEmpresa.Tables[0].Rows[0]["dirbackup"].ToString();
                            string queryInsert = "insert into dbo.empresas values (0,'" + _pfx + "'," + idempresaREV + ",'" + rfcREV + "','" + nombreREV + "','" + dirbackupREV + "','" + dbname + "','" + versionREV +"')";
                            int result = genericas.generales.executeNonQuery(queryInsert, _conexionString);
                            if (result > 0)
                            {
                                if (msg == "")
                                {
                                    msg = "Se han recuperado las siguientes empresas: " + Environment.NewLine + Environment.NewLine;
                                }
                                msg += rfcREV +"-" +nombreREV + "(" +versionREV +")" + Environment.NewLine;
                            }
                        }
                    }
                }

               
                if (msg == "")
                {
                    msg = "¡Proceso de verificación concluido con éxito!" + Environment.NewLine;
                }
                else
                {
                    msg += "¡Proceso de verificación concluido con éxito!" + Environment.NewLine;
                }

                MessageBox.Show(msg, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarempresas();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool existeRFC(string rfc, DataSet DSDBDefault)
        {
            try
            {
                bool existe = false;
                foreach(DataRow oRow in DSDBDefault.Tables[0].Rows)
                {
                    if (oRow["rfc"].ToString() == rfc)
                    {
                        existe = true;
                        break;
                    }
                }

                return existe;
            }
            catch
            {
                return true;
            }
        }

        private void btndirectoriorespaldos_Click(object sender, EventArgs e)
        {
            try
            {
                string dirbackup = this.txtdirectoriorespaldos.Text.Trim();
                if (System.IO.Directory.Exists(dirbackup))
                {
                    string windir = Environment.GetEnvironmentVariable("WINDIR");
                    System.Diagnostics.Process prc = new System.Diagnostics.Process();
                    prc.StartInfo.FileName = windir + @"\explorer.exe";
                    prc.StartInfo.Arguments = dirbackup;
                    prc.Start();
                }
                else
                {
                    string msg = "";
                    msg = "No se encontró el directorio de respaldos en el servidor. ¿Desea generar este directorio?";
                    if (MessageBox.Show(msg, "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        System.IO.Directory.CreateDirectory(dirbackup);

                        DirectoryInfo dirInfo = new DirectoryInfo(dirbackup);
                        DirectorySecurity dirSecurity = dirInfo.GetAccessControl();
                        dirSecurity.AddAccessRule(new FileSystemAccessRule(@"Todos", FileSystemRights.FullControl, AccessControlType.Allow));

                        string windir = Environment.GetEnvironmentVariable("WINDIR");
                        System.Diagnostics.Process prc = new System.Diagnostics.Process();
                        prc.StartInfo.FileName = windir + @"\explorer.exe";
                        prc.StartInfo.Arguments = dirbackup;
                        prc.Start();
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

 

        private void gridempresas_AfterRowActivate(object sender, EventArgs e)
        {
            try
            {
                if (gridempresas.ActiveRow != null)
                {
                    cargainfo();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnrespaldar_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridempresas.ActiveRow != null)
                {

                    string dbnameBACKUP = gridempresas.ActiveRow.Cells["dbname"].Value.ToString();

                    string dirbackup = this.txtdirectoriorespaldos.Text.Trim();
                    string filebackup = this.txtarchivorespaldo.Text.Trim();
                    if (filebackup != "")
                    {
                        if (MessageBox.Show("¿Está seguro de realizar la copia de seguridad " + filebackup + "?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string fileOUT = dirbackup + filebackup;

                            string cnnBACKUP = genericas.generales.getconnexionstring(_tipodeinstalacion,  _servidor, _instancia, _username, _password, "master");
                            string queryBACKUP = "BACKUP DATABASE [" + dbnameBACKUP + "] TO DISK = N'" + fileOUT + "' WITH NOFORMAT, NOINIT, NAME =N'" + dbnameBACKUP + "-Full Database Backup',SKIP, NOREWIND, NOUNLOAD,  STATS = 10";

                            int result = 0;
                            if (!System.IO.Directory.Exists(dirbackup))
                            {
                                System.IO.Directory.CreateDirectory(dirbackup);
                                DirectoryInfo dirInfo = new DirectoryInfo(dirbackup);
                                DirectorySecurity dirSecurity = dirInfo.GetAccessControl();
                                dirSecurity.AddAccessRule(new FileSystemAccessRule(@"Todos", FileSystemRights.FullControl, AccessControlType.Allow));
                                result = genericas.generales.executeNonQuery(queryBACKUP, cnnBACKUP);
                            }
                            else
                            {
                                result = genericas.generales.executeNonQuery(queryBACKUP, cnnBACKUP);
                            }
                            
                            if (result == -1)
                            {
                                MessageBox.Show("¡Copia de seguridad generada correctamente!", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cargainfo();
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



        private void gridempresas_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            try
            {
                this.btningresar_Click(null, null);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridempresas.ActiveRow != null)
                {
                    dbname = gridempresas.ActiveRow.Cells["dbname"].Value.ToString();
                    this.Close();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            try
            {
                string connexionstringDefault = genericas.generales.getconnexionstring(this._tipodeinstalacion, this._servidor,this._instancia, this._username, this._password, "default");
                string connexionstringMaster = genericas.generales.getconnexionstring(this._tipodeinstalacion, this._servidor,this._instancia, this._username, this._password, "master");

                frmempresa ofrmempresa = new frmempresa(connexionstringDefault, connexionstringMaster,this._tipodeinstalacion,this._servidor, this._instancia, this._username, this._password,this._eapp,this._pfx);
                ofrmempresa.ShowDialog();

                if (ofrmempresa.update)
                {
                    cargarempresas();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridempresas.ActiveRow != null)
                {
                    string empresa = gridempresas.ActiveRow.Cells["nombre"].Value.ToString();

                    if (MessageBox.Show("¿Esta seguro de borrar la base de datos de la empresa " + empresa + "?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {


                        string connexionstringMaster = genericas.generales.getconnexionstring(this._tipodeinstalacion, this._servidor, this._instancia, this._username, this._password, "master");
                        dbname = gridempresas.ActiveRow.Cells["dbname"].Value.ToString();


                        string queryprocess = "SELECT * FROM sys.dm_exec_sessions WHERE DB_NAME(database_id) ='" + dbname + "'";
                        DataSet DS = genericas.generales.executeDS(queryprocess, connexionstringMaster);
                        foreach(DataRow orow in DS.Tables[0].Rows)
                        {
                            genericas.generales.executeDS("KILL " + orow["session_id"].ToString(), connexionstringMaster);
                        }

                        string querydeletedatabase = "DROP DATABASE " + dbname;
                        genericas.generales.executeNonQuery(querydeletedatabase, connexionstringMaster);


                        string connexionstringDefault = genericas.generales.getconnexionstring(this._tipodeinstalacion, this._servidor, this._instancia, this._username, this._password, "default");
                        string querydeleteempresa = "delete from dbo.empresas where dbname='" + dbname + "'";
                        genericas.generales.executeNonQuery(querydeleteempresa, connexionstringDefault);

                        cargarempresas();
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
