using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace cipal.componentes.seguridad
{

    public partial class frmLogin : Form
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

        private string _conexionString="";
        public string username = "";
        public string password = "";
     
        public frmLogin(string token, string cnn)
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

            _conexionString = genericas.generales.getconnexionstring(_tipodeinstalacion,_servidor, _instancia, _username,_password,"default");
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {


            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                if (validacontroles())
                {
                    username = this.txtusername.Text.Trim();
                    password = this.txtpassword.Text.Trim();

                    string query = "select count(*) [cantidad] from dbo.usuarios where dbo.usuarios.baja=0 and lower(ltrim(rtrim(dbo.usuarios.username)))='" + username.ToLower() + "' and dbo.usuarios.password='" + password +"'";
                    DataSet DS = genericas.generales.executeDS(query, _conexionString);

                    if (DS.Tables[0].Rows.Count > 0)
                    {
                        int cantidad = Convert.ToInt32(DS.Tables[0].Rows[0][0]);
                        if (cantidad == 1)
                        {
                            this.Close();
                        }
                        else
                        {
                            username = "";
                            password = "";
                            if (cantidad > 1)
                            {
                                MessageBox.Show("¡Usuario no identificado!" + Environment.NewLine + "", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("¡Usuario y/ contraseña incorrectos!" + Environment.NewLine + "", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                           
                        }
                           
                    }
                    else
                    {
                        username = "";
                        password = "";
                        MessageBox.Show("¡Usuario no encontrado!", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
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


        private bool validacontroles()
        {
            try
            {
                bool valid = true;

                err.Clear();
                if (string.IsNullOrEmpty(this.txtusername.Text))
                {
                    this.err.SetError(this.txtusername, "Se requiere un 'username' para iniciar sesión");
                    valid = false;
                }

                if (string.IsNullOrEmpty(this.txtpassword.Text))
                {
                    this.err.SetError(this.txtpassword, "Se requiere un 'password' para iniciar sesión");
                    valid = false;
                }

                return valid;
            }
            catch
            {
                return false;
            }
        }



        private void txtusername_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.btnIniciarSesion_Click(null, null);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.btnIniciarSesion_Click(null, null);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
