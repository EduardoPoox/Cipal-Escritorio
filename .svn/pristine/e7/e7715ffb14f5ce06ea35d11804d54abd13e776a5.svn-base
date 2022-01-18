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
    public partial class frmunidades : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;

        public bool _update = false;
        public frmunidades(int id, int idusuario, string connexionstring)
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

        private void frmunidad_Load(object sender, EventArgs e)
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
                unidades ounidad = new unidades();

                ounidad.idunidad = unidadnc.getid(this._connexionstring);
                ounidad.nombre = this.txtnombre.Text;
                ounidad.cveunidad = this.txtcvunidad.Text;
                ounidad.simbologia = this.txtsimbologia.Text;
                ounidad.usuario = this._idusuario.ToString();
                ounidad.baja = false;

                unidadnc.save(ounidad, this._connexionstring);

                this.txtnombre.Text = "";
                this.txtcvunidad.Text = "";
                this.txtsimbologia.Text = "";
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
                List<unidades> olistunidades = unidadnc.getunidades(this._connexionstring);
                this.grdunidades.SetDataBinding(olistunidades, null);
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grdunidades.DisplayLayout.Bands[0].Columns)
                {
                    oColumn.Hidden = true;
                }
                this.grdunidades.DisplayLayout.Bands[0].Columns["nombre"].Hidden = false;
                this.grdunidades.DisplayLayout.Bands[0].Columns["nombre"].Header.Caption = "Unidad";
                this.grdunidades.DisplayLayout.Bands[0].Columns["cveunidad"].Hidden = false;
                this.grdunidades.DisplayLayout.Bands[0].Columns["cveunidad"].Header.Caption = "Clave del SAT";
                this.grdunidades.DisplayLayout.Bands[0].Columns["simbologia"].Hidden = false;
                this.grdunidades.DisplayLayout.Bands[0].Columns["simbologia"].Header.Caption = "Simbología";
                this.grdunidades.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;

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
                int id = Convert.ToInt32(this.grdunidades.ActiveRow.Cells["idunidad"].Value);
                if (MessageBox.Show("¿Esta seguro de borrar el registro", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    unidades ounidad = unidadnc.getunidad(id, this._connexionstring);
                    ounidad.baja = true;
                    unidadnc.update(ounidad, this._connexionstring);

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
