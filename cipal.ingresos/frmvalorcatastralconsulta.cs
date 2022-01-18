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
    public partial class frmvalorcatastralconsulta : Form
    {
        private string _connexionstring;
        private int _idusuario;
        public frmvalorcatastralconsulta(int idusuario, string connexionstring)
        {
            InitializeComponent();
            this._idusuario = idusuario;
            this._connexionstring = connexionstring;
        }

        private void frmvalorcatastralconsulta_Load(object sender, EventArgs e)
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
            try
            {

                List<valorpredial> olistvalorpredial = valorpredialnc.getvalorprediales( this._connexionstring);
                this.grdcatastral.SetDataBinding(olistvalorpredial, null);
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grdcatastral.DisplayLayout.Bands[0].Columns)
                {
                    oColumn.Hidden = true;
                }

                this.grdcatastral.DisplayLayout.Bands[0].Columns["limiteinferior"].Hidden = false;
                this.grdcatastral.DisplayLayout.Bands[0].Columns["limitesuperior"].Hidden = false;
                this.grdcatastral.DisplayLayout.Bands[0].Columns["cuotafijaanual"].Hidden = false;
                this.grdcatastral.DisplayLayout.Bands[0].Columns["factorexcedentelimite"].Hidden = false;

                this.grdcatastral.DisplayLayout.Bands[0].Columns["limiteinferior"].Header.Caption = "Limite inferior";
                this.grdcatastral.DisplayLayout.Bands[0].Columns["limitesuperior"].Header.Caption = "Limite superior";
                this.grdcatastral.DisplayLayout.Bands[0].Columns["cuotafijaanual"].Header.Caption = "Cuota fija anual";
                this.grdcatastral.DisplayLayout.Bands[0].Columns["factorexcedentelimite"].Header.Caption = "Factor excedente limite";
            
                this.grdcatastral.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
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
                frmvalorcatastral ofrmvalorcatastral = new frmvalorcatastral(id, this._idusuario, this._connexionstring);
                ofrmvalorcatastral.ShowDialog();
                if (ofrmvalorcatastral._update)
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
                int id = Convert.ToInt32(this.grdcatastral.ActiveRow.Cells["idvalorcatastral"].Value);
                if (MessageBox.Show("¿Esta seguro de borrar el registro", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    valorpredial ovalorpredial = valorpredialnc.getvalorpredial(id, this._connexionstring);
                    //ovalorpredial.baja = true;
                    valorpredialnc.update(ovalorpredial, this._connexionstring);

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
                int id = Convert.ToInt32(this.grdcatastral.ActiveRow.Cells["idvalorcatastral"].Value);
                frmvalorcatastral ofrmvalorcatastral = new frmvalorcatastral(id, this._idusuario, this._connexionstring);
                ofrmvalorcatastral.ShowDialog();
                if (ofrmvalorcatastral._update)
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
