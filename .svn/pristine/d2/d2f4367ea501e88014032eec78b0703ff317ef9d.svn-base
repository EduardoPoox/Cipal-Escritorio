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
    public partial class frmvehiculo : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;

        public bool _update = false;
        public int idvehiculonuevo = 0;
        public frmvehiculo(int id, int idusuario, string connexionstring)
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

        private void frmvehiculo_Load(object sender, EventArgs e)
        {
            try
            {

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
                    vehiculos ovehiculo = vehiculonc.getvehiculo(this._id, this._connexionstring);
                    this.txtnombre.Text = ovehiculo.nombre;
                    this.txtmarca.Text = ovehiculo.marca;
                    this.txtmodelo.Text = ovehiculo.modelo;
                    this.txtplaca.Text = ovehiculo.placa;
                    this.txtrendimiento.Text = ovehiculo.rendimiento;
                }

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
                this.Close();
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
                if (this._id > 0)
                {
                    vehiculos ovehiculo = vehiculonc.getvehiculo(this._id, this._connexionstring);
                    ovehiculo.nombre = this.txtnombre.Text;
                    ovehiculo.placa = this.txtplaca.Text;
                    ovehiculo.modelo = this.txtmodelo.Text;
                    ovehiculo.marca = this.txtmarca.Text;
                    ovehiculo.rendimiento = this.txtrendimiento.Text;
                    ovehiculo.usuario = this._idusuario.ToString();
                    vehiculonc.update(ovehiculo, this._connexionstring);
                }
                else
                {
                    vehiculos ovehiculo = new vehiculos();
                    ovehiculo.idvehiculo = vehiculonc.getid(this._connexionstring);
                    ovehiculo.nombre = this.txtnombre.Text;
                    ovehiculo.placa = this.txtplaca.Text;
                    ovehiculo.modelo = this.txtmodelo.Text;
                    ovehiculo.marca = this.txtmarca.Text;
                    ovehiculo.rendimiento = this.txtrendimiento.Text;
                    ovehiculo.usuario = this._idusuario.ToString();
                    ovehiculo.baja = false;
                    vehiculonc.save(ovehiculo, this._connexionstring);
                    this.idvehiculonuevo = ovehiculo.idvehiculo;
                }

                this._update = true;
                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
