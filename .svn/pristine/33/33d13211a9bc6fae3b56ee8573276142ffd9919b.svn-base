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
    public partial class frmtipoapoyo : Form
    {

        private string _connexionstring;
        private int _idusuario;
        private int _id;

        public bool _update = false;
        public frmtipoapoyo(int id, int idusuario, string connexionstring)
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

        private void frmtipoapoyo_Load(object sender, EventArgs e)
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

        private void consultar()
        {
            List<tipoapoyos> olisttipoapoyos = tipoapoyonc.gettipoapoyos(this._connexionstring);
            this.grdtipoapoyos.SetDataBinding(olisttipoapoyos, null);
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grdtipoapoyos.DisplayLayout.Bands[0].Columns)
            {
                oColumn.Hidden = true;
            }
            this.grdtipoapoyos.DisplayLayout.Bands[0].Columns["nombre"].Hidden = false;

            this.grdtipoapoyos.DisplayLayout.Bands[0].Columns["nombre"].Header.Caption = "Nombre";

            this.grdtipoapoyos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                tipoapoyos otipoapoyo = new tipoapoyos();

                otipoapoyo.idtipoapoyo = tipoapoyonc.getid(this._connexionstring);
                otipoapoyo.nombre = this.txtnombre.Text;
                otipoapoyo.usuario = this._idusuario.ToString();
                otipoapoyo.baja = false;

                tipoapoyonc.save(otipoapoyo, this._connexionstring);

                this.txtnombre.Text = "";
                //this._update = true;
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

        private void btnborrar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(this.grdtipoapoyos.ActiveRow.Cells["idtipoapoyo"].Value);
                if (MessageBox.Show("¿Esta seguro de borrar el registro", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    tipoapoyos otipoapoyos = tipoapoyonc.gettipoapoyo(id, this._connexionstring);
                    otipoapoyos.baja = true;
                    tipoapoyonc.update(otipoapoyos, this._connexionstring);
                     
                    consultar();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gbgeneral_Click(object sender, EventArgs e)
        {

        }
        
    }
}
