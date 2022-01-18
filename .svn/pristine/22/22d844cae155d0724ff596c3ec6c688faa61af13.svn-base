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
    public partial class frmvehiculos : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;
        public frmvehiculos(int id, int idusuario, string connexionstring)
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
                consultar();
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

                this.txtnombre.Text = "";
                this.txtplaca.Text = "";
                this.txtmodelo.Text = "";
                this.txtmarca.Text = "";
                this.txtrendimiento.Text = "";
                //this.Close();
                consultar();

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


        private void consultar()
        {
            try
            {
                List<vehiculos> olistvehiculos = vehiculonc.getvehiculos(this._connexionstring);
                this.grdvehiculos.SetDataBinding(olistvehiculos, null);
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grdvehiculos.DisplayLayout.Bands[0].Columns)
                {
                    oColumn.Hidden = true;
                }
             
                this.grdvehiculos.DisplayLayout.Bands[0].Columns["nombre"].Hidden = false;
                this.grdvehiculos.DisplayLayout.Bands[0].Columns["nombre"].Header.Caption = "Nombre";
                this.grdvehiculos.DisplayLayout.Bands[0].Columns["placa"].Hidden = false;
                this.grdvehiculos.DisplayLayout.Bands[0].Columns["placa"].Header.Caption = "Placa";
                this.grdvehiculos.DisplayLayout.Bands[0].Columns["modelo"].Hidden = false;
                this.grdvehiculos.DisplayLayout.Bands[0].Columns["modelo"].Header.Caption = "Modelo";
                this.grdvehiculos.DisplayLayout.Bands[0].Columns["marca"].Hidden = false;
                this.grdvehiculos.DisplayLayout.Bands[0].Columns["marca"].Header.Caption = "Marca";
                this.grdvehiculos.DisplayLayout.Bands[0].Columns["rendimiento"].Hidden = false;
                this.grdvehiculos.DisplayLayout.Bands[0].Columns["rendimiento"].Header.Caption = "Rendimiento";
                this.grdvehiculos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void btnborrar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(this.grdvehiculos.ActiveRow.Cells["idvehiculo"].Value);
                if (MessageBox.Show("¿Esta seguro de borrar el registro", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    vehiculos ovehiculo = vehiculonc.getvehiculo(id, this._connexionstring);
                    ovehiculo.baja = true;
                    vehiculonc.update(ovehiculo, this._connexionstring);

                    consultar();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
