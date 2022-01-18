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
    
    public partial class frmcontribuyenteconsulta : Form
    {
        private string _connexionstring;
        private int _idusuario;
        public frmcontribuyenteconsulta(int idusuario, string connexionstring)
        {
            InitializeComponent();
            this._idusuario = idusuario;
            this._connexionstring = connexionstring;
        }

        private void frmcontribuyenteconsulta_Load(object sender, EventArgs e)
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
                string rfc = this.txtrfc.Text;
                string nombre = this.txtnombre.Text;

                List<contribuyentes> olistcontribuyentes = contribuyentenc.getcontribuyentesbyparams(rfc, nombre,this._connexionstring);
                this.grdcontribuyentes.SetDataBinding(olistcontribuyentes, null);
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grdcontribuyentes.DisplayLayout.Bands[0].Columns)
                {
                    oColumn.Hidden = true;
                }
                //this.grdcontribuyentes.DisplayLayout.Bands[0].Columns["idcontribuyente"].Hidden = false;
                this.grdcontribuyentes.DisplayLayout.Bands[0].Columns["rfc"].Hidden = false;
                this.grdcontribuyentes.DisplayLayout.Bands[0].Columns["nombre"].Hidden = false;
                this.grdcontribuyentes.DisplayLayout.Bands[0].Columns["correo"].Hidden = false;
                this.grdcontribuyentes.DisplayLayout.Bands[0].Columns["telefono"].Hidden = false;
                this.grdcontribuyentes.DisplayLayout.Bands[0].Columns["contacto"].Hidden = false;
                this.grdcontribuyentes.DisplayLayout.Bands[0].Columns["movil"].Hidden = false;
                this.grdcontribuyentes.DisplayLayout.Bands[0].Columns["domicilio"].Hidden = false;

                this.grdcontribuyentes.DisplayLayout.Bands[0].Columns["rfc"].Header.Caption = "RFC";
                this.grdcontribuyentes.DisplayLayout.Bands[0].Columns["nombre"].Header.Caption = "Nombre Completo";
                this.grdcontribuyentes.DisplayLayout.Bands[0].Columns["correo"].Header.Caption = "Correo Electrónico";
                this.grdcontribuyentes.DisplayLayout.Bands[0].Columns["telefono"].Header.Caption = "Teléfono";
                this.grdcontribuyentes.DisplayLayout.Bands[0].Columns["contacto"].Header.Caption = "Contacto";
                this.grdcontribuyentes.DisplayLayout.Bands[0].Columns["movil"].Header.Caption = "Móvil";
                this.grdcontribuyentes.DisplayLayout.Bands[0].Columns["domicilio"].Header.Caption = "Domicilio";

                this.grdcontribuyentes.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
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
                frmcontribuyente ofrmcontribuyente = new frmcontribuyente(id, this._idusuario, this._connexionstring);
                ofrmcontribuyente.ShowDialog();
                if (ofrmcontribuyente._update)
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
                int id = Convert.ToInt32(this.grdcontribuyentes.ActiveRow.Cells["idcontribuyente"].Value);
                if (MessageBox.Show("¿Esta seguro de borrar el registro", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    contribuyentes contribuyentes = contribuyentenc.getcontribuyentes(id, this._connexionstring);
                    contribuyentes.baja = true;
                    contribuyentenc.update(contribuyentes, this._connexionstring);

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
                int id = Convert.ToInt32(this.grdcontribuyentes.ActiveRow.Cells["idcontribuyente"].Value);
                frmcontribuyente ofrmcontribuyente = new frmcontribuyente(id, this._idusuario, this._connexionstring);
                ofrmcontribuyente.ShowDialog();
                if (ofrmcontribuyente._update)
                {
                    consultar();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdcontribuyentes_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            try
            {
                btneditar_Click(null, null);
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
