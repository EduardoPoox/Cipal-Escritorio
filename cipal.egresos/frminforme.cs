using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cipal.catalogos;
using cipal.entidades;
using cipal.negocios;

namespace cipal.egresos
{
    public partial class frminforme : Form
    {
        private string _connexionstring;
        private int _idusuario;
        public int _id;
        private int _idconfig;
        private int _iddocumentodigital;
        public bool _update = false;

        private List<detinformes> odetinformes = new List<detinformes>();
        seriesfoliacion oseriesfoliacion = null;

        public frminforme(int id, int idusuario, string connexionstring)
        {
            try
            {
                InitializeComponent();
                this._connexionstring = connexionstring;
                this._idusuario = idusuario;
                this._id = id;
                this._idconfig = 1;
                oseriesfoliacion = seriefoliacionnc.getseriefoliacionvigentebytiposerie(genericas.enums.etiposerie.informe.ToString(), this._connexionstring);

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frminforme_Load(object sender, EventArgs e)
        {
            try
            {
                cargainfo();
                cargadepartamento();
                cargaempleado();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargadepartamento()
        {
            try
            {
                List<departamentos> olistdepartamentos = departamentonc.getdepartamentos(this._connexionstring);
                this.cmbdepartamento.SetDataBinding(olistdepartamentos, null);
                this.cmbdepartamento.ValueMember = "iddepartamento";
                this.cmbdepartamento.DisplayMember = "nombre";
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void cargaempleado()
        {
            try
            {
                List<empleados> olistempleados = empleadonc.getempleados(this._connexionstring);
                foreach (empleados oempleado in olistempleados)
                {
                    oempleado.nombres = oempleado.nombres + " " + oempleado.apellidopaterno + " " + oempleado.apellidomaterno;
                }

                this.cmbempleado.SetDataBinding(olistempleados, null);
                this.cmbempleado.ValueMember = "idempleado";
                this.cmbempleado.DisplayMember = "nombres";
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void cargainfo()
        {
            try
            {
                if (this._id > 0)
                {
                    informes oinforme = informenc.getinforme(this._id, this._connexionstring);
                    //this.cmbidtipoinforme.Value = oapoyo.idtipoapoyo;
                    this.dtfecha.DateTime = (DateTime)oinforme.fecha;
                    this.cmbdepartamento.Value = oinforme.iddepartamento;
                    this.cmbempleado.Value = oinforme.idempleado;
                    this.txtfolio.Text = oinforme.folio;
                    this.txtcomentario.Text = oinforme.comentarios;
                    this._iddocumentodigital = Convert.ToInt32(oinforme.iddocumentodigital);

                    documentosdigitales odoc = documentodigitalnc.getgetdocumentodigital(this._iddocumentodigital, this._connexionstring);
                    txtdoctodigital.Text = odoc.folio + " - " + odoc.uuid;

                }
                else
                {
                    txtfolio.Text = oseriesfoliacion.serie.ToUpper() + (oseriesfoliacion.actual + 1).ToString().PadLeft(4, '0');
                    this._iddocumentodigital = 0;
                }

                this.cargadetalle();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            try
            {
                frminformedetalle ofrmdetinforme = new frminformedetalle(this._id, 0, this._idusuario, this._connexionstring);
                ofrmdetinforme.ShowDialog();
                if (ofrmdetinforme._update)
                {
                    this.odetinformes.Add(ofrmdetinforme._odetinforme);
                    cargadetalle();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargadetalle()
        {
            try
            {
                if(this._id > 0)
                {
                    List<detinformes> otmp = detinformenc.getdetinformesporid(this._id, this._connexionstring);
                    if (odetinformes.Count == 0)
                    {
                        odetinformes.AddRange(otmp);
                    }
                }

                DataTable dtdetinformes = genericas.helpers.ToDataTable(odetinformes);
                dtdetinformes.Columns.Add(new DataColumn("nombreunidad", typeof(string)));

                foreach (DataRow orow in dtdetinformes.Rows)
                {
                    //int idconcepto = Convert.ToInt32(orow["idconcepto"]);
                    int idunidad = Convert.ToInt32(orow["idunidad"]);

                    //conceptos oconcepto = conceptonc.getconcepto(idconcepto, this._connexionstring);
                    unidades ounidad = unidadnc.getunidad(idunidad, this._connexionstring);

                    //orow["nombreconcepto"] = oconcepto.nombre;
                    orow["nombreunidad"] = ounidad.nombre;
                }
                dtdetinformes.AcceptChanges();
                
                this.grddetinformes.SetDataBinding(dtdetinformes, null);

                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grddetinformes.DisplayLayout.Bands[0].Columns)
                {
                    oColumn.Hidden = true;
                }
                //this.grddetinformes.DisplayLayout.Bands[0].Columns["idinforme"].Hidden = false;
                //this.grddetinformes.DisplayLayout.Bands[0].Columns["idconcepto"].Hidden = false;
                this.grddetinformes.DisplayLayout.Bands[0].Columns["nombreunidad"].Hidden = false;
                this.grddetinformes.DisplayLayout.Bands[0].Columns["descripcion"].Hidden = false;
                this.grddetinformes.DisplayLayout.Bands[0].Columns["cantidad"].Hidden = false;
                this.grddetinformes.DisplayLayout.Bands[0].Columns["descripcion"].Hidden = false;

                //this.grddetinformes.DisplayLayout.Bands[0].Columns["idinforme"].Header.Caption = "Solicitud";
                //this.grddetinformes.DisplayLayout.Bands[0].Columns["idconcepto"].Header.Caption = "Concepto";
                this.grddetinformes.DisplayLayout.Bands[0].Columns["idunidad"].Header.Caption = "Unidad";
                this.grddetinformes.DisplayLayout.Bands[0].Columns["cantidad"].Header.Caption = "Cantidad";
                this.grddetinformes.DisplayLayout.Bands[0].Columns["descripcion"].Header.Caption = "Descripción";

                this.grddetinformes.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this._id > 0)
                {
                    informes oinforme = informenc.getinforme(this._id, this._connexionstring);
                    //oinforme.idtipoinforme = Convert.ToInt32(this.cmbidtipoapoyo.Value);
                    oinforme.folio = this.txtfolio.Text;
                    oinforme.fecha = Convert.ToDateTime(this.dtfecha.Value);
                    oinforme.idempleado = Convert.ToInt32(this.cmbempleado.Value);
                    oinforme.iddepartamento = Convert.ToInt32(this.cmbdepartamento.Value);
                    oinforme.comentarios = this.txtcomentario.Text;
                    informenc.update(oinforme, this._connexionstring);

                    List<detinformes> otmp = detinformenc.getdetinformesporid(oinforme.idinforme, this._connexionstring);
                    foreach (detinformes odet in otmp)
                    {
                        detinformenc.delete(odet, this._connexionstring);
                    }

                    foreach (detinformes odetinforme in this.odetinformes)
                    {
                        odetinforme.idinforme = oinforme.idinforme;
                        odetinforme.iddetinforme = detinformenc.getid(this._connexionstring);
                        detinformenc.save(odetinforme, this._connexionstring);
                    }
                }
                else
                {
                    oseriesfoliacion = seriefoliacionnc.getseriefoliacionvigentebytiposerie(genericas.enums.etiposerie.informe.ToString(), this._connexionstring);
                    oseriesfoliacion.actual = oseriesfoliacion.actual + 1;
                    seriefoliacionnc.update(oseriesfoliacion, this._connexionstring);
                    txtfolio.Text = oseriesfoliacion.serie.ToUpper() + (oseriesfoliacion.actual).ToString().PadLeft(4, '0');

                    informes oinforme = new informes();
                    oinforme.idinforme = informenc.getid(this._connexionstring);
                    //oinforme.idtipoinforme = Convert.ToInt32(this.cmbidtipoapoyo.Value);
                    oinforme.folio = this.txtfolio.Text;
                    oinforme.fecha = Convert.ToDateTime(this.dtfecha.Value);
                    oinforme.idempleado = Convert.ToInt32(this.cmbempleado.Value);
                    oinforme.iddepartamento = Convert.ToInt32(this.cmbdepartamento.Value);
                    oinforme.comentarios = this.txtcomentario.Text;
                    oinforme.usuario = this._idusuario.ToString();
                    oinforme.baja = false;
                    informenc.save(oinforme, this._connexionstring);
                    this._id = oinforme.idinforme; 

                    foreach (detinformes odetinforme in this.odetinformes)
                    {
                        odetinforme.idinforme = oinforme.idinforme;
                        odetinforme.iddetinforme = detinformenc.getid(this._connexionstring);
                        detinformenc.save(odetinforme, this._connexionstring);
                    }
                }
                this._update = true;
                this.Close();

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

        private void btnquitar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(this.grddetinformes.ActiveRow.Cells["iddetinforme"].Value);
                if (MessageBox.Show("¿Esta seguro de eliminar el registro", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.odetinformes.RemoveAt(this.grddetinformes.ActiveRow.Index);


                    this.cargadetalle();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gbgeneral_Click(object sender, EventArgs e)
        {

        }

        private void btnbuscardoctodigital_Click(object sender, EventArgs e)
        {
            try
            {
                frmbuscardocumentodigital ofrmdocumentodigitalconsulta = new frmbuscardocumentodigital(this._id, this._idconfig, this._idusuario, this._connexionstring);
                ofrmdocumentodigitalconsulta.ShowDialog();
                if (ofrmdocumentodigitalconsulta.ok)
                {
                    int iddocumentodigital = ofrmdocumentodigitalconsulta.iddocumentodigital;
                    documentosdigitales odoc = documentodigitalnc.getgetdocumentodigital(iddocumentodigital, this._connexionstring);

                    string seriefolio = odoc.serie + odoc.folio;

                    if (seriefolio.Trim() !="")
                    {
                        txtdoctodigital.Text = seriefolio + " - " + odoc.uuid;
                    }
                    else
                    {
                        txtdoctodigital.Text = odoc.uuid;
                    }

                   
                    this._iddocumentodigital = iddocumentodigital;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnagregardepartamento_Click(object sender, EventArgs e)
        {
            try
            {
                frmdepartamento ofrmdepartamento = new frmdepartamento(0, this._idusuario, this._connexionstring);
                ofrmdepartamento.ShowDialog();
                if (ofrmdepartamento._update)
                {
                    cargadepartamento();
                    this.cmbdepartamento.Value = ofrmdepartamento.iddepartamentonuevo;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnagregarempleado_Click(object sender, EventArgs e)
        {
            try
            {
                frmempleado ofrmempleado = new frmempleado(0, this._idusuario, this._connexionstring);
                ofrmempleado.ShowDialog();
                if (ofrmempleado._update)
                {
                    cargaempleado();
                    this.cmbempleado.Value = ofrmempleado.idempleadonuevo;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btncambiarfolio_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    frmcambiarseriedefoliacion ofrmcambiarseriefoliacion = new frmcambiarseriedefoliacion(this._id, this._idconfig, this._idusuario, genericas.enums.etiposerie.constancia.ToString(), this._connexionstring);
                    ofrmcambiarseriefoliacion.ShowDialog();
                    if (ofrmcambiarseriefoliacion.ok)
                    {
                        oseriesfoliacion = seriefoliacionnc.getseriefoliacion(ofrmcambiarseriefoliacion.idseriefoliacion, this._connexionstring);
                        txtfolio.Text = oseriesfoliacion.serie.ToUpper() + (oseriesfoliacion.actual + 1).ToString().PadLeft(4, '0');
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
