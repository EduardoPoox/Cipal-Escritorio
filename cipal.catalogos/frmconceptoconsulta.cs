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
    public partial class frmconceptoconsulta : Form
    {
        private string _connexionstring;
        private int _idusuario;
        public frmconceptoconsulta(int idusuario, string connexionstring)
        {
            InitializeComponent();
            this._idusuario = idusuario;
            this._connexionstring = connexionstring;
        }
        private void frmconceptoconsulta_Load(object sender, EventArgs e)
        {
            try
            {
                this.cmbtipoconcepto.SetDataBinding(Enum.GetNames(typeof(genericas.enums.etipoconcepto)), null);
                this.cmbtipoconcepto.SelectedIndex = 0;

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
                string tipoconcepto = this.cmbtipoconcepto.Text;
                string nombre = this.txtnombre.Text;

                List<conceptos> olistconceptos = conceptonc.getconceptosbyparams(tipoconcepto,nombre,this._connexionstring);

                DataTable dtconceptos = genericas.helpers.ToDataTable(olistconceptos);
                dtconceptos.Columns.Add(new DataColumn("unidadmedida", typeof(string)));
                foreach(DataRow orow in dtconceptos.Rows)
                {
                    int idunidad = Convert.ToInt32(orow["idunidad"]);
                    if (idunidad > 0)
                    {
                        unidades ounidad = unidadnc.getunidad(idunidad, this._connexionstring);
                        orow["unidadmedida"] = ounidad.cveunidad + "-"+ ounidad.nombre;
                    }
                    else
                    {
                        orow["unidadmedida"] = "";
                    }
                }
                dtconceptos.AcceptChanges();

                this.grdconceptos.SetDataBinding(dtconceptos, null);
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grdconceptos.DisplayLayout.Bands[0].Columns)
                {
                    oColumn.Hidden = true;
                }
                
                this.grdconceptos.DisplayLayout.Bands[0].Columns["grupo"].Hidden = false;
                this.grdconceptos.DisplayLayout.Bands[0].Columns["tipoconcepto"].Hidden = false;
                this.grdconceptos.DisplayLayout.Bands[0].Columns["nombre"].Hidden = false;
                this.grdconceptos.DisplayLayout.Bands[0].Columns["descripcion"].Hidden = false;
                this.grdconceptos.DisplayLayout.Bands[0].Columns["unidadmedida"].Hidden = false;
                this.grdconceptos.DisplayLayout.Bands[0].Columns["inventario"].Hidden = false;
                this.grdconceptos.DisplayLayout.Bands[0].Columns["cvesat"].Hidden = false;

                this.grdconceptos.DisplayLayout.Bands[0].Columns["grupo"].Header.Caption = "Grupo de Concepto";
                this.grdconceptos.DisplayLayout.Bands[0].Columns["tipoconcepto"].Header.Caption = "Tipo de Concepto";
                this.grdconceptos.DisplayLayout.Bands[0].Columns["nombre"].Header.Caption = "Nombre";
                this.grdconceptos.DisplayLayout.Bands[0].Columns["descripcion"].Header.Caption = "Descripción";
                this.grdconceptos.DisplayLayout.Bands[0].Columns["unidadmedida"].Header.Caption = "Unidad de Medida";
                this.grdconceptos.DisplayLayout.Bands[0].Columns["inventario"].Header.Caption = "Inventariable";
                this.grdconceptos.DisplayLayout.Bands[0].Columns["cvesat"].Header.Caption = "Clave del SAT";

                this.grdconceptos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
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
                frmconcepto ofrmconcepto = new frmconcepto(id, this._idusuario, this._connexionstring);
                ofrmconcepto.ShowDialog();
                if (ofrmconcepto._update)
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
                int id = Convert.ToInt32(this.grdconceptos.ActiveRow.Cells["idconcepto"].Value);
                if (MessageBox.Show("¿Esta seguro de borrar el registro", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conceptos oconcepto = conceptonc.getconcepto(id, this._connexionstring);
                    oconcepto.baja = true;
                    conceptonc.update(oconcepto, this._connexionstring);

                    consultar();
;                }
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
                int id = Convert.ToInt32(this.grdconceptos.ActiveRow.Cells["idconcepto"].Value);
                frmconcepto ofrmconcepto = new frmconcepto(id, this._idusuario, this._connexionstring);
                ofrmconcepto.ShowDialog();
                if (ofrmconcepto._update)
                {
                    consultar();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdconceptos_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
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
