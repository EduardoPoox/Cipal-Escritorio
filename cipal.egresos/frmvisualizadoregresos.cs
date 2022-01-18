using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cipal.egresos
{
    public partial class frmvisualizadoregresos : Form
    {
        private ReportDocument oReporteActual;
        public frmvisualizadoregresos(ReportDocument oReportDocument)
        {
            oReporteActual = oReportDocument;
            InitializeComponent();
        }

        private void frmvisualizadorcfdi_Load(object sender, EventArgs e)
        {
            crvReportViewer.ReportSource = oReporteActual;
        }

        private void frmVisualizador_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                oReporteActual.Dispose();
                oReporteActual.Close();
            }
            catch
            {
            }
        }
    }
}
