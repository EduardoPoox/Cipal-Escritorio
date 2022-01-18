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
    public partial class frmmantenimiento : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;
        private int _idconfig;
        public int _iddocumentodigital=0;
        public bool _update = false;

        private List<detmantenimientos> odetmantenimientos = new List<detmantenimientos>();

        seriesfoliacion oseriesfoliacion = null;
        public frmmantenimiento(int id, int idusuario, string connexionstring)
        {
            try
            {
                InitializeComponent();
                this._connexionstring = connexionstring;
                this._idusuario = idusuario;
                this._id = id;
                this._idconfig = 1;
                oseriesfoliacion = seriefoliacionnc.getseriefoliacionvigentebytiposerie(genericas.enums.etiposerie.mantenimiento.ToString(), this._connexionstring);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmmantenimiento_Load(object sender, EventArgs e)
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
                    mantenimientos omantenimiento = mantenimientonc.getmantenimiento(this._id, this._connexionstring);
                    this.dtfecha.DateTime = (DateTime)omantenimiento.fecha;
                    this.cmbdepartamentos.Value = omantenimiento.iddepartamento;
                    this.cmbvehiculos.Value = omantenimiento.idvehiculo;
                    this.cmbempleados.Value = omantenimiento.idempleado;
                    this.txtfolio.Text = omantenimiento.folio;
                    this.txtcomentario.Text = omantenimiento.comentarios;
                    this._iddocumentodigital = Convert.ToInt32(omantenimiento.iddocumentodigital);

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

        private void cargardetalle()
        {
            try
            {
                if (this._id > 0)
                {
                    List<detmantenimientos> otmp = detmantenimientonc.getdetmantenimientosbyid(this._id, this._connexionstring);
                    if (odetmantenimientos.Count == 0)
                    {
                        odetmantenimientos.AddRange(otmp);
                    }
                }

                DataTable dtdetmantenimientos = genericas.helpers.ToDataTable(odetmantenimientos);

                this.grddetmantenimientos.SetDataBinding(dtdetmantenimientos, null);

                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grddetmantenimientos.DisplayLayout.Bands[0].Columns)
                {
                    oColumn.Hidden = true;
                }

                this.grddetmantenimientos.DisplayLayout.Bands[0].Columns["cantidad"].Hidden = false;
                this.grddetmantenimientos.DisplayLayout.Bands[0].Columns["descripcion"].Hidden = false;
                this.grddetmantenimientos.DisplayLayout.Bands[0].Columns["cantidad"].Header.Caption = "Cantidad";
                this.grddetmantenimientos.DisplayLayout.Bands[0].Columns["descripcion"].Header.Caption = "Descripción";

                this.grddetmantenimientos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
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
                int idmantenimiento = this._id;
                int iddetmantenimiento = 0;
                frmmantenimientodetalle ofrmmantenimientodetalle = new frmmantenimientodetalle(idmantenimiento, iddetmantenimiento, this._idusuario, this._connexionstring);
                ofrmmantenimientodetalle.ShowDialog();
                if (ofrmmantenimientodetalle._update)
                {
                    this.odetmantenimientos.Add(ofrmmantenimientodetalle._odetmantenimiento);
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
                int id = Convert.ToInt32(this.grddetmantenimientos.ActiveRow.Cells["iddetmantenimiento"].Value);
                if (MessageBox.Show("¿Esta seguro de eliminar el registro", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.odetmantenimientos.RemoveAt(this.grddetmantenimientos.ActiveRow.Index);

                    this.cargardetalle();
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

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this._id > 0)
                {
                    mantenimientos omantenimiento = mantenimientonc.getmantenimiento(this._id, this._connexionstring);
                    omantenimiento.fecha = Convert.ToDateTime(this.dtfecha.Value);
                    omantenimiento.folio = this.txtfolio.Text;
                    omantenimiento.comentarios = this.txtcomentario.Text;
                    omantenimiento.iddepartamento = Convert.ToInt32(this.cmbdepartamentos.Value);
                    omantenimiento.idempleado = Convert.ToInt32(this.cmbempleados.Value);
                    omantenimiento.idvehiculo = Convert.ToInt32(this.cmbvehiculos.Value);
                    omantenimiento.iddocumentodigital = this._iddocumentodigital;
                    mantenimientonc.update(omantenimiento, this._connexionstring);

                    List<detmantenimientos> otmp = detmantenimientonc.getdetmantenimientosbyid(omantenimiento.idmantenimiento, this._connexionstring);
                    foreach (detmantenimientos odet in otmp)
                    {
                        detmantenimientonc.delete(odet, this._connexionstring);
                    }

                    foreach (detmantenimientos odetmantenimiento in this.odetmantenimientos)
                    {
                        odetmantenimiento.idmantenimiento = omantenimiento.idmantenimiento;
                        odetmantenimiento.iddetmantenimiento = detmantenimientonc.getid(this._connexionstring);
                        detmantenimientonc.save(odetmantenimiento, this._connexionstring);
                    }
                }
                else
                {
                    mantenimientos omantenimiento = new mantenimientos();
                    omantenimiento.idmantenimiento = mantenimientonc.getid(this._connexionstring);
                    omantenimiento.fecha = Convert.ToDateTime(this.dtfecha.Value);
                    omantenimiento.folio = this.txtfolio.Text;
                    omantenimiento.comentarios = this.txtcomentario.Text;
                    omantenimiento.iddepartamento = Convert.ToInt32(this.cmbdepartamentos.Value);
                    omantenimiento.idempleado = Convert.ToInt32(this.cmbempleados.Value);
                    omantenimiento.idvehiculo = Convert.ToInt32(this.cmbvehiculos.Value);

                    omantenimiento.fechacreacion = DateTime.Now;
                    omantenimiento.usuario = this._idusuario.ToString();
                    omantenimiento.baja = false;
                    omantenimiento.iddocumentodigital = this._iddocumentodigital;
                    mantenimientonc.save(omantenimiento, this._connexionstring);

                    foreach (detmantenimientos odetmantenimiento in this.odetmantenimientos)
                    {
                        odetmantenimiento.idmantenimiento = omantenimiento.idmantenimiento;
                        odetmantenimiento.iddetmantenimiento = detmantenimientonc.getid(this._connexionstring);
                        detmantenimientonc.save(odetmantenimiento, this._connexionstring);
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
    }
}
