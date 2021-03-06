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
    public partial class frmapoyoconsulta : Form
    {
        private string _connexionstring;
        private int _id;
        private int _idconfig;
        private int _idusuario;

        string[] ejercicios = { "2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028" };

        public frmapoyoconsulta(int id, int idconfig,int idusuario, string connexionstring)
        {
            InitializeComponent();
            this._id = id;
            this._idconfig = idconfig;
            this._idusuario = idusuario;
            this._connexionstring = connexionstring;

            this.cmbejercicios.SetDataBinding(ejercicios, null);
            this.cmbejercicios.Text = DateTime.Now.Year.ToString();

            this.cmbperiodo.SetDataBinding(Enum.GetNames(typeof(genericas.enums.emeses)), null);
            this.cmbperiodo.Text = genericas.enums.emeses.enero.ToString();
        }

        private void frmapoyoconsulta_Load(object sender, EventArgs e)
        {
            try
            {
                cargartiposapoyos();

                consultar();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargartiposapoyos()
        {
            try
            {
                List<tipoapoyos> olisttiposapoyos = tipoapoyonc.gettipoapoyos(this._connexionstring);
                this.cmbtipoapoyo.SetDataBinding(olisttiposapoyos, null);
                this.cmbtipoapoyo.ValueMember = "idtipoapoyo";
                this.cmbtipoapoyo.DisplayMember = "nombre";
                this.cmbtipoapoyo.SelectedIndex = 0;
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
                string folio = this.txtfolio.Text;
                int idtipoapoyo = Convert.ToInt32(cmbtipoapoyo.Value);

                List<vapoyos> olistvapoyos = vapoyonc.getapoyosbyparams(folio, idtipoapoyo,this._connexionstring);
                this.grdapoyos.SetDataBinding(olistvapoyos, null);
                foreach(Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grdapoyos.DisplayLayout.Bands[0].Columns)
                {
                    oColumn.Hidden = true;
                }

                this.grdapoyos.DisplayLayout.Bands[0].Columns["folio"].Hidden = false;
                this.grdapoyos.DisplayLayout.Bands[0].Columns["tipoapoyo"].Hidden = false;
                this.grdapoyos.DisplayLayout.Bands[0].Columns["nombrecompleto"].Hidden = false;
                this.grdapoyos.DisplayLayout.Bands[0].Columns["domicilio"].Hidden = false;
                this.grdapoyos.DisplayLayout.Bands[0].Columns["fechasolicitud"].Hidden = false;
                this.grdapoyos.DisplayLayout.Bands[0].Columns["fechaentrega"].Hidden = false;
                this.grdapoyos.DisplayLayout.Bands[0].Columns["comentarios"].Hidden = false;
                //this.grdapoyos.DisplayLayout.Bands[0].Columns["estatus"].Hidden = false;

                this.grdapoyos.DisplayLayout.Bands[0].Columns["folio"].Header.Caption = "Folio";
                this.grdapoyos.DisplayLayout.Bands[0].Columns["tipoapoyo"].Header.Caption = "Tipo de apoyo";
                this.grdapoyos.DisplayLayout.Bands[0].Columns["nombrecompleto"].Header.Caption = "Beneficiario";
                this.grdapoyos.DisplayLayout.Bands[0].Columns["domicilio"].Header.Caption = "Domicilio";
                this.grdapoyos.DisplayLayout.Bands[0].Columns["fechasolicitud"].Header.Caption = "Fecha de Solicitud";
                this.grdapoyos.DisplayLayout.Bands[0].Columns["fechaentrega"].Header.Caption = "Fecha de Entrega";
                this.grdapoyos.DisplayLayout.Bands[0].Columns["comentarios"].Header.Caption = "Comentarios";
                //this.grdapoyos.DisplayLayout.Bands[0].Columns["estatus"].Header.Caption = "Estatus";

                this.grdapoyos.DisplayLayout.Bands[0].Columns["fechasolicitud"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                this.grdapoyos.DisplayLayout.Bands[0].Columns["fechaentrega"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                this.grdapoyos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
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
                frmapoyo ofrmapoyo = new frmapoyo(0, this._idusuario, this._connexionstring);
                ofrmapoyo.ShowDialog();
                if (ofrmapoyo._update)
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
                int id = Convert.ToInt32(this.grdapoyos.ActiveRow.Cells["idapoyo"].Value);
                if (MessageBox.Show("¿Esta seguro de borrar el registro", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    apoyos oapoyo = apoyonc.getapoyo(id, this._connexionstring);
                    oapoyo.baja = true;
                    apoyonc.update(oapoyo, this._connexionstring);

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
                int id = Convert.ToInt32(this.grdapoyos.ActiveRow.Cells["idapoyo"].Value);
                frmapoyo ofrmapoyo = new frmapoyo(id, this._idusuario, this._connexionstring);
                ofrmapoyo.ShowDialog();
                if (ofrmapoyo._update)
                {
                    consultar();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void grdapoyos_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
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

        private void btnexportar_Click(object sender, EventArgs e)
        {
            try
            {
                parametros oconfig = parametronc.getparametro(this._idconfig, this._connexionstring);
                string dirfile = oconfig.direxportaciones + @"\apoyos.xlsx";
                this.ugExcel.Export(grdapoyos, dirfile);
                System.Diagnostics.Process.Start(dirfile);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbperiodo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string periodo = this.cmbperiodo.Text.Trim();
                switch (this.cmbperiodo.Text.Trim())
                {
                    case "enero": periodo = "01"; break;
                    case "febrero": periodo = "02"; break;
                    case "marzo": periodo = "03"; break;
                    case "abril": periodo = "04"; break;
                    case "mayo": periodo = "05"; break;
                    case "junio": periodo = "06"; break;
                    case "julio": periodo = "07"; break;
                    case "agosto": periodo = "08"; break;
                    case "septiembre": periodo = "09"; break;
                    case "octubre": periodo = "10"; break;
                    case "noviembre": periodo = "11"; break;
                    case "diciembre": periodo = "12"; break;
                }
                DateTime fi = new DateTime(Convert.ToInt32(this.cmbejercicios.Text), Convert.ToInt32(periodo), 1);
                DateTime ff = fi.AddMonths(1).AddSeconds(-1);

                this.cmbfechainicial.Value = fi;
                this.cmbfechafinal.Value = ff;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
