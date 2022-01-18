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

namespace cipal.catalogos
{
    public partial class frmdepartamento : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;

        public bool _update = false;

        public int iddepartamentonuevo;
        public frmdepartamento(int id, int idusuario, string connexionstring)
        {
            try
            {
                InitializeComponent();
                this._connexionstring = connexionstring;
                this._idusuario = idusuario;
                this._id = id;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmdepartamentos_Load(object sender, EventArgs e)
        {
            try
            {
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
                    departamentos odepartamento = departamentonc.getdepartamento(this._id, this._connexionstring);
                    this.txtnombre.Text = odepartamento.nombre;
                }
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
                if(this._id > 0)
                {
                    departamentos odepartamento = departamentonc.getdepartamento(this._id, this._connexionstring);
                    odepartamento.nombre = this.txtnombre.Text;
                    departamentonc.update(odepartamento, this._connexionstring);
                }
                else
                {
                    departamentos odepartamento = new departamentos();
                    odepartamento.iddepartamento = departamentonc.getid(this._connexionstring);
                    odepartamento.nombre = this.txtnombre.Text;
                    odepartamento.usuario = this._idusuario.ToString();
                    odepartamento.baja = false;
                    departamentonc.save(odepartamento, this._connexionstring);

                    this.iddepartamentonuevo = odepartamento.iddepartamento;
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
    }
}
