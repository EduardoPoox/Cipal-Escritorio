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
    public partial class frmcambiarseriedefoliacion : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;
        private int _idconfig;
        private string _tiposerie;

        public bool ok = false;
        public int idseriefoliacion = 0;
        public frmcambiarseriedefoliacion(int id, int idconfig, int idusuario, string tiposerie, string connexionstring)
        {
            InitializeComponent();
            this._idusuario = idusuario;
            this._connexionstring = connexionstring;
            this._id = id;
            this._idconfig = idconfig;
            this._tiposerie = tiposerie;
        }

        private void frmcambiarseriedefoliacion_Load(object sender, EventArgs e)
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
                //List<seriesfoliacion> olistseriesfoliacion = 
                //    seriefoliacionnc.getseriesfoliacion(this._connexionstring);
                List<seriesfoliacion> olistseriesfoliacion =
                    seriefoliacionnc.getseriesfoliacionbytiposerie(this._tiposerie, this._connexionstring);

                this.grdseriesfoliacion.SetDataBinding(olistseriesfoliacion, null);
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grdseriesfoliacion.DisplayLayout.Bands[0].Columns)
                {
                    oColumn.Hidden = true;
                }

                //this.grdseriesfoliacion.DisplayLayout.Bands[0].Columns["tiposerie"].Hidden = false;
                this.grdseriesfoliacion.DisplayLayout.Bands[0].Columns["serie"].Hidden = false;
                this.grdseriesfoliacion.DisplayLayout.Bands[0].Columns["inicial"].Hidden = false;
                this.grdseriesfoliacion.DisplayLayout.Bands[0].Columns["actual"].Hidden = false;
                //this.grdseriesfoliacion.DisplayLayout.Bands[0].Columns["vigente"].Hidden = false;

                //this.grdseriesfoliacion.DisplayLayout.Bands[0].Columns["tiposerie"].Header.Caption = "Tipo de serie";
                this.grdseriesfoliacion.DisplayLayout.Bands[0].Columns["serie"].Header.Caption = "Serie";
                this.grdseriesfoliacion.DisplayLayout.Bands[0].Columns["inicial"].Header.Caption = "Inicial";
                this.grdseriesfoliacion.DisplayLayout.Bands[0].Columns["actual"].Header.Caption = "Actual";
                //this.grdseriesfoliacion.DisplayLayout.Bands[0].Columns["vigente"].Header.Caption = "Vigente";

                this.grdseriesfoliacion.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void btnseleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdseriesfoliacion.ActiveRow != null)
                {
                    this.idseriefoliacion = Convert.ToInt32(grdseriesfoliacion.ActiveRow.Cells["idseriefoliacion"].Value);
                    this.ok = true;
                    this.Close();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
