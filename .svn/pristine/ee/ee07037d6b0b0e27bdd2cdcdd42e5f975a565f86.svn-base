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

namespace cipal.ingresos
{
    public partial class frmcobropredialconsulta : Form
    {
        private string _connexionstring;
        private int _idusuario;

        public frmcobropredialconsulta(int idusuario, string connexionstring)
        {
            InitializeComponent();
            this._idusuario = idusuario;
            this._connexionstring = connexionstring;
        }

        private void frmcobropredialconsulta_Load(object sender, EventArgs e)
        {
            try
            {
                cargarcontribuyentes();
                consultar();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarcontribuyentes()
        {
            try
            {
                List<contribuyentes> olistcontribuyentes = contribuyentenc.getcontribuyentes(this._connexionstring);
                this.cmbidcontribuyente.SetDataBinding(olistcontribuyentes, null);
                this.cmbidcontribuyente.ValueMember = "idtipoingreso";
                this.cmbidcontribuyente.DisplayMember = "nombre";
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void consultar()
        {
            try
            {

                List<cobropredial> olistcobropredial = cobropredialnc.getcobroprediales( this._connexionstring);
                this.grdcobropredial.SetDataBinding(olistcobropredial, null);
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grdcobropredial.DisplayLayout.Bands[0].Columns)
                {
                    oColumn.Hidden = true;
                }

                this.grdcobropredial.DisplayLayout.Bands[0].Columns["idcontribuyente"].Hidden = false;
                this.grdcobropredial.DisplayLayout.Bands[0].Columns["valorcatrastral"].Hidden = false;
                this.grdcobropredial.DisplayLayout.Bands[0].Columns["limiteinferior"].Hidden = false;
                this.grdcobropredial.DisplayLayout.Bands[0].Columns["factorexcedentelimite"].Hidden = false;
                this.grdcobropredial.DisplayLayout.Bands[0].Columns["cuotafija"].Hidden = false;
                this.grdcobropredial.DisplayLayout.Bands[0].Columns["total"].Hidden = false;
                

                this.grdcobropredial.DisplayLayout.Bands[0].Columns["idcontribuyente"].Header.Caption = "Contribuyente";
                this.grdcobropredial.DisplayLayout.Bands[0].Columns["valorcatrastral"].Header.Caption = "Valor catastral";
                this.grdcobropredial.DisplayLayout.Bands[0].Columns["limiteinferior"].Header.Caption = "Limite inferior";
                this.grdcobropredial.DisplayLayout.Bands[0].Columns["factorexcedentelimite"].Header.Caption = "Factor del excedente limite";
                this.grdcobropredial.DisplayLayout.Bands[0].Columns["cuotafija"].Header.Caption = "Cuota fija";
                this.grdcobropredial.DisplayLayout.Bands[0].Columns["total"].Header.Caption = "Total";

                this.grdcobropredial.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = 0; //REGISTRO NUEVO
                frmcobropredial ofrmcobropredial = new frmcobropredial(id, this._idusuario, this._connexionstring);
                ofrmcobropredial.ShowDialog();
                if (ofrmcobropredial._update)
                {
                    consultar();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnconsultar_Click(object sender, EventArgs e)
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

        private void btnborrar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(this.grdcobropredial.ActiveRow.Cells["idcobropredial"].Value);
                if (MessageBox.Show("¿Esta seguro de borrar el registro", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cobropredial ocobropredial = cobropredialnc.getcobropredial(id, this._connexionstring);
                    //ocobropredial.baja = true;
                    cobropredialnc.update(ocobropredial, this._connexionstring);

                    consultar();

                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(this.grdcobropredial.ActiveRow.Cells["idcobropredial"].Value);
                frmcobropredial ofrmcobropredial = new frmcobropredial(id, this._idusuario, this._connexionstring);
                ofrmcobropredial.ShowDialog();
                if (ofrmcobropredial._update)
                {
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
