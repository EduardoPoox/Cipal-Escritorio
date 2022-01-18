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

namespace cipal.gestion
{
    public partial class frminventarioconsulta : Form
    {
        private string _connexionstring;
        private int _idusuario;
        public frminventarioconsulta(int idusuario, string connexionstring)
        {
            InitializeComponent();
            this._idusuario = idusuario;
            this._connexionstring = connexionstring;
        }

        private void frminventarioconsulta_Load(object sender, EventArgs e)
        {
            try
            {
                cargarconceptos();
                consultar();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarconceptos()
        {
            try
            {
                List<conceptos> olistconceptos = conceptonc.getconceptos(this._connexionstring);

                DataTable DT = genericas.helpers.ToDataTable(olistconceptos);
                DataRow oRow = DT.NewRow();
                oRow["idconcepto"] = 0;
                oRow["nombre"] = "TODOS";
                oRow["usuario"] = this._idusuario.ToString();
                oRow["baja"] = (false).ToString();
                DT.Rows.Add(oRow);

                this.cmbidconcepto.SetDataBinding(DT, null);
                this.cmbidconcepto.ValueMember = "idconcepto";
                this.cmbidconcepto.DisplayMember = "nombre";
                this.cmbidconcepto.SelectedText = "TODOS";
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
                int idconcepto = Convert.ToInt32(cmbidconcepto.Value);

                List<vinventarios> olistinventarios = vinventarionc.getinventariosbyparams(idconcepto, this._connexionstring);
                this.grdinventarios.SetDataBinding(olistinventarios, null);
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grdinventarios.DisplayLayout.Bands[0].Columns)
                {
                    oColumn.Hidden = true;
                }

                this.grdinventarios.DisplayLayout.Bands[0].Columns["nombreconcepto"].Hidden = false;
                this.grdinventarios.DisplayLayout.Bands[0].Columns["existencia"].Hidden = false;
                this.grdinventarios.DisplayLayout.Bands[0].Columns["nombreunidad"].Hidden = false;

                this.grdinventarios.DisplayLayout.Bands[0].Columns["nombreconcepto"].Header.Caption = "Concepto";
                this.grdinventarios.DisplayLayout.Bands[0].Columns["existencia"].Header.Caption = "Existecia";
                this.grdinventarios.DisplayLayout.Bands[0].Columns["nombreunidad"].Header.Caption = "Unidad";

                this.grdinventarios.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
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
                frminventario ofrminventario = new frminventario(id, this._idusuario, this._connexionstring);
                ofrminventario.ShowDialog();
                if (ofrminventario._update)
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
                int id = Convert.ToInt32(this.grdinventarios.ActiveRow.Cells["idinventario"].Value);
                if (MessageBox.Show("¿Esta seguro de borrar el registro", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    inventarios oinventario = inventarionc.getinventario(id, this._connexionstring);
                    oinventario.baja = true;
                    inventarionc.update(oinventario, this._connexionstring);

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
                int id = Convert.ToInt32(this.grdinventarios.ActiveRow.Cells["idinventario"].Value);
                frminventario ofrminventario = new frminventario(id, this._idusuario, this._connexionstring);
                ofrminventario.ShowDialog();
                if (ofrminventario._update)
                {
                    consultar();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdinventarios_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
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
