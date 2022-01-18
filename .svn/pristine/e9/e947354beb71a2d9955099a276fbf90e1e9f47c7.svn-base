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
    public partial class frmproveedorconsulta : Form
    {
        private string _connexionstring;
        private int _idusuario;
        public frmproveedorconsulta(int idusuario, string connexionstring)
        {
            InitializeComponent();
            this._idusuario = idusuario;
            this._connexionstring = connexionstring;
        }

        private void frmproveedorconsulta_Load(object sender, EventArgs e)
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

                List<proveedores> olistproveedores = proveedornc.getproveedoresbyparams(rfc, nombre, this._connexionstring); 
                this.grdproveedores.SetDataBinding(olistproveedores, null);
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grdproveedores.DisplayLayout.Bands[0].Columns)
                {
                    oColumn.Hidden = true;
                }
                //this.grdproveedores.DisplayLayout.Bands[0].Columns["idproveedor"].Hidden = false;
                this.grdproveedores.DisplayLayout.Bands[0].Columns["rfc"].Hidden = false;
                this.grdproveedores.DisplayLayout.Bands[0].Columns["nombre"].Hidden = false;
                this.grdproveedores.DisplayLayout.Bands[0].Columns["correo"].Hidden = false;
                this.grdproveedores.DisplayLayout.Bands[0].Columns["telefono"].Hidden = false;
                this.grdproveedores.DisplayLayout.Bands[0].Columns["contacto"].Hidden = false;
                this.grdproveedores.DisplayLayout.Bands[0].Columns["movil"].Hidden = false;
                this.grdproveedores.DisplayLayout.Bands[0].Columns["domicilio"].Hidden = false;

                this.grdproveedores.DisplayLayout.Bands[0].Columns["rfc"].Header.Caption = "RFC";
                this.grdproveedores.DisplayLayout.Bands[0].Columns["nombre"].Header.Caption = "Nombre Completo";
                this.grdproveedores.DisplayLayout.Bands[0].Columns["correo"].Header.Caption = "Correo Electrónico";
                this.grdproveedores.DisplayLayout.Bands[0].Columns["telefono"].Header.Caption = "Teléfono";
                this.grdproveedores.DisplayLayout.Bands[0].Columns["contacto"].Header.Caption = "Contacto";
                this.grdproveedores.DisplayLayout.Bands[0].Columns["movil"].Header.Caption = "Móvil";
                this.grdproveedores.DisplayLayout.Bands[0].Columns["domicilio"].Header.Caption = "Domicilio";

                this.grdproveedores.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;


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
                frmproveedor ofrmproveedor = new frmproveedor(id, this._idusuario, this._connexionstring);
                ofrmproveedor.ShowDialog();
                if (ofrmproveedor._update)
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
                int id = Convert.ToInt32(this.grdproveedores.ActiveRow.Cells["idproveedor"].Value);
                if (MessageBox.Show("¿Esta seguro de borrar el registro", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    proveedores oproveedores = proveedornc.getproveedor(id, this._connexionstring);
                    oproveedores.baja = true;
                    proveedornc.update(oproveedores, this._connexionstring);

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
                int id = Convert.ToInt32(this.grdproveedores.ActiveRow.Cells["idproveedor"].Value);
                frmproveedor ofrmproveedor = new frmproveedor(id, this._idusuario, this._connexionstring);
                ofrmproveedor.ShowDialog();
                if (ofrmproveedor._update)
                {
                    consultar();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdproveedores_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
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
