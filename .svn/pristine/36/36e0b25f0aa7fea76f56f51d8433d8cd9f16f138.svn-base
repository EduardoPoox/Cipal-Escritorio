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
    public partial class frmconfdapempleadosconsulta : Form
    {
        private string _connexionstring;
        private int _idusuario;
        public frmconfdapempleadosconsulta(int idusuario, string connexionstring)
        {
            InitializeComponent();
            this._idusuario = idusuario;
            this._connexionstring = connexionstring;
        }

        private void frmconfdapempleadosconsulta_Load(object sender, EventArgs e)
        {
            try
            {
                cargardepartamentos();
                cargarpuestos();

                consultar();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargardepartamentos()
        {
            try
            {
                List<departamentos> olistdepartamentos = departamentonc.getdepartamentos(this._connexionstring);

                DataTable DT = genericas.helpers.ToDataTable(olistdepartamentos);
                DataRow oRow = DT.NewRow();
                oRow["iddepartamento"] = 0;
                oRow["nombre"] = "TODOS";
                oRow["usuario"] = this._idusuario.ToString();
                oRow["baja"] = (false).ToString();
                DT.Rows.Add(oRow);

                this.cmbiddepartamento.SetDataBinding(DT, null);
                this.cmbiddepartamento.ValueMember = "iddepartamento";
                this.cmbiddepartamento.DisplayMember = "nombre";
                this.cmbiddepartamento.SelectedText = "TODOS";
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            
        }

        private void cargarpuestos()
        {
            try
            {
                List<puestos> olistpuestos = puestonc.getpuestos(this._connexionstring);

                DataTable DT = genericas.helpers.ToDataTable(olistpuestos);
                DataRow oRow = DT.NewRow();
                oRow["idpuesto"] = 0;
                oRow["nombre"] = "TODOS";
                oRow["usuario"] = this._idusuario.ToString();
                oRow["baja"] = (false).ToString();
                DT.Rows.Add(oRow);

                this.cmbidpuesto.SetDataBinding(DT, null);
                this.cmbidpuesto.ValueMember = "idpuesto";
                this.cmbidpuesto.DisplayMember = "nombre";
                this.cmbidpuesto.SelectedText = "TODOS";
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
                int iddepartamento = Convert.ToInt32(cmbiddepartamento.Value);
                int idpuesto = Convert.ToInt32(cmbidpuesto.Value);

                List<vconfdapempleados> olistconfdapempleados = vconfdapempleadonc.getconfdaempleadosbyparams(iddepartamento, idpuesto,this._connexionstring);
                this.grdpuestosdeempleados.SetDataBinding(olistconfdapempleados, null);
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grdpuestosdeempleados.DisplayLayout.Bands[0].Columns)
                {
                    oColumn.Hidden = true;
                }

                this.grdpuestosdeempleados.DisplayLayout.Bands[0].Columns["nombrecompleto"].Hidden = false;
                this.grdpuestosdeempleados.DisplayLayout.Bands[0].Columns["nombredepartamento"].Hidden = false;
                this.grdpuestosdeempleados.DisplayLayout.Bands[0].Columns["nombrepuesto"].Hidden = false;
                this.grdpuestosdeempleados.DisplayLayout.Bands[0].Columns["estatus"].Hidden = false;
                this.grdpuestosdeempleados.DisplayLayout.Bands[0].Columns["observaciones"].Hidden = false;

                this.grdpuestosdeempleados.DisplayLayout.Bands[0].Columns["nombrecompleto"].Header.Caption = "Empleado";
                this.grdpuestosdeempleados.DisplayLayout.Bands[0].Columns["nombredepartamento"].Header.Caption = "Departamento";
                this.grdpuestosdeempleados.DisplayLayout.Bands[0].Columns["nombrepuesto"].Header.Caption = "Puesto";
                this.grdpuestosdeempleados.DisplayLayout.Bands[0].Columns["estatus"].Header.Caption = "Estatus";
                this.grdpuestosdeempleados.DisplayLayout.Bands[0].Columns["observaciones"].Header.Caption = "Observaciones";

                this.grdpuestosdeempleados.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
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
                frmconfdapempleado oconfdapempleado = new frmconfdapempleado(id, this._idusuario, this._connexionstring);
                oconfdapempleado.ShowDialog();
                if (oconfdapempleado._update)
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
                int id = Convert.ToInt32(this.grdpuestosdeempleados.ActiveRow.Cells["idconfdapempleado"].Value);
                if (MessageBox.Show("¿Esta seguro de borrar el registro", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    confdapempleados oconfdapempleado = confdapempleadonc.getconfdaempleado(id, this._connexionstring);
                    oconfdapempleado.baja = true;
                    confdapempleadonc.update(oconfdapempleado, this._connexionstring);

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
                int id = Convert.ToInt32(this.grdpuestosdeempleados.ActiveRow.Cells["idconfdapempleado"].Value);
                frmconfdapempleado ofrmconfdapempleado = new frmconfdapempleado(id, this._idusuario, this._connexionstring);
                ofrmconfdapempleado.ShowDialog();
                if (ofrmconfdapempleado._update)
                {
                    consultar();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdpuestosdeempleados_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
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
