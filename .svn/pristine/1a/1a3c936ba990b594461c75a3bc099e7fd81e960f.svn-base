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

namespace cipal.egresos
{
    public partial class frmpedidodetalleimpuesto : Form
    {
        private string _connexionstring;
        private int _index = -1;
        public DataTable _dtImpuestoDetalle = null;
        public Decimal _baseimpuesto = 0;

        public bool _changing = false;
        public bool _update = false;

        //private List<detpedidos> odetpedidos = new List<detpedidos>();
        public frmpedidodetalleimpuesto(DataTable dtImpuestos, Decimal baseimpuesto, string connexionstring)
        {
            try
            {
                InitializeComponent();
                this._connexionstring = connexionstring;
                this._dtImpuestoDetalle = dtImpuestos;
                this._baseimpuesto = baseimpuesto;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmorden_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "Select";
                query += " impuestos.idimpuesto,";
                query += " (impuestos.nombre +' '+ impuestos.tipoimpuesto +' '+  cast(impuestos.tasa as varchar(15))) as descripcion ";
                query += " From impuestos ";
                query += " where baja=0 ";
                DataTable dtImpuestos = genericas.generales.executeDS(query, this._connexionstring).Tables[0];

                cmbimpuesto.DataSource = dtImpuestos;
                cmbimpuesto.ValueMember = "idimpuesto";
                cmbimpuesto.DisplayMember = "descripcion";
                cmbimpuesto.SelectedIndex = -1;


                DataTable dttipoimpuesto = new DataTable("dttipoimpuesto");
                dttipoimpuesto.Columns.Add(new DataColumn("valor", typeof(string)));
                dttipoimpuesto.Columns.Add(new DataColumn("descripcion", typeof(string)));

                DataRow orow = dttipoimpuesto.NewRow();
                orow["valor"] = genericas.enums.etipodeimpuesto.trasladado.ToString();
                orow["descripcion"] = genericas.enums.etipodeimpuesto.trasladado.ToString();
                dttipoimpuesto.Rows.Add(orow);

                orow = dttipoimpuesto.NewRow();
                orow["valor"] = genericas.enums.etipodeimpuesto.retenido.ToString();
                orow["descripcion"] = genericas.enums.etipodeimpuesto.retenido.ToString();
                dttipoimpuesto.Rows.Add(orow);

                orow = dttipoimpuesto.NewRow();
                orow["valor"] = genericas.enums.etipodeimpuesto.trasladadolocal.ToString();
                orow["descripcion"] = genericas.enums.etipodeimpuesto.trasladadolocal.ToString();
                dttipoimpuesto.Rows.Add(orow);

                orow = dttipoimpuesto.NewRow();
                orow["valor"] = genericas.enums.etipodeimpuesto.retenidolocal.ToString();
                orow["descripcion"] = genericas.enums.etipodeimpuesto.retenidolocal.ToString();
                dttipoimpuesto.Rows.Add(orow);

                cmbtipoimpuesto.DataSource = dttipoimpuesto;
                cmbtipoimpuesto.ValueMember = "valor";
                cmbtipoimpuesto.DisplayMember = "descripcion";
                cmbtipoimpuesto.SelectedIndex = 0;

                cargainfo();

                cmbimpuesto.ValueChanged += cmbImpuesto_ValueChanged;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cargainfo()
        {
            try
            {
                this.cargardetalle();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
      
        private void cargardetalle()
        {
            try
            {

                this.grddetalleimpuestodetalle.SetDataBinding(_dtImpuestoDetalle, null);
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grddetalleimpuestodetalle.DisplayLayout.Bands[0].Columns)
                {
                    oColumn.Hidden = true;
                }

                this.grddetalleimpuestodetalle.DisplayLayout.Bands[0].Columns["tipoimpuesto"].Hidden = false;
                this.grddetalleimpuestodetalle.DisplayLayout.Bands[0].Columns["nombre"].Hidden = false;
                this.grddetalleimpuestodetalle.DisplayLayout.Bands[0].Columns["tasa"].Hidden = false;
                this.grddetalleimpuestodetalle.DisplayLayout.Bands[0].Columns["cveimpuesto"].Hidden = false;
                this.grddetalleimpuestodetalle.DisplayLayout.Bands[0].Columns["importe"].Hidden = false;

                this.grddetalleimpuestodetalle.DisplayLayout.Bands[0].Columns["tipoimpuesto"].Header.Caption = "Tipo Impuesto";
                this.grddetalleimpuestodetalle.DisplayLayout.Bands[0].Columns["nombre"].Header.Caption = "Nombre";
                this.grddetalleimpuestodetalle.DisplayLayout.Bands[0].Columns["tasa"].Header.Caption = "Tasa";
                this.grddetalleimpuestodetalle.DisplayLayout.Bands[0].Columns["cveimpuesto"].Header.Caption = "CveImpuesto";
                this.grddetalleimpuestodetalle.DisplayLayout.Bands[0].Columns["importe"].Header.Caption = "Importe";
                this.grddetalleimpuestodetalle.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
                if (_dtImpuestoDetalle.Rows.Count > 0)
                {
                    this.grddetalleimpuestodetalle.Rows[0].Selected = false;
                    this.grddetalleimpuestodetalle.ActiveRow = null;
                    this.grddetalleimpuestodetalle.Refresh();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void cmbImpuesto_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if(!_changing)
                {
                    int idimpuesto = Convert.ToInt32(cmbimpuesto.Value);

                    impuestos odoc = impuestonc.getimpuesto(idimpuesto, this._connexionstring);
                    cmbtipoimpuesto.Value = odoc.tipoimpuesto;
                    txtnombre.Text = odoc.nombre;
                    txttasa.Value = odoc.tasa;
                    txtclaveimpuesto.Text = odoc.cveimpuesto;
                    txtimporte.Value = System.Math.Round(_baseimpuesto * ((decimal)odoc.tasa/ (decimal)100), 6);
                    
                }
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
                if (this._index >= 0)
                {
                    _changing = true;
                    DataRow oRow = _dtImpuestoDetalle.Rows[this._index];
                    oRow["idimpuesto"] = Convert.ToInt32(cmbimpuesto.Value);
                    oRow["tipoimpuesto"] = Convert.ToString(cmbtipoimpuesto.Value);
                    oRow["nombre"] = txtnombre.Text;
                    oRow["tasa"] = Convert.ToDecimal(txttasa.Value);
                    oRow["cveimpuesto"] = Convert.ToString(txtclaveimpuesto.Text);
                    oRow["importe"] = Convert.ToDecimal(txtimporte.Value);
                    _dtImpuestoDetalle.AcceptChanges();
                    grddetalleimpuestodetalle.Update();
                    _changing = false;
                }
                else
                {
                    _changing = true;
                    DataRow oRow = _dtImpuestoDetalle.NewRow();
                    oRow["idimpuesto"] = Convert.ToInt32(cmbimpuesto.Value);
                    oRow["tipoimpuesto"] = Convert.ToString(cmbtipoimpuesto.Value);
                    oRow["nombre"] = txtnombre.Text;
                    oRow["tasa"] = Convert.ToDecimal(txttasa.Value);
                    oRow["cveimpuesto"] = Convert.ToString(txtclaveimpuesto.Text);
                    oRow["importe"] = Convert.ToDecimal(txtimporte.Value);
                    _dtImpuestoDetalle.Rows.Add(oRow);
                    grddetalleimpuestodetalle.Update();
                    _changing = false;
                }
                SetNuevo();
                if (_dtImpuestoDetalle.Rows.Count > 0)
                {
                    this.grddetalleimpuestodetalle.Rows[0].Selected = false;
                    this.grddetalleimpuestodetalle.ActiveRow = null;
                    this.grddetalleimpuestodetalle.Refresh();
                }
                grpeditar.Enabled = false;
            }
            catch (System.Exception ex)
            {
                _changing = false;
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            try
            {
                SetNuevo();
                grpeditar.Enabled = false;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnquitar_Click(object sender, EventArgs e)
        {
            
        }

        private void gbgeneral_Click(object sender, EventArgs e)
        {
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                SetNuevo();
                grpeditar.Enabled = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetNuevo()
        {
            _index = -1;
            cmbtipoimpuesto.SelectedIndex = 0;
            //cmbimpuesto.SelectedIndex = -1;
            txtnombre.Text = string.Empty;
            txttasa.Value = 0;
            txtclaveimpuesto.Text = string.Empty;
            txtimporte.Value = 0;
        }

        private void grddetalleimpuestodetalle_ClickCell(object sender, Infragistics.Win.UltraWinGrid.ClickCellEventArgs e)
        {
            try
            {
                if (grddetalleimpuestodetalle.ActiveRow != null)
                {
                    this._index = grddetalleimpuestodetalle.ActiveRow.Index;
                    DataRow oRow = _dtImpuestoDetalle.Rows[this._index];
                    cmbimpuesto.Value = Convert.ToInt32(oRow["idimpuesto"]);
                    cmbtipoimpuesto.Value = Convert.ToString(oRow["tipoimpuesto"]);
                    txtnombre.Text = Convert.ToString(oRow["nombre"]);
                    txttasa.Value = Convert.ToDecimal(oRow["tasa"]);
                    txtclaveimpuesto.Text = Convert.ToString(oRow["cveimpuesto"]);
                    txtimporte.Value = Convert.ToDecimal(oRow["importe"]);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this._index >= 0)
                {
                    grpeditar.Enabled = true;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                this._dtImpuestoDetalle.AcceptChanges();
                this._update = true;
                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (grddetalleimpuestodetalle.ActiveRow != null)
                {
                    this._dtImpuestoDetalle.Rows.RemoveAt(this.grddetalleimpuestodetalle.ActiveRow.Index);
                    this._dtImpuestoDetalle.AcceptChanges();
                    this.cargardetalle();
                    this.SetNuevo();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
