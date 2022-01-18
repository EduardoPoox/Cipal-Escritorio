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
    public partial class frmempleadoconsulta : Form
    {
        private string _connexionstring;
        private int _idusuario;
        public frmempleadoconsulta(int idusuario, string connexionstring)
        {
            InitializeComponent();
            this._idusuario = idusuario;
            this._connexionstring = connexionstring;
        }

        private void frmempleadoconsulta_Load(object sender, EventArgs e)
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

                List<empleados> olistempleados = empleadonc.getempleadosbyparams(rfc, nombre,this._connexionstring); //CAMBIAR A DETAPOYOSBYIDAPOYO
                this.grdempleados.SetDataBinding(olistempleados, null);
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grdempleados.DisplayLayout.Bands[0].Columns)
                {
                    oColumn.Hidden = true;
                }
                
                this.grdempleados.DisplayLayout.Bands[0].Columns["nombres"].Hidden = false;
                this.grdempleados.DisplayLayout.Bands[0].Columns["apellidopaterno"].Hidden = false;
                this.grdempleados.DisplayLayout.Bands[0].Columns["apellidomaterno"].Hidden = false;
                this.grdempleados.DisplayLayout.Bands[0].Columns["rfc"].Hidden = false;
                this.grdempleados.DisplayLayout.Bands[0].Columns["curp"].Hidden = false;
                this.grdempleados.DisplayLayout.Bands[0].Columns["correo"].Hidden = false;
                this.grdempleados.DisplayLayout.Bands[0].Columns["telefono"].Hidden = false;
                this.grdempleados.DisplayLayout.Bands[0].Columns["movil"].Hidden = false;


                this.grdempleados.DisplayLayout.Bands[0].Columns["nombres"].Header.Caption = "Nombres";
                this.grdempleados.DisplayLayout.Bands[0].Columns["apellidopaterno"].Header.Caption = "Apellido Paterno";
                this.grdempleados.DisplayLayout.Bands[0].Columns["apellidomaterno"].Header.Caption = "Apellido Materno";
                this.grdempleados.DisplayLayout.Bands[0].Columns["rfc"].Header.Caption = "RFC";
                this.grdempleados.DisplayLayout.Bands[0].Columns["curp"].Header.Caption = "CURP";
                this.grdempleados.DisplayLayout.Bands[0].Columns["correo"].Header.Caption = "Correo Electrónico";
                this.grdempleados.DisplayLayout.Bands[0].Columns["telefono"].Header.Caption = "Teléfono";
                this.grdempleados.DisplayLayout.Bands[0].Columns["movil"].Header.Caption = "Móvil";

                this.grdempleados.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
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
                frmempleado ofrmempleado = new frmempleado(id, this._idusuario, this._connexionstring);
                ofrmempleado.ShowDialog();
                if (ofrmempleado._update)
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
                int id = Convert.ToInt32(this.grdempleados.ActiveRow.Cells["idempleado"].Value);
                if (MessageBox.Show("¿Esta seguro de borrar el registro", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    empleados oempleado = empleadonc.getempleado(id, this._connexionstring);
                    oempleado.baja = true;
                    empleadonc.update(oempleado, this._connexionstring);

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
                int id = Convert.ToInt32(this.grdempleados.ActiveRow.Cells["idempleado"].Value);
                frmempleado ofrmempleado = new frmempleado(id, this._idusuario, this._connexionstring);
                ofrmempleado.ShowDialog();
                if (ofrmempleado._update)
                {
                    consultar();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void grdempleados_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
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
