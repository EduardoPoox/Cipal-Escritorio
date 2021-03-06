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
    public partial class frmorden : Form
    {
        private string _connexionstring;
        private int _idusuario;
        public int _id;
        private int _idconfig;
        private int _iddocumentodigital;
        public bool _update = false;

        private List<detordenes> odetordenes = new List<detordenes>();
        seriesfoliacion oseriesfoliacion = null;

        public frmorden(int id, int idusuario, string connexionstring)
        {
            try
            {
                InitializeComponent();
                this._connexionstring = connexionstring;
                this._idusuario = idusuario;
                this._id = id;
                this._idconfig = 1;
                oseriesfoliacion = seriefoliacionnc.getseriefoliacionvigentebytiposerie(genericas.enums.etiposerie.orden.ToString(), this._connexionstring);

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmsolicitud_Load(object sender, EventArgs e)
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
                    ordenes oorden = ordennc.getorden(this._id, this._connexionstring);
                    //this.cmbidtiposolicitud.Value = oapoyo.idtipoapoyo;
                    this.dtfecha.DateTime = (DateTime)oorden.fecha;
                    this.cmbdepartamento.Value = oorden.iddepartamento;
                    this.cmbempleado.Value = oorden.idempleado;
                    this.txtfolio.Text = oorden.folio;
                    this.txtcomentario.Text = oorden.comentarios;
                    this._iddocumentodigital = Convert.ToInt32(oorden.iddocumentodigital);

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
                frmordendetalle ofrmdetorden = new frmordendetalle(this._id, 0, this._idusuario, this._connexionstring);
                ofrmdetorden.ShowDialog();
                if (ofrmdetorden._update)
                {
                    this.odetordenes.Add(ofrmdetorden._odetorden);
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
                    List<detordenes> otmp = detordennc.getdetordenesporid(this._id, this._connexionstring);
                    if (odetordenes.Count == 0)
                    {
                        odetordenes.AddRange(otmp);
                    }
                }

                DataTable dtdetordenes = genericas.helpers.ToDataTable(odetordenes);
                dtdetordenes.Columns.Add(new DataColumn("nombreunidad", typeof(string)));

                foreach (DataRow orow in dtdetordenes.Rows)
                {
                    //int idconcepto = Convert.ToInt32(orow["idconcepto"]);
                    int idunidad = Convert.ToInt32(orow["idunidad"]);

                    //conceptos oconcepto = conceptonc.getconcepto(idconcepto, this._connexionstring);
                    unidades ounidad = unidadnc.getunidad(idunidad, this._connexionstring);

                    //orow["nombreconcepto"] = oconcepto.nombre;
                    orow["nombreunidad"] = ounidad.nombre;
                }
                dtdetordenes.AcceptChanges();
                
                this.grddetordenes.SetDataBinding(dtdetordenes, null);

                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grddetordenes.DisplayLayout.Bands[0].Columns)
                {
                    oColumn.Hidden = true;
                }
                //this.grddetsolicitudes.DisplayLayout.Bands[0].Columns["idsolicitud"].Hidden = false;
                //this.grddetsolicitudes.DisplayLayout.Bands[0].Columns["idconcepto"].Hidden = false;
                this.grddetordenes.DisplayLayout.Bands[0].Columns["nombreunidad"].Hidden = false;
                this.grddetordenes.DisplayLayout.Bands[0].Columns["descripcion"].Hidden = false;
                this.grddetordenes.DisplayLayout.Bands[0].Columns["cantidad"].Hidden = false;
                //this.grddetordenes.DisplayLayout.Bands[0].Columns["descripcion"].Hidden = false;

                //this.grddetsolicitudes.DisplayLayout.Bands[0].Columns["idsolicitud"].Header.Caption = "Solicitud";
                //this.grddetsolicitudes.DisplayLayout.Bands[0].Columns["idconcepto"].Header.Caption = "Concepto";
                //this.grddetordenes.DisplayLayout.Bands[0].Columns["idunidad"].Header.Caption = "Unidad";
                this.grddetordenes.DisplayLayout.Bands[0].Columns["cantidad"].Header.Caption = "Cantidad";
                this.grddetordenes.DisplayLayout.Bands[0].Columns["descripcion"].Header.Caption = "Descripción";
                this.grddetordenes.DisplayLayout.Bands[0].Columns["nombreunidad"].Header.Caption = "Unidad de Medida";
                this.grddetordenes.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
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
                    ordenes oorden = ordennc.getorden(this._id, this._connexionstring);
                    //osolicitud.idtiposolicitud = Convert.ToInt32(this.cmbidtipoapoyo.Value);
                    oorden.folio = this.txtfolio.Text;
                    oorden.fecha = Convert.ToDateTime(this.dtfecha.Value);
                    oorden.idempleado = Convert.ToInt32(this.cmbempleado.Value);
                    oorden.iddepartamento = Convert.ToInt32(this.cmbdepartamento.Value);
                    oorden.comentarios = this.txtcomentario.Text;
                    ordennc.update(oorden, this._connexionstring);

                    List<detordenes> otmp = detordennc.getdetordenesporid(oorden.idorden, this._connexionstring);
                    foreach (detordenes odet in otmp)
                    {
                        detordennc.delete(odet, this._connexionstring);
                    }

                    foreach (detordenes odetorden in this.odetordenes)
                    {
                        odetorden.idorden = oorden.idorden;
                        odetorden.iddetorden = detsolicitudnc.getid(this._connexionstring);
                        detordennc.save(odetorden, this._connexionstring);
                    }
                }
                else
                {
                    oseriesfoliacion = seriefoliacionnc.getseriefoliacionvigentebytiposerie(genericas.enums.etiposerie.orden.ToString(), this._connexionstring);
                    oseriesfoliacion.actual = oseriesfoliacion.actual + 1;
                    seriefoliacionnc.update(oseriesfoliacion, this._connexionstring);
                    txtfolio.Text = oseriesfoliacion.serie.ToUpper() + (oseriesfoliacion.actual).ToString().PadLeft(4, '0');

                    ordenes oorden = new ordenes();
                    oorden.idorden = ordennc.getid(this._connexionstring);
                    //osolicitud.idtiposolicitud = Convert.ToInt32(this.cmbidtipoapoyo.Value);
                    oorden.folio = this.txtfolio.Text;
                    oorden.fecha = Convert.ToDateTime(this.dtfecha.Value);
                    oorden.idempleado = Convert.ToInt32(this.cmbempleado.Value);
                    oorden.iddepartamento = Convert.ToInt32(this.cmbdepartamento.Value);
                    oorden.comentarios = this.txtcomentario.Text;
                    oorden.usuario = this._idusuario.ToString();
                    oorden.baja = false;
                    ordennc.save(oorden, this._connexionstring);
                    this._id = oorden.idorden;

                    foreach (detordenes odetorden in this.odetordenes)
                    {
                        odetorden.idorden = odetorden.idorden;
                        odetorden.iddetorden = detsolicitudnc.getid(this._connexionstring);
                        detordennc.save(odetorden, this._connexionstring);
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
                int id = Convert.ToInt32(this.grddetordenes.ActiveRow.Cells["iddetorden"].Value);
                if (MessageBox.Show("¿Esta seguro de eliminar el registro", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.odetordenes.RemoveAt(this.grddetordenes.ActiveRow.Index);


                    this.cargadetalle();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                frmempleado ofrmempleado = new frmempleado(0, this._idusuario,this._connexionstring);
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
                //Para llamar a la ventana CAMBIAR SERIE FOLIO
                frmcambiarseriedefoliacion ofrmcambiarseriefoliacion = new frmcambiarseriedefoliacion(this._id, this._idconfig, this._idusuario, genericas.enums.etiposerie.orden.ToString(), this._connexionstring);
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

        private void gbgeneral_Click(object sender, EventArgs e)
        {

        }
    }
}
