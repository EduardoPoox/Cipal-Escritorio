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
    public partial class frmpuesto : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;

        public bool _update = false;

        public int idpuestonuevo;
        public frmpuesto(int id, int idusuario, string connexionstring)
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

        private void frmpuesto_Load(object sender, EventArgs e)
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
                    puestos opuesto = puestonc.getpuesto(this._id, this._connexionstring);
                    this.txtnombre.Text = opuesto.nombre;
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
                if (this._id > 0)
                {
                    puestos opuesto = puestonc.getpuesto(this._id, this._connexionstring);
                    opuesto.nombre = this.txtnombre.Text;
                    puestonc.update(opuesto, this._connexionstring);
                }
                else
                {
                    puestos opuesto = new puestos();
                    opuesto.idpuesto = puestonc.getid(this._connexionstring);
                    opuesto.nombre = this.txtnombre.Text;
                    opuesto.usuario = this._idusuario.ToString();
                    opuesto.baja = false;
                    puestonc.save(opuesto, this._connexionstring);

                    this.idpuestonuevo = opuesto.idpuesto;
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
