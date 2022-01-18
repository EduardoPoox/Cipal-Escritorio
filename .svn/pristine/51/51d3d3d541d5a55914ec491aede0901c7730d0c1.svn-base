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
    public partial class frmimpuestos : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;
        public frmimpuestos(int id, int idusuario, string connexionstring)
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

        private void consultar()
        {
            try
            {
                List<impuestos> olistimpuestos = impuestonc.getimpuestos(this._connexionstring);
                this.grdimpuestos.SetDataBinding(olistimpuestos, null);
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grdimpuestos.DisplayLayout.Bands[0].Columns)
                {
                    oColumn.Hidden = true;
                }
                this.grdimpuestos.DisplayLayout.Bands[0].Columns["tipoimpuesto"].Hidden = false;
                this.grdimpuestos.DisplayLayout.Bands[0].Columns["tipoimpuesto"].Header.Caption = "Tipo de Impuesto";
                this.grdimpuestos.DisplayLayout.Bands[0].Columns["nombre"].Hidden = false;
                this.grdimpuestos.DisplayLayout.Bands[0].Columns["nombre"].Header.Caption = "Nombre";
                this.grdimpuestos.DisplayLayout.Bands[0].Columns["cveimpuesto"].Hidden = false;
                this.grdimpuestos.DisplayLayout.Bands[0].Columns["cveimpuesto"].Header.Caption = "Clave del SAT";
                this.grdimpuestos.DisplayLayout.Bands[0].Columns["tasa"].Hidden = false;
                this.grdimpuestos.DisplayLayout.Bands[0].Columns["tasa"].Header.Caption = "Tasa";
                this.grdimpuestos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        private void frmimpuesto_Load(object sender, EventArgs e)
        {
            try
            {
                this.cmbtipodeimpuesto.SetDataBinding(Enum.GetNames(typeof(genericas.enums.etipodeimpuesto)), null);
                this.cmbtipodeimpuesto.SelectedIndex = 0;

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
                impuestos oimpuesto = new impuestos();

                oimpuesto.idimpuesto = impuestonc.getid(this._connexionstring);
                oimpuesto.tipoimpuesto = this.cmbtipodeimpuesto.Text;
                oimpuesto.cveimpuesto = this.txtcvimpuesto.Text;
                oimpuesto.nombre = this.txtnombre.Text;
                oimpuesto.tasa = Convert.ToDecimal(this.txttasa.Value);
                oimpuesto.usuario = this._idusuario.ToString();
                oimpuesto.baja = false;

                impuestonc.save(oimpuesto, this._connexionstring);

                this.cmbtipodeimpuesto.SelectedIndex = 0;
                this.txtcvimpuesto.Text = "";
                this.txtnombre.Text = "";
                this.txttasa.Value = 0;
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

        private void btnborrar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(this.grdimpuestos.ActiveRow.Cells["idimpuesto"].Value);
                if (MessageBox.Show("¿Esta seguro de borrar el registro", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    impuestos oimpuesto = impuestonc.getimpuesto(id, this._connexionstring);
                    oimpuesto.baja = true;
                    impuestonc.update(oimpuesto, this._connexionstring);

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
