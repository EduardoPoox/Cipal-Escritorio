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
    public partial class frmbeneficiarioconsulta : Form
    {
        private string _connexionstring;
        private int _idusuario;
        public frmbeneficiarioconsulta(int idusuario, string connexionstring)
        {
            InitializeComponent();
            this._idusuario = idusuario;
            this._connexionstring = connexionstring;
        }

        private void frmbeneficiarioconsulta_Load(object sender, EventArgs e)
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

                List<beneficiarios> olistbeneficiarios = beneficiarionc.getbeneficiariosbyparams(rfc, nombre,this._connexionstring);
                this.grdbeneficiarios.SetDataBinding(olistbeneficiarios, null);
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grdbeneficiarios.DisplayLayout.Bands[0].Columns)
                {
                    oColumn.Hidden = true;
                }
                this.grdbeneficiarios.DisplayLayout.Bands[0].Columns["rfc"].Hidden = false;
                this.grdbeneficiarios.DisplayLayout.Bands[0].Columns["nombre"].Hidden = false;
                this.grdbeneficiarios.DisplayLayout.Bands[0].Columns["correo"].Hidden = false;
                this.grdbeneficiarios.DisplayLayout.Bands[0].Columns["telefono"].Hidden = false;
                this.grdbeneficiarios.DisplayLayout.Bands[0].Columns["contacto"].Hidden = false;
                this.grdbeneficiarios.DisplayLayout.Bands[0].Columns["movil"].Hidden = false;
                this.grdbeneficiarios.DisplayLayout.Bands[0].Columns["curp"].Hidden = false;
                this.grdbeneficiarios.DisplayLayout.Bands[0].Columns["ine"].Hidden = false;
                this.grdbeneficiarios.DisplayLayout.Bands[0].Columns["domicilio"].Hidden = false;

                this.grdbeneficiarios.DisplayLayout.Bands[0].Columns["rfc"].Header.Caption = "RFC";
                this.grdbeneficiarios.DisplayLayout.Bands[0].Columns["nombre"].Header.Caption = "Nombre Completo";
                this.grdbeneficiarios.DisplayLayout.Bands[0].Columns["correo"].Header.Caption = "Correo Electrónico";
                this.grdbeneficiarios.DisplayLayout.Bands[0].Columns["telefono"].Header.Caption = "Teléfono";
                this.grdbeneficiarios.DisplayLayout.Bands[0].Columns["contacto"].Header.Caption = "Contacto";
                this.grdbeneficiarios.DisplayLayout.Bands[0].Columns["movil"].Header.Caption = "Móvil";
                this.grdbeneficiarios.DisplayLayout.Bands[0].Columns["curp"].Header.Caption = "CURP";
                this.grdbeneficiarios.DisplayLayout.Bands[0].Columns["ine"].Header.Caption = "INE";
                this.grdbeneficiarios.DisplayLayout.Bands[0].Columns["domicilio"].Header.Caption = "Domicilio";

                this.grdbeneficiarios.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
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
                frmbeneficiario ofrmbeneficiario = new frmbeneficiario(id, this._idusuario, this._connexionstring);
                ofrmbeneficiario.ShowDialog();
                if (ofrmbeneficiario._update)
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
                int id = Convert.ToInt32(this.grdbeneficiarios.ActiveRow.Cells["idbeneficiario"].Value);
                if (MessageBox.Show("¿Esta seguro de borrar el registro", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    beneficiarios obeneficiarios = beneficiarionc.getbeneficiario(id, this._connexionstring);
                    obeneficiarios.baja = true;
                    beneficiarionc.update(obeneficiarios, this._connexionstring);

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
                int id = Convert.ToInt32(this.grdbeneficiarios.ActiveRow.Cells["idbeneficiario"].Value);
                frmbeneficiario ofrmbeneficiario = new frmbeneficiario(id, this._idusuario, this._connexionstring);
                ofrmbeneficiario.ShowDialog();
                if (ofrmbeneficiario._update)
                {
                    consultar();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void grdbeneficiarios_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
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

    }
}
