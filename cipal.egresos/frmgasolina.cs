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
    public partial class frmgasolina : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;
        private int _idconfig;
        public int _iddocumentodigital=0;
        public bool _update = false;

        private List<detgasolinas> odetgasolinas = new List<detgasolinas>();

        seriesfoliacion oseriesfoliacion = null;

        public frmgasolina(int id, int idusuario, string connexionstring)
        {
            try
            {
                InitializeComponent();
                this._connexionstring = connexionstring;
                this._idusuario = idusuario;
                this._id = id;
                this._idconfig = 1;
                oseriesfoliacion = seriefoliacionnc.getseriefoliacionvigentebytiposerie(genericas.enums.etiposerie.gasolina.ToString(), this._connexionstring);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmgasolina_Load(object sender, EventArgs e)
        {
            try
            {
                cargainfo();
                cargadepartamentos();
                cargavehiculos();
                cargaempleados();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargadepartamentos()
        {
            try
            {
                List<departamentos> olistdepartamentos = departamentonc.getdepartamentos(this._connexionstring);
                this.cmbdepartamentos.SetDataBinding(olistdepartamentos, null);
                this.cmbdepartamentos.ValueMember = "iddepartamento";
                this.cmbdepartamentos.DisplayMember = "nombre";
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void cargavehiculos()
        {
            try
            {
                List<vehiculos> olistvehiculos = vehiculonc.getvehiculos(this._connexionstring);
                this.cmbvehiculos.SetDataBinding(olistvehiculos, null);
                this.cmbvehiculos.ValueMember = "idvehiculo";
                this.cmbvehiculos.DisplayMember = "nombre";
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        private void cargaempleados()
        {
            try
            {
                List<empleados> olistempleados = empleadonc.getempleados(this._connexionstring);

                foreach (empleados oempleado in olistempleados)
                {
                    oempleado.nombres = oempleado.nombres + " " + oempleado.apellidopaterno + " " + oempleado.apellidomaterno;
                }

                this.cmbempleados.SetDataBinding(olistempleados, null);
                this.cmbempleados.ValueMember = "idempleado";
                this.cmbempleados.DisplayMember = "nombres";
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
                    gasolinas ogasolina = gasolinanc.getgasolina(this._id, this._connexionstring);
                    this.dtfecha.DateTime = (DateTime)ogasolina.fecha;
                    this.cmbdepartamentos.Value = ogasolina.iddepartamento;
                    this.cmbvehiculos.Value = ogasolina.idvehiculo;
                    this.cmbempleados.Value = ogasolina.idempleado;
                    this.txtfolio.Text = ogasolina.folio;
                    this.txtcomentario.Text = ogasolina.comentarios;
                    this._iddocumentodigital = Convert.ToInt32(ogasolina.iddocumentodigital);

                    documentosdigitales odoc = documentodigitalnc.getgetdocumentodigital(this._iddocumentodigital, this._connexionstring);
                    string seriefolio = odoc.serie + odoc.folio;
                    if (seriefolio.Trim() != "")
                    {
                        txtdoctodigital.Text = seriefolio + " - " + odoc.uuid;
                    }
                    else
                    {
                        txtdoctodigital.Text = odoc.uuid;
                    }

                }
                else
                {
                    txtfolio.Text = oseriesfoliacion.serie.ToUpper() + (oseriesfoliacion.actual + 1).ToString().PadLeft(4, '0');
              

                    if (this._iddocumentodigital > 0)
                    {
                        documentosdigitales odoc = documentodigitalnc.getgetdocumentodigital(this._iddocumentodigital, this._connexionstring);
                        string seriefolio = odoc.serie + odoc.folio;
                        if (seriefolio.Trim() != "")
                        {
                            txtdoctodigital.Text = seriefolio + " - " + odoc.uuid;
                        }
                        else
                        {
                            txtdoctodigital.Text = odoc.uuid;
                        }

                        this.btnbuscardoctodigital.Enabled = false;
                        this.txtdoctodigital.Enabled = false;
                    }

                }

                this.cargardetalle();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch(System.Exception ex)
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
                    if (seriefolio.Trim() != "")
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
                    cargadepartamentos();
                    this.cmbdepartamentos.Value = ofrmdepartamento.iddepartamentonuevo;
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
                    cargaempleados();
                    this.cmbempleados.Value = ofrmempleado.idempleadonuevo;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnagregarvehiculo_Click(object sender, EventArgs e)
        {
            try
            {
                frmvehiculo ofrmvehiculo = new frmvehiculo(0, this._idusuario, this._connexionstring);
                ofrmvehiculo.ShowDialog();
                if (ofrmvehiculo._update)
                {
                    cargavehiculos();
                    this.cmbvehiculos.Value = ofrmvehiculo.idvehiculonuevo;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            try
            {
                int idgasolina = this._id;
                int iddetgasolina = 0;
                frmgasolinadetalle ofrmgasolinadetalle = new frmgasolinadetalle(idgasolina, iddetgasolina, this._idusuario, this._connexionstring);
                ofrmgasolinadetalle.ShowDialog();
                if (ofrmgasolinadetalle._update)
                {
                    this.odetgasolinas.Add(ofrmgasolinadetalle._odetgasolina);
                    cargardetalle();
                }
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
                int id = Convert.ToInt32(this.grddetgasolinas.ActiveRow.Cells["iddetgasolina"].Value);
                if (MessageBox.Show("¿Esta seguro de eliminar el registro", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.odetgasolinas.RemoveAt(this.grddetgasolinas.ActiveRow.Index);

                    this.cargardetalle();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void cargardetalle()
        {
            try
            {
                if (this._id > 0)
                {
                    List<detgasolinas> otmp = detgasolinanc.getdetgasolinasbyid(this._id, this._connexionstring);
                    if (odetgasolinas.Count == 0)
                    {
                        odetgasolinas.AddRange(otmp);
                    }
                }



                DataTable dtdetgasolinas = genericas.helpers.ToDataTable(odetgasolinas);

                this.grddetgasolinas.SetDataBinding(dtdetgasolinas, null);

                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grddetgasolinas.DisplayLayout.Bands[0].Columns)
                {
                    oColumn.Hidden = true;
                }
                this.grddetgasolinas.DisplayLayout.Bands[0].Columns["fecha"].Hidden = false;
                this.grddetgasolinas.DisplayLayout.Bands[0].Columns["kminicial"].Hidden = false;
                this.grddetgasolinas.DisplayLayout.Bands[0].Columns["kmfinal"].Hidden = false;
                this.grddetgasolinas.DisplayLayout.Bands[0].Columns["origen"].Hidden = false;
                this.grddetgasolinas.DisplayLayout.Bands[0].Columns["destino"].Hidden = false;
                this.grddetgasolinas.DisplayLayout.Bands[0].Columns["kmrecorridos"].Hidden = false;
                this.grddetgasolinas.DisplayLayout.Bands[0].Columns["litros"].Hidden = false;
                this.grddetgasolinas.DisplayLayout.Bands[0].Columns["pesos"].Hidden = false;
                this.grddetgasolinas.DisplayLayout.Bands[0].Columns["motivoviaje"].Hidden = false;

                this.grddetgasolinas.DisplayLayout.Bands[0].Columns["fecha"].Header.Caption = "Fecha";
                this.grddetgasolinas.DisplayLayout.Bands[0].Columns["kminicial"].Header.Caption = "KM Inicial";
                this.grddetgasolinas.DisplayLayout.Bands[0].Columns["kmfinal"].Header.Caption = "KM Final";
                this.grddetgasolinas.DisplayLayout.Bands[0].Columns["origen"].Header.Caption = "Origen";
                this.grddetgasolinas.DisplayLayout.Bands[0].Columns["destino"].Header.Caption = "Destino";
                this.grddetgasolinas.DisplayLayout.Bands[0].Columns["kmrecorridos"].Header.Caption = "KM Recorridos";
                this.grddetgasolinas.DisplayLayout.Bands[0].Columns["litros"].Header.Caption = "Litros";
                this.grddetgasolinas.DisplayLayout.Bands[0].Columns["pesos"].Header.Caption = "Pesos";
                this.grddetgasolinas.DisplayLayout.Bands[0].Columns["motivoviaje"].Header.Caption = "Motivo del Viaje";



                this.grddetgasolinas.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
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
                    gasolinas ogasolina = gasolinanc.getgasolina(this._id, this._connexionstring);
                    ogasolina.fecha = Convert.ToDateTime(this.dtfecha.Value);
                    ogasolina.folio = this.txtfolio.Text;
                    ogasolina.comentarios = this.txtcomentario.Text;
                    ogasolina.iddepartamento = Convert.ToInt32( this.cmbdepartamentos.Value);
                    ogasolina.idempleado = Convert.ToInt32(this.cmbempleados.Value);
                    ogasolina.idvehiculo = Convert.ToInt32(this.cmbvehiculos.Value);
                    ogasolina.iddocumentodigital = this._iddocumentodigital;
                    gasolinanc.update(ogasolina, this._connexionstring);

                    List<detgasolinas> otmp = detgasolinanc.getdetgasolinasbyid(ogasolina.idgasolina, this._connexionstring);
                    foreach (detgasolinas odet in otmp)
                    {
                        detgasolinanc.delete(odet, this._connexionstring);
                    }

                    foreach (detgasolinas odetgasolina in this.odetgasolinas)
                    {
                        odetgasolina.idgasolina = ogasolina.idgasolina;
                        odetgasolina.iddetgasolina = detgasolinanc.getid(this._connexionstring);
                        detgasolinanc.save(odetgasolina, this._connexionstring);
                    }
                }
                else
                {
                    gasolinas ogasolina = new gasolinas();
                    ogasolina.idgasolina = gasolinanc.getid(this._connexionstring);
                    ogasolina.fecha = Convert.ToDateTime(this.dtfecha.Value);
                    ogasolina.folio = this.txtfolio.Text;
                    ogasolina.comentarios = this.txtcomentario.Text;
                    ogasolina.iddepartamento = Convert.ToInt32(this.cmbdepartamentos.Value);
                    ogasolina.idempleado = Convert.ToInt32(this.cmbempleados.Value);
                    ogasolina.idvehiculo = Convert.ToInt32(this.cmbvehiculos.Value);

                    ogasolina.usuario = this._idusuario.ToString();
                    ogasolina.baja = false;
                    ogasolina.iddocumentodigital = this._iddocumentodigital;
                    gasolinanc.save(ogasolina, this._connexionstring);

                    foreach (detgasolinas odetgasolina in this.odetgasolinas)
                    {
                        odetgasolina.idgasolina = ogasolina.idgasolina;
                        odetgasolina.iddetgasolina = detgasolinanc.getid(this._connexionstring);
                        detgasolinanc.save(odetgasolina, this._connexionstring);
                    }


                    oseriesfoliacion.actual = (oseriesfoliacion.actual + 1);
                    seriefoliacionnc.update(oseriesfoliacion, this._connexionstring);
                }
                this._update = true;
                this.Close();

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
                frmcambiarseriedefoliacion ofrmcambiarseriefoliacion = new frmcambiarseriedefoliacion(this._id, this._idconfig, this._idusuario, genericas.enums.etiposerie.solicitud.ToString(), this._connexionstring);
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
