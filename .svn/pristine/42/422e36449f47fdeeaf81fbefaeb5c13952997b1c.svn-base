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
    public partial class frmpuestos : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;

        public bool _update = false;
        public frmpuestos(int id, int idusuario, string connexionstring)
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
                consultar();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void consultar()
        {
            List<puestos> olistpuestos = puestonc.getpuestos(this._connexionstring);
            this.grdpuestos.SetDataBinding(olistpuestos, null);
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grdpuestos.DisplayLayout.Bands[0].Columns)
            {
                oColumn.Hidden = true;
            }
            this.grdpuestos.DisplayLayout.Bands[0].Columns["nombre"].Hidden = false;

            this.grdpuestos.DisplayLayout.Bands[0].Columns["nombre"].Header.Caption = "Puestos";

            this.grdpuestos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                puestos opuesto = new puestos();

                opuesto.idpuesto = puestonc.getid(this._connexionstring);
                opuesto.nombre = this.txtnombre.Text;
                opuesto.usuario = this._idusuario.ToString();
                opuesto.baja = false;

                puestonc.save(opuesto, this._connexionstring);

                this.txtnombre.Text = "";
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

        private void gbgeneral_Click(object sender, EventArgs e)
        {

        }

        private void gbgeneral_Click_1(object sender, EventArgs e)
        {

        }

        private void btnborrar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(this.grdpuestos.ActiveRow.Cells["idpuesto"].Value);
            if (MessageBox.Show("¿Esta seguro de borrar el registro", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                puestos opuestos = puestonc.getpuesto(id, this._connexionstring);
                opuestos.baja = true;
                puestonc.update(opuestos, this._connexionstring);

                consultar();
            }
        }
    }
}
