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
    public partial class frmsolicitud : Form
    {
        private string _connexionstring;
        private int _idusuario;
        public int _id;
        private int _idconfig;
        private int _iddocumentodigital;
        //private int _idseriefoliacion;
        public bool _update = false;

        private List<detsolicitudes> odetsolicitudes = new List<detsolicitudes>();
        seriesfoliacion oseriesfoliacion = null;

        public frmsolicitud(int id, int idusuario, int idconfig, string connexionstring)
        {
            try
            {
                InitializeComponent();
                this._connexionstring = connexionstring;
                this._idusuario = idusuario;
                this._id = id;
                this._idconfig = idconfig;
                oseriesfoliacion = seriefoliacionnc.getseriefoliacionvigentebytiposerie(genericas.enums.etiposerie.solicitud.ToString(), this._connexionstring);

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
                    solicitudes osolicitud = solicitudnc.getsolicitud(this._id, this._connexionstring);
                    //this.cmbidtiposolicitud.Value = oapoyo.idtipoapoyo;
                    this.dtfecha.DateTime = (DateTime)osolicitud.fecha;
                    this.cmbdepartamento.Value = osolicitud.iddepartamento;
                    this.cmbempleado.Value = osolicitud.idempleado;
                    this.txtfolio.Text = osolicitud.folio;
                    this.txtcomentario.Text = osolicitud.comentarios;
                    this._iddocumentodigital = Convert.ToInt32(osolicitud.iddocumentodigital);
                    

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
                frmsolicituddetalle ofrmdetsolicitud = new frmsolicituddetalle(this._id, 0, this._idusuario, this._connexionstring);
                ofrmdetsolicitud.ShowDialog();
                if (ofrmdetsolicitud._update)
                {
                    this.odetsolicitudes.Add(ofrmdetsolicitud._odetsolicitud);
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
                    List<detsolicitudes> otmp = detsolicitudnc.getdetsolicitudesporid(this._id, this._connexionstring);
                    if (odetsolicitudes.Count == 0)
                    {
                        odetsolicitudes.AddRange(otmp);
                    }
                }

                DataTable dtdetsolicitudes = genericas.helpers.ToDataTable(odetsolicitudes);
                dtdetsolicitudes.Columns.Add(new DataColumn("nombreunidad", typeof(string)));

                foreach (DataRow orow in dtdetsolicitudes.Rows)
                {
                    //int idconcepto = Convert.ToInt32(orow["idconcepto"]);
                    int idunidad = Convert.ToInt32(orow["idunidad"]);

                    //conceptos oconcepto = conceptonc.getconcepto(idconcepto, this._connexionstring);
                    unidades ounidad = unidadnc.getunidad(idunidad, this._connexionstring);

                    //orow["nombreconcepto"] = oconcepto.nombre;
                    orow["nombreunidad"] = ounidad.nombre;
                }
                dtdetsolicitudes.AcceptChanges();
                
                this.grddetsolicitudes.SetDataBinding(dtdetsolicitudes, null);

                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grddetsolicitudes.DisplayLayout.Bands[0].Columns)
                {
                    oColumn.Hidden = true;
                }
                //this.grddetsolicitudes.DisplayLayout.Bands[0].Columns["idsolicitud"].Hidden = false;
                //this.grddetsolicitudes.DisplayLayout.Bands[0].Columns["idconcepto"].Hidden = false;
                this.grddetsolicitudes.DisplayLayout.Bands[0].Columns["nombreunidad"].Hidden = false;
                this.grddetsolicitudes.DisplayLayout.Bands[0].Columns["descripcion"].Hidden = false;
                this.grddetsolicitudes.DisplayLayout.Bands[0].Columns["cantidad"].Hidden = false;
                this.grddetsolicitudes.DisplayLayout.Bands[0].Columns["descripcion"].Hidden = false;

                //this.grddetsolicitudes.DisplayLayout.Bands[0].Columns["idsolicitud"].Header.Caption = "Solicitud";
                //this.grddetsolicitudes.DisplayLayout.Bands[0].Columns["idconcepto"].Header.Caption = "Concepto";
                this.grddetsolicitudes.DisplayLayout.Bands[0].Columns["idunidad"].Header.Caption = "Unidad";
                this.grddetsolicitudes.DisplayLayout.Bands[0].Columns["cantidad"].Header.Caption = "Cantidad";
                this.grddetsolicitudes.DisplayLayout.Bands[0].Columns["descripcion"].Header.Caption = "Descripción";
                this.grddetsolicitudes.DisplayLayout.Bands[0].Columns["nombreunidad"].Header.Caption = "Unidad de Medida";
                this.grddetsolicitudes.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
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
                    solicitudes osolicitud = solicitudnc.getsolicitud(this._id, this._connexionstring);
                    //osolicitud.idtiposolicitud = Convert.ToInt32(this.cmbidtipoapoyo.Value);
                    osolicitud.folio = this.txtfolio.Text;
                    osolicitud.fecha = Convert.ToDateTime(this.dtfecha.Value);
                    osolicitud.idempleado = Convert.ToInt32(this.cmbempleado.Value);
                    osolicitud.iddepartamento = Convert.ToInt32(this.cmbdepartamento.Value);
                    osolicitud.comentarios = this.txtcomentario.Text;
                    osolicitud.iddocumentodigital = this._iddocumentodigital;
                    solicitudnc.update(osolicitud, this._connexionstring);

                    List<detsolicitudes> otmp = detsolicitudnc.getdetsolicitudesporid(osolicitud.idsolicitud, this._connexionstring);
                    foreach (detsolicitudes odet in otmp)
                    {
                        detsolicitudnc.delete(odet, this._connexionstring);
                    }

                    foreach (detsolicitudes odetsolicitud in this.odetsolicitudes)
                    {
                        odetsolicitud.idsolicitud = osolicitud.idsolicitud;
                        odetsolicitud.iddetsolicitud = detsolicitudnc.getid(this._connexionstring);
                        detsolicitudnc.save(odetsolicitud, this._connexionstring);
                    }
                }
                else
                {
                    oseriesfoliacion = seriefoliacionnc.getseriefoliacionvigentebytiposerie(genericas.enums.etiposerie.solicitud.ToString(), this._connexionstring);
                    oseriesfoliacion.actual = oseriesfoliacion.actual + 1;
                    seriefoliacionnc.update(oseriesfoliacion, this._connexionstring);
                    txtfolio.Text = oseriesfoliacion.serie.ToUpper() + (oseriesfoliacion.actual).ToString().PadLeft(4, '0');
                    
                    solicitudes osolicitud = new solicitudes();
                    osolicitud.idsolicitud = solicitudnc.getid(this._connexionstring);
                    //osolicitud.idtiposolicitud = Convert.ToInt32(this.cmbidtipoapoyo.Value);
                    osolicitud.folio = this.txtfolio.Text;
                    osolicitud.fecha = Convert.ToDateTime(this.dtfecha.Value);
                    osolicitud.idempleado = Convert.ToInt32(this.cmbempleado.Value);
                    osolicitud.iddepartamento = Convert.ToInt32(this.cmbdepartamento.Value);
                    osolicitud.comentarios = this.txtcomentario.Text;
                    osolicitud.iddocumentodigital = this._iddocumentodigital;
                    osolicitud.usuario = this._idusuario.ToString();
                    osolicitud.baja = false;
                    solicitudnc.save(osolicitud, this._connexionstring);
                    this._id = osolicitud.idsolicitud;

                    foreach (detsolicitudes odetsolicitud in this.odetsolicitudes)
                    {
                        odetsolicitud.idsolicitud = osolicitud.idsolicitud;
                        odetsolicitud.iddetsolicitud = detsolicitudnc.getid(this._connexionstring);
                        detsolicitudnc.save(odetsolicitud, this._connexionstring);
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
                int id = Convert.ToInt32(this.grddetsolicitudes.ActiveRow.Cells["iddetsolicitud"].Value);
                if (MessageBox.Show("¿Esta seguro de eliminar el registro", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.odetsolicitudes.RemoveAt(this.grddetsolicitudes.ActiveRow.Index);


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
                frmcambiarseriedefoliacion ofrmcambiarseriefoliacion = new frmcambiarseriedefoliacion(this._id, this._idconfig, this._idusuario,genericas.enums.etiposerie.solicitud.ToString(), this._connexionstring);
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
    }
}
